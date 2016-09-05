using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace OneClickDeploy.Model
{
	public class FlowProject
	{
		public string Name { get; set; }
		public string Location { get; set; }
		public string FullName 
		{ 
			get
			{
				return Location + Name;
			}
			set {
                Location = value.Substring(0, value.LastIndexOf('\\') + 1);
                Name = value.Substring(value.LastIndexOf('\\'));
			}
		}

		public FlowProject() {
            tasks = new List<TaskFlow>();
            Name = String.Empty;
            Location = String.Empty;
		}

		List<TaskFlow> tasks;

		public List<TaskFlow> Tasks { get { return tasks; } set { tasks = value; } }

		public void AddTask(TaskFlow task) 
		{
            tasks.Add(task);
		}

		public void RemoveTask(TaskFlow task) 
		{
            tasks.Remove(task);
		}

		public void Reset() {
            tasks.Clear();
		}

        public void Save() {
			XDocument proj = new XDocument();
			proj.Add(new XElement("Project"));
			proj.Root.Add(new XElement("Tasks",
				from task in Tasks
                select task.ToXml()));
			proj.Save(FullName);
		}

		public void Play() {
			foreach (TaskFlow task in Tasks)
			{
				task.CanDo(null);
			}
		}

        public void Open()
        {
            XDocument proj = XDocument.Load(FullName);
            foreach (XElement xmlTask in proj.Root.Descendants("Task"))
            {
                TaskFlow newTask = TaskFactory.Create(xmlTask.Attribute("Discriminator").Value);
                newTask.Init(xmlTask);
                Tasks.Add(newTask);
            }
        }
    }
}
