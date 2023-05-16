using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

namespace _Scripts
{
    public class CardSlotManager : MonoBehaviour
    { 
        public static CardSlotManager Instance { get; private set; }
        
        public List<CardSlot> cardSlotList;


        private void Awake()
        {
            Instance = this;
        }


        private void Start()
        {
            cardSlotList[0].cardList = CardManager.Instance.cardList;
        }


        public CardSlot GetCardSlotList(int index)
        {
            return cardSlotList[index];
        }
    }
}