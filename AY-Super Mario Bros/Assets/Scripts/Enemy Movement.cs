using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed = 2f;
    public Vector2 direction = Vector2.left;
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        // calling the enemies
        rb = GetComponent<Rigidbody2D>();

        OnBecameVisible();

    }
    // the enemies move only once seen

    private void OnBecameVisible()

    {
        rb.velocity = direction * speed;


    }

   
}
