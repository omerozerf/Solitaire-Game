using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace _Scripts
{
    public class Card : MonoBehaviour
    {
        public CardData cardData;
        public CardDisplay cardDisplay;


        [SerializeField] private GameObject FrontFace;
        [SerializeField] private GameObject BackFace;


        private CardSlot cardSlot;


        public CardSlot GetCardSlot()
        {
            return cardSlot;
        }


        public void SetCardSlot(CardSlot cardSlot)
        {
            this.cardSlot = cardSlot;
        }
        
        
        public void ShowFrontFace()
        {
            FrontFace.SetActive(true);
            BackFace.SetActive(false);
        }


        public void HideFrontFace()
        {
            FrontFace.SetActive(false);
            BackFace.SetActive(true);
        }


        public GameObject GetFrontFace()
        {
            return FrontFace;
        }
    }
}