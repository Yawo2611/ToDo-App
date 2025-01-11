namespace ToDo_App
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute("MainPage", typeof(MainPage));
            Routing.RegisterRoute("CreateTask", typeof(CreateTask));
            Routing.RegisterRoute("TaskDetail", typeof(TaskDetail));

        }
    }
}
