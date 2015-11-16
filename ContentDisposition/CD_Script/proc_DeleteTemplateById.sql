-- Delete Template By Id
create proc proc_DeleteTemplateById
(
@CommandId smallint
)
as
BEGIN
DELETE FROM COMMANDDEFS WHERE CommandId = @CommandId and params like '%put-file%' 
END



