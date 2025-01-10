namespace ToDo_App;

using ToDo_App.Models;

public partial class TaskDetailPage : ContentPage
{
    public TaskDetailPage(Task task)
    {
        InitializeComponent();

        // Setze die Task-Details
        taskTitleLabel.Text = task.Title;
        taskDescriptionLabel.Text = task.Description;
    }
}
