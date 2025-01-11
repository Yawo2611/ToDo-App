namespace ToDo_App.Models;
using Newtonsoft.Json;

public class Task
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime DueDate { get; set; }
    public bool IsCompleted { get; set; } = false;

    [JsonConstructor]
    public Task(int id, string title, string description, DateTime dueDate, bool isCompleted)
    {
        Id = id;
        Title = title;
        Description = description;
        DueDate = dueDate;
        IsCompleted = isCompleted;
    }

    public Task(string title, string description, DateTime dueDate)
    {
        Id = MainPage.nextRecID;
        Title = title;
        Description = description;
        DueDate = dueDate;
        IsCompleted = false;
    }
}
