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
            image.color = Color.red;
        }
        else
        {
            image.color = Color.white;
        }
    }

    void IPointerClickHandler.OnPointerClick(PointerEventData eventData)
    {
        bc.ChooseEnemy(this.gameObject);
    }
}
