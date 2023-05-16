using System.Collections.Generic;
using UnityEngine;

namespace _Scripts.Solitaire
{
    public class MoveHistory : MonoBehaviour
    {
        private Stack<UndoData> undoDataStack = new Stack<UndoData>();


        public void UndoMove()
        {
            if (undoDataStack.Count > 0)
            {
                UndoData undoData = undoDataStack.Pop();
                
            }
        }
    }
}