using System;
using System.Collections;
using System.Text;
using System.Xml;

namespace ToDo
{
    // a simple to-do list
    public class ToDoList
    {
        private String owner;                   // the name of the owner of the list
        private ArrayList notes;                // the notes collection, dynamically sized

        // constructor
        public ToDoList(String owner)
        {
            Owner = owner;
            notes = new ArrayList();           // new collection
        }

        // property for owner
        public String Owner
        {
            get
            {
                return owner;
            }

            set
            {
                owner = value;
            }
        }

        // indexer so list can be accessed using [] notation
        public ToDoNote this[int i]
        {
            get
            {
                if ((i >= 0) && (i < notes.Count))
                {
                    return (ToDoNote) notes[i];
                }
                else
                {
                    throw new ArgumentException("Invalid index!");
                }
            }
        }

        // return current length of notes collection
        public int Length
        {
            get
            {
                return notes.Count;
            }
        }

        // add a new to-do note to end of collection
        public void AddToDoNote(ToDoNote note)
        {
            notes.Add(note);
        }
    }

    // priorty for to-do note
    public enum ToDoNotePriority
    {
        High, Normal, Low
    }

    // interface indicating item can be serialised to XML
    public interface SerialiseToXML
    {
        void WriteToXML(String filename);
    }

    // a to-do note
    public class ToDoNote : SerialiseToXML                  // interface implementation
    {
        // fields
        private string subject;                             // subject of note
        private DateTime dueDate;                           // when it has to be done by
        private ToDoNotePriority priority;                  // priority for completion

        // constructor
        public ToDoNote(string subject, DateTime dueDate, ToDoNotePriority priority)
        {
            Subject = subject;
            DueDate = dueDate;
            Priority = priority;
        }

        // properties
        public String Subject
        {
            get
            {
                return subject;
            }
            set
            {
                subject = value;
            }
        }

        public DateTime DueDate
        {
            get
            {
                return dueDate;
            }
            set
            {
                dueDate = value;
            }
        }

        public ToDoNotePriority Priority
        {
            get
            {
                return priority;
            }
            set
            {
                priority = value;
            }
        }

        // write XML for note to a file
        public void WriteToXML(String filename)
        {
            XmlTextWriter tw = new XmlTextWriter(filename, null);
            tw.Formatting = Formatting.Indented;
            tw.WriteStartDocument();
            tw.WriteStartElement("To-Do-Note");
            tw.WriteElementString("Subject", subject);
            tw.WriteElementString("Due-date", dueDate.ToString());
            tw.WriteElementString("Priority", priority.ToString("d"));
            tw.WriteEndElement();
            tw.WriteEndDocument();

            tw.Flush();
            tw.Close();
        }

        // return String representation of the to-do note
        public override string ToString()
        {
            return "Subject: " + Subject + " due date: " + DueDate.ToString("d") + " priority: " + Priority.ToString();
        }
    }
}
