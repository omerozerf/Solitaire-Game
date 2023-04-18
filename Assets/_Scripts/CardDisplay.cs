using UnityEngine;
using UnityEngine.Serialization;

namespace _Scripts
{
    public class CardDisplay : MonoBehaviour
    {
        public Sprite iconSprite;
        public Sprite numberSprite;
        public SpriteRenderer iconSpriteRenderer;
        public SpriteRenderer numberSpriteRenderer;


        public void UpdateVisual()
        {
            iconSpriteRenderer.sprite = iconSprite;
            numberSpriteRenderer.sprite = numberSprite;
        }
    }
}