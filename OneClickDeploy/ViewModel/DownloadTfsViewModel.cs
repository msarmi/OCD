using OneClickDeploy.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace OneClickDeploy.ViewModel
{
	public class DownloadTfsViewModel : TaskViewModel
	{
        DownloadTfs model;
        public DownloadTfs Model { get { return model; } set { model = value; } }

		public string TfsFile
		{
			get
			{
				return Model.TfsFile;
			}
			set
			{
				Model.TfsFile = value;
				OnPropertyChanged("TfsFile");
			}
		}

		public string LocalPath
		{
			get
			{
				return Model.LocalPath;
			}
			set
			{
				Model.LocalPath = value;
				OnPropertyChanged("LocalPath");
			}
		}

		public string Changeset 
		{
			get
			{
				return Model.Changeset;
			}
			set
			{
				Model.Changeset = value;
				OnPropertyChanged("Changeset");
			}
		}

		public DownloadTfsViewModel() {
            Model = new DownloadTfs();
		}

		public override TaskFlow GetModel() {
			return Model;
		}

        public override void SetModel(TaskFlow task)
        {
            Model = (DownloadTfs)task;
        }        
    }
}