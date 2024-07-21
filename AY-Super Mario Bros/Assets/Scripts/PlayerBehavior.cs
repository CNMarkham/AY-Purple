using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{
    //The variables
    public SpriteRenderer smallRenderer;
    public SpriteRenderer bigRenderer;
    private Animator smallAnimator;
    public bool big;
    // Start is called before the first frame update
    private void Start()
    {
        // turning off or on small or big Mario
        smallAnimator = smallRenderer.gameObject.GetComponent<Animator>();
        big = false;

    }

    public void Hit()
    {
        //If hit by a enemy if Mario is big he shrinks and if small he dies
        if (big)
        {
            Shrink();
        }
        else
        {
            Death();
        }

    }

    private void Shrink()
    { // shrinking player
        smallRenderer.enabled = true;
        bigRenderer.enabled = false;

        GetComponent<CapsuleCollider2D>().size = Vector2.one;
        GetComponent<CapsuleCollider2D>().offset = Vector2.zero;

        big = false;
// calling Changesize which is a Coroutine
        StartCoroutine("Changesize");


    }

    public void Grow()
    { // growing player
        if (big)
        {
            return;
        }

        GetComponent<CapsuleCollider2D>().size = new Vector2(1f, 2f);
        GetComponent<CapsuleCollider2D>().offset = new Vector2(0, 0.5f);

        big = true;
        StartCoroutine("ChangeSize");


    }

    private void Death()
    {
        //killing player
        smallAnimator.SetTrigger("death");

        GetComponent<CapsuleCollider2D>().enabled = false;

        GetComponent<Rigidbody2D>().velocity = Vector2.up * 10;
        GetComponent<PlayerMovement>().enabled = false;
        Destroy(gameObject, 0.5f);

    }

    private IEnumerator ChangeSize()
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        Vector3 velocity = rb.velocity;
        GetComponent<PlayerMovement>().enabled = false;
        GetComponent<CapsuleCollider2D>().enabled = false;
        rb.isKinematic = true;
        rb.velocity = Vector3.zero;

        for(int i = 0; i < 8; i++)
        {
            bigRenderer.enabled ^= true;
            smallRenderer.enabled ^= true;
            yield return new WaitForSeconds(0.25f);
            rb.isKinematic = false;
            rb.velocity = velocity;
            GetComponent<PlayerMovement>().enabled = true;
            GetComponent<CapsuleCollider2D>().enabled = true;
        }

    }
}
