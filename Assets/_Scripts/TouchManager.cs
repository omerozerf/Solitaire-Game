using System;
using Unity.VisualScripting;
using UnityEngine;

namespace _Scripts
{
    public class TouchManager : MonoBehaviour
    {
        public static event EventHandler<(Card, CardSlotStickyObject)> OnUpMouse;
        
        
        private MoveToPosition moveToPosition;
        private CardStickyObject stickyObject;
        public Card card;


        private void Awake()
        {
            moveToPosition = GetComponent<MoveToPosition>();
            stickyObject = GetComponentInChildren<CardStickyObject>();
            card = GetComponent<Card>();
        }


        private void OnMouseUp()
        {
            stickyObject.MoveToClosestStickyObject();
            OnUpMouse?.Invoke(this, (card, stickyObject.GetClosestStickyObject()));
        }


        private void OnMouseDrag()
        { 
            Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10); 
            Vector3 objPosition = Camera.main.ScreenToWorldPoint(mousePosition);
            moveToPosition.SetTargetPos(objPosition);
        }
    }
}