namespace ToDo_App;
using ToDo_App.Models;
using Newtonsoft.Json;

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
        
        if (File.Exists(fullPath))
        {
            
        }
        
    }

    private async void OnTaskSelected(object sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection.FirstOrDefault() is Task selectedTask)
        {
            // Navigiere zur TaskDetailPage und übergebe die ausgewählte Task
            await Navigation.PushAsync(new TaskDetailPage(selectedTask));
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
                await DisplayAlert("Deserialization complete", "Length: " + tasks.Count.ToString() + " records read.", "OK");
            }
            else
            {
                await DisplayAlert("No data", "NO data currently exists...add some records!", "OK");
            }
        }
        catch (Exception exc)
        {
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
    }


}
