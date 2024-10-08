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
    public static Transform[,] grid = new Transform[width, height];
    public void AddToGrid()
    {
       foreach(Transform child in transform)
        {
            int x = Mathf.RoundToInt(child.transform.position.x);
            int y = Mathf.RoundToInt(child.transform.position.y);

            grid[x, y] = child;


        }

    }



    // Update is called once per frame
    void Update()
    {
        
        
        // movement of the tertroninos
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            transform.position += Vector3.left;

            if (!ValidMove())
            {
                transform.position += Vector3.right;
            }

        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {

            transform.position += Vector3.right;

            if (!ValidMove())
            {
                transform.position += Vector3.left;
            }
        }

        tempTime = fallTime;

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            tempTime = tempTime / 15;

            if (!ValidMove())
            {
                transform.position += Vector3.up;
            }
        }

        // helps the tetronino move down every 0.8 seconds
        if (Time.time - previousTime > tempTime)
        {
            transform.position += Vector3.down;

            previousTime = Time.time;

            if (!ValidMove())
            {
                transform.position += Vector3.up;
                this.enabled = false;
                AddToGrid();
                CheckLines();
                FindAnyObjectByType<Spawner>().SpawnTetromino();
            }
        }
        // checking if up arrow is pressed and the tetronino will rotate around its rotate point
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            Vector3 convertedPoint = transform.TransformPoint(rotationPoint);

            transform.RotateAround(convertedPoint, Vector3.forward, 90);

            if (!ValidMove())
            {
                transform.RotateAround(convertedPoint, Vector3.forward, -90);
                transform.position += Vector3.up;
                


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


            if (grid[x, y] != null)
            {

                return false;
            }
        }
         return true;
       
    }

    public void CheckLines()
    {

        for (int i = height - 1; i >= 0; i--)
        {
            if (HasLine(i))
            {
                DeleteLine(i);
                Rowdown(i);

            }


        }

       


    }

    public bool HasLine(int i)
    {
        for (int j = 0; j < width; j++)
        {
            if (grid[j, i] == null)
            {
                return false;

            }

        }

        return true;


    }

    public void DeleteLine(int i)
    {
        for (int j = 0; j < width; j++)
        {
            Destroy(grid[j, i].gameObject);
            grid[j, i] = null;

        }


    }

    public void Rowdown(int i)
    {
        for(int y = i; y < width; y++)
        {
            for(int x = 0; x < width; x++)
            {
                if(grid[x, y] != null)
                {
                    grid[x, y - 1] = grid[x, y];
                    grid[x, y] = null;
                    grid[x, y -1].transform.position += Vector3.down;

                }

            }

        }


    }

}
