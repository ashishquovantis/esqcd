-- Get Templates
create proc proc_GetTemplates
as
BEGIN
SELECT DISTINCT * from COMMANDDEFS (NOLOCK) WHERE params like'%put-file%'
END
