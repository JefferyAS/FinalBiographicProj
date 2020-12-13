using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyAi : MonoBehaviour
{
    public GameObject[] activeCardList;
    public GameObject[] enemyCards;
    public string enemyName;
    public Text resultText;

    public GameObject textBoard;
    private GameObject enemyWinCard;
    private GameObject playerLoseCard;
    public BattleChecker bc;
    public GameObject handIcon;

    private float tieTextTimer;
    public float tieTextSetTimer=3f;

    private bool isWinMoving;
    private bool isWining;
    private float winMoveTimer;
    public float winMoveSetTimer=3f;
    public HandIconScript handIconScript;

    private string element;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (tieTextTimer>0) {
            TieMove();
        }

        if (isWinMoving && handIconScript.isArrived) {
            WinMoveEnd();
        }
        if (winMoveTimer > 0) {
            winMoveTimer -= Time.deltaTime;
        }
        else if (isWining) {
            WinMove();
        }
    }
    public void SetActiveCardList(GameObject[] list)
    {
        activeCardList = list;
    }
    public void StartTurn()
    {
        resultText.text = enemyName+" is thinking...";
        textBoard.SetActive(true);
        string[] reuslt =Count();
        if (reuslt[0] == "lose")
        {
            element = reuslt[1];
            isWining = true;
            winMoveTimer = winMoveSetTimer;
        }
        else {
            tieTextTimer = tieTextSetTimer;
        }
    }
    public string[] Count() {
        for (int i=0;i<enemyCards.Length;i++) {
            EnemyCardScript enemy = enemyCards[i].GetComponent<EnemyCardScript>();
            if (!enemy.isDefeated)
            {
                for (int j = 0; j < activeCardList.Length; j++)
                {
                    CardInBattle player = activeCardList[j].GetComponent<CardInBattle>();
                    if (!player.isDefeated)
                    {
                        string[] result = player.CompareCard(enemy);
                        Debug.Log(result[0]);
                        if (result[0] == "lose")
                        {
                            enemyWinCard = enemyCards[i];
                            playerLoseCard = activeCardList[j];
                            return result;
                        }
                    }
                }
            }
        }
        return new string[] {"Tie",""};
    }
    public void WinMove()
    {
        isWinMoving = true;
        isWining = false;
        enemyWinCard.GetComponent<EnemyCardScript>().ChangeColor();
        GameObject hand = Instantiate(handIcon,enemyWinCard.transform.position,Quaternion.identity,transform);
        handIconScript=hand.GetComponent<HandIconScript>();
        handIconScript.enemyWinCard = enemyWinCard;
        handIconScript.playerLoseCard = playerLoseCard;
        handIconScript.StartMove();
    }
    public void WinMoveEnd()
    {
        isWinMoving = false;
        CardInBattle player = playerLoseCard.GetComponent<CardInBattle>();
        player.ChangeColor();
        EnemyCardScript enemy = enemyWinCard.GetComponent<EnemyCardScript>();
        enemy.ChangeToOriginColor();
        player.ChangeToOriginColor();
        resultText.gameObject.GetComponent<ResultText>().loseText(player.cardName, enemy.cardName);
        bc.EnemyWin();
        bc.isYourTurn = true;
        Destroy(handIconScript.gameObject);
        bc.youTurn.enabled = true;
        bc.enemyTurn.enabled = false;
        bc.CreateIcon(player.cardName,element);
        Instantiate(bc.defeatIcon, playerLoseCard.transform.position, Quaternion.identity, playerLoseCard.transform);
        bc.enemyResult = false;
    }
    public void TieMove()
    {
        tieTextTimer -= Time.deltaTime;
        if (tieTextTimer<=0) {
            textBoard.SetActive(true);
            resultText.text = enemyName+" can do nothing with your cards.";
            bc.isYourTurn = true;
            bc.youTurn.enabled = true;
            bc.enemyTurn.enabled = false;
            bc.enemyResult = true;
        }
    }
}
