using System.Collections.Generic;
using UnityEngine;

namespace _Scripts.Solitaire
{
    public class MoveHistory : MonoBehaviour, ICommand

    {
    private Stack<ICommand> ICommandStack = new Stack<ICommand>();


    public void UndoMove()
    {
        if (ICommandStack.Count > 0)
        {
            ICommand Icommand = ICommandStack.Pop();

        }
    }

    public void Execute()
    {
        throw new System.NotImplementedException();
    }

    public void Undo()
    {
        throw new System.NotImplementedException();
    }
    }
}