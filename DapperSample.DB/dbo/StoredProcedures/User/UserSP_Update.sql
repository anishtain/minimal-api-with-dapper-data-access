CREATE PROCEDURE [dbo].[UserSP_Update]
	@Id int,
	@FirstName nvarchar(64),
	@LastName nvarchar(64)
AS
begin
	update dbo.[User]
	set FirstName = @FirstName, LastName = @LastName
	where Id = @Id
end
