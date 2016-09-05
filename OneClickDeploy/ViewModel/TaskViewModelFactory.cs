using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OneClickDeploy.ViewModel
{
    public class TaskViewModelFactory
    {
        public static TaskViewModel Create(string taskType) {
            switch (taskType)
            {
                case "Copy": return new CopyViewModel();
				case "Cmd": return new CmdViewModel();
				case "Build": return new BuildViewModel();
				case "DownloadTfs": return new DownloadTfsViewModel();
				default:return null;
            }
        }
    }
}
