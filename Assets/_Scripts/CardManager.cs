using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace _Scripts
{
    public class CardManager : MonoBehaviour
    {
        public static CardManager Instance { get; private set; }
        
        
        public List<Card> cardList;


        private void Awake()
        {
            Instance = this;
        }


        private void Start()
        {
            cardList = new List<Card>(FindObjectsOfType<Card>());
            
            foreach (var card in cardList)
            {
                card.ShowFrontFace();
            }
        }


        public Card GetCard(CardData cardData)
        {
            foreach (var card in cardList)
            {
                if (card.cardData == cardData) return card;
            }

            return default;
        }
    }
}