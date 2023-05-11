using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Solitaire : MonoBehaviour
{
    public static string[] suitArray = new string[]
        { "Clubs", "Diamonds", "Hearts", "Spades" };
    public static string[] valueArray = new string[]
        { "A", "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K" };

    public Sprite[] cardFaceArray;
    public List<string> deckList;
    public GameObject cardPrefab;

    private void Start()
    {
        PlayCards();
    }


    public void PlayCards()
    {
        deckList = GenerateDeck();
        Shuffle(deckList);
        SolitaireDeal();

        foreach (string card in deckList)
        {
            print(card);
        }
    }
    
    
    public static List<string> GenerateDeck()
    {
        List<string> newDeckList = new List<string>();

        foreach (string suit in suitArray)
        {
            foreach (string value in valueArray)
            {
                newDeckList.Add(suit + " - " + value);
            }
        }

        return newDeckList;
    }


    void Shuffle<T>(List<T> list)
    {
        System.Random random = new System.Random();
        int n = list.Count;

        while (n > 1)
        {
            int k = random.Next(n);
            n--;
            T temp = list[k];
            list[k] = list[n];
            list[n] = temp;
        }
    }


    void SolitaireDeal()
    {
        float yOffset = 0f;
        float zOffset = 0.03f;
        
        
        foreach (string card in deckList)
        {
            Vector3 rotation = new Vector3(0, 0, 270);
            Vector3 position = transform.position;
            
            GameObject newCard = Instantiate
                (cardPrefab, new Vector3(position.x, position.y - yOffset, position.z - zOffset), Quaternion.Euler(rotation));

            yOffset = yOffset + 0.1f;
            zOffset = zOffset + 0.03f;
            
            newCard.name = card;
        }
    }
}
