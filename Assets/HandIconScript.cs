using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandIconScript : MonoBehaviour
{
    public GameObject enemyWinCard;
    public float moveSpeed=0.2f;
    public GameObject playerLoseCard;
    private Vector3 endPoint;
    private bool isMoving;
    public bool isArrived;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isMoving) {
            Move();
        }
    }
    public void StartMove() {
        endPoint = playerLoseCard.transform.position;
        isMoving = true;
    }
    private void Move()
    {
        transform.position = Vector3.Lerp(transform.position,endPoint,moveSpeed);
        if (Vector3.Distance(transform.position,endPoint)<=2) {
            isMoving = false;
            isArrived = true;
        }
    }
}
