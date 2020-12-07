CREATE PROCEDURE [dbo].[spProducts_GetById]
	@Id int
AS
begin
set nocount on
	SELECT Id, ProductName, [Description], RetailPrice, QuantityInStock, IsTaxable
	from Products
	where Id = @Id;
end
