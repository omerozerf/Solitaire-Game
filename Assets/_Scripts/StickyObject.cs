using System;
using UnityEngine;

namespace _Scripts
{
    public class StickyObject : MonoBehaviour
    {
        public void GetClosestStickyObject()
        {
            StickyObject[] stickyObjectArray = FindObjectsOfType<StickyObject>();
            foreach (var stickyObject in stickyObjectArray)
            {
                Card card = stickyObject.GetComponentInParent<Card>();
                if (card == null)
                {
                    Debug.Log(stickyObject, stickyObject);    
                }
                
            }
        }
    }
}