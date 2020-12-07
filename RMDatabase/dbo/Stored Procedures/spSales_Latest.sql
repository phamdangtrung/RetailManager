CREATE PROCEDURE [dbo].[spSales_Latest]
	@CashierId varchar(128) = NULL,
	@SaleDate datetime2 = NULL
	as
begin
set nocount on;
	select Id
	from Sales
	where CashierId = @CashierId and SaleDate = @SaleDate;
end
