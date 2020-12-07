CREATE PROCEDURE [dbo].[spSales_Insert]
	@Id int = 0,
	@CashierId varchar(128) = NULL,
	@SaleDate datetime2 = NULL,
	@SubTotal money = 0,
	@Tax money = 0,
	@Total money = 0
AS
set nocount on
begin
	insert into [dbo].[Sales](CashierId, SaleDate, SubTotal, Tax, Total)
	values (@CashierId, @SaleDate, @SubTotal, @Tax, @Total);

	select @Id = @@IDENTITY;
end