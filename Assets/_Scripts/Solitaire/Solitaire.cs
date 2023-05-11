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
    
    public List<string> deckList;
    public List<string>[] rights;
    public List<string>[] fields;

    public GameObject cardPrefab;

    private List<string> field0 = new List<string>();
    private List<string> field1 = new List<string>();
    private List<string> field2 = new List<string>();
    private List<string> field3 = new List<string>();
    private List<string> field4 = new List<string>();
    private List<string> field5 = new List<string>();
    private List<string> field6 = new List<string>();

    private void Start()
    {
        fields = new List<string>[] { field0, field1, field2, field3, field4, field5, field6 };
        
        PlayCards();
    }


    public void PlayCards()
    {
        deckList = GenerateDeck();
        Shuffle(deckList);
        SolitaireSort();
        StartCoroutine(SolitaireDeal());

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

                if (card == fields[i][fields[i].Count -1])
                {
                    newCard.GetComponent<Selectable>().faceUp = true;
                }
                
                yOffset = yOffset + 0.3f;
                zOffset = zOffset + 0.03f;
            
                newCard.name = card;
            }
        }
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
}
