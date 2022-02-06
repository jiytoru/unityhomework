using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Transform[] spawner;
    public GameObject Points;
    // Start is called before the first frame update
    void Start()
    {
        SpawnObjects();
    }

   void SpawnObjects()
    {
        Instantiate(Points, spawner[0].transform.position, Quaternion.identity);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
