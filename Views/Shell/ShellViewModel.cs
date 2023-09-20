//using Microsoft.Toolkit.Mvvm;
//using Microsoft.Toolkit.Mvvm.ComponentModel;
//using Microsoft.Toolkit.Mvvm.Input;
using CommunityToolkit.Helpers;
using CommunityToolkit.Common;
using CommunityToolkit.Mvvm;
using CommunityToolkit.Mvvm.Messaging;
using CommunityToolkit.Mvvm.ComponentModel;

using System.Collections.ObjectModel;
//using BuildSqliteCF.Entity;
//using GalaSoft.MvvmLight;
//using GalaSoft.MvvmLight.Messaging;
//using LoggerLib;
using System;
//using System.Collections.ObjectModel;
using System.Data;  //Validation;
using System.Diagnostics;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Threading;

namespace nuT3
{
    public class ShellViewModel : ObservableRecipient
    {
        public ShellViewModel()
        {
            ///ObservableCollection<ViewVM> views = new ObservableCollection<ViewVM>
            ////{
            ////    new ViewVM{ ViewDisplay="ToDos", ViewType = typeof(ToDosView), ViewModelType = typeof(ToDosViewModel)},
            ////    new ViewVM{ ViewDisplay="Tracks", ViewType = typeof(TracksView), ViewModelType = typeof(TracksViewModel)},
            ////    new ViewVM{ ViewDisplay="Planning", ViewType = typeof(PlansView), ViewModelType = typeof(PlansViewModel)},
            ////    new ViewVM{ ViewDisplay="Reports", ViewType = typeof(ReportsView), ViewModelType = typeof(ReportsViewModel)}
            ////};
            ////Views = views;
            ////RaisePropertyChanged("Views");

        // Navigate to ToDos (as default view)
        //var defaultView = new ViewVM { ViewDisplay = "ToDos", ViewType = typeof(ToDosView),   ViewModelType = typeof(ToDosViewModel) };
         ViewVM defaultView = new ViewVM { ViewDisplay = "Tracks", ViewType = typeof(TracksView), ViewModelType = typeof(TracksViewModel)};
            //defaultView.NavigateExecute();

            //var msg1 = new ChangeViewMessage { ViewModelType = typeof(ToDosView), ViewType = typeof(ToDosViewModel) };
            //Messenger.Default.Send<ChangeViewMessage>(msg1);
            //  views[0].NavigateExecute();  // Move to an initial view.
            //mLogger.AddLogMessage();
        }
    }

}   