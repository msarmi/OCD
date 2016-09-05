using OneClickDeploy.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace OneClickDeploy.ViewModel
{
	class TaskFlowViewModel : ViewModelBase
	{
		ObservableCollection<TaskViewModel> tareas;
        public ObservableCollection<TaskViewModel> Tareas
		{
			get
			{
				return tareas;
			}
			set
			{
				tareas = value;
                OnPropertyChanged("Tareas");
            }
		}
		
        bool flyoutOpen;
        public bool FlyoutOpen
        {
            get
            {
                return flyoutOpen;
            }
            set
            {
                flyoutOpen = value;
                OnPropertyChanged("FlyoutOpen");
            }
        }

        private FlowProject project;
        public FlowProject Project
        {
            get { return project; }
            set { 
				project = value;
				OnPropertyChanged("Project");
			}
        }
				
		public string ProjectFileName
		{
			get { return Project.FullName; }
			set 
			{
                Project.FullName = value;
				OnPropertyChanged("ProjectFileName");
			}
		}

        private int selectedIndex;
        public int SelectedIndex
        {
            get { return selectedIndex; }
            set
            {
                if (selectedIndex != value)
                {
                    selectedIndex = value;
                    OnPropertyChanged("SelectedIndex");
                }
            }
        }

        void Reset() {
            Tareas.Clear();
        }

        public TaskFlowViewModel() {
            tareas = new ObservableCollection<TaskViewModel>();			
            Project = new FlowProject();
		}
		
        void AddTaskExecute(string taskType)
        {
			TaskViewModel vm = TaskViewModelFactory.Create(taskType);
			vm.Id = tareas.Count + 1;
			vm.Order = tareas.Count + 1;
            Tareas.Add(vm);
			Project.AddTask(vm.GetModel());
            FlyoutOpen = true;
        }
		
		void SaveProjectExecute()
        {
            // Acá se verifica si hay un nombre cargado, si no hay se pide uno y se guarda ahí, se le pasa como parámetro al Guardar()
            // Luego de la verificación de nombre se deben obtener las tareas de la collección de tareas, hay que pedirsela a cada viewmodel.
			ProjectFileName = @"C:\Users\JONATAN\Desktop\OCDTESTS\ProjectOCD.xml";			
			Project.Save();
        }

		void ShowDetailExecute() {
            FlyoutOpen = true;
		}

		void PlayProjectExecute() {
			Project.Play();
		}

        void OpenProjectExecute()
        {
            Reset();
            Project.Reset();
            // Acá se verifica si hay un nombre cargado, si no hay se pide uno y se guarda ahí, se le pasa como parámetro al Guardar()
            // Luego de la verificación de nombre se deben obtener las tareas de la collección de tareas, hay que pedirsela a cada viewmodel.
            ProjectFileName = @"C:\Users\JONATAN\Desktop\OCDTESTS\ProjectOCD.xml";
            Project.Open();
            foreach (TaskFlow task in Project.Tasks)
            {
                TaskViewModel viewModel = TaskViewModelFactory.Create(task.Discriminator);
                viewModel.SetModel(task);
                Tareas.Add(viewModel);
            }
        }

        void RemoveTaskExecute() {
			if (SelectedIndex > -1)
			{
				Tareas.RemoveAt(SelectedIndex);
			}			
        }

        public ICommand AddCopy { get { return new CommandBase(param => AddTaskExecute("Copy")); } }

		public ICommand AddCmd { get { return new CommandBase(param => AddTaskExecute("Cmd")); } }

		public ICommand AddBuild { get { return new CommandBase(param => AddTaskExecute("Build")); } }

		public ICommand AddDownloadTfs { get { return new CommandBase(param => AddTaskExecute("DownloadTfs")); } }

		public ICommand SaveProject { get { return new CommandBase(param => SaveProjectExecute()); } }

		public ICommand ShowDetail { get { return new CommandBase(param => ShowDetailExecute()); } }

		public ICommand PlayProject { get { return new CommandBase(param => PlayProjectExecute()); } }

        public ICommand OpenProject { get { return new CommandBase(param => OpenProjectExecute()); } }

        public ICommand RemoveTask { get { return new CommandBase(param => RemoveTaskExecute()); } }
    }
}