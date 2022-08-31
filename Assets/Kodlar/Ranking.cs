using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ranking : MonoBehaviour
{
    public GameObject RankingEkrani;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RankAc()
    {
        RankingEkrani.SetActive(true);
    }

    public void RankKapa()
    {
        RankingEkrani.SetActive(false);
    }

}
