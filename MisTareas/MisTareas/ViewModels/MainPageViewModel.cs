using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Collections.ObjectModel;

using MisTareas.Models;

namespace MisTareas.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {

        private ObservableCollection<Tarea> _lstTareas;
        public ObservableCollection<Tarea> LstTareas
        {
            get => _lstTareas;
            set => SetProperty(ref _lstTareas, value);
        }


        private Tarea _tareaSeleccionada;
        public Tarea TareaSeleccionada
        {
            get => _tareaSeleccionada;
            set => SetProperty(ref _tareaSeleccionada, value);
        }


        public DelegateCommand AddTaskCommand { get; private set; }
        public DelegateCommand DetailTaskCommand { get; private set; }


        public MainPageViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            AddTaskCommand = new DelegateCommand(ExecuteAddTaskCommand);
            DetailTaskCommand = new DelegateCommand(ExecuteDetailTaskCommand);
        }

        private void ExecuteDetailTaskCommand()
        {
            var NavParameteres = new NavigationParameters() { { "IdTask", TareaSeleccionada.Id } };
            NavigationService.NavigateAsync("DetailTaskPage", NavParameteres);
        }

        private void UpdateTaskList()
        {
            SQLmanager _sqlManager = new SQLmanager();
            LstTareas = new ObservableCollection<Tarea>(_sqlManager.GetAllItems<Tarea>());
        }

        private void ExecuteAddTaskCommand()
        {

            NavigationService.NavigateAsync("AddTaskPage");
        }

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            UpdateTaskList();
        }


    }
}
