using System;
using System.Collections.Generic;
using UnityEngine;

namespace _Scripts
{
    public class StickyObject : MonoBehaviour
    {
        [SerializeField] private MoveToPosition moveToPosition;


        private static StickyObject[] stickyObjectArray;
        
        
        private List<StickyObject> cardSlotStickyObjectList = new List<StickyObject>();


        private void Start()
        {
            if (stickyObjectArray == null)
            {
                stickyObjectArray = FindObjectsOfType<StickyObject>();
            }
        }


        public void GetClosestStickyObject()
        {
            foreach (var stickyObject in stickyObjectArray)
            {
                Card card = stickyObject.GetComponentInParent<Card>();
                if (card == null) cardSlotStickyObjectList.Add(stickyObject);
            }
        }


        public void MoveToClosestStickyObject()
        {
            var currentDistance = float.PositiveInfinity;
            foreach (var cardSlotStickyObject in cardSlotStickyObjectList)
            {
                var distance = (transform.position - cardSlotStickyObject.transform.position).magnitude;

                if (distance < currentDistance)
                {
                    currentDistance = distance;

                    // card.transform.position = cardSlotStickyObject.transform.position;
                    moveToPosition.SetTargetPos(cardSlotStickyObject.transform.position);

                    Debug.Log("yapışşş!");
                }
            }
        }
    }
}