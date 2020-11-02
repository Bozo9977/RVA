
using Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Helpers
{
    public class CommandHandler
    {
        private static CommandHandler instance;

        public static CommandHandler Instance
        {
            get
            {
                if (instance == null)
                    instance = new CommandHandler();

                return instance;
            }
        }



        public List<MyICommand> undoCommands = new List<MyICommand>();
        public List<MyICommand> redoCommands = new List<MyICommand>();
        public List<object> undoObjects = new List<object>();
        public List<object> redoObjects = new List<object>();

        public void AddAndExecute(MyICommand c, object o)
        {
            undoCommands.Add(c);
            undoObjects.Add(o);
        }

        public void Redo()
        {
            if (redoCommands.Count != 0)
            {
                undoCommands.Add(redoCommands[redoCommands.Count - 1]);
                undoObjects.Add(redoObjects[redoObjects.Count - 1]);

                redoCommands[redoCommands.Count - 1].Execute(redoObjects[redoObjects.Count - 1]);
                
                redoCommands.RemoveAt(redoCommands.Count - 1);
                redoObjects.RemoveAt(redoObjects.Count - 1);
            }
        }

        public void Undo()
        {
            if (undoCommands.Count != 0)
            {
                redoCommands.Add(undoCommands[undoCommands.Count - 1]);
                redoObjects.Add(undoObjects[undoObjects.Count - 1]);

                undoCommands[undoCommands.Count - 1].Unexecute(undoObjects[undoObjects.Count - 1]);
              
                undoCommands.RemoveAt(undoCommands.Count - 1);
                undoObjects.RemoveAt(undoObjects.Count - 1);
            }
        }

        public void UpdateCheckIDS(int oldID, int newID)
        {
            undoObjects.RemoveAll(x => x == null);
            redoObjects.RemoveAll(X => X == null);

            foreach(Check c in undoObjects)
            {
                if(c.Id == oldID)
                {
                    c.Id = newID;
                }
            }
            foreach (Check c in redoObjects)
            {
                if(c.Id == oldID)
                {
                    c.Id = newID;
                }
            }
        }

    }
}
