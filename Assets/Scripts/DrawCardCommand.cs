using System.Collections.Generic;
using UnityEngine;


namespace _Scripts.Solitaire
{
    public class DrawCardCommand : ICommand
    {
        private global::Solitaire solitaire;
        private List<string> deck;
        private GameObject deckButton;
        private List<string> discardPile;
        private int deckLocation;
        private int trips;
        private List<string> tripsOnDisplay;
        private List<List<string>> deckTrips;
        private GameObject cardPrefab;

        public DrawCardCommand(global::Solitaire solitaire, List<string> deck, GameObject deckButton, List<string> discardPile, int deckLocation, int trips, List<string> tripsOnDisplay, List<List<string>> deckTrips, GameObject cardPrefab)
        {
            this.solitaire = solitaire;
            this.deck = deck;
            this.deckButton = deckButton;
            this.discardPile = discardPile;
            this.deckLocation = deckLocation;
            this.trips = trips;
            this.tripsOnDisplay = tripsOnDisplay;
            this.deckTrips = deckTrips;
            this.cardPrefab = cardPrefab;
        }

        public void Execute()
        {
            // add remaining cards to discard pile

            foreach (Transform child in deckButton.transform)
            {
                if (child.CompareTag("Card"))
                {
                    deck.Remove(child.name);
                    discardPile.Add(child.name);
                    Object.Destroy(child.gameObject);
                }
            }


            if (deckLocation < trips)
            {
                // draw 3 new cards
                tripsOnDisplay.Clear();
                float yOffset = -3.5f;
                float zOffset = -0.2f;

                foreach (string card in deckTrips[deckLocation])
                {
                    GameObject newTopCard = Object.Instantiate(cardPrefab, new Vector3(deckButton.transform.position.x, deckButton.transform.position.y + yOffset, deckButton.transform.position.z + zOffset), Quaternion.identity, deckButton.transform);
                    yOffset = yOffset - 0.5f;
                    zOffset = zOffset - 0.2f;
                    newTopCard.name = card;
                    tripsOnDisplay.Add(card);
                    newTopCard.GetComponent<Selectable>().faceUp = true;
                    newTopCard.GetComponent<Selectable>().inDeckPile = true;
                }
                deckLocation++;

            }
            else
            {
                //Restack the top deck
                solitaire.RestackTopDeck();
            }
        }

        public void Undo()
        {
            
        }
    }
}