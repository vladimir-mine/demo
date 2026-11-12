using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace ChudoObuv
{
    // Один класс для всех SQL-запросов. Не требует NuGet на .NET Framework 4.8.
    static class Db
    {
        // Впишите сюда ТО ЖЕ имя сервера, что в окне подключения SSMS.
        public const string ConnectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=ChudoObuv_DE_2027;Integrated Security=True";

        public static SqlParameter P(string name, object value)
        {
            return new SqlParameter(name, value ?? DBNull.Value);
        }

        public static SqlConnection Open()
        {
            var connection = new SqlConnection(ConnectionString);
            connection.Open();
            return connection;
        }

        public static DataTable Read(string sql, params SqlParameter[] parameters)
        {
            using (var connection = Open())
            using (var command = new SqlCommand(sql, connection))
            using (var adapter = new SqlDataAdapter(command))
            {
                command.Parameters.AddRange(parameters);
                var result = new DataTable();
                adapter.Fill(result);
                return result;
            }
        }

        public static int Run(string sql, params SqlParameter[] parameters)
        {
            using (var connection = Open())
            using (var command = new SqlCommand(sql, connection))
            {
                command.Parameters.AddRange(parameters);
                return command.ExecuteNonQuery();
            }
        }

        public static object Scalar(string sql, params SqlParameter[] parameters)
        {
            using (var connection = Open())
            using (var command = new SqlCommand(sql, connection))
            {
                command.Parameters.AddRange(parameters);
                return command.ExecuteScalar();
            }
        }

        static object InTransaction(SqlConnection connection, SqlTransaction transaction,
            string sql, params SqlParameter[] parameters)
        {
            using (var command = new SqlCommand(sql, connection, transaction))
            {
                command.Parameters.AddRange(parameters);
                return command.ExecuteScalar();
            }
        }

        static int ExecuteInTransaction(SqlConnection connection, SqlTransaction transaction,
            string sql, params SqlParameter[] parameters)
        {
            using (var command = new SqlCommand(sql, connection, transaction))
            {
                command.Parameters.AddRange(parameters);
                return command.ExecuteNonQuery();
            }
        }

        static void Transaction(Action<SqlConnection, SqlTransaction> work)
        {
            using (var connection = Open())
            using (var transaction = connection.BeginTransaction())
            {
                try
                {
                    work(connection, transaction);
                    transaction.Commit();
                }
                catch
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }

        static void InsertItem(SqlConnection connection, SqlTransaction transaction,
            int orderId, int stockId, int quantity)
        {
            if (quantity < 1) throw new Exception("Количество должно быть больше нуля.");
            int changed = ExecuteInTransaction(connection, transaction,
                "UPDATE dbo.Stock SET Quantity=Quantity-@q WHERE Id=@s AND Quantity>=@q",
                P("@q", quantity), P("@s", stockId));
            if (changed != 1) throw new Exception("Недостаточно пар выбранного размера на складе.");

            // Зафиксируем цену покупки до изменения состава заказа.
            object price = InTransaction(connection, transaction,
                "SELECT v.FinalPrice FROM dbo.vCatalog v JOIN dbo.Stock s ON s.ProductId=v.Id WHERE s.Id=@s",
                P("@s", stockId));
            if (price == null) throw new Exception("Товар не найден.");
            ExecuteInTransaction(connection, transaction,
                "INSERT INTO dbo.OrderItems(OrderId,StockId,Quantity,UnitPrice) VALUES(@o,@s,@q,@p)",
                P("@o", orderId), P("@s", stockId), P("@q", quantity), P("@p", price));
        }

        public static void CreateOrder(int userId, List<CartLine> cart)
        {
            if (cart.Count == 0) throw new Exception("Корзина пуста.");
            Transaction((connection, transaction) =>
            {
                int orderId = Convert.ToInt32(InTransaction(connection, transaction,
                    "INSERT INTO dbo.Orders(OrderDate,UserId) OUTPUT INSERTED.Id VALUES(GETDATE(),@u)",
                    P("@u", userId)));
                foreach (var item in cart)
                    InsertItem(connection, transaction, orderId, item.StockId, item.Quantity);
            });
        }

        public static void AddItem(int orderId, int stockId, int quantity)
        {
            Transaction((connection, transaction) =>
                InsertItem(connection, transaction, orderId, stockId, quantity));
        }

        public static void DeleteItem(int itemId)
        {
            Transaction((connection, transaction) =>
            {
                int changed = ExecuteInTransaction(connection, transaction,
                    "UPDATE s SET s.Quantity=s.Quantity+i.Quantity " +
                    "FROM dbo.Stock s JOIN dbo.OrderItems i ON i.StockId=s.Id WHERE i.Id=@id",
                    P("@id", itemId));
                if (changed != 1) throw new Exception("Позиция заказа не найдена.");
                ExecuteInTransaction(connection, transaction,
                    "DELETE FROM dbo.OrderItems WHERE Id=@id", P("@id", itemId));
            });
        }

        public static void DeleteOrder(int orderId)
        {
            Transaction((connection, transaction) =>
            {
                // Суммируем позиции, если один размер встречается в заказе несколько раз.
                ExecuteInTransaction(connection, transaction,
                    "UPDATE s SET s.Quantity=s.Quantity+x.Qty FROM dbo.Stock s " +
                    "JOIN (SELECT StockId,SUM(Quantity) Qty FROM dbo.OrderItems " +
                    "WHERE OrderId=@id GROUP BY StockId) x ON x.StockId=s.Id",
                    P("@id", orderId));
                ExecuteInTransaction(connection, transaction,
                    "DELETE FROM dbo.OrderItems WHERE OrderId=@id", P("@id", orderId));
                int changed = ExecuteInTransaction(connection, transaction,
                    "DELETE FROM dbo.Orders WHERE Id=@id", P("@id", orderId));
                if (changed != 1) throw new Exception("Заказ не найден.");
            });
        }
    }

    class CartLine
    {
        public int StockId;
        public int Quantity;
    }
}
