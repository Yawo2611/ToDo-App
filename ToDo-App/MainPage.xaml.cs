namespace ToDo_App;
using ToDo_App.Models;
using Newtonsoft.Json;
using System.Diagnostics;

public partial class MainPage : ContentPage
{

    public static int nextRecID;
    public static List<Task> tasks = new List<Task>();
    public static string dataPath = FileSystem.AppDataDirectory;
    public static string fileName = "tasks.json";
    public static string fullPath;
    public static string jsonData;


    public MainPage()
    {
        InitializeComponent();
        nextRecID = Preferences.Default.Get("nextRecordID", 0);
        fullPath = Path.Combine(dataPath, fileName);
        BindingContext = this;

        if (File.Exists(fullPath))
        {
            RetrieveJSON(fullPath);
        }

    }

    private async void OnTaskSelected(object sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection.FirstOrDefault() is Task selectedTask)
        {
            await Navigation.PushAsync(new TaskDetail(selectedTask));
        }


        ((CollectionView)sender).SelectedItem = null;
    }


    private async void RetrieveJSON(string myPath)
    {
        try
        {
            string data = await System.IO.File.ReadAllTextAsync(myPath);
            if (data.Length > 5)
            {
                tasks.Clear();
                tasks = JsonConvert.DeserializeObject<List<Task>>(data);
                ShowAllTasks(null, null);
            }
        }
        catch (Exception exc)
        {
            Debug.WriteLine($"Error: {exc.Message}");
            await DisplayAlert("Something went wrong", exc.Message, "OK");
        }
    }



    public static int FindIndex(int searchId)
    {
        for (int i = 0; i < tasks.Count; i++)
        {
            if (tasks[i].Id == searchId) { return i; }
        }

        return -1;

    }

    private void OnTaskCompletedChanged(object sender, CheckedChangedEventArgs e)
    {
        var checkBox = (CheckBox)sender;
        var task = (Task)checkBox.BindingContext;

        if (task != null)
        {
            task.IsCompleted = e.Value;

            // Aktualisiere das JSON
            MainPage.jsonData = JsonConvert.SerializeObject(MainPage.tasks);
            System.IO.File.WriteAllText(MainPage.fullPath, MainPage.jsonData);
            Debug.WriteLine($"Task '{task.Title}' marked as {(task.IsCompleted ? "completed" : "not completed")}");

        }
    }




    protected override void OnNavigatedTo(NavigatedToEventArgs args)
    {
        // Aktualisiere die Aufgabenliste, wenn die Seite aufgerufen wird
        base.OnNavigatedTo(args);
        ShowAllTasks(null, null);
    }

    private void ShowAllTasks(object sender, EventArgs e)
    {
        // Zeige alle Aufgaben an, sortiert nach Titel
        var allTasks = from task in MainPage.tasks
                       orderby task.Title
                       select task;

        // CollectionView aktualisieren
        taskView.ItemsSource = allTasks;
        Debug.WriteLine($"Tasks count: {MainPage.tasks.Count}");

    }


}
