using Ebra.Infrastructure;
using MaterialDesignThemes.Wpf;
using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;

namespace Ebra.WPF
{
    public class TaskManagerVM : BindableBase
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

        public TaskManagerVM(IEventAggregator eventAggregator)
        {
            ProgressBarVisibility = Visibility.Hidden;
            eventAggregator.GetEvent<MessageLoadProcessEvent>().Subscribe(OnMessageLoadProcessEvent);
            DarkModeCommand = new DelegateCommand<object>(ExecuteDarkModeCommand);

            //OnMessageLoadProcessEvent(false);
        }

        private void OnMessageLoadProcessEvent(bool isbusy)
        {
            if(Application.Current is null || Application.Current.Dispatcher is null)
            {
                return;
            }
            else
            {
                Application.Current.Dispatcher.BeginInvoke(DispatcherPriority.Background, new Action(() =>
                {
                    Isbusy = isbusy;
                    ProgressBarVisibility = isbusy ? Visibility.Visible : Visibility.Hidden;
                }));
            }
        }

        private bool _isChecked;

        public bool IsChecked
        {
            get { return _isChecked; }
            set
            {
                _isChecked = value;
                //OnPropertyChanged(nameof(IsChecked));
                SetProperty(ref _isChecked, value);
            }
        }

        public ICommand DarkModeCommand { get; }

        private void ExecuteDarkModeCommand(object obj)
        {
            PaletteHelper palette = new PaletteHelper();
            ITheme theme = palette.GetTheme();

            if (IsChecked)
            {
                theme.SetBaseTheme(Theme.Dark);
            }
            else
            {
                theme.SetBaseTheme(Theme.Light);
            }
            palette.SetTheme(theme);
        }
    }
}
