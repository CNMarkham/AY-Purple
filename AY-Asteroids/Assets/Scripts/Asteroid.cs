using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    public float minSize;
    public float speed;
    // Start is called before the first frame update
    void Start()
    
    {
        GetComponent<Rigidbody2D>().velocity = Random.insideUnitCircle * speed;

        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(collision.gameObject);
        if(transform.localScale.x> minSize)
        {
            transform.localScale = transform.localScale * 0.5f;
            Instantiate(gameObject, transform.position, Quaternion.identity);

        }
        else
        {

            Destroy(gameObject);
        }
        
    }


}
