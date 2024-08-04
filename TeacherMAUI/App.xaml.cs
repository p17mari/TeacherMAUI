using TeacherMAUI.Services;

namespace TeacherMAUI
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();
        }
        static Database database;

        public static Database Database //gets the database when the app launches
        {
            get
            {
                if (database == null) //checks if the database is null
                {
                    database = new Database(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "database.db3"));
                    //initialises database in local folder if it doesn't exist already
                }
                return database;
            }
        }
    }
}
