using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class EnemyCardScript : MonoBehaviour, IPointerClickHandler
{
    public string[] element;
    public string[] advElement;
    private Image image;
    //public bool isChosen;
    public BattleChecker bc;
    public string cardName;
    public bool isDefeated;
    public Color selectedColor;
    private bool isChangingColor;
    private float colorTimer;
    // Start is called before the first frame update
    void Start()
    {
        image = GetComponent<Image>();
        bc = GameObject.Find("BattleChecker").GetComponent<BattleChecker>();
    }

    // Update is called once per frame
    void Update()
    {
        if (bc.choseEnemy == this.gameObject)
        {
            ChangeColor();
        }
        else
        {
            ChangeToOriginColor();
        }
    }
    public void ChangeColor()
    {
        image.color = selectedColor;
    }
    public void ChangeToOriginColor()
    {
        if (colorTimer <= 0 && isChangingColor)
        {
            image.color = Color.white;
            isChangingColor = false;
        }
        else if (colorTimer <= 0 && !isChangingColor)
        {
            isChangingColor = true;
            colorTimer = 1;
        }
        else
        {
            colorTimer -= Time.deltaTime;
        }
    }

    void IPointerClickHandler.OnPointerClick(PointerEventData eventData)
    {
        if (!isDefeated && bc.isYourTurn)
        {
            bc.ChooseEnemy(this.gameObject);
        }
    }
}
