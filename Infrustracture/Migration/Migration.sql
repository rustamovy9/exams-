Create database exam_db

Create table Users
(
    Id uuid primary key DEFAULT  gen_random_uuid(),
    UserName varchar not null unique,
    Email varchar not null unique,
    PasswordHash varchar not null,
    CreatedAt timestamp default NOW()
);


Create table Categories
(
    Id uuid primary key DEFAULT gen_random_uuid(),
    Name varchar not null unique,
    CreatedAt timestamp default NOW()
);



Create table Tasks
(
    Id uuid primary key DEFAULT  gen_random_uuid(),
    Title varchar not null,
    Description varchar not null,
    IsCompleted bool,
    DueDate timestamp default NOW(),
    UserId uuid ,
    CategoryId uuid,
    Priority varchar not null default 'low',
    CreatedAt timestamp default NOW(), 
    Foreign key(UserId) references Users(Id),
    Foreign key(CategoryId) references Categories(Id)
);



Create table Comments
(
    Id uuid primary key DEFAULT  gen_random_uuid(),
    TaskId uuid,
    UserId uuid,
    Content varchar not null,
    CreatedAt timestamp default NOW(),
    Foreign key(TaskId) references Tasks(Id),
    Foreign key(UserId) references Users(Id)
);

Create table TaskAttachments
(
    Id uuid primary key DEFAULT  gen_random_uuid(),
    TaskId uuid,
    FilePath varchar not null,
    CreatedAt timestamp default NOW(),
    Foreign key(TaskId) references Tasks(Id)
);

Create table TaskHistory
(
    Id uuid primary key DEFAULT  gen_random_uuid(),
    TaskId uuid,
    ChangeDescription varchar not null,
    ChangedAt timestamp default NOW(), 
    Foreign key(TaskId) references Tasks(Id)
);

Select u.id,u.username,email,t.id,t.title,t.description,t.priority
from users u
         join tasks t On t.userid=u.id;

select c.name as CategoryName,Count(t.id)As TaskCount
from categories c
         Join Tasks t on t.categoryid=c.id
Group By c.name;

select* from Tasks where  priority=@Priority;

select t.id as TaskId,t.title as TaskTitle,t.description as TaskDescription,t.isCompleted,t.dueDate,u.id as UserId,u.username,c.id as CategoryId,c.name as CategoryName,t.priority
from tasks t
join users u ON t.userId = u.id
join categories c on t.categoryId = c.id;


select *
from Tasks
order by Duedate ;

select * from TaskHistory where TaskId = @TaskId;

select c.content, c.CreatedAt, u.UserName
from comments c
join Users u ON c.UserId = u.Id
where c.TaskId = @TaskId
and c.UserId = @UserId;


select ta.FilePath,ta.CreatedAt,u.UserName,u.Email
from TaskAttachments as ta
         join tasks as t on ta.taskId = t.id
         join users as u on t.userId=u.id
where ta.taskId=@TaskId

select *
from Tasks
where IsCompleted = @IsCompleted
and Priority = @Priority

SELECT *
FROM Tasks
WHERE TO_CHAR(DueDate, 'YYYY-MM-DD') LIKE @Date || '%'