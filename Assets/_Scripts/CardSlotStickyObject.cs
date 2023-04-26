using System;
using UnityEngine;

namespace _Scripts
{
    public class CardSlotStickyObject : MonoBehaviour
    {
        public static CardSlotStickyObject[] cardSlotStickyObjectArray;


        private void Start()
        {
            if (cardSlotStickyObjectArray == null) cardSlotStickyObjectArray = FindObjectsOfType<CardSlotStickyObject>();
        }
    }
}