using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Artislar : MonoBehaviour
{
    public float speed;
    public TextMeshPro score;
    public Clicker clicker;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        score.text = "+" + clicker.ShowClick.ToString();
        transform.position += Vector3.up * speed * Time.deltaTime;
    }
}
