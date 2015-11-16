-- Update Terminal Filter
create proc proc_UpdateTerminalFilter
(
@FilterId int,
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
UPDATE [FilterDefs] SET [FilterName] = @FilterName, [Description] = @Description, [SQL] = @SQL,
 [FilterExpression] = @FilterExpression, [CreatedOn] = @CreatedOn, [CreatedBy] = @CreatedBy, [VisibleToOthers] = @VisibleToOthers, 
 [ShownOnModules] = @ShownOnModules 
 WHERE [FilterId] = @FilterId
 set @returnValue=1;
END

