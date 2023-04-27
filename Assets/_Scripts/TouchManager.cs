using System;
using UnityEngine;

namespace _Scripts
{
    public class TouchManager : MonoBehaviour
    {
        private MoveToPosition moveToPosition;
        private StickyObject stickyObject;


        private void Awake()
        {
            moveToPosition = GetComponent<MoveToPosition>();
            stickyObject = GetComponentInChildren<StickyObject>();
        }


        private void OnMouseUp()
        {
            stickyObject.MoveToClosestStickyObject();
        }


        private void OnMouseDrag()
        { 
            Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10); 
            Vector3 objPosition = Camera.main.ScreenToWorldPoint(mousePosition);
            moveToPosition.SetTargetPos(objPosition);
        }
    }
}