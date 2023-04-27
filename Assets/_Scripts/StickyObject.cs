using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace _Scripts
{
    public class StickyObject : MonoBehaviour
    {
        private static StickyObject[] stickyObjectArray;
        
        [SerializeField] private MoveToPosition moveToPosition;
        [SerializeField] private bool canSnapToCardSlot = true;
        [SerializeField] private bool canSnapToCard;
        
        
        private void Start()
        {
            if (stickyObjectArray == null) stickyObjectArray = FindObjectsOfType<StickyObject>();
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


        public void ChangeList(Card card, List<CardSlot> removeList, List<CardSlot> addList)
        {
            removeList.Remove(card);
        }
    }
}