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
    //[TextArea]
    //public string winText;
    //[TextArea]
    //public string LoseText;
    //[TextArea]
    //public string Tie;
    public string cardName;
    public bool isDefeated;
    public Color selectedColor;
    

    private float colorTimer;
    private bool isChangingColor;
    //public GameObject defeatIcon;
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
            ChangeColor();
        }
        else if(!isChangingColor&&image.color!=Color.white){
            ChangeToOriginColor();
        }

        if (isChangingColor) {
            //Debug.Log(colorTimer);
            ChangeToOriginColor(0);
        }
    }

    public void ChangeColor() {
        image.color = selectedColor;
    }
    private void ChangeToOriginColor(int time) {
        if (colorTimer <= 0 && isChangingColor)
        {
            image.color = Color.white;
            isChangingColor = false;
        }
        else {
            colorTimer -= Time.deltaTime;
        }
    }
    public void ChangeToOriginColor()
    {
        isChangingColor = true;
        colorTimer = 0.5f;
    }

    void IPointerClickHandler.OnPointerClick(PointerEventData eventData)
    {
        if (!isDefeated && bc.isYourTurn) {
            bc.ChooseCard(this.gameObject);
        }
    }
    public string[] CompareCard(EnemyCardScript enemy) {
        string[] result=new string[2];
        for (int i=0;i<element.Length;i++) {
            for (int j=0;j<enemy.advElement.Length;j++) {
                if (element[i]==enemy.advElement[j]) {
                    result[0]="win";
                    result[1] = enemy.advElement[j];
                    //Instantiate(defeatIcon,enemy.gameObject.transform.position,Quaternion.identity, enemy.gameObject.transform);
                }
            }
        }
        for (int i = 0; i < advElement.Length; i++)
        {
            for (int j = 0; j < enemy.element.Length; j++)
            {
                if (advElement[i] == enemy.element[j])
                {
                    isDefeated = true;
                    result[0] = "lose";
                    result[1] = advElement[i];
                    //Instantiate(defeatIcon, transform.position, Quaternion.identity, transform);
                }
            }
        }
        return result;
    }
}
