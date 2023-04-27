using System;
using System.Collections.Generic;
using UnityEngine;

namespace _Scripts
{
    public class CardSlotStickyObject : MonoBehaviour
    {
        public static List<CardSlotStickyObject> cardSlotStickyObjectList;
        
        
        [SerializeField] private bool canSnapToCardSlot = true;
        [SerializeField] private bool canSnapToCard;
        

        private void Start()
        {
            if (cardSlotStickyObjectList == null) 
                cardSlotStickyObjectList = new List<CardSlotStickyObject>(FindObjectsOfType<CardSlotStickyObject>());
        }
    }
}