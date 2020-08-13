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
    public GameObject spellPrefab;

    private Vector3 hiddenOffset = new Vector3(1000, 0, 0);

    //other Controllers
    //TODO cycle dependecyを防ぐためにhand,trash,deckを管理するクラスを作る
    public HandController hand;
    public TrashController trash;

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
                AddWholeCard(card);
            }

        }
    }

    public void Draw(int amounts)
    {
        for (int i = 0; i < amounts; i++)
        {
            if (model.cards.Count <= 0)
            {
                //TODO refresh
                if (trash.model.cards.Count <= 0) return;
                foreach (var c in trash.model.cards)
                {
                    AddWholeCard(c);
                }
                trash.model.cards.Clear();
            }
            CardController card = model.cards[Random.Range(0,model.cards.Count)];
            model.cards.Remove(card);
            hand.AddCard(card);
        }
    }

    public void AddWholeCard(CardController card)
    {
        model.cards.Add(card);
        card.transform.SetParent(transform, false);
        card.transform.position = transform.position + hiddenOffset;
    }

    public void AddSpellCard(CardController generatingCard)
    {
        for (int i = 0; i < generatingCard.model.greenPerTurn.Value; i++)
        {
            GameObject cardObject = Instantiate(spellPrefab) as GameObject;
            CardController generatedCard = cardObject.GetComponent<CardController>();
            generatedCard.Init(1000);
            AddWholeCard(generatedCard);
        }
        for (int i = 0; i < generatingCard.model.bluePerTurn.Value; i++)
        {
            GameObject cardObject = Instantiate(spellPrefab) as GameObject;
            CardController generatedCard = cardObject.GetComponent<CardController>();
            generatedCard.Init(1001);
            AddWholeCard(generatedCard);
        }
        for (int i = 0; i < generatingCard.model.redPerTurn.Value; i++)
        {
            GameObject cardObject = Instantiate(spellPrefab) as GameObject;
            CardController generatedCard = cardObject.GetComponent<CardController>();
            generatedCard.Init(1002);
            AddWholeCard(generatedCard);
        }
    }

}
