using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleChecker : MonoBehaviour
{
    public GameObject choseCard;
    public GameObject choseEnemy;
    public ResultText resultText;
    public Text youScoreBoard;
    public Text enemyScoreBoard;

    private int youScore;
    private int enemyScore;
    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        youScoreBoard.text = youScore.ToString();
        enemyScoreBoard.text = enemyScore.ToString();
    }
    public void ChooseCard(GameObject card) {
        choseCard = card;
    }
    public void ChooseEnemy(GameObject card) {
        if (choseCard!=null) {
            choseEnemy = card;
            CardInBattle cardInBattle = choseCard.GetComponent<CardInBattle>();
            string result=cardInBattle.CompareCard(choseEnemy.GetComponent<EnemyCardScript>());
            if (result == "win")
            {
                resultText.winText(cardInBattle.winText);
                youScore += 1;
            }
            else if (result == "lose")
            {
                resultText.loseText(cardInBattle.LoseText);
                enemyScore += 1;
            }
            else {
                resultText.tieText(cardInBattle.Tie);
            }
            choseCard = null;
            choseEnemy = null;
        }
    }
}
