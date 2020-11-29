CREATE PROCEDURE [dbo].[spUserLookUp]
	@Id nvarchar(128) = NULL
AS
set nocount on
	select *	
	from dbo.Users
	where Id = @Id
