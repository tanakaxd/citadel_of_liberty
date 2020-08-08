using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using static CardData;

[CreateAssetMenu(menuName = "CardDataBase")]
public class CardDataBase : ScriptableObject
{
    public List<CardData> dataBase;

    public CardData GetRandomData()
    {
        return dataBase[Random.Range(0, dataBase.Count)];
    }


    public CardData GetRandomData(CardCategory category)
    {
        List<CardData> candidates = dataBase.Where(data => data.category == category).ToList();
        return candidates[Random.Range(0, candidates.Count)];
    }


    public int GetRandomID()
    {
        List<int> ids = dataBase.Select(data=>data.ID).ToList();
        return ids[Random.Range(0, ids.Count)];
    }

    public CardData GetData(int ID)
    {
        //return dataBase.Where(model => model.ID == ID).First();
        return dataBase.FirstOrDefault(data => data.ID == ID);//あてはまるものが無ければnullを返す
    }
}
