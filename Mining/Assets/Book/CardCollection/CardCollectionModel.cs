using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

public class CardCollectionModel
{
    public event Action<CardInfo> OnOpenCard;

    private Cards cards;

    private List<CardData> cardDatas = new List<CardData>();

    public readonly string FilePath = Path.Combine(Application.persistentDataPath, "Cards.json");

    public CardCollectionModel(Cards cards)
    {
        this.cards = cards;
    }

    public void Initialize()
    {
        if (File.Exists(FilePath))
        {
            string loadedJson = File.ReadAllText(FilePath);
            CardDatas cardDatas = JsonUtility.FromJson<CardDatas>(loadedJson);

            Debug.Log("Success");

            this.cardDatas = cardDatas.Datas.ToList();
        }
        else
        {
            cardDatas = new List<CardData>();

            for (int i = 0; i < 180; i++)
            {
                cardDatas.Add(new CardData(i, false));
            }
        }


        for (int i = 0; i < cardDatas.Count; i++)
        {
            if (cardDatas[i].IsOpen)
                OnOpenCard?.Invoke(cards.cards[cardDatas[i].Number]);
        }
    }

    public void Dispose()
    {
        string json = JsonUtility.ToJson(new CardDatas(cardDatas.ToArray()));
        File.WriteAllText(FilePath, json);
    }

    public void UnlockCard(int number)
    {
        var cardData = cardDatas.FirstOrDefault(gd => gd.Number == number);

        if (cardData != null && !cardData.IsOpen)
        {
            cardData.IsOpen = true;

            Debug.Log("Unlock Card:" + number);
            for (int i = 0; i < cardDatas.Count; i++)
            {
                Debug.Log($"NumberGame - {cardDatas[i].Number}, Unlocked - {cardDatas[i].IsOpen}");
            }

            OnOpenCard?.Invoke(cards.cards[cardData.Number]);

            return;
        }
    }


    public bool IsOpenCard(int id, object sender)
    {
        //Debug.Log(id + "//" + sender);

        var data = cardDatas.FirstOrDefault(data => data.Number == id);

        return data.IsOpen;
    }
}

[Serializable]
public class CardDatas
{
    public CardData[] Datas;

    public CardDatas(CardData[] datas)
    {
        Datas = datas;
    }
}

[Serializable]
public class CardData
{
    public int Number;
    public bool IsOpen;

    public CardData(int number, bool isOpen)
    {
        this.Number = number;
        this.IsOpen = isOpen;
    }
}
