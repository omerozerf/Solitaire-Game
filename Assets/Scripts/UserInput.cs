﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using _Scripts;
using _Scripts.Solitaire;
using TMPro;
using UnityEngine.Serialization;

public class UserInput : MonoBehaviour
{
    public static UserInput Instance;
    
    
    public GameObject slot1;
    public int move;
    public int score;
    private Solitaire solitaire;
    private float timer;
    private float doubleClickTime = 0.3f;
    private int clickCount = 0;

    [FormerlySerializedAs("textMeshProUGUI")] [SerializeField] private TextMeshProUGUI moveTextMeshProUGUI;
    [SerializeField] private TextMeshProUGUI scoreTextMeshProUGUI;
    [SerializeField] private CommandHistory commandHistory;


    private void Awake()
    {
        Instance = this;
    }


    void Start()
    {
        solitaire = FindObjectOfType<Solitaire>();
        slot1 = this.gameObject;
    }

    void Update()
    {
        moveTextMeshProUGUI.text = $"Moves: {move}";
        scoreTextMeshProUGUI.text = $"Score: {score}";
        
        
        if (clickCount == 1)
        {
            timer += Time.deltaTime;
        }
        if (clickCount == 3)
        {
            timer = 0;
            clickCount = 1;
        }
        if (timer > doubleClickTime)
        {
            timer = 0;
            clickCount = 0;
        }

        GetMouseClick();
    }

    void GetMouseClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            clickCount++;

            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, -10));
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
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
                else if (hit.collider.CompareTag("Top"))
                {
                    Top(hit.collider.gameObject);
                }
                else if (hit.collider.CompareTag("Bottom"))
                {
                    Bottom(hit.collider.gameObject);
                }
            }
        }
    }

    void Deck()
    {
        print("Clicked on deck");
        solitaire.DrawFromDeck();
        slot1 = this.gameObject;

    }
    void Card(GameObject selected)
    {
        print("Clicked on Card");

        if (!selected.GetComponent<Selectable>().faceUp)
        {
            if (!Blocked(selected))
            {
                selected.GetComponent<Selectable>().faceUp = true;
                slot1 = this.gameObject;
            }

        }
        else if (selected.GetComponent<Selectable>().inDeckPile) 
        {
            
            if (!Blocked(selected))
            {
                if (slot1 == selected)
                {
                    if (DoubleClick())
                    {
                        AutoStack(selected);
                    }
                }
                else
                {
                    slot1 = selected;
                }                
            }

        }
        else
        {

            // if the card is face up
            // if there is no card currently selected
            // select the card

            if (slot1 == this.gameObject)
            {
                slot1 = selected;
            }

            
            else if (slot1 != selected)
            {
                // kart ekleme
                if (Stackable(selected))
                {
                    StackCard(selected);
                    move++;
                    score = 5 * move;
                }
                else
                {
                    slot1 = selected;
                }
            }

            else if (slot1 == selected)
            {
                if (DoubleClick())
                {
                    AutoStack(selected);
                }
            }


        }
    }
    void Top(GameObject selected)
    {
        print("Clicked on Top");
        if (slot1.CompareTag("Card"))
        {
            if (slot1.GetComponent<Selectable>().value == 1)
            {
                StackCard(selected);
            }

        }
    }
    void Bottom(GameObject selected)
    {
        print("Clicked on Bottom");

        if (slot1.CompareTag("Card"))
        {
            if (slot1.GetComponent<Selectable>().value == 13)
            {
                StackCard(selected);
            }
        }
    }

    bool Stackable(GameObject selected)
    {
        Selectable s1 = slot1.GetComponent<Selectable>();
        Selectable s2 = selected.GetComponent<Selectable>();

        if (!s2.inDeckPile)
        {
            if (s2.top)
            {
                if (s1.suit == s2.suit || (s1.value == 1 && s2.suit == null))
                {
                    if (s1.value == s2.value + 1)
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
                if (s1.value == s2.value - 1)
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
                        print("Not stackable");
                        return false;
                    }
                    else
                    {
                        print("Stackable");
                        return true;
                    }
                }
            }
        }
        return false;
    }

    void StackCard(GameObject selected)
    {
        Selectable s1 = slot1.GetComponent<Selectable>();
        Selectable s2 = selected.GetComponent<Selectable>();

        MoveToPosition moveToPosition = slot1.GetComponent<MoveToPosition>();
        
        StackCardCommand stackCardCommand = 
            new StackCardCommand(slot1, solitaire, this.gameObject, selected, s1, s2, moveToPosition);
        stackCardCommand.Execute();
        commandHistory.AddCommand(stackCardCommand);
    }

    bool Blocked(GameObject selected)
    {
        Selectable s2 = selected.GetComponent<Selectable>();
        if (s2.inDeckPile == true)
        {
            if (s2.name == solitaire.tripsOnDisplay.Last()) 
            {
                return false;
            }
            else
            {
                print(s2.name + " is blocked by " + solitaire.tripsOnDisplay.Last());
                return true;
            }
        }
        else
        {
            if (s2.name == solitaire.bottoms[s2.row].Last())
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }

    bool DoubleClick()
    {
        if (timer < doubleClickTime && clickCount == 2)
        {
            print("Double Click");
            return true;
        }
        else
        {
            return false;
        }
    }

    void AutoStack(GameObject selected)
    {
        for (int i = 0; i < solitaire.topPos.Length; i++)
        {
            Selectable stack = solitaire.topPos[i].GetComponent<Selectable>();
            if (selected.GetComponent<Selectable>().value == 1)
            {
                if (solitaire.topPos[i].GetComponent<Selectable>().value == 0) 
                {
                    slot1 = selected;
                    StackCard(stack.gameObject);
                    break;
                }
            }
            else
            {
                if ((solitaire.topPos[i].GetComponent<Selectable>().suit == slot1.GetComponent<Selectable>().suit) && 
                    (solitaire.topPos[i].GetComponent<Selectable>().value == slot1.GetComponent<Selectable>().value - 1))
                {
                    if (HasNoChildren(slot1))
                    {
                        slot1 = selected;
                        string lastCardname = stack.suit + stack.value.ToString();
                        if (stack.value == 1)
                        {
                            lastCardname = stack.suit + "A";
                        }
                        if (stack.value == 11)
                        {
                            lastCardname = stack.suit + "J";
                        }
                        if (stack.value == 12)
                        {
                            lastCardname = stack.suit + "Q";
                        }
                        if (stack.value == 13)
                        {
                            lastCardname = stack.suit + "K";
                        }
                        GameObject lastCard = GameObject.Find(lastCardname);
                        StackCard(lastCard);
                        break;
                    }
                }
            }



        }
    }

    bool HasNoChildren(GameObject card)
    {
        int i = 0;
        foreach (Transform child in card.transform)
        {
            i++;
        }
        if (i == 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

}
