using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace OneClickDeploy.Model
{
	public class DownloadTfs : Cmd
	{
		public override string CmdString
		{
			get
			{
				return
					TfsFile + " get " +
					LocalPath + " " +					
					(String.IsNullOrEmpty(Changeset) ? String.Empty : @"/version:" + Changeset + " ") +					
					@"/force /all /overwrite /recursive";
			}
			set { }
		}
		public override string Discriminator { get { return "DownloadTfs"; } }
		
		public string TfsFile { get; set; }
		public string LocalPath { get; set; }
		public string Changeset	 { get; set; }		

		public DownloadTfs() : base()
		{
			TfsFile = @"c:\Program Files (x86)\Microsoft Visual Studio 12.0\Common7\IDE\tf.exe";
		}

		public override XElement ToXml()
		{
			XElement task = base.ToXml();
			List<XAttribute> attributes = new List<XAttribute>(){
				new XAttribute("TfsFile", TfsFile),
				new XAttribute("LocalPath", LocalPath),
				new XAttribute("Changeset", (Changeset != null ? Changeset : String.Empty))				
			};
			task.Add(attributes);
			return task;
		}

		public override void Init(XElement xmlTask)
		{
			base.Init(xmlTask);
			TfsFile = xmlTask.Attribute("TfsFile").Value;
			LocalPath = xmlTask.Attribute("LocalPath").Value;
			Changeset = xmlTask.Attribute("Changeset").Value;
		}
	}
}
