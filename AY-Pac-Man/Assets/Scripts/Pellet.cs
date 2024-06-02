using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pellet : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Tag 0"))
        {

            Eat();
        }
     
      
    }

    protected virtual void Eat()
    {

        gameObject.SetActive(false);
    }
}
