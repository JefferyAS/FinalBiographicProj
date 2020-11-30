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
    public void CreateCard(GameObject card) {
        GameObject gameObj =Instantiate(card, transform);
        gameObj.transform.localPosition = new Vector3(0,0,0);
    }
}
