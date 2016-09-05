using OneClickDeploy.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace OneClickDeploy.ViewModel
{
	public class CopyViewModel : TaskViewModel
	{
        Copy model;
        public Copy Model { get { return model; } set { model = value; } }
		
		#region Properties
		
        public string PathFrom
		{
			get
			{
				return Model.PathFrom;
			}
			set
			{
                Model.PathFrom = value;
				OnPropertyChanged("PathFrom");
			}
		}

		public string PathTo
		{
			get
			{
				return Model.PathTo;
			}
			set
			{
                Model.PathTo = value;
				OnPropertyChanged("PathTo");
			}
		}

		public string IncludedTypes
		{
			get
			{
				return String.Join(",", Model.IncludedTypes);
			}
			set
			{
                Model.IncludedTypes = value.Trim().Replace(" ",String.Empty).Split(',').ToList();
				OnPropertyChanged("IncludedTypes");
			}
		}

		public string ExcludedTypes
		{
			get
			{
				return String.Join(",", Model.ExcludedTypes);
			}
			set
			{
                Model.ExcludedTypes = value.Trim().Replace(" ", String.Empty).Split(',').ToList();
				OnPropertyChanged("ExcludedTypes");
			}
		}

		public string IncludedRegex
		{
			get
			{
				return Model.IncludedRegex;
			}
			set
			{
                Model.IncludedRegex = value;
                OnPropertyChanged("IncludedRegex");
			}
		}

		public string ExcludedRegex
		{
			get
			{
				return Model.ExcludedRegex;
			}
			set
			{
                Model.ExcludedRegex = value;
                OnPropertyChanged("ExcludedRegex");
			}
		}

		public bool ReplaceIfExists
		{
			get
			{
				return Model.ReplaceIfExists;
			}
			set
			{
                Model.ReplaceIfExists = value;
				OnPropertyChanged("ReplaceIfExists");
			}
		}

		public bool Recursive
		{
			get
			{
				return Model.Recursive;
			}
			set
			{
                Model.Recursive = value;
				OnPropertyChanged("Recursive");
			}
		}

		public CopyViewModel() {
            Model = new Copy();
		}

		public override TaskFlow GetModel() {
			return Model;
		}

        public override void SetModel(TaskFlow task)
        {
            Model = (Copy)task;
        }
        #endregion
    }
}