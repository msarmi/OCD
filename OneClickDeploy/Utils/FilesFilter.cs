using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace OneClickDeploy.Utils
{
	public static class FilesFilter
	{
		public static FileInfo[] Filter(FileInfo[] files, List<string> includedTypes, string includedRegex, List<string> excludedTypes, string excludedRegex)
		{
			// Includes files when the file´s name matchs with any of the list. e.g. ".pdf", ".txt", ".dll.pdb"
			if (includedTypes != null && includedTypes.Count > 0)
			{
				files = files.Where(file => includedTypes.Any(fileExtention => file.Name.EndsWith(fileExtention))).ToArray();
			}
			// Includes files when the file´s name matchs with a regular expression. e.g. "Core.*", "*.net*"
			if (!String.IsNullOrEmpty(includedRegex))
			{
				files = files.Where(file => Regex.IsMatch(file.Name, includedRegex)).ToArray();
			}
			// Includes files when the file´s name DOES NOT match with any of the list. e.g. ".pdf", ".txt", ".dll.pdb"
			if (excludedTypes != null && excludedTypes.Count > 0)
			{
				files = files.Where(file => !excludedTypes.Any(fileExtention => file.Name.EndsWith(fileExtention))).ToArray();
			}
			// Includes files when the file´s name DOES NOT match with a regular expression. e.g. "Core.*", "*.net*"
			if (!String.IsNullOrEmpty(excludedRegex))
			{
				files = files.Where(file => !Regex.IsMatch(file.Name, excludedRegex)).ToArray();
			}
			return files;
		}
	}
}
