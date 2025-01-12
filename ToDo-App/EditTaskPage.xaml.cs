namespace ToDo_App;

using ToDo_App.Models;
using Newtonsoft.Json;

public partial class EditTaskPage : ContentPage
{
    private Task _task;

    public EditTaskPage(Task task)
    {
        InitializeComponent();
        _task = task;

        // Load current task details
        titleEntry.Text = task.Title;
        descriptionEditor.Text = task.Description;
        dueDatePicker.Date = task.DueDate;
        priorityPicker.SelectedIndex = task.Priority - 1;
    }

    private async void OnSaveTask(object sender, EventArgs e)
    {
        // Update task properties
        _task.Title = titleEntry.Text;
        _task.Description = descriptionEditor.Text;
        _task.DueDate = dueDatePicker.Date;
        _task.Priority = priorityPicker.SelectedIndex + 1;

        // Save updated tasks to JSON
        MainPage.jsonData = JsonConvert.SerializeObject(MainPage.tasks);
        System.IO.File.WriteAllText(MainPage.fullPath, MainPage.jsonData);

        Navigation.RemovePage(this);
        await Navigation.PushAsync(new TaskDetail(_task));

    }

    private async void OnCancel(object sender, EventArgs e)
    {
        Navigation.RemovePage(this);
        await Navigation.PushAsync(new TaskDetail(_task));
    }


}
