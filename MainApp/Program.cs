using Infrustracture.Models;
using Infrustracture.Services;
using Infrustracture.Services.CategoryService;
using Infrustracture.Services.CommentService;
using Infrustracture.Services.TaskAttachmentsService;
using Infrustracture.Services.TaskHistoryService;
using Infrustracture.Services.TaskService;
using Infrustracture.Services.UsersService;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

#region Users
IUserService userService = new UserService();

app.MapPost("api/users", async (Users user) =>
{
    return await userService.CreateUserAsync(user);
});

app.MapPut("api/users", async (Users user) =>
{
    return await userService.UpdateUserAsync(user);
});
app.MapDelete("api/users{id}", async (Guid id) =>
{
    return await userService.DeleteUserAsync(id);
});

app.MapGet("api/users", async () =>
{
   return await userService.GetUsersAsync();  
});

app.MapGet("api/users{id}", async (Guid id) =>
{
    return await userService.GetUserByIdAsync(id);
});
#endregion

#region Catrgories

ICategoryService categoryService = new CategoryService();

app.MapPost("api/categories", async (Categories category) =>
{
    return await categoryService.CreateCategoryAsync(category);
});

app.MapPut("api/categories", async (Categories category) =>
{
    return await categoryService.UpdateCategoryAsync(category);
});
app.MapDelete("api/categories{id}", async (Guid id) =>
{
    return await categoryService.DeleteCategoryAsync(id);
});

app.MapGet("api/categories", async () =>
{
    return await categoryService.GetAllCategoriesAsync();
});

app.MapGet("api/categories{id}", async (Guid id) =>
{
    return await categoryService.GetCategoryByIdAsync(id);
});

#endregion

#region Comments

ICommentService commentService = new CommentService();

app.MapPost("api/comments", async (Comments comment) =>
{
    return await commentService.CreateCommentAsync(comment);
});

app.MapPut("api/comments", async (Comments comment) =>
{
    return await commentService.UpdateCommentAsync(comment);
});
app.MapDelete("api/comments{id}", async (Guid id) =>
{
    return await commentService.DeleteCommentAsync(id);
});

app.MapGet("api/comments", async () =>
{
    return await commentService.GetAllCommentsAsync();
});

app.MapGet("api/comments{id}", async (Guid id) =>
{
    return await commentService.GetCommentByIdAsync(id);
});

#endregion

#region Tasks
ITaskService taskService = new TaskService();

app.MapPost("api/tasks", async (Tasks task) =>
{
    return await taskService.CreateTaskAsync(task);
});

app.MapPut("api/tasks", async (Tasks task) =>
{
    return await taskService.UpdateTaskAsync(task);
});
app.MapDelete("api/tasks{id}", async (Guid id) =>
{
    return await taskService.DeleteTaskAsync(id);
});

app.MapGet("api/tasks", async () =>
{
    return await taskService.GetTasksAsync();
});

app.MapGet("api/tasks{id}", async (Guid id) =>
{
    return await taskService.GetTaskByIdAsync(id);
});

#endregion


#region Task Attachments

ITaskAttachmentsService taskAttachmentsService = new TaskAttachmentsService();

app.MapPost("api/task-attachments", async (TaskAttachments taskAttachments) =>
{
    return await taskAttachmentsService.CreateTaskAttachmentsAsync(taskAttachments);
});

app.MapPut("api/task-attachments", async (TaskAttachments taskAttachments) =>
{
    return await taskAttachmentsService.UpdateTaskAttachmentsAsync(taskAttachments);
});
app.MapDelete("api/task-attachments{id}", async (Guid id) =>
{
    return await taskAttachmentsService.DeleteTaskAttachmentsAsync(id);
});

app.MapGet("api/task-attachments", async () =>
{
    return await taskAttachmentsService.GetAllTaskAttachmentsAsync();
});

app.MapGet("api/task-attachments{id}", async (Guid id) =>
{
    return await taskAttachmentsService.GetTaskAttachmentsByIdAsync(id);
});

#endregion

#region Task History

ITaskHistoryService taskHistoryService = new TaskHistoryService();

app.MapPost("api/task-history", async (TaskHistory taskHistory) =>
{
    return await taskHistoryService.CreateTaskHistoryAsync(taskHistory);
});

app.MapPut("api/task-history", async (TaskHistory taskHistory) =>
{
    return await taskHistoryService.UpdateTaskHistoryAsync(taskHistory);
});
app.MapDelete("api/task-history{id}", async (Guid id) =>
{
    return await taskHistoryService.DeleteTaskHistoryAsync(id);
});

app.MapGet("api/task-history", async () =>
{
    return await taskHistoryService.GetAllTaskHistoriesAsync();
});

app.MapGet("api/task-history{id}", async (Guid id) =>
{
    return await taskHistoryService.GetTaskHistoryByIdAsync(id);
});

#endregion


#region Queryes

IQueryServices queryServices = new QueryServices();

app.MapGet("api/select-user-task", async () =>
{
    return await queryServices.SelectUserTasksAsync();
});

app.MapGet("api/select-category-taskcount", async () =>
{
    return await queryServices.SelectCategoryTasksCountAsync();
});

app.MapGet("api/select-task-by-priority{priority}", async (string priority) =>
{
    return await queryServices.SelectTasksByPriorityAsync( priority);
});

app.MapGet("api/select-tasks-users-categories",async ()=>
{
    return await queryServices.SelectTasksUsersCategoriesAsync();
});


app.MapGet("api/select-task-order-by-duedate", async () =>
{
    return await queryServices.SelectTasksOrderByDueDateAsync(); 
});


app.MapGet("api/select-taskhistory-by-taskid", async (Guid taskId) =>
{
    return await queryServices.SelectTaskHistroyByTaskIdAsync(taskId); 
});

app.MapGet("api/select-comment-task-by-user", async (Guid taskId, Guid userId) =>
{
    return await queryServices.SelectCommentTaskFilteringUserAsync(taskId, userId);
});


app.MapGet("api/select-task-attachment-by-taskid", async (Guid taskId) =>
{
    return await queryServices.SelectTaskAttachmentsUserAsync(taskId);
});

app.MapGet("api/select-task-filtering=by-duedate", async (string date)=>
{
    return await queryServices.selectTaskFiltringDueDateAsync(date);
});


app.MapGet("api/select-task-filtring-by-priority-and-iscompleted", async (bool isCompleted, string priority) =>
{
    return await queryServices.SelectAllTaskFiltringIsStatuseAndPriorityAsync(isCompleted, priority);
});

#endregion


app.Run();
