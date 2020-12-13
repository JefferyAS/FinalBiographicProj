using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReplaceObjectTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public GameObject CreateCard(GameObject card) {
        GameObject gameObj =Instantiate(card, transform.position,Quaternion.identity,transform);
        return gameObj;
        //gameObj.transform.localPosition = new Vector3(0,0,0);
    }
}
