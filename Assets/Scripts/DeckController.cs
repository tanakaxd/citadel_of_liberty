using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class DeckController : MonoBehaviour
{
    public DeckModel model;
    public DeckView view;
    public TextAsset csvFile;
    public HandController hand;
    private ReactiveCollection<CardController> cards = new ReactiveCollection<CardController>();
    public GameObject cardPrefab;
    void Start()
    {
        //デッキの枚数をviewに結び付ける
        cards.ObserveCountChanged().DistinctUntilChanged().SubscribeToText(view.deckCount);
        Init();
    }

    public void Init()
    {
        string[] textLines = csvFile.text.Split('\n');

        foreach (string textLine in textLines)
        {
            string[] cardData = textLine.Split(',');

            if (cardData[0] == "") continue;

            int ID = int.Parse(cardData[0]);
            int cardAmount = int.Parse(cardData[13]);

            for (int j = 0; j < cardAmount; j++)
            {
                GameObject cardObject = Instantiate(cardPrefab) as GameObject;
                CardController card = cardObject.GetComponent<CardController>();
                card.Init(ID);
                card.transform.SetParent(this.transform);
                cards.Add(card);
            }

        }
    }

    public void Draw(int amounts)
    {
        for (int i = 0; i < amounts; i++)
        {
            CardController card = cards[Random.Range(0,cards.Count)];
            cards.Remove(card);
            hand.AddCard(card);
        }
    }

}
