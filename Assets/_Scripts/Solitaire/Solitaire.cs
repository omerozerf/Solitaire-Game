using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Solitaire : MonoBehaviour
{
    public static string[] suitArray = new string[]
        { "Clubs", "Diamonds", "Hearts", "Spades" };
    public static string[] valueArray = new string[]
        { "A", "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K" };

    public Sprite[] cardFaceArray;
    public GameObject[] rightPosArray;
    public GameObject[] fieldPosArray;

    public List<string> discardPile = new List<string>();
    public List<string> deckList;
    public List<string>[] rights;
    public List<string>[] fields;
    public List<string> tripsOnDisplay = new List<string>();
    public List<List<string>> deckTrips = new List<List<string>>();

    public GameObject cardPrefab;
    public GameObject deckButton;

    private List<string> field0 = new List<string>();
    private List<string> field1 = new List<string>();
    private List<string> field2 = new List<string>();
    private List<string> field3 = new List<string>();
    private List<string> field4 = new List<string>();
    private List<string> field5 = new List<string>();
    private List<string> field6 = new List<string>();

    private int trips;
    private int tripsRemainder;
    private int deckLocation;
    

    private void Start()
    {
        fields = new List<string>[] { field0, field1, field2, field3, field4, field5, field6 };
        
        PlayCards();
    }


    public void PlayCards()
    {
        deckList = GenerateDeck();
        Shuffle(deckList);
        
        foreach (string card in deckList)
        {
            print(card);
        }
        
        SolitaireSort();
        StartCoroutine(SolitaireDeal());
        SortDeckIntoTrips();
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


    IEnumerator SolitaireDeal()
    {
        for (int i = 0; i < 7; i++)
        {
            float yOffset = 0f;
            float zOffset = 0.03f;
        
        
            foreach (string card in fields[i])
            {
                yield return new WaitForSeconds(0.01f);
                
                Vector3 position = fieldPosArray[i].transform.position;
            
                GameObject newCard = Instantiate
                    (cardPrefab, new Vector3(position.x, position.y - yOffset, position.z - zOffset), Quaternion.identity, fieldPosArray[i].transform);

                newCard.name = card;

                if (card == fields[i][fields[i].Count -1])
                {
                    newCard.GetComponent<Selectable>().faceUp = true;
                }
                
                yOffset = yOffset + 0.3f;
                zOffset = zOffset + 0.03f;
            
                discardPile.Add(card);
            }
        }

        foreach (string card in discardPile)
        {
            if (deckList.Contains(card))
            {
                deckList.Remove(card);
            }
        }
        
        discardPile.Clear();
    }


    void SolitaireSort()
    {
        for (int i = 0; i < 7; i++)
        {
            for (int j = i; j < 7; j++)
            {
                fields[j].Add(deckList.Last<string>());
                deckList.RemoveAt(deckList.Count - 1);
            }
        }
    }


    public void SortDeckIntoTrips()
    {
        trips = deckList.Count / 3;
        tripsRemainder = deckList.Count % 3;
        
        deckTrips.Clear();

        int modifier = 0;
        for (int i = 0; i < trips; i++)
        {
            List<string> myTrips = new List<string>();
            for (int j = 0; j < 3; j++)
            {
                myTrips.Add(deckList[j + modifier]);
            }
            
            deckTrips.Add(myTrips);
            modifier = modifier + 3;
        }

        if (tripsRemainder != 0)
        {
            List<string> myRemainders = new List<string>();
            modifier = 0;
            for (int k = 0; k < tripsRemainder; k++)
            {
                myRemainders.Add(deckList[deckList.Count - tripsRemainder + modifier]);
                modifier++;
            }
            
            deckTrips.Add(myRemainders);
            trips++;
        }

        deckLocation = 0;
    }


    public void DealFromDeck()
    {
        foreach (Transform child in deckButton.transform)
        {
            if (child.CompareTag("Card"))
            {
                deckList.Remove(child.name);
                discardPile.Add(child.name);
                Destroy(child.gameObject);
            }
        }
        
        
        if (deckLocation < trips)
        {
            // draw 3 new cards
            
            tripsOnDisplay.Clear();
            
            float xOffset = 2.5f;
            float zOffset = -0.2f;

            foreach (string card in deckTrips[deckLocation])
            {
                Vector3 position = deckButton.transform.position;

                GameObject newTopCard = Instantiate
                    (cardPrefab, new Vector3(position.x + xOffset, position.y, position.z + zOffset), Quaternion.identity, deckButton.transform);

                xOffset = xOffset + 0.5f;
                zOffset = zOffset - 0.2f;
                
                newTopCard.name = card;
                tripsOnDisplay.Add(card);
                newTopCard.GetComponent<Selectable>().faceUp = true;
            }

            deckLocation++;
        }
        else
        {
            // restack top deck

            RestackTopDeck();
        }
    }

    void RestackTopDeck()
    {
        foreach (string card in discardPile)
        {
            deckList.Add(card);
        }
        
        discardPile.Clear();
        SortDeckIntoTrips();
    }
}
