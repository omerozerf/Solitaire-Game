using Unity.VisualScripting;
using UnityEngine;

namespace _Scripts.Solitaire
{
    public class StackCardCommand : ICommand
    {
        private GameObject slot1;
        private global::Solitaire solitaire;
        private GameObject myGameObject;
        private GameObject selected;
        private Selectable s1;
        private Selectable s2;
        private MoveToPosition moveToPosition;

        private GameObject previousSlot1;
        private Vector3 previousPosition;
        private Transform previousParent;
        private bool previousInDeckPile;
        private int previousRow;
        private bool previousTop;
        private bool previousS2Top;

        public StackCardCommand(GameObject slot1, global::Solitaire solitaire, GameObject myGameObject, GameObject selected, Selectable s1, Selectable s2, MoveToPosition moveToPosition)
        {
            this.slot1 = slot1;
            this.solitaire = solitaire;
            this.myGameObject = myGameObject;
            this.selected = selected;
            this.s1 = s1;
            this.s2 = s2;
            this.moveToPosition = moveToPosition;
        }

        public void Execute()
        {
            float yOffset = 0.3f;
            previousSlot1 = UserInput.Instance.slot1;
            if (s2.top || (!s2.top && s1.value == 13))
            {
                yOffset = 0;
            }

            previousPosition = UserInput.Instance.slot1.transform.position;
            previousParent = UserInput.Instance.slot1.transform.parent;

            var position = selected.transform.position;
            slot1.transform.position = new Vector3(position.x, position.y - yOffset, position.z - 0.01f);
            // moveToPosition.SetTargetPos(new Vector3(position.x, position.y - yOffset, position.z - 0.01f));
            
            slot1.transform.parent = selected.transform; 
            if (s1.inDeckPile) 
            {
                solitaire.tripsOnDisplay.Remove(slot1.name);
            }
            else if (s1.top && s2.top && s1.value == 1)
            {
                solitaire.topPos[s1.row].GetComponent<Selectable>().value = 0;
                solitaire.topPos[s1.row].GetComponent<Selectable>().suit = null;
            }
            else if (s1.top)
            {
                solitaire.topPos[s1.row].GetComponent<Selectable>().value = s1.value - 1;
            }
            else 
            {
                solitaire.bottoms[s1.row].Remove(slot1.name);
            }

            previousInDeckPile = s1.inDeckPile;
            previousRow = s1.row;
            previousTop = s1.top;
            previousS2Top = s2.top;
            
            s1.inDeckPile = false;
            s1.row = s2.row;

            if (s2.top) 
            {
                solitaire.topPos[s1.row].GetComponent<Selectable>().value = s1.value;
                solitaire.topPos[s1.row].GetComponent<Selectable>().suit = s1.suit;
                s1.top = true;
            }
            else
            {
                s1.top = false;
            }

            previousSlot1 = slot1;
            slot1 = this.myGameObject;
        }

        public void Undo()
        {
            // Önceki durumu geri yükle

            // slot1'i önceki durumuna getir
            slot1 = previousSlot1;

            // yOffset'i önceki değerine geri al
            // yOffset = previousYOffset;

            // slot1'in transformunu geri yükle
            slot1.transform.position = previousPosition;
            slot1.transform.parent = previousParent;

            // s1'in değerlerini geri yükle
            s1.inDeckPile = previousInDeckPile;
            s1.row = previousRow;
            s1.top = previousTop;

            // s2'nin değerlerini geri yükle
            s2.top = previousS2Top;

            // Diğer gerekli geri yükleme işlemlerini yap

            // ...
        }


    }
}