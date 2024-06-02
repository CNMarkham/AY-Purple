using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    public LayerMask obstacleLayer;
    public List<Vector2> availableDirections;

    // Start is called before the first frame update
    void Start()
    {
        availableDirections = new List<Vector2>();

        CheckAvailableDirections(Vector2.up);
        CheckAvailableDirections(Vector2.down);
        CheckAvailableDirections(Vector2.left);
        CheckAvailableDirections(Vector2.right);
     }

    private void CheckAvailableDirections(Vector2 newDirection)
    {
        RaycastHit2D hit = Physics2D.BoxCast(transform.position, Vector2.one * 0.75f, 0f, newDirection, 2f, obstacleLayer);

        if(hit.collider == null)
        {
            availableDirections.Add(newDirection);
        }
    }

   
}
