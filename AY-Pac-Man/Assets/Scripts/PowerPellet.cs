using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerPellet : Pellet
{
    protected override void Eat()
    {

        base.Eat();

        GameObject[] ghosts = GameObject.FindGameObjectsWithTag("Tag 1");

        foreach (GameObject ghost in ghosts)
        {


        }
    }
}
   