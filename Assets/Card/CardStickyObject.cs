using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace _Scripts
{
    public class CardStickyObject : MonoBehaviour
    {
        
        [SerializeField] private MoveToPosition moveToPosition;
        [SerializeField] private bool canSnapToCardSlot = true;
        [SerializeField] private bool canSnapToCard;
        
        private static CardStickyObject[] cardStickyObjectArray;

        private Card card;
        
        
        private void Start()
        {
            card = GetComponent<Card>();
            if (cardStickyObjectArray == null) cardStickyObjectArray = FindObjectsOfType<CardStickyObject>();
        }


        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Keypad1))
            {
                UpdateCardStickyObject();
                Debug.Log("Card Stickleri yedim");
            }
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


        private bool IsLastCardStickyObject()
        {
            if (card.GetCardSlot().cardList.Count - 1 == card.GetCardIndexOfCardSlot())
            {
                return true;
            }

            return false;
        }


        public void UpdateCardStickyObject()
        {
            if (IsLastCardStickyObject())
            {
                return;
            }
            
            gameObject.SetActive(false);
        }
    }
}