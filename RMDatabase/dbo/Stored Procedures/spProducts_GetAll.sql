CREATE PROCEDURE [dbo].[spProducts_GetAll]
AS
begin
	set nocount on;

	SELECT Id, ProductName, [Description], RetailPrice, QuantityInStock
	from dbo.Products
	order by ProductName;
end