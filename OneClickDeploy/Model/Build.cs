using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace OneClickDeploy.Model
{
	public class Build : Cmd
	{
		public override string CmdString
		{
			get
			{
				return
					MsBuild + " " +
					FullProjectName + " " +
					(PDeployOnBuild ? @"/p:DeployOnBuild=true" : String.Empty) +
					(String.IsNullOrEmpty(PPublishProfile) ? String.Empty : @"/p:PublishProfile=" + PPublishProfile + " ") +
					(String.IsNullOrEmpty(PPublishProfileRootFolder) ? String.Empty : @"/p:PublishProfileRootFolder=" + PPublishProfileRootFolder + " ") +
					(String.IsNullOrEmpty(LogFileName) ? String.Empty : @"/fl /flp:logfile=" + LogFileName + " ") +
					@"/noconlog /m /t:rebuild /p:Configuration=Release";
			}
			set { }
		}
		public override string Discriminator { get { return "Build"; } }
		
		public string MsBuild { get; set; }
		public string FullProjectName { get; set; }
		public bool PDeployOnBuild { get; set; }
		public string PPublishProfile { get; set; }
		public string PPublishProfileRootFolder { get; set; }
		public string LogFileName { get; set; }

		public Build() : base()
		{
			MsBuild = @"%programfiles(x86)%\MSBuild\12.0\Bin\msbuild.exe";
		}

		public override XElement ToXml()
		{
			XElement task = base.ToXml();
			List<XAttribute> attributes = new List<XAttribute>(){
				new XAttribute("MsBuild", MsBuild),
				new XAttribute("FullProjectName", FullProjectName),
				new XAttribute("pDeployOnBuild", PDeployOnBuild),
				new XAttribute("pPublishProfile", PPublishProfile != null ? PPublishProfile : String.Empty),
				new XAttribute("pPublishProfileRootFolder", PPublishProfileRootFolder != null ? PPublishProfileRootFolder : String.Empty),
				new XAttribute("flpLogFile", LogFileName != null ? LogFileName : String.Empty)
				
			};
			task.Add(attributes);
			return task;
		}

		public override void Init(XElement xmlTask)
		{
			base.Init(xmlTask);
			MsBuild = xmlTask.Attribute("MsBuild").Value;
			FullProjectName = xmlTask.Attribute("FullProjectName").Value;
			PDeployOnBuild = bool.Parse(xmlTask.Attribute("pDeployOnBuild").Value);
			PPublishProfile = xmlTask.Attribute("pPublishProfile").Value;
			PPublishProfileRootFolder = xmlTask.Attribute("pPublishProfileRootFolder").Value;
			LogFileName = xmlTask.Attribute("flpLogFile").Value;
		}
	}
}
