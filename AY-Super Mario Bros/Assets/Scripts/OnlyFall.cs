using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnlyFall : MonoBehaviour
{
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 velocity = rb.velocity;
        velocity.y = Mathf.Min(velocity.y, 0);
        rb.velocity = velocity;

    }
}
