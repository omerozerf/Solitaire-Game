using System;
using _Scripts;
using UnityEngine;

public class CardDrag : MonoBehaviour
{
    private MoveToPosition moveToPosition;


    private void Awake()
    {
        moveToPosition = GetComponent<MoveToPosition>();
    }
    
    /*
    private void OnMouseDrag()
    { 
        Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10); 
        Vector3 objPosition = Camera.main.ScreenToWorldPoint(mousePosition);
        moveToPosition.SetTargetPos(objPosition);
    }
     */
}