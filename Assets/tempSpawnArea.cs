using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tempSpawnArea : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject thingToSpawn;
    public int amountToSpawn;
    public float spawnRadius;
    Vector3 whereToSpawn;
    public float variationSize;

    void Start()
    {
        for (int i = 0; i < amountToSpawn; i++)
        {
            whereToSpawn = Random.insideUnitSphere * spawnRadius;
            var t = Instantiate(thingToSpawn, whereToSpawn, Quaternion.identity);
            t.transform.parent = transform;
            float size = Random.Range(1, variationSize);
            t.transform.localScale = Vector3.Scale(t.transform.localScale, new Vector3(size, size, size));

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
