using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tetromino : MonoBehaviour
{
    public float speed;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed );

        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {

            transform.Translate(Vector3.right * Time.deltaTime * speed);
        }
    }
}
