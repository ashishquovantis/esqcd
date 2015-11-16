-- update Template
create proc proc_UpdateTemplate 
(
    @Name varchar(50),
    @CommandId smallint,
	@Params varchar(max),
	@CommandResultTestPatternText nvarchar(max),
	@CommandResultTestPatternType smallint,
	@returnValue smallint output
)
as

BEGIN
UPDATE COMMANDDEFS SET Params= @Params , CommandResultTestPatternType = @CommandResultTestPatternType, 
CommandResultTestPatternText = @CommandResultTestPatternText where CommandId = @CommandId

SET @returnValue = 1;
return
END

