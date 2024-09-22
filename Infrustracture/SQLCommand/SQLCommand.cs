namespace Infrustracture.SQLCommand;

public class SQLCommand
{
    public const string connectionString = "Server=localhost;Port=5432;Database=exam_db;Username=postgres;Password=123456";
    public const string createCategory = "INSERT INTO categories (Name) VALUES (@Name)";
    public const string updateCategory = "UPDATE categories SET Name=@Name WHERE Id=@Id";
    public const string deleteCategory = "DELETE FROM categories WHERE Id=@Id";
    public const string getCategoryById = "SELECT * FROM categories WHERE Id=@Id";
    public const string getAllCategories = "SELECT * FROM categories";
    
    public const string createTask = "INSERT INTO tasks (Title, Description,IsCompleted, DueDate, Priority, CategoryId,UserId) VALUES (@Title, @Description,@IsCompleted, @DueDate, @Priority, @CategoryId,@UserId)";
    public const string updateTask = "UPDATE tasks SET Title=@Title, Description=@Description, IsCompleted=@IsCompleted, DueDate=@DueDate, Priority=@Priority,UserId=@UserId WHERE Id=@Id";
    public const string deleteTask = "DELETE FROM tasks WHERE Id=@Id";
    public const string getTaskById = "SELECT * FROM tasks WHERE Id=@Id";
    public const string getAllTasks = "SELECT * FROM tasks";

    public const string createComment = "Insert into comments (TaskId,UserId,Content)VALUES (@TaskId, @UserId, @Content)";
    public const string updateComment = "UPDATE comments SET Content=@Content,TaskId=@TaskId,UserId=@UserId WHERE Id=@Id";
    public const string getCommentsByTaskId = "SELECT * FROM comments WHERE TaskId=@TaskId";
    public const string deleteComment = "DELETE FROM comments WHERE Id=@Id";
    public const string getAllComments = "SELECT * FROM comments";
    
    public const string createUser = "INSERT INTO users (UserName, Email, PasswordHash) VALUES (@UserName,@Email, @PasswordHash)";
    public const string getUserById = "SELECT * FROM users WHERE Id=@Id";
    public const string getAllUsers = "SELECT * FROM users";
    public const string deleteUser = "DELETE FROM users WHERE Id=@Id";
    public const string updateUser = "Update users Set UserName=@UserName,Email=@Email,PasswordHash=@PasswordHash WHERE Id=@Id";
    
    public const string createTaskAttachment = "INSERT INTO TaskAttachments (TaskId,FilePath) VALUES (@TaskId,@FilePath)";
    public const string deleteTaskAttachment = "DELETE FROM TaskAttachments WHERE Id=@Id";
    public const string getTaskAttachmentsById = "SELECT * FROM TaskAttachments WHERE Id=@Id";
    public const string getAllTaskAttachments = "SELECT * FROM TaskAttachments";
    public const string updateTaskAttachment = "UPDATE TaskAttachments SET TaskId=@TaskId,FilePath=@FilePath WHERE Id=@Id";

    public const string createTaskHistory = "INSERT INTO TaskHistory (TaskId,ChangeDescription) VALUES (@TaskId,@ChangeDescription)";
    public const string deleteTaskHistory = "DELETE FROM TaskHistory WHERE Id=@Id";
    public const string getTaskHistoryById = "SELECT * FROM TaskHistory WHERE Id=@Id";
    public const string getAllTaskHistories = "SELECT * FROM TaskHistory";
    public const string updateTaskHistory = "UPDATE TaskHistory SET TaskId=@TaskId,ChangeDescription=@ChangeDescription WHERE Id=@Id";

    public const string selectusersTask =
        "Select u.id,u.username,email,t.id,t.title,t.description,t.priority\nfrom users u \njoin tasks t On t.userid=u.id";

    public const string selectCategoryTaskCount =
        "select c.id,c.name as CategoryName,Count(t.id)As TaskCount\nfrom categories c\nJoin Tasks t on t.categoryid=c.id\nGroup By c.name,c.id";

    public const string selectTasksByPriority = "select* from Tasks where  priority =@Priority";

    public const string selectTaskUsersCategory =
        "select t.id as TaskId,t.title as TaskTitle,t.description as TaskDescription,t.isCompleted,t.dueDate,u.id as UserId,u.username,c.id as CategoryId,c.name as CategoryName,t.priority\nfrom tasks t\njoin  users u on t.userId = u.id\njoin categories c on t.categoryId = c.id;";

    public const string selectTaskOrderByDuedate = "\nselect *\nfrom Tasks\norder by Duedate ;\n";
    public const string selectTaskHistoryOrderByChangedAt = "select * from TaskHistory\nwhere TaskId = @TaskId;";

    public const string selectCommentTaskFiltringUser =
        "select c.content, c.CreatedAt, u.UserName\nfrom comments c\njoin Users u ON c.UserId = u.Id\nwhere c.TaskId = @TaskId\nand c.UserId = @UserId ";

    public const string selectAllTaskAttachmentsTaskUser =
        "select ta.FilePath,ta.CreatedAt,u.UserName,u.Email\nfrom TaskAttachments as ta\njoin tasks as t on ta.taskId = t.id\njoin users as u on t.userId=u.id\nwhere ta.taskId=@TaskId";

    public const string selectTaskFiltringDueDate =
        "SELECT *\nFROM Tasks\nWHERE TO_CHAR(DueDate, 'YYYY-MM-DD') LIKE @DueDate || '%'";
    
    public const string selectAllTaskFiltringIsStatuseAndPriority =
        "SELECT *\nFROM Tasks\nWHERE IsCompleted = @IsCompleted\n  AND Priority = @Priority";
    
}