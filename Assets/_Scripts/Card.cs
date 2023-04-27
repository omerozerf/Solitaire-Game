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
        
        
        
    }
}