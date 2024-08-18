using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tetromino : MonoBehaviour
{
    public float speed = 100;
    private float previousTime;
    public float fallTime = 0.8f;
    private float tempTime;
    public static int width = 10;
    public static int height = 20;
    public Vector3 rotationPoint;
    // Update is called once per frame
    void Update()
    {
        
        // movement of the tertroninos
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed);

            if (!ValidMove())
            {
                transform.Translate(Vector3.right);
            }

        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {

            transform.Translate(Vector3.right * Time.deltaTime * speed);

            if (!ValidMove())
            {
                transform.Translate(Vector3.left);
            }
        }

        tempTime = fallTime;

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            tempTime = tempTime / 15;

            if (!ValidMove())
            {
                transform.Translate(Vector3.up);
            }
        }

        // helps the tetronino move down every 0.8 seconds
        if (Time.time - previousTime > tempTime)
        {
            transform.Translate(Vector3.down);

            previousTime = Time.time;

            if (!ValidMove())
            {
                transform.Translate(Vector3.up);
            }
        }

    }

    // a bool method helps determine the position of the childs to make sure its in the backround
    public bool ValidMove()
    {
        foreach (Transform child in transform)
        {
            int x = Mathf.RoundToInt(child.position.x);
            int y = Mathf.RoundToInt(child.position.y);

            if(x < 0 || x >= width)
            {
                return false;
            }

            if (y < 0 || y >= height)
            {
                return false;
            }
        }
         return true;
       
    }

}
