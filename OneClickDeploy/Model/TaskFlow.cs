using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace OneClickDeploy.Model
{
	public abstract class TaskFlow
	{
		public int Id { get; set; }
		public int Order { get; set; }
		public string Description { get; set; }
        public virtual string Discriminator { get { return "TaskFlow"; } }

		public abstract void CanDo(object accomplishedData);

		public virtual XElement ToXml() {
			XElement task = new XElement("Task");
			List<XAttribute> attributes = new List<XAttribute>(){
				new XAttribute("Id", Id),
				new XAttribute("Order", Order),
				new XAttribute("Description", Description),
                new XAttribute("Discriminator", Discriminator)
            };
			task.Add(attributes);
			return task;
		}

        public virtual void Init(XElement xmlTask) {
            Id = int.Parse(xmlTask.Attribute("Id").Value);
            Order = int.Parse(xmlTask.Attribute("Order").Value);
            Description = xmlTask.Attribute("Description").Value;            
        }
	}
}
