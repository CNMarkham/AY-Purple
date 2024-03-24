using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public Transform player1;
    public Transform player2;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody2D>().velocity = Random.insideUnitCircle.normalized * 10;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < player1.transform.position.x)
        {
            transform.position = Vector2.zero;
            GetComponent<Rigidbody2D>().velocity = Random.insideUnitCircle.normalized * 10;
        }

        if (transform.position.x > player2.transform.position.x)
        {
            transform.position = Vector2.zero;
            GetComponent<Rigidbody2D>().velocity = Random.insideUnitCircle.normalized * 10;
        }
    }
}
