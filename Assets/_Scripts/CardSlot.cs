using System;
using System.Collections.Generic;
using UnityEngine;

namespace _Scripts
{
    public class CardSlot : MonoBehaviour
    {
        public List<Card> cardList;
        

        [SerializeField] private Vector2 size = Vector2.one;
        

        private void Start()
        {
            TouchManager.OnUpMouse += TouchManagerOnUpMouse;
        }

        private void TouchManagerOnUpMouse(object sender, (Card, CardSlotStickyObject) valueTuple)
        {
            CardSlot cardSlot = valueTuple.Item2.GetComponent<CardSlot>();
            
            if (cardSlot == this)
            {
                AddCardToList(valueTuple.Item1);
                Debug.Log($"{valueTuple.Item1} - {this}");
            }
        }


        private void AddCardToList(Card card)
        {
            CardSlot currentCardSlot = card.GetCardSlot();

            if (currentCardSlot)
            {
                currentCardSlot.RemoveCardToList(card);
            }
            
            cardList.Add(card);
            card.SetCardSlot(this);
        }
        
        
        private void RemoveCardToList(Card card)
        {
            cardList.Remove(card);
            card.SetCardSlot(null);
        }


        private void OnDestroy()
        {
            TouchManager.OnUpMouse -= TouchManagerOnUpMouse;
        }
    }
}