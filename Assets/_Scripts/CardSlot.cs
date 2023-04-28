using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

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

        
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                List<Card> cardList = new List<Card>(CardManager.Instance.cardList);

                for (int i = 0; i < CardSlotManager.Instance.cardSlotList.Count; i++)
                {
                    if(i == 0) continue;
                    for (int j = 0; j < i; j++)
                    {
                        int randomNumber = Random.Range(0, cardList.Count);
                        Card randomIndex = cardList[randomNumber];

                        CardSlot cardSlot = CardSlotManager.Instance.GetCardSlotList(i);
                        cardSlot.AddCardToList(randomIndex);
                        
                        cardList.Remove(randomIndex);
                        
                        // Debug.Log($"{randomIndex} - {cardSlot}");
                    } 
                    Debug.Log("Calıstım");
                }
            }
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