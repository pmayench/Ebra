using AutoMapper;
using Ebra.Infrastructure;
using Prism.Events;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;

namespace ProcessModule.VM
{
    public class ProcessViewModel : BindableBase
    {
        private ProcessDTO _selectedProcess;
        public string Name
        {
            get { return _name; }
            set
            {
                //Application.Current.Dispatcher.BeginInvoke(DispatcherPriority.Background, new Action(() =>
                //{
                //    SetProperty(ref _name, value);
                //}));
                SetProperty(ref _name, value);
            }
        }

        private string _name;
        public ProcessDTO SelectedProcess
        {
            get { return _selectedProcess; }
            set
            {
                SetProperty(ref _selectedProcess, value);
                Name = _selectedProcess.Name;
                OnPropertyChanged(new PropertyChangedEventArgs("Name"));
            }
        }

        private ObservableCollection<ProcessDTO> _processes;
        public ObservableCollection<ProcessDTO> Processes
        {
            get { return _processes; }
            set
            {
                SetProperty(ref _processes, value);
            }
        }

        private readonly IMapper _mapper;
        private readonly IEventAggregator _eventAggregator;

        public ProcessViewModel(IMapper mapper, IEventAggregator eventAggregator)
        {
            _mapper = mapper;
            _eventAggregator = eventAggregator;

        }

        public async Task Load()
        {
            Processes = new ObservableCollection<ProcessDTO>();
            _eventAggregator.GetEvent<MessageLoadProcessEvent>().Publish(true);
            var result = await LoadProcess();
        }

        public async Task<bool> LoadProcess()
        {
            Task.Run(() =>
            {
                var ListProcess = Process.GetProcesses();
                var ListProcessDTO = _mapper.Map<List<Process>, List<ProcessDTO>>(ListProcess.ToList());
                Processes = new ObservableCollection<ProcessDTO>(ListProcessDTO);

                SelectedProcess = Processes[0];
                _eventAggregator.GetEvent<MessageLoadProcessEvent>().Publish(false);
            });
            return true;
        }
    }
}
