using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleChecker : MonoBehaviour
{
    public GameObject choseCard;
    public GameObject choseEnemy;
    public ResultText resultText;
    public GameObject textBoard;
    public Text youScoreBoard;
    public Text enemyScoreBoard;
    public GameObject icon;
    public GameObject defeatIcon;

    public bool isYourTurn=true;
    public Text youTurn;
    public Text enemyTurn;
    //public Sprite[] iconSprites;

    public int youScore;
    public int enemyScore;

    private float endTurnTimer;
    public float endTurnSetTimer=3f;
    private bool isEndTurn;

    public bool enemyResult;

    //result buttons
    public GameObject winButton;
    public GameObject loseButton;
    public GameObject tieButton;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        youScoreBoard.text = youScore.ToString();
        enemyScoreBoard.text = enemyScore.ToString();

        if (endTurnTimer > 0f && isEndTurn) {
            endTurnTimer -= Time.deltaTime;
        }
        else if (endTurnTimer<=0 &&isEndTurn) {
            isEndTurn = false;
            EndTurn();
        }


        //show result buttons
        if (isYourTurn)
        {
            if (youScore > enemyScore &&enemyResult)
            {
                winButton.SetActive(true);
            }
            else if (enemyResult && youScore == enemyScore)
            {
                tieButton.SetActive(true);
            }
            else if (youScore < enemyScore)
            {
                loseButton.SetActive(true);
            }
        }
        else {
            winButton.SetActive(false);
            loseButton.SetActive(false);
            tieButton.SetActive(false);
        }
    }
    public void ChooseCard(GameObject card) {
        choseCard = card;
    }
    public void ChooseEnemy(GameObject card) {
        if (choseCard!=null) {
            choseEnemy = card;
            CardInBattle cardInBattle = choseCard.GetComponent<CardInBattle>();
            EnemyCardScript enemy = choseEnemy.GetComponent<EnemyCardScript>();
            string[] result=cardInBattle.CompareCard(enemy);
            //Debug.Log(result[1]);
            if (result[0] == "win")
            {
                enemy.isDefeated = true;
                CreateIcon(enemy.cardName,result[1]);
                textBoard.SetActive(true);
                resultText.winText(cardInBattle.cardName, enemy.cardName);
                youScore += 1;
                Instantiate(defeatIcon, choseEnemy.transform.position, Quaternion.identity, choseEnemy.transform);
            }
            else if (result[0] == "lose")
            {
                CreateIcon(cardInBattle.cardName, result[1]);
                textBoard.SetActive(true);
                resultText.loseText(cardInBattle.cardName, enemy.cardName);
                enemyScore += 1;
                Instantiate(defeatIcon, choseCard.transform.position, Quaternion.identity, choseCard.transform);
            }
            else {
                textBoard.SetActive(true);
                resultText.tieText(cardInBattle.cardName, enemy.cardName);
            }
            isYourTurn = false;
            EndTurn(0);
        }
    }
    public void CreateIcon(string cardName, string element) {
        GameObject avatar = GameObject.Find(cardName);
        GameObject icon=Instantiate(this.icon,avatar.transform.position,Quaternion.identity,avatar.transform);
        icon.GetComponent<ElementIconScript>().SetIcon(element);
    }

    public void EnemyWin() {
        enemyScore += 1;
    }
    private void EndTurn() {
        choseCard = null;
        choseEnemy = null;
        youTurn.enabled = false;
        enemyTurn.enabled = true;
        GetComponent<EnemyAi>().StartTurn();
    }
    private void EndTurn(int time) {
        isEndTurn = true;
        endTurnTimer = endTurnSetTimer;
    }
}
