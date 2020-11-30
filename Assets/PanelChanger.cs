using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelChanger : MonoBehaviour
{
    private GameObject currentPanel;
    // Start is called before the first frame update
    void Start()
    {
        currentPanel= GameObject.Find("PlotPanel0");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void showNextPanel(GameObject next) {
        currentPanel.SetActive(false);
        next.SetActive(true);
        currentPanel = next;
    }
}
