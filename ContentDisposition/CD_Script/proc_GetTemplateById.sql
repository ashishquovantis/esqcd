-- Get Template By Id
create proc proc_GetTemplateById
(
@CommandId smallint
)
as
BEGIN
SELECT DISTINCT * from COMMANDDEFS (NOLOCK) WHERE CommandId=@CommandId
END
