using System;
using System.Collections.Generic;
using UnityEngine;

namespace _Scripts
{
    public class CardManager : MonoBehaviour
    {
        public List<Card> cardList;


        private void Start()
        {
            foreach (var card in cardList)
            {
                card.HideFrontFace();
            }
        }


        public Card GetCard(CardData cardData)
        {
            return cardList.Find(x => x.cardData == cardData);
        }
    }
}