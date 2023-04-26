using System;
using System.Collections.Generic;
using UnityEngine;

namespace _Scripts
{
    public class StickyObject : MonoBehaviour
    {
        private static StickyObject[] stickyObjectArray;
        
        [SerializeField] private MoveToPosition moveToPosition;

        private bool canSnap;
        
        
        private void Start()
        {
            if (stickyObjectArray == null) stickyObjectArray = FindObjectsOfType<StickyObject>();
        }


        public void MoveToClosestStickyObject()
        {
            var currentDistance = float.PositiveInfinity;
            foreach (var cardSlotStickyObject in CardSlotStickyObject.cardSlotStickyObjectArray)
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
}