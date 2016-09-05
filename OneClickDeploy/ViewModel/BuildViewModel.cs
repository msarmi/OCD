using OneClickDeploy.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace OneClickDeploy.ViewModel
{
	public class BuildViewModel : TaskViewModel
	{
        Build model;
        public Build Model { get { return model; } set { model = value; } }

		public string MsBuild
		{
			get
			{
				return Model.MsBuild;
			}
			set
			{
				Model.MsBuild = value;
				OnPropertyChanged("MsBuild");
			}
		}

		public string FullProjectName
		{
			get
			{
				return Model.FullProjectName;
			}
			set
			{
				Model.FullProjectName = value;
				OnPropertyChanged("FullProjectName");
			}
		}

		public bool PDeployOnBuild
		{
			get
			{
				return Model.PDeployOnBuild;
			}
			set
			{
				Model.PDeployOnBuild = value;
				OnPropertyChanged("PDeployOnBuild");
			}
		}

		public string PPublishProfile
		{
			get
			{
				return Model.PPublishProfile;
			}
			set
			{
				Model.PPublishProfile = value;
				OnPropertyChanged("PPublishProfile");
			}
		}

		public string PPublishProfileRootFolder
		{
			get
			{
				return Model.PPublishProfileRootFolder;
			}
			set
			{
				Model.PPublishProfileRootFolder = value;
				OnPropertyChanged("PPublishProfileRootFolder");
			}
		}

		public string LogFileName
		{
			get
			{
				return Model.LogFileName;
			}
			set
			{
				Model.LogFileName = value;
				OnPropertyChanged("LogFileName");
			}
		}

		public BuildViewModel() {
            Model = new Build();
		}

		public override TaskFlow GetModel() {
			return Model;
		}

        public override void SetModel(TaskFlow task)
        {
            Model = (Build)task;
        }        
    }
}