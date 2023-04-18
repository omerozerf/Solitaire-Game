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

        
        private const int CARD_TYPE_MAX_SIZE = 13;
        
        
        [ContextMenu(nameof(Create))]
        private void Create()
        {
            CardType currentType = CardType.Hearts;
            
            for (int i = 0; i < iconSpriteArray.Length; i++)
            {
                for (int j = 0; j < numberArray.Length; j++)
                {
                    int number = j % CARD_TYPE_MAX_SIZE;
                    number++;

                    if (number == 1 && j != 0) currentType++;

                    Card card = Instantiate(cardPrefab);
                    card.cardData = new CardData(number, currentType);
                }
            }    
            
            
            
        }
    }
}