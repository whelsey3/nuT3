using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.IO;

namespace nuT3
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    /// 
 
    public partial class App : Application
    {
    // private Logger mLogger;
    //private FileLogger mFileLogger;
        //mLogger = Logger.Instance;
        // static FileLogger mFileLogger;

        Logger mLogger;
        FileLogger mFileLogger;

        public string dbFileName = "TDTDb.sqlite";
        public string logDirectory = "Temp\\TDTnew";

        //public UserControl priorView = null;
        //public TDTDbContext db;

        public App()
        {
            InitializeComponent();

            // Single Instance Check
            bool notAlreadyRunning = false;
            if (notAlreadyRunning)
            {
                this.Properties["dbFile"] = dbFileName;  // need access in views for dbContext
                this.Properties["dbFile2"] = dbFileName;  // need access in views for dbContext

                GetLogDirectory(logDirectory);

                AppSpecificSetUp();

            }
            else
            {
                // Send message and close out new App
            }


            mLogger = Logger.Instance;

            
        }

        private void GetLogDirectory(string logDirectory)
        {
            // Change to use AppData for UWP requirement
            //string localDrive = Path.GetPathRoot(Environment.CurrentDirectory);
            string localDrive = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            logDirectory = Path.Combine(localDrive, logDirectory);
            if (!Directory.Exists(logDirectory))
                Directory.CreateDirectory(logDirectory);  // C:\Users\be3so\AppData\Local\Temp\TDTnew

            SetUpLogging(logDirectory);

            mLogger.AddLogMessage("Logging running! ++++++++++++++++++++++++++++");
        }

        #region Logging
        private void SetUpLogging(string logDirectory)
        {
            mLogger = Logger.Instance;
            string logName0 = System.IO.Path.Combine(logDirectory, "logTDTnew_" + System.DateTime.Now.ToString("yyyyMMdd_HH_mm_ss") + ".log");

            mFileLogger = new FileLogger(logName0);
            mFileLogger.Init();
            mLogger.RegisterObserver(mFileLogger);
            mLogger.AddLogMessage("logName0->" + logName0);
        }
        #endregion Loggin

        private void AppSpecificSetUp()
        {
            //SetUpDataStorage();   // sets App.Current.Properties["destFilePath"] 
            //App.Current.Properties["dbContext"] = new TDTDbContext();
            ////    db = new TDTDbContext();
            //db = (TDTDbContext)App.Current.Properties["dbContext"];

            mLogger.AddLogMessage("<=== Checking AdHoc Folder ID ===>");

            //int? theAdHocFolderID = CheckAdHoc();
            //App.Current.Properties["AdHocFolderID"] = theAdHocFolderID;

            //int? theRoutineTasksFolderID = CheckRoutineTasks();
            //App.Current.Properties["RoutineTasksFolderID"] = theRoutineTasksFolderID;

            //App.Current.Properties["priorView"] = null;
            //var theProperties = App.Current.Properties;
            //var r = App.Current.Properties["RoutineTasksFolderID"];
        }

    }
}
