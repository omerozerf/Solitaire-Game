using System;
using System.Collections.Generic;
using UnityEngine;

namespace _Scripts
{
    public class CardSlot : MonoBehaviour
    {
        public List<Card> cardList;
        

        [SerializeField] private Vector2 size = Vector2.one;


        private Card card;
        

        private void Start()
        {
            TouchManager.OnUpMouse += TouchManagerOnUpMouse;
        }

        private void TouchManagerOnUpMouse(object sender, Card card)
        {
            this.card = card;
        }


        private void AddCardToList(Card card, List<CardSlot> addToCardSlotList, List<CardSlot> removeToCardSlotList)
        {
            // card listlerine tutan listlere ulaşıyorsun sadece cardların listesine ulaş
        }
    }
}