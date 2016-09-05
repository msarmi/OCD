using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace OneClickDeploy.Model
{
	public class Cmd : TaskFlow
	{
		public virtual string CmdString { get; set; }
		public override string Discriminator { get { return "Cmd"; } }
		public override void CanDo(object accomplishedData)
		{
			Process cmd = new Process();
			cmd.StartInfo.FileName = "cmd.exe";
			cmd.StartInfo.RedirectStandardInput = true;
			cmd.StartInfo.RedirectStandardOutput = true;
			cmd.StartInfo.CreateNoWindow = true;
			cmd.StartInfo.UseShellExecute = false;
			cmd.Start();

			cmd.StandardInput.WriteLine(CmdString);
			cmd.StandardInput.Flush();
			cmd.StandardInput.Close();
			cmd.WaitForExit();
			//Console.WriteLine(cmd.StandardOutput.ReadToEnd());
		}

		public override XElement ToXml()
		{
			XElement task = base.ToXml();
			XElement cmd = new XElement("CmdString", new XCData(CmdString));			
			task.Add(cmd);
			return task;
		}

		public override void Init(XElement xmlTask)
		{
			base.Init(xmlTask);
			CmdString = ((XCData)xmlTask.Element("CmdString").FirstNode).Value;
		}
	}
}
