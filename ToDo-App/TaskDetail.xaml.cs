namespace ToDo_App;

using System.Diagnostics;
using Newtonsoft.Json;
using ToDo_App.Models;

public partial class TaskDetail : ContentPage
{
    private int id;
    public TaskDetail(Task task)
    {
        InitializeComponent();

        id = task.Id;
        taskTitleLabel.Text = task.Title;
        taskDescriptionLabel.Text = task.Description;
    }

    private void DeleteTask(object sender, EventArgs e)
    {
        Debug.WriteLine("DeleteTask Called");

        var taskToRemove = MainPage.tasks.FirstOrDefault(t => t.Id == id);
        if (taskToRemove != null)
        {
            MainPage.tasks.Remove(taskToRemove);
            MainPage.jsonData = JsonConvert.SerializeObject(MainPage.tasks);
            System.IO.File.WriteAllText(MainPage.fullPath, MainPage.jsonData);

            Navigation.PopAsync();
        }
    }
}
