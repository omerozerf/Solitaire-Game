using System;
using UnityEngine;

namespace _Scripts
{
    public class TouchManager : MonoBehaviour
    {
        private void OnMouseUp()
        {
            Debug.Log("On Mouse Up!");
        }


        private void OnMouseDrag()
        { 
            Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10); 
            Vector3 objPosition = Camera.main.ScreenToWorldPoint(mousePosition); 
            gameObject.transform.position = objPosition;
        }
    }
}