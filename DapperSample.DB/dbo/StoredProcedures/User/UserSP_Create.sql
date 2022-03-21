CREATE PROCEDURE [dbo].[UserSP_Create]
	@FirstName nvarchar(64),
	@LastName nvarchar(64)
AS
begin
	insert into dbo.[User] (FirstName, LastName) 
	values (@FirstName, @LastName)
end
