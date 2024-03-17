using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMove : MonoBehaviour
{
    private Rigidbody2D rb;
    private CircleCollider2D circleCollider;

    [Range(0f, 10f)]
    public float speed;
    [Range(0f, 1f)]
    public float bounciness;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        circleCollider = GetComponent<CircleCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(speed, rb.velocity.y);
        if (circleCollider.sharedMaterial.bounciness != bounciness)
        {
            PhysicsMaterial2D newMat = new PhysicsMaterial2D();
            newMat.bounciness = bounciness;
            circleCollider.sharedMaterial = newMat;
        }
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
