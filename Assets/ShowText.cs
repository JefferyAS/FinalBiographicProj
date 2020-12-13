using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ShowText : MonoBehaviour
{

    //private Text text;
    public bool[] buttonIsOn;
    // Start is called before the first frame update
    void Start()
    {
        //text = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void ButtonOn(int button) {
        if (button<buttonIsOn.Length) {
            buttonIsOn[button] = true;
        }
        bool check = true;
        for (int i = 0; i < buttonIsOn.Length; i++)
        {
            if (buttonIsOn[i] == false) {
                check = false;
            }
        }
        if (check)
        {
            this.gameObject.SetActive(true);
        }
    }
}
