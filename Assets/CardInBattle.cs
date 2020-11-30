using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class CardInBattle : MonoBehaviour, IPointerClickHandler
{
    public string[] element;
    public string[] advElement;
    private Image image;
    //public bool isChosen;
    public BattleChecker bc;
    [TextArea]
    public string winText;
    [TextArea]
    public string LoseText;
    [TextArea]
    public string Tie;
    // Start is called before the first frame update
    void Start()
    {
        //transform.localPosition = new Vector3(0,0,0);
        image = GetComponent<Image>();
        bc = GameObject.Find("BattleChecker").GetComponent<BattleChecker>();
    }

    // Update is called once per frame
    void Update()
    {
        if (bc.choseCard==this.gameObject)
        {
            image.color = Color.green;
        }
        else {
            image.color = Color.white;
        }
    }

    void IPointerClickHandler.OnPointerClick(PointerEventData eventData)
    {
        bc.ChooseCard(this.gameObject);
    }
    public string CompareCard(EnemyCardScript enemy) {
        for (int i=0;i<element.Length;i++) {
            for (int j=0;j<enemy.advElement.Length;j++) {
                if (element[i]==enemy.advElement[j]) {
                    return "win";
                }
            }
        }
        for (int i = 0; i < advElement.Length; i++)
        {
            for (int j = 0; j < enemy.element.Length; j++)
            {
                if (advElement[i] == enemy.element[j])
                {
                    return "lose";
                }
            }
        }
        return "tie";
    }
}
