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
    public class DetailTaskPageViewModel : ViewModelBase
    {

        private long _IdTask;

        private Tarea _tareaActual;
        public Tarea TareaActual
        {
            get => _tareaActual;
            set => SetProperty(ref _tareaActual, value);
        }


        public DelegateCommand CompleteTaskCommand { get; private set; }
        public DelegateCommand DeleteTaskCommand { get; private set; }

        public DetailTaskPageViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            Title = "Gestionar Tarea";

            CompleteTaskCommand = new DelegateCommand(ExecuteCompleteTaskCommand);
            DeleteTaskCommand = new DelegateCommand(ExecuteDeleteTaskCommand);
        }

        private void ExecuteDeleteTaskCommand()
        {
            SQLmanager _sqlManager = new SQLmanager();
            _sqlManager.DeleteValue<Tarea>(TareaActual);

            Xamarin.Forms.Application.Current.MainPage.DisplayAlert("Mensaje", "Se elimino la Tarea", "Ok");
            NavigationService.GoBackAsync();
        }

        private void ExecuteCompleteTaskCommand()
        {
            SQLmanager _sqlManager = new SQLmanager();
            TareaActual.Complete = true;
            _sqlManager.SetValue<Tarea>(TareaActual);

            Xamarin.Forms.Application.Current.MainPage.DisplayAlert("Mensaje", "Se completo la tarea", "Ok");
        }

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            _IdTask = parameters.GetValue<long>("IdTask");

            SQLmanager _sqlManager = new SQLmanager();
            TareaActual = _sqlManager.GetAllItems<Tarea>().Where(t => t.Id == _IdTask).FirstOrDefault();
        }

    }
}
