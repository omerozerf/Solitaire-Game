using System;
using UnityEngine;

namespace _Scripts
{
    public class CardSlot : MonoBehaviour
    {
        [SerializeField] private Vector2 size = Vector2.one;

        private void OnValidate()
        {
            transform.localScale = size;
            


            // Debug.Log("On Validate!");
        }
    }
}