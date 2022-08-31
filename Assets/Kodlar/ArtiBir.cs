using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArtiBir : MonoBehaviour
{
     public float speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void FixedUpdate()
    {
        transform.position += Vector3.up * speed * Time.deltaTime;

        //Destroy(gameObject)
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
