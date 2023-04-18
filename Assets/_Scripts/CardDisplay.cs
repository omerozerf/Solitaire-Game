using UnityEngine;

namespace _Scripts
{
    public class CardDisplay : MonoBehaviour
    {
        public Sprite front;
        public Sprite back;
        public SpriteRenderer spriteRenderer;


        public void UpdateVisual()
        {
            spriteRenderer.sprite = front;
        }
    }
}