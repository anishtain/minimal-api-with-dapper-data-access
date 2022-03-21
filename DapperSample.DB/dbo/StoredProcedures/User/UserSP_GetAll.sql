CREATE PROCEDURE [dbo].[UserSP_GetAll]
As
begin
	select Id, FirstName, LastName
	from dbo.[User] 
end
