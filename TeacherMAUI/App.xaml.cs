using TeacherMAUI.Services;

namespace TeacherMAUI
{
    public partial class App : Application
    {
        public static DatabaseService Database { get; private set; }//getting data commands from DataService.cs
        public App()
        {
            InitializeComponent();

            string dbPath = Path.Combine(FileSystem.AppDataDirectory, "data.db3");//establishing path for a local database
            Database = new DatabaseService(dbPath);//inputing tables in the dbpath

            MainPage = new AppShell();
        }


       
    }
}
