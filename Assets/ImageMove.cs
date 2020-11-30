using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImageMove : MonoBehaviour
{
    public Vector3 newPos;
    public Vector3 originPos;
    public float scale=1;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.localPosition = originPos + newPos;
    }
    public void movePos(Vector3 move) {
        newPos = move * scale;
    }
}
