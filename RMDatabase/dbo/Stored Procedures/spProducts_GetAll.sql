CREATE PROCEDURE [dbo].[spProducts_GetAll]
AS
begin
	set nocount on;

	SELECT Id, ProductName, [Description], RetailPrice, QuantityInStock, IsTaxable
	from dbo.Products
	order by ProductName;
end