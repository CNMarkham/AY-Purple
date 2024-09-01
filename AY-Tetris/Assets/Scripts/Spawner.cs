using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] tetrominoes;
    // Start is called before the first frame update
    void Start()
    {
        SpawnTetromino();
    }

    public void SpawnTetromino()
    {
        int randNum = Random.Range(0, tetrominoes.Length);
        GameObject randomTetromino = tetrominoes[randNum];
        Instantiate(randomTetromino, transform.position, Quaternion.identity);


    }

    public void CheckLines()
    {
        for(int i =


    }

    public bool HasLine(int i)
    {


    }

    public void  DeleteLine(int i)
    {


    }

    public void Rowdown(int i)
    {


    }





}
