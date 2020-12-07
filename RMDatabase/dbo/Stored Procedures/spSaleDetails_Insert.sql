CREATE PROCEDURE [dbo].[spSaleDetails_Insert]
	@SaleId int = 0,
	@ProductId int = 0,
	@Quantity int = 0,
	@PurchasePrice money = 0,
	@Tax money = 0
AS
begin
	set nocount on;
	
	insert into dbo.SaleDetails(SaleId, ProductId, Quantity, PurchasePrice, Tax)
	values (@SaleId, @ProductId, @Quantity, @PurchasePrice, @Tax);
end