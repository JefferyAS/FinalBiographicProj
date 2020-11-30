using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultText : MonoBehaviour
{
    private Text text;
    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void winText(string win) {
        text.text = win;
    }
    public void loseText(string lose) {
        text.text = lose;
    }
    public void tieText(string tie) {
        text.text = tie;
    }
}
