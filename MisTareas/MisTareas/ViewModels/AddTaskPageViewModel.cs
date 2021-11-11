using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using MisTareas.Models;

namespace MisTareas.ViewModels
{
    public class AddTaskPageViewModel : ViewModelBase
    {


        private string _taskDescription;
        public string TaskDescription
        {
            get => _taskDescription;
            set => SetProperty(ref _taskDescription, value);
        }



        public DelegateCommand SaveTaskCommand { get; private set; }
        public AddTaskPageViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            Title = "Agregar Tarea";

            SaveTaskCommand = new DelegateCommand(ExecuteSaveTaskCommand);


        }

        private void ExecuteSaveTaskCommand()
        {
            SQLmanager _sqlManager = new SQLmanager();

            Tarea newTask = new Tarea();
            newTask.Description = TaskDescription;
            newTask.Complete = false;
            _sqlManager.SetValue<Tarea>(newTask);

            Xamarin.Forms.Application.Current.MainPage.DisplayAlert("Correcto", "Tarea Agregada", "Ok");

            NavigationService.GoBackAsync();
        }
    }
}
