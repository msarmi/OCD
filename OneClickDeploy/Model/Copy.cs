using OneClickDeploy.Utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace OneClickDeploy.Model
{
	public class Copy : TaskFlow
	{
		public string PathFrom { get; set; }
		public string PathTo { get; set; }
		public List<string> IncludedTypes { get; set; }
		public List<string> ExcludedTypes { get; set; }
		public string IncludedRegex { get; set; }
		public string ExcludedRegex { get; set; }
		public bool ReplaceIfExists { get; set; }
		public bool Recursive { get; set; }
        public override string Discriminator { get { return "Copy"; } }

        public Copy() {
            IncludedTypes = new List<string>();
            ExcludedTypes = new List<string>();
		}

		public override void CanDo(object accomplishedData)
		{
            DirectoryCopy(PathFrom, PathTo);
		}

		private void DirectoryCopy(string sourceDirName, string destDirName)
		{
			// Get the subdirectories for the specified directory.
			DirectoryInfo dir = new DirectoryInfo(sourceDirName);

			if (!dir.Exists)
			{
				throw new DirectoryNotFoundException("Mr Meeseeks cannot do impossible: source directory does not exist or could not be found: " + sourceDirName);
			}

			DirectoryInfo[] dirs = dir.GetDirectories();
			// If the destination directory doesn't exist, create it.
			if (!Directory.Exists(destDirName))
			{
				Directory.CreateDirectory(destDirName);
			}

			// Get the files in the directory and copy them to the new location.
			FileInfo[] files = dir.GetFiles();
			files = FilesFilter.Filter(files, IncludedTypes, IncludedRegex, ExcludedTypes, ExcludedRegex);

			foreach (FileInfo file in files)
			{
				string temppath = Path.Combine(destDirName, file.Name);
				file.CopyTo(temppath, ReplaceIfExists);
			}

			// If copying subdirectories, copy them and their contents to new location.
			if (Recursive)
			{
				foreach (DirectoryInfo subdir in dirs)
				{
					string temppath = Path.Combine(destDirName, subdir.Name);
					DirectoryCopy(subdir.FullName, temppath);
					// Here we should delete empty trees.
				}
			}
		}

		public override XElement ToXml()
		{
			XElement task = base.ToXml();
			List<XAttribute> attributes = new List<XAttribute>(){
				new XAttribute("PathFrom", PathFrom),
				new XAttribute("PathTo", PathTo),
				new XAttribute("IncludedTypes", String.Join(",", IncludedTypes)),
				new XAttribute("ExcludedTypes", String.Join(",", ExcludedTypes)),
				new XAttribute("IncludedRegex", IncludedRegex ?? String.Empty),
				new XAttribute("ExcludedRegex", ExcludedRegex ?? String.Empty),
				new XAttribute("ReplaceIfExists", ReplaceIfExists),
				new XAttribute("Recursive", Recursive)
			};
			task.Add(attributes);			
			return task;
		}

        public override void Init(XElement xmlTask)
        {
            base.Init(xmlTask);
            PathFrom = xmlTask.Attribute("PathFrom").Value;
            PathTo = xmlTask.Attribute("PathTo").Value;
            if (!String.IsNullOrWhiteSpace(xmlTask.Attribute("IncludedTypes").Value.Trim()))
            {
                IncludedTypes.AddRange(xmlTask.Attribute("IncludedTypes").Value.Trim().Replace(",","").Split(','));
            }
            if (!String.IsNullOrWhiteSpace(xmlTask.Attribute("ExcludedTypes").Value.Trim()))
            {
                ExcludedTypes.AddRange(xmlTask.Attribute("ExcludedTypes").Value.Trim().Replace(",", "").Split(','));
            }
            IncludedRegex = xmlTask.Attribute("IncludedRegex").Value;
            ExcludedRegex = xmlTask.Attribute("ExcludedRegex").Value;
            if (!String.IsNullOrWhiteSpace(xmlTask.Attribute("ReplaceIfExists").Value))
            {
                ReplaceIfExists = bool.Parse(xmlTask.Attribute("ReplaceIfExists").Value);
            }
            if (!String.IsNullOrWhiteSpace(xmlTask.Attribute("Recursive").Value))
            {
                Recursive = bool.Parse(xmlTask.Attribute("Recursive").Value);
            }
        }
    }
}
