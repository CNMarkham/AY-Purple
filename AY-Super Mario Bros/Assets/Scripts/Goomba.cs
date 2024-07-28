using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goomba : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // seeing if Goomba is touching  the mario
        if (collision.gameObject.CompareTag("Player"))
        {
            // seeing if Mario is jumping on top of Goomba by comparing their y positions
            if(collision.transform.position.y > transform.position.y + 0.4f)
            {   // enemy death animation and remving itself (circle colider)
                GetComponent<Animator>().SetTrigger("death");
                GetComponent<CircleCollider2D>().enabled = false;
                GetComponent<EnemyMovement>().enabled = false;
                //player's little jump after jumping on Goomba
                Rigidbody2D playerRB = collision.gameObject.GetComponent<Rigidbody2D>();
                playerRB.velocity = new Vector2(playerRB.velocity.x, 10);
                //destroying Goomba
                Destroy(gameObject, 0.5f);
            }
            else
            {
                //calling hit method
                collision.gameObject.GetComponent<PlayerBehavior>().Hit();

            }
        }
    }

}
