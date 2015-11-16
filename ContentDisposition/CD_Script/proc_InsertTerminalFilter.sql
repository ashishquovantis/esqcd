-- Create a Terminal Filter
create proc proc_InsertTerminalFilter
(
@FilterName nvarchar(128),
@Description nvarchar(512),
@SQL nvarchar(max),
@FilterExpression nvarchar(max),
@CreatedOn datetime,
@CreatedBy smallint,
@VisibleToOthers tinyint,
@ShownOnModules int,
@returnValue smallint output
)
as
BEGIN
INSERT INTO [FilterDefs] ([FilterName], [Description], 
 [SQL], [FilterExpression], [CreatedOn], [CreatedBy], [VisibleToOthers],
 [ShownOnModules]) VALUES (@FilterName, @Description, @SQL, @FilterExpression, @CreatedOn, @CreatedBy, @VisibleToOthers, @ShownOnModules)
set @returnValue=1;
END