using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2 : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        float x = transform.position.x;
        float y = Camera.main.ScreenToWorldPoint(Input.mousePosition).y;
        Vector2 tempPosition = new Vector2(x,y);
        transform.position = tempPosition;
        
    }
}
