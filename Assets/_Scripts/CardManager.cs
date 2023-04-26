using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace _Scripts
{
    public class CardManager : MonoBehaviour
    {
        private Card[] cards;


        private void Start()
        {
            cards = FindObjectsOfType<Card>();
            
            foreach (var card in cards)
            {
                card.HideFrontFace();
            }
        }


        public Card GetCard(CardData cardData)
        {
            foreach (var card in cards)
            {
                if (card.cardData == cardData) return card;
            }

            return default;
        }
    }
}