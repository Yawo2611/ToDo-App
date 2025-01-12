namespace ToDo_App.Models;
using Newtonsoft.Json;

public class Task
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime DueDate { get; set; }
    public bool IsCompleted { get; set; } = false;
    public int Priority { get; set; } // 1 = High, 2 = Medium, 3 = Low

    [JsonIgnore]
    public string PriorityText => Priority switch
    {
        1 => "High",
        2 => "Medium",
        3 => "Low",
        _ => "Unknown"
    };

    [JsonConstructor]
    public Task(int id, string title, string description, DateTime dueDate, bool isCompleted, int priority)
    {
        Id = id;
        Title = title;
        Description = description;
        DueDate = dueDate;
        IsCompleted = isCompleted;
        Priority = priority;
    }

    public Task(string title, string description, DateTime dueDate, int priority)
    {
        Id = MainPage.nextRecID;
        Title = title;
        Description = description;
        DueDate = dueDate;
        IsCompleted = false;
        Priority = priority;
    }
}
