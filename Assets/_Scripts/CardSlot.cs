using System;
using System.Collections.Generic;
using UnityEngine;

namespace _Scripts
{
    public class CardSlot : MonoBehaviour
    {
        [SerializeField] private Vector2 size = Vector2.one;


        public List<Card> cardList;


        private void OnValidate()
        {
            transform.localScale = size;
            // Debug.Log("On Validate!");
        }
    }
}