using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RunnerScript : MonoBehaviour
{
    public int runTimes=50;
    private Image image;

    public Sprite sprite1;
    public Sprite sprite2;
    public GameObject runButton;
    public GameObject nextButton;

    public float speed=2;
    // Start is called before the first frame update
    void Start()
    {
        image = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Run() {
        runTimes -= 1;
        if (runTimes % 2 == 1)
        {
            image.sprite = sprite2;
        }
        else {
            image.sprite = sprite1;
        }
        transform.localPosition += new Vector3(speed,0,0);
        if (runTimes<=0) {
            EndRun();
        }
    }
    public void EndRun() {
        nextButton.SetActive(true);
        runButton.SetActive(false);
    }
}
