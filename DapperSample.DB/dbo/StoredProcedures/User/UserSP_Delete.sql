CREATE PROCEDURE [dbo].[UserSP_Delete]
	@Id int
AS
begin
	delete from dbo.[User]
	where Id = @Id
end
