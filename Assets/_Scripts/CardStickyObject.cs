using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace _Scripts
{
    public class CardStickyObject : MonoBehaviour
    {
        private static CardStickyObject[] stickyObjectArray;
        
        [SerializeField] private MoveToPosition moveToPosition;
        [SerializeField] private bool canSnapToCardSlot = true;
        [SerializeField] private bool canSnapToCard;
        
        
        private void Start()
        {
            if (stickyObjectArray == null) stickyObjectArray = FindObjectsOfType<CardStickyObject>();
        }


        public void MoveToClosestStickyObject()
        {
            if (canSnapToCardSlot)
            {
                // canSnapToCardSlot = false;
                // canSnapToCard = true;
                
                var currentDistance = float.PositiveInfinity;
                foreach (var cardSlotStickyObject in CardSlotStickyObject.cardSlotStickyObjectList)
                {
                    var distance = (transform.position - cardSlotStickyObject.transform.position).magnitude;

                    if (distance < currentDistance)
                    {
                        currentDistance = distance;
                        
                        moveToPosition.SetTargetPos(cardSlotStickyObject.transform.position);
                    }
                }
            }
        }


        public CardSlotStickyObject GetClosestStickyObject()
        {
            var currentDistance = float.PositiveInfinity;
            CardSlotStickyObject currentCardSlotStickyObject = null;
            foreach (var cardSlotStickyObject in CardSlotStickyObject.cardSlotStickyObjectList)
            {
                var distance = (transform.position - cardSlotStickyObject.transform.position).magnitude;

                if (distance < currentDistance)
                {
                    currentDistance = distance;

                    currentCardSlotStickyObject = cardSlotStickyObject;
                }
            }

            return currentCardSlotStickyObject;
        }
    }
}