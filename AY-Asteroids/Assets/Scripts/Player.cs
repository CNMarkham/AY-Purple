using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PL : MonoBehaviour

{
    public float lookspeed;
    public float moveSpeed;
    public float maxspeed;
    private Rigidbody2D rb;
    public GameObject bulletPrefab;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {

            Vector3 velcoity = rb.velocity;
            velcoity = velcoity + transform.right * Time.deltaTime * moveSpeed;
            Vector3.ClampMagnitude(velcoity, maxspeed);
            rb.velocity = velcoity;
        }
       
        
        
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Rotate(Vector3.forward * Time.deltaTime* lookspeed );

        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Rotate(Vector3.back * Time.deltaTime * lookspeed);

        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(bulletPrefab, transform.position, transform.rotation);

        }

    }
}
