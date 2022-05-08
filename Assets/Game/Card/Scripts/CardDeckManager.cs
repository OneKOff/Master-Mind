
using System.Collections.Generic;
using UnityEngine;

public class CardDeckManager
{
    public const int HAND_SIZE = 6;

    public List<Card> DrawPile = new List<Card>();
    public Card[] HandPile = new Card[HAND_SIZE];
    public List<Card> DiscardPile = new List<Card>();

    public void FillDeck(List<Card> cards)
    {
        DrawPile = ShuffleDeck(cards);
    }

    public List<Card> ShuffleDeck(List<Card> cards)
    {
        var newDeck = new List<Card>();
        var cardCount = cards.Count;

        for (var i = 0; i < cardCount; i++)
        {
            var id = Random.Range(0, cards.Count);

            newDeck.Add(cards[id]);
            cards.RemoveAt(id);
        }

        return newDeck;
    }

    public void DrawCard(int amount)
    {
        for (var i = 0; i < amount; i++)
        {
            MoveCards();

            HandPile[0] = DrawPile[0];
            DrawPile.RemoveAt(0);
        }
    } 

    private void MoveCards()
    {
        var i = 0;
        for (; i < HAND_SIZE; i++)
        {
            if (HandPile[i] == null)
            {
                break;
            }
        }

        i--;

        if (i == HAND_SIZE - 1)
        {
            DiscardCard(i, false);
        }

        for (; i >= 0; i--)
        {
            HandPile[i + 1] = HandPile[i];
        }

    }

    public void DiscardCard(int id, bool isPlayed)
    {
        DiscardPile.Add(HandPile[id]);
        HandPile[id] = null;

        // if (!isPlayed) OnCardDiscard()
    }

    public void ReshufflePiles()
    {
        FillDeck(DiscardPile);

        DiscardPile.Clear();
    }
}
