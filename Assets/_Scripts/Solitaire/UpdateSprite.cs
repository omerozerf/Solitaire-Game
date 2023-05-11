using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateSprite : MonoBehaviour
{
    public Sprite cardFace;
    public Sprite cardBack;

    private SpriteRenderer spriteRenderer;
    private Selectable selectable;
    private GameManager solitaire;


    private void Start()
    {
        List<string> deckList = GameManager.GenerateDeck();
        solitaire = FindObjectOfType<GameManager>();

        int i = 0;
        foreach (string card in deckList)
        {
            if (name == card)
            {
                cardFace = solitaire.cardFaceArray[i];
                break;
            }
            
            i++;
        }

        spriteRenderer = GetComponent<SpriteRenderer>();
        selectable = GetComponent<Selectable>();
    }


    private void Update()
    {
        if (selectable.faceUp == true)
        {
            spriteRenderer.sprite = cardFace;
        }
        else
        {
            spriteRenderer.sprite = cardBack;
        }
    }
}
