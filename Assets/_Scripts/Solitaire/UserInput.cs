using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserInput : MonoBehaviour
{
    public GameObject slot1;
    
    private GameManager solitaire;


    private void Start()
    {
        solitaire = FindObjectOfType<GameManager>();
        slot1 = gameObject;
    }


    private void Update()
    {
        GetMouseClick();
    }


    void GetMouseClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePosition =
                Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, -10));
            RaycastHit2D hit = 
                Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

            if (hit)
            {
                if (hit.collider.CompareTag("Deck"))
                {
                    Deck();
                }
                
                else if (hit.collider.CompareTag("Card"))
                {
                    Card(hit.collider.gameObject);
                }
                
                else if (hit.collider.CompareTag("Field"))
                {
                    Field();
                }
                
                else if (hit.collider.CompareTag("Right"))
                {
                    Right();
                }
            }
        }
    }


    void Deck()
    {
        solitaire.DealFromDeck();

        print("Deck");
    }
    
    
    void Card(GameObject selected)
    {
        if (slot1 = gameObject)
        {
            slot1 = selected;
        }
     
        print("Card");
    }
    
    
    void Field()
    {
        print("Field");
    }
    
    
    void Right()
    {
        print("Right");
    }
}
