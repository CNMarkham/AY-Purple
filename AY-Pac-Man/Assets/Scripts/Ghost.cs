using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : Movement
{
    public GameObject body;
    public GameObject eyes;
    public GameObject blue;
    public GameObject white;
    public bool atHome;
    public float homeDuration;
    private bool frightened;

    private void Awake()
    {
        
    }

    protected override void ChildUpdate()
    {
        
    }

    private void OnCollisionEnter2D( Collision2D collision)
    {

        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Node node = collision.GetComponent<Node>();

        if(node != null)
        {
            int index = Random.Range(0, node.availableDirections.Count);

            SetDirection(node.availableDirections[index]);
        }
    }

    private void LeaveHome()
    {

    }

    public void Frighten()
    {

    }

    private void Flash()
    {

    }

    private void Reset()
    {
        
    }

   
}
