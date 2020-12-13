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
    public void winText(string card1,string card2) {
        text.color = new Color(57f/255f,99f/255f,194f/255f);
        text.text = "Your "+card1+" defeat enemy's "+card2+" :P";
    }
    public void loseText(string card1, string card2) {
        text.color = new Color(154f / 255f, 57f / 255f, 66f / 255f);
        text.text = "Your " + card1 + " is defeated by enemy's " + card2 + " XD";
    }
    public void tieText(string card1, string card2) {
        text.color = Color.black;
        text.text = "Your " + card1 + " isn't related to " + card2 + ". It's a tie!";
    }
}
