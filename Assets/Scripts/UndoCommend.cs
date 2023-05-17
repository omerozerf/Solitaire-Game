using UnityEngine;

namespace _Scripts.Solitaire
{
    public class UndoCommend : MoveHistoryCommandBase
    {
        public UndoCommend(GameObject card, int row, bool faceUp, bool top) : base(card, row, faceUp, top)
        {
        }

        public override bool Execute()
        {
            throw new System.NotImplementedException();
        }

        public override bool Undo()
        {
            throw new System.NotImplementedException();
        }
    }
}