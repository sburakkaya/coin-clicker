using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeWarp : MonoBehaviour
{
    public GameObject TimeEkrani;
    public bool Hiz;
    float countdownTo = 50.0F;
    public float time;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if (countdownTo < 2f)
        {
            Time.timeScale = 1;
        }

    }

    public void TimeAc()
    {
        TimeEkrani.SetActive(true);
    }

    public void TimeKapat()
    {
        TimeEkrani.SetActive(false);
    }


    public void HizlandiriciBaslat() 
    {
        StartCoroutine(HizlanArtik(time));

        Time.timeScale = 50;

        
    }

    public IEnumerator HizlanArtik(float time)
    {
        for (int i = 0; i < 50; i++)
        {
            countdownTo -= 1;
            yield return new WaitForSeconds(1f);
            Debug.Log(countdownTo);
        }
        countdownTo = 50;
    }


    }
