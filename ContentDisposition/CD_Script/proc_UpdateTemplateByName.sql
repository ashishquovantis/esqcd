-- update Template by name
create proc proc_UpadteTemplateByName 
(
	@Name varchar(50),
	@Params varchar(max),
	@CommandResultTestPatternText nvarchar(max),
	@CommandResultTestPatternType smallint,
	@returnValue smallint output
)
as

BEGIN
UPDATE COMMANDDEFS SET Params= @Params , CommandResultTestPatternType = @CommandResultTestPatternType, 
CommandResultTestPatternText = @CommandResultTestPatternText where Name= @Name
SET @returnValue = 1;
return
END