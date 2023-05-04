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


        private static bool isDealCards = false;
        

        private void Start()
        {
            TouchManager.OnUpMouse += TouchManager_OnUpMouse;
        }

        
        private void Update()
        {
            TryDealCards();
        }

        private void TryDealCards()
        {
            if (!isDealCards)
            {
                DealCardToList();
            }
        }

        private void DealCardToList()
        {
            
            if (Input.GetKeyDown(KeyCode.Space))
            {
                isDealCards = true;

                
                List<Card> cardCopyList = new List<Card>(CardManager.Instance.cardList);

                for (int i = 0; i < CardSlotManager.Instance.cardSlotList.Count; i++)
                {
                    if (i == 0) continue;
                    for (int j = 0; j < i; j++)
                    {
                        int randomNumber = Random.Range(0, cardCopyList.Count);
                        Card randomCard = cardCopyList[randomNumber];

                        CardSlot cardSlot = CardSlotManager.Instance.GetCardSlotList(i);
                        cardSlot.AddCardToList(randomCard);

                        SpriteRenderer[] spriteRendererArray =
                            randomCard.GetFrontFace().GetComponentsInChildren<SpriteRenderer>();

                        Transform frontFaceTransform = randomCard.transform.GetChild(1);
                        SpriteRenderer frontFaceSpriteRenderer = frontFaceTransform.GetComponent<SpriteRenderer>();

                        SpriteRenderer maskSpriteRenderer = frontFaceTransform.GetChild(0).GetComponent<SpriteRenderer>();
                        
                        foreach (SpriteRenderer spriteRenderer in spriteRendererArray)
                        {
                            if (spriteRenderer == frontFaceSpriteRenderer ||
                                spriteRenderer == maskSpriteRenderer)
                            {
                                frontFaceSpriteRenderer.sortingOrder = 0;
                                maskSpriteRenderer.sortingOrder = 0;
                                continue;
                            }
                            spriteRenderer.sortingOrder = cardList.Count + 1;
                        }
                        

                        cardCopyList.Remove(randomCard);

                        MoveToPosition moveToPosition = randomCard.GetComponent<MoveToPosition>();
                        
                        Vector3 objPos = cardSlot.transform.position;
                        
                        moveToPosition.SetTargetPos(objPos);
                        
                        UpdateCardParent(randomCard, cardSlot);
                    }
                }
            }
        }

        private static void UpdateCardParent(Card card, CardSlot cardSlot)
        {
            card.transform.SetParent(cardSlot.transform);
        }


        private void TouchManager_OnUpMouse(object sender, (Card, CardSlotStickyObject) valueTuple)
        {
            CardSlot cardSlot = valueTuple.Item2.GetComponent<CardSlot>();
            

            if (cardSlot == this)
            {
                AddCardToList(valueTuple.Item1);
                
                UpdateCardParent(valueTuple.Item1, cardSlot);
                valueTuple.Item1.GetCardData();
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
            TouchManager.OnUpMouse -= TouchManager_OnUpMouse;
        }
    }
}