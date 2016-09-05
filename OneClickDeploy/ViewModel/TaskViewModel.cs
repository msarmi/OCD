using OneClickDeploy.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OneClickDeploy.ViewModel
{
	public abstract class TaskViewModel : ViewModelBase
	{		
		public abstract TaskFlow GetModel();
        public abstract void SetModel(TaskFlow task);


		public int Id
		{
			get { return GetModel().Id; }
			set
			{
				if (GetModel().Id != value)
				{
					GetModel().Id = value;
					OnPropertyChanged("Id");
				}
			}
		}

		public int Order
		{
			get { return GetModel().Order; }
			set
			{
				if (GetModel().Order != value)
				{
					GetModel().Order = value;
					OnPropertyChanged("Order");
				}
			}
		}

		public string Description
		{
			get { return GetModel().Description; }
			set
			{
				if (GetModel().Description != value)
				{
					GetModel().Description = value;
					OnPropertyChanged("Description");
				}
			}
		}
	}
}
