using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleInitialize : MonoBehaviour
{
    public DeckTracker deckTracker;
    public GameObject[] placeHolder;
    public GameObject avatarHolder;

    // Start is called before the first frame update
    void Start()
    {
        GameObject[] cardList = deckTracker.GetCardList();
        for (int i=0;i<cardList.Length;i++)
        {
            placeHolder[i].GetComponent<ReplaceObjectTest>().CreateCard(cardList[i]);
        }
        avatarHolder.GetComponent<ReplaceObjectTest>().CreateCard(deckTracker.avatar);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
