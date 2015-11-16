-- Create Template 

create proc proc_InsertTemplate 
(
    @CommandId smallint,
    @CannedCommand tinyint,
	@Name varchar(50),
	@Description varchar(256),
	@AppName varchar(260),
	@Params varchar(max),
	@UseCommandShell tinyint,
	@TimeoutDurationSecs smallint,
	@UserId smallint,
	@WaitInterval smallint,
	@InvokeCategory varchar(20),
	@CommandResultTestPatternText nvarchar(max),
	@CommandResultTestPatternType smallint,
	@returnValue smallint output
)
as

BEGIN
INSERT INTO COMMANDDEFS (CommandId,CannedCommand,Name,[Description],AppName,Params,UseCommandShell,TimeoutDurationSecs,UserId,WaitInterval,InvokeCategory,
CommandResultTestPatternText,CommandResultTestPatternType)
values (@CommandId,@CannedCommand,@Name, @Description,@AppName,@Params,@UseCommandShell,@TimeoutDurationSecs,@UserId,@WaitInterval,
@InvokeCategory,@CommandResultTestPatternText,@CommandResultTestPatternType)

SET @returnValue = SCOPE_IDENTITY();
return
END