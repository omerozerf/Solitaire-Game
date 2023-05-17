using System.Collections.Generic;
using UnityEngine;

namespace _Scripts.Solitaire
{
    public abstract class MoveHistoryCommandBase : ICommand
    {
        protected GameObject card;
        protected int row;
        protected bool faceUp;
        protected bool top;


        protected MoveHistoryCommandBase(GameObject card, int row, bool faceUp, bool top)
        {
            this.card = card;
            this.row = row;
            this.faceUp = faceUp;
            this.top = top;
        }


        public abstract bool Execute();

        public abstract bool Undo();
    }
}