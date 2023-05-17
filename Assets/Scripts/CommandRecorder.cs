using System.Collections.Generic;

namespace _Scripts.Solitaire
{
    public class CommandRecorder
    {
        public ICommand LastActionCommandBase => commandStack is { Count: > 0 } ? commandStack.Peek() : null;
        
        
        private Stack<ICommand> commandStack = new Stack<ICommand>();
        private List<ICommand> commandList = new List<ICommand>();
        
        
        
    }
}