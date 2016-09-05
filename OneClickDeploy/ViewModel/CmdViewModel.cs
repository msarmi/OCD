using OneClickDeploy.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace OneClickDeploy.ViewModel
{
	public class CmdViewModel : TaskViewModel
	{
        Cmd model;
        public Cmd Model { get { return model; } set { model = value; } }

		public string CmdString
		{
			get
			{
				return Model.CmdString;
			}
			set
			{
				Model.CmdString = value;
				OnPropertyChanged("CmdString");
			}
		}

		public CmdViewModel() {
            Model = new Cmd();
		}

		public override TaskFlow GetModel() {
			return Model;
		}

        public override void SetModel(TaskFlow task)
        {
            Model = (Cmd)task;
        }        
    }
}