using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CopyAvatar : MonoBehaviour
{
    public DeckTracker dc;
    // Start is called before the first frame update
    void Start()
    {
        CreateAvatar();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void CreateAvatar() {
        Instantiate(dc.avatar,transform.position,Quaternion.identity,transform);
    }
}
