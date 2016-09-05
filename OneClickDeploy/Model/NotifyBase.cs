using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace OneClickDeploy.Model
{
	public class NotifyBase : INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler PropertyChanged;
 
        protected virtual void OnPropertyChanged(string propertyName)
		{
            if (PropertyChanged != null) 
			{
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
	}
}