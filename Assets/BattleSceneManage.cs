using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleSceneManage : MonoBehaviour
{
    public GameObject battleScene;
    public GameObject canvas;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ShowBattleScene() {
        GameObject newScene=Instantiate(battleScene,canvas.transform.position,Quaternion.identity,canvas.transform);
        battleScene.SetActive(true);
        battleScene = newScene;
    }
    public void ChangeBattleScene(GameObject scene)
    {
        battleScene = scene;
        GameObject newScene = Instantiate(battleScene, canvas.transform.position, Quaternion.identity, canvas.transform);
        battleScene.SetActive(true);
        battleScene = newScene;
    }
}
