using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ElementIconScript : MonoBehaviour
{
    public Sprite[] icons;
    public string[] iconNames;
    private Image image;
    // Start is called before the first frame update
    void Start()
    {
        image = GetComponent<Image>();
        //Debug.Log(iconNames[1]);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetIcon(string element) {
        Debug.Log(iconNames[1]);
        Debug.Log(element);
        for (int i=0;i<iconNames.Length;i++) {
            if (iconNames[i]==element) {
                GetComponent<Image>().overrideSprite = icons[i];
            }
        }
    }
}
