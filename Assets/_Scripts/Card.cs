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
        [SerializeField] private SpriteRenderer[] frontFaceChildrenArray;
        
        
        private CardSlot cardSlot;


        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.P))
            {
                UpdateVisual();
            }
        }


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


        public void UpdateVisual()
        {
            if (cardSlot.cardList == null) return;
            
            int cardIndex = cardSlot.cardList.IndexOf(this);
            
            foreach (SpriteRenderer frontFaceChildren in frontFaceChildrenArray)
            {
                frontFaceChildren.sortingOrder = cardIndex + 1;
            }
        }


        public CardData GetCardData()
        {
            Debug.Log($"Number: {cardData.number} | Type: {cardData.cardType}");


            return cardData;
        }
    }
}