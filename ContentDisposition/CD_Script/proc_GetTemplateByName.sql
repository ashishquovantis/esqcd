-- Get Template By Name
create proc proc_GetTemplateByName
(
@Name varchar(50)
)
as
BEGIN
SELECT DISTINCT * from COMMANDDEFS (NOLOCK) WHERE Name=@Name
END
