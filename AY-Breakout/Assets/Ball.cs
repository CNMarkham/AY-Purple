using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody2D>().velocity = Random.insideUnitCircle.normalized * 10;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < player.transform.position.y)
        {
            Time.timeScale = 0;
        }
    }
}
