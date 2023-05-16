using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace _Scripts
{
    public class CardGenerator : MonoBehaviour
    {
        [SerializeField] private Sprite[] iconPeopleSpriteArray;
        [SerializeField] private Sprite[] numberArray;
        [SerializeField] private Sprite[] iconSpriteArray;
        [SerializeField] private Card cardPrefab;
        [SerializeField] private Transform deckTransform;
        
        
        private const int CARD_TYPE_MAX_SIZE = 13;


        private void Awake()
        {
            CreateCard();
            CardManager.Instance.SettAllCardsToMainCardSlot();
        }


        private void CreateCard()
        {
            CardType currentType = CardType.Clubs;
            int currentTypeInt = 0;
            int numberSpriteInt = 0;

            int deckSize = 52;
            for (int j = 0; j < deckSize ; j++)
            {
                int number = j % CARD_TYPE_MAX_SIZE;
                number++;

                if (number == 1 && j != 0) currentType++;
                if (number == 1 && j != 0) currentTypeInt++;

                Card card = Instantiate(cardPrefab, deckTransform);
                card.cardData = new CardData(number, currentType);

                card.cardDisplay.numberSprite = numberArray[numberSpriteInt % 26];
                card.cardDisplay.iconSprite = iconSpriteArray[currentTypeInt];
                card.cardDisplay.UpdateVisual();

                card.name = $"Card {currentType} {number} ";
                
                numberSpriteInt++;
            }
        }
    }
}