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

        else if (slot1 != selected)
        {
            if (Stackable(selected))
            {
                
            }

            else
            {
                slot1 = selected;
            }
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


    bool Stackable(GameObject selected)
    {
        Selectable s1 = slot1.GetComponent<Selectable>();
        Selectable s2 = selected.GetComponent<Selectable>();


        if (s2.top)
        {
            if (s1.suit == s2.suit || (s1.value == 1 && s2.suit == null))
            {
                if (s1.value == s2.value +1)
                {
                    return true;
                }
            }
            else
            {
                return false;
            }
        }

        else
        {
            if (s1.value == s2.value -1)
            {
                bool card1Red = true;
                bool card2Red = true;

                if (s1.suit == "C" || s1.suit == "S")
                {
                    card1Red = false;
                }

                if (s2.suit == "C" || s2.suit == "S")
                {
                    card2Red = false;
                }

                if (card1Red == card2Red)
                {
                    print("No stackable");
                    return false;
                }
                
                else
                {
                    print("Stackable");
                    return true;
                }
            }
        }

        return false;
    }
}
