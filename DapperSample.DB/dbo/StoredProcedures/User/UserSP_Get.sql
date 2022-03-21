CREATE PROCEDURE [dbo].[UserSP_Get]
	@Id int
AS
Begin
	select Id, FirstName, LastName
	from dbo.[User]
	where Id = @Id
End
