-- Delete Template By Name
create proc proc_DeleteTemplateByName
(
@Name varchar(50)
)
as
BEGIN
DELETE FROM COMMANDDEFS WHERE Name = @Name and params like '%put-file%' 
END
