using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace _Scripts
{
    public class CardSlotManager : MonoBehaviour
    { 
        public List<CardSlot> cardSlotList;


        private void Start()
        {
            cardSlotList[0].cardList = CardManager.Instance.cardList;
        }
    }
}