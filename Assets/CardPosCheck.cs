using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardPosCheck : MonoBehaviour
{
    public RectTransform includingArea;
    public RectTransform excludingArea;
    private RectTransform rt;
    private Image image;
    public bool isInDeck=true;
    public GameObject cardImage;
    public int CardNum;
    private DeckTracker deckTracker;
    public Vector3 originPos;
    // Start is called before the first frame update
    void Start()
    {
        rt = GetComponent<RectTransform>();
        image = GetComponent<Image>();
        deckTracker = GameObject.Find("GameManager").GetComponent<DeckTracker>();
    }

    // Update is called once per frame
    void Update()
    {
        checkPosition();
        if (rt.Overlaps(includingArea)) {
            cardImage.GetComponent<ImageMove>().movePos(transform.localPosition-originPos);
        }
    }

    void checkPosition() {
        bool checkIn = rt.Overlaps(includingArea);
        bool checkOut = rt.Overlaps(excludingArea);
        if (checkIn && !isInDeck &&!checkOut)
        {
            //image.color = Color.green;
            isInDeck = true;
            cardImage.SetActive(true);
            deckTracker.changeCard(CardNum, true) ;
        }
        else if(checkOut && isInDeck &&!checkIn) {
            isInDeck = false;
            //image.color = Color.red;
            cardImage.SetActive(false);
            deckTracker.changeCard(CardNum, false);
        }
    }
    public void RemoveFromDeck() {
        cardImage.SetActive(false);
        isInDeck = false;
        //deckTracker.changeCard(CardNum,false);
        gameObject.SetActive(false);
    }
    //void changeColor(int count,Color color) {
    //    if (count == 0)
    //    {
    //        image.color = Color.white;
    //        return;
    //    }
    //    else {
    //        image.color = color;

    //    }
    //}
}
