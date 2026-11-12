USE [ChudoObuv_DE_2027];
SELECT 'Categories' AS [Table], COUNT(*) AS [Rows] FROM dbo.Categories UNION ALL
SELECT 'Subcategories',COUNT(*) FROM dbo.Subcategories UNION ALL
SELECT 'Manufacturers',COUNT(*) FROM dbo.Manufacturers UNION ALL
SELECT 'Sizes',COUNT(*) FROM dbo.Sizes UNION ALL
SELECT 'Roles',COUNT(*) FROM dbo.Roles UNION ALL
SELECT 'Users',COUNT(*) FROM dbo.Users UNION ALL
SELECT 'Products',COUNT(*) FROM dbo.Products UNION ALL
SELECT 'Stock',COUNT(*) FROM dbo.Stock UNION ALL
SELECT 'Orders',COUNT(*) FROM dbo.Orders UNION ALL
SELECT 'OrderItems',COUNT(*) FROM dbo.OrderItems;
SELECT TOP 5 * FROM dbo.vCatalog ORDER BY Id;
-- Проверка поиска «сирот» (ожидается 0 строк)
SELECT s.Id FROM dbo.Stock s LEFT JOIN dbo.Products p ON p.Id=s.ProductId WHERE p.Id IS NULL;
SELECT oi.Id FROM dbo.OrderItems oi LEFT JOIN dbo.Stock s ON s.Id=oi.StockId WHERE s.Id IS NULL;
