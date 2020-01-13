Create PROCEDURE addUserProject 
(
@UserId int,
@ProjectId int ,
@IsActive bit ,
@AssignedDate datetime 
)
as begin
insert into UserProject values(@UserId,@ProjectId,@IsActive,@AssignedDate)

end
 