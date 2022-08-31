using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class More : MonoBehaviour
{
    public GameObject MoreEkrani;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MoreAc()
    {
        MoreEkrani.SetActive(true);
    }

    public void MoreKapat()
    {
        MoreEkrani.SetActive(false);
    }
}
