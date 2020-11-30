using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeckTracker : MonoBehaviour
{
    public bool[] cardInDeck;
    public GameObject[] cardList;
    public GameObject avatar;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void changeCard(int num, bool status) {
        cardInDeck[num] = status;
    }
    public GameObject[] GetCardList() {
        int length = 0;
        for (int i = 0; i < cardInDeck.Length; i++)
        {
            if (cardInDeck[i])
            {
                length += 1;
            }
        }
        GameObject[] list=new GameObject[length];
        int index = 0;
        for (int i=0; i<cardList.Length; i++) {
            if (cardInDeck[i])
            {
                list[index]=(cardList[i]);
                index += 1;
            }
        }
        return list;
    }
    public void SaveAvatar(GameObject avatar) {
        this.avatar = avatar;
    }
}
