using System;
using System.Collections.Generic;
using System.Text;

namespace ToDo
{
    // driver class
    class Test
    {
        static void Main()
        {
            // create a to-do list and add some to-do notes
            ToDoList list = new ToDoList("Gary");
            list.AddToDoNote(new ToDoNote("Call to Britney", new DateTime(2007, 12, 15), ToDoNotePriority.High));
            list.AddToDoNote(new ToDoNote("Go to Cinema", new DateTime(2007, 12, 18), ToDoNotePriority.Normal));

            // display contents of notes on screen
            for (int i = 0; i < list.Length; i++)
            {
                Console.WriteLine(list[i]);
            }

            // write first note to an XML file
            list[0].WriteToXML("todo.xml");
        }
    }
}
