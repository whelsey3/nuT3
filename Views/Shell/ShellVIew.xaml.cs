using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Media.Animation;
//using Microsoft.Toolkit.Mvvm;
//using Microsoft.Toolkit.Mvvm.Messaging;
//using Microsoft.Toolkit.Mvvm.ComponentModel;
//using Microsoft.Toolkit.Mvvm.Input;
using CommunityToolkit.Common;
using CommunityToolkit.Mvvm;
using CommunityToolkit.Mvvm.Messaging;
using CommunityToolkit.Mvvm.ComponentModel;

using LoggerLib;

namespace nuT3
{
    /// <summary>
    /// Interaction logic for ShellView.xaml
    /// </summary>
    public partial class ShellView : Window
    {
        Logger mLogger;
        public ShellView()
        {
            InitializeComponent();

            //  Need to have this near top
            mLogger = Logger.Instance;

            // Apply default form level font style
            Style = (Style)FindResource(typeof(Window));

            //Messenger.Default.Register<ChangeViewMessage>(this, (action) => ShowUserControl(action));
    //        WeakReferenceMessenger.Default.Register<ChangeViewMessage>(this, (action) => ShowUserControl(action));
            //Messenger.Default.Register<UserMessage>(this, (action) => ReceiveUserMessage(action));
            ////   Messenger.Default.Register<InEdit>(this, (action) => ReceiveInEditMessage(action));


            // Register a message in some module
            WeakReferenceMessenger.Default.Register<ChangeViewMessage>(this, (r, m) =>
            {
                // Handle the message here, with r being the recipient and m being the
                // input message. Using the recipient passed as input makes it so that
                // the lambda expression doesn't capture "this", improving performance.

            });

            DataContext = new ShellViewModel();
            mLogger.AddLogMessage("DataContext was set!");
            DisplayDefault();    // experiment to get started
        }

        private void DisplayDefault()
        {
            // throw new NotImplementedException();
            mLogger.AddLogMessage("reached DisplayDefault");


            mLogger.AddLogMessage("Activator call for '" + typeof(TracksViewModel) + "'");
            //  activation automatically refreshes data
      //      UserControl theNewOne = (UserControl)Activator.CreateInstance(typeof(TracksViewModel));
            //View = theNewOne;
            
            ChangeViewMessage message = new ChangeViewMessage { //newView = TracksView,
                ViewType = typeof(TracksViewModel), ViewModelType = typeof(TracksView)
            };
                
            //  , newView = the
            ShowUserControl(message);
        }

        private void ShowUserControl(ChangeViewMessage nm)
        {
            // Get current view and save
            //         App.Current.Properties["priorView"] = Holder.Content;
            //  nm.previousView = (UserControl)Holder.Content;
            //string chkValue = Holder.Content as string;
            //if (chkValue != null)
            //{
            //    // have original string value
            //    App.Current.Properties["priorView"] = null;
            //}
            //else
            //{
            //    App.Current.Properties["priorView"] = Holder.Content;
            //mLogger.AddLogMessage("Set priorView to " + Holder.Content);
            ////}
            // Disconnect previous view messaging ??
            if (Holder.Content != null)
            {
                var oldView = Holder.Content;
                Type oldType = oldView.GetType();
                mLogger.AddLogMessage("ChangeViewMessage(ShellView)->ShowUserControl - current Holder content: '" + oldType.Name + "'");
                //Type oldType2 = oldView.GetType().BaseType;

                //    Messenger.Default.Unregister<CommandMessage>(oldView);
                //    Messenger.Default.Unregister<NavigateMessage>(oldView);

                //ToDosView a = oldView as ToDosView;
                //TracksView b = oldView as TracksView;
                //PlansView c = oldView as PlansView;
                //if (c != null)
                //{
                //    //        Messenger.Default.Unregister<CurrentViewMessage>(c);
                //    //  TracksViewModel tvm = (TracksViewModel)(b.DataContext);
                //    // TDTDbContext db0 = (TDTDbContext)(tvm.db);
                //}

                //var a = ((Type)oldType);
                //Type b = a.UnderlyingSystemType;
                //var x = ((b)oldView);
                //var x = ((oldType.UnderlyingSystemType)oldView);
                //if (b != null)
                //{
                //    b = null;
                //}
                //if (a != null)
                //{
                //    a = null;
                //}
            }

            //  ((ToDosViewModel)((ToDosView)(nm.View)).DataContext)

            //       var msg = new CommandMessage { Command = CommandType.Refresh };
            //       Messenger.Default.Send<CommandMessage>(msg);
            //var oldView = Holder.Content;
            //Type oldType = oldView.GetType();
            //mLogger.AddLogMessage("ChangeViewMessage(ShellView)->ShowUserControl - current Holder content: '" + oldType.Name + "'");
            //Type oldType2 = oldView.GetType().BaseType;
            //if (chkValue != null)
            //{
            //    //            var oldView = Holder.Content;
            //    ToDosView a = oldView as ToDosView;
            //    TracksView b = oldView as TracksView;
            //    PlansView c = oldView as PlansView;
            //    if (a != null)
            //    {
            //        mLogger.AddLogMessage("Refreshing old view: ToDosView");
            //        ((ToDosViewModel)a.DataContext).RefreshData();
            //    }
            //    else if (b != null)
            //    {
            //        mLogger.AddLogMessage("Refreshing old view: TracksView");

            //        ((TracksViewModel)b.DataContext).RefreshData();
            //    }
            //    else if (c != null)
            //    {
            //        mLogger.AddLogMessage("Refreshing old view: PlansView");
            //        ((PlansViewModel)c.DataContext).RefreshData();
            //    }
            //}
         //   nm.v
            Holder.Content = nm.newView;
            mLogger.AddLogMessage("ShellView - ShowUserControl - Content set to '" + nm.ViewType.Name + "'");
            App.Current.Properties["priorView"] = Holder.Content;
            mLogger.AddLogMessage("Set priorView to " + Holder.Content);
            //}

            // Adjust window title to show view name.
            this.Title = GetTitle(nm.ViewType.FullName);
        }

        private string GetTitle(string p)
        {
            string theTitle = "";
            if (p.Contains("Track"))
            {
                theTitle = "Tracks - Elapsed Time";
            }
            else if (p.Contains("ToDo"))
            {
                theTitle = "ToDoToday (TDT)";
            }
            else if (p.Contains("Plans2View"))
            {
                theTitle = "Test Version";
            }
            else if (p.Contains("PlansView"))
            {
                theTitle = "Planning";
            }
            else if (p.Contains("ReportsView"))
            {
                theTitle = "Reports";
            }
            else if (p.Contains("DBProject"))
            {
                theTitle = "Database Projects List";
            }
            else if (p.Contains("Project"))
            {
                theTitle = "Projects List";
            }
            else theTitle = "Problem ??";

            string AppName = "  Version: " + typeof(nuT3.ShellView).Assembly.GetName().Version.ToString();
            theTitle = theTitle + " - " + AppName + "   --   " + DateTime.Now.ToString("MM/dd/yy H:mm:ss");
            // theTitle = theTitle + " - " + BuildDate;
            return theTitle;
        }

        private void ReceiveUserMessage(UserMessage msg)
        {
            //   UIMessage is textblock defined  on UI for ShellView
            UIMessage.Opacity = 1;
            UIMessage.Text = msg.Message;
            Storyboard sb = (Storyboard)this.FindResource("FadeUIMessage");
            sb.Begin();
            mLogger.AddLogMessage("ReceiveUserMessage: " + "'" + msg.Message + "'");
        }

    }
}
