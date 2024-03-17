using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject ballPrefab;

    [Range(0.5f, 3f)]
    public float spawnRate;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("SpawnBall");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator SpawnBall()
    {
        Instantiate(ballPrefab, transform.position, Quaternion.identity);
        yield return new WaitForSeconds(spawnRate);
        StartCoroutine("SpawnBall");
    }
}
