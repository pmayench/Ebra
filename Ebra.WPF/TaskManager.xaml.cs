using Ebra.Infrastructure;
using Ebra.Infrastructure.Prism;
using Ebra.WPF.Views;
using ImTools;
using Prism.Events;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;

namespace Ebra.WPF
{
    /// <summary>
    /// Lógica de interacción para TaskManager.xaml
    /// </summary>
    public partial class TaskManager : Window
    {
        public TaskManager(IRegionManager regionManager, IEventAggregator eventAggregator)
        {
            InitializeComponent();
            regionManager.RegisterViewWithRegion(RegionNames.MenuRegion.ToString(), typeof(MenuView));
        
            this.DataContext = new TaskManagerVm(eventAggregator);


        }


      

    }




    public class TaskManagerVm : BindableBase
    {



        private bool _isbusy;
        public bool Isbusy
        {
            get { return _isbusy; }
            set { SetProperty(ref _isbusy, value); }
        }

        private Visibility _progressBarVisibility;
        public Visibility ProgressBarVisibility
        {
            get { return _progressBarVisibility; }
            set { SetProperty(ref _progressBarVisibility, value); }
        }

        public TaskManagerVm(IEventAggregator eventAggregator)
        {
            eventAggregator.GetEvent<MessageLoadProcessEvent>().Subscribe(OnMessageLoadProcessEvent);
            //OnMessageLoadProcessEvent(false);
        }

        private void OnMessageLoadProcessEvent(bool isbusy)
        {
            Isbusy = isbusy;

            ProgressBarVisibility = isbusy ? Visibility.Visible : Visibility.Hidden;
        }
    }
}
