using System.Collections.Generic;
using UnityEngine;

namespace _Scripts.Solitaire
{
    public class CommandHistory : MonoBehaviour
    {
        private Stack<ICommand> commandStack = new Stack<ICommand>();


        public void AddCommand(ICommand command)
        {
            commandStack.Push(command);
        }


        public void UndoCommand()
        {
            if (commandStack.TryPop(out ICommand command))
            {
                command.Undo();
            }
        }
    }
}