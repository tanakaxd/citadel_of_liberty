using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class DeckController : MonoBehaviour
{
    //MVC
    public DeckModel model;
    public DeckView view;

    public TextAsset csvFile;
    public GameObject cardPrefab;

    //other Controllers
    public HandController hand;

    void Start()
    {
        //デッキの枚数をviewに結び付ける
        model.cards.ObserveCountChanged().DistinctUntilChanged().SubscribeToText(view.deckCount);

        Init();
    }

    public void Init()
    {
        string[] textLines = csvFile.text.Split('\n');

        foreach (string textLine in textLines)
        {

            string[] cardData = textLine.Split(',');

            if (cardData[0].Equals("1000")) break;
            if (cardData[0] == "") continue;

            int ID = int.Parse(cardData[0]);
            int cardAmount = int.Parse(cardData[13]);

            for (int j = 0; j < cardAmount; j++)
            {
                GameObject cardObject = Instantiate(cardPrefab) as GameObject;
                CardController card = cardObject.GetComponent<CardController>();
                card.Init(ID);
                card.transform.SetParent(this.transform);
                model.cards.Add(card);
            }

        }
    }

    public void Draw(int amounts)
    {
        for (int i = 0; i < amounts; i++)
        {
            CardController card = model.cards[Random.Range(0,model.cards.Count)];
            model.cards.Remove(card);
            hand.AddCard(card);
            if (model.cards.Count <= 0)
            {
                //TODO refresh
            }
        }
    }

    public void AddCard(CardController card)
    {
        model.cards.Add(card);

    }

    public void AddSpellCard(CardController generatingCard)
    {
        for (int i = 0; i < generatingCard.model.greenPerTurn.Value; i++)
        {
            GameObject cardObject = Instantiate(cardPrefab) as GameObject;
            CardController generatedCard = cardObject.GetComponent<CardController>();
            generatedCard.Init(1000);
            generatedCard.transform.SetParent(this.transform);
            model.cards.Add(generatedCard);
        }
        for (int i = 0; i < generatingCard.model.bluePerTurn.Value; i++)
        {
            GameObject cardObject = Instantiate(cardPrefab) as GameObject;
            CardController generatedCard = cardObject.GetComponent<CardController>();
            generatedCard.Init(1001);
            generatedCard.transform.SetParent(this.transform);
            model.cards.Add(generatedCard);
        }
        for (int i = 0; i < generatingCard.model.redPerTurn.Value; i++)
        {
            GameObject cardObject = Instantiate(cardPrefab) as GameObject;
            CardController generatedCard = cardObject.GetComponent<CardController>();
            generatedCard.Init(1002);
            generatedCard.transform.SetParent(this.transform);
            model.cards.Add(generatedCard);
        }
    }

}
