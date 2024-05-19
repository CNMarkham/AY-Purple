using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pellet : MonoBehaviour
{
    private void OnTriggerEnter(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Pacman"))
        {

            Eat();
        }
     
      
    }

    protected virtual void Eat()
    {

        gameObject.SetActive(false);
    }
}
