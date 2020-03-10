using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class temp : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(Random.Range(0, 0.1f), Random.Range(0, 0.1f), Random.Range(0, 0.1f))) ;
    }
}
