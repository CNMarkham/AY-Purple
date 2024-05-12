using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PacMan : Movement
{
   protected override void ChildUpdate()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Horizontal");

        if(horizontal != 0 || vertical != 0)
        {

            SetDirection(new Vector2(horizontal, vertical));
        }

        transform.right = direction;

    }

   
}
