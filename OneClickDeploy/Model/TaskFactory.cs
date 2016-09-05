using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OneClickDeploy.Model
{
    public class TaskFactory
    {
        public static TaskFlow Create(string taskType) {
            switch (taskType)
            {
                case "Copy": return new Copy();
				case "Cmd": return new Cmd();
				case "Build": return new Build();
				case "DownloadTfs": return new DownloadTfs();
				default: return null;                    
            }
        }
    }
}
