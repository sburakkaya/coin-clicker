using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SocialPlatforms.Impl;
using Random = UnityEngine.Random;


public class Clicker : MonoBehaviour
{
    public Text ClicksTotalText;
    public Text AutoClcPerSec;

    public float TotalClicks;
    public int UpgradedClicker;
    public float ShowClick;
    public int ScoreYaz;


    public int hasUpgrade;
    public int autoClicksPerSecond;
    public int minimumClicksToUnlockUpgrade;
    public GameObject Isik;
    public GameObject ArtiBir;
    public float height;
    public GameObject welcomePopup;
    public Text welcomePopupSeconds;
    public Text rewardText;
    public float reward;


    public LeaderBoard leaderboard;
    public CoinAsset _coinAsset;

    public float noOfClicks = 0;
    public float noOfBarClicks = 1;
    float lastClickedTime = 0;
    float maxComboDelay = 0.9f;
    public Image barImage;
    public int comboCarpan = 1;
    public GameObject comboBar;

    
    public void AddClicks()
    {
        TotalClicks++;
        TotalClicks+=UpgradedClicker * comboCarpan;
        PlayerPrefs.SetFloat("totalClicks",TotalClicks);

        
        lastClickedTime = Time.time;
        noOfClicks+=0.02f;
        
        noOfClicks = Mathf.Clamp(noOfClicks, 0, 40);

        StartCoroutine(CoinPlus());

        Instantiate(ArtiBir,new Vector3(Random.Range(-height,height),Random.Range(-height,height),0),Quaternion.identity);
    }

    IEnumerator CoinPlus() 
    {

        ScoreYaz = Mathf.RoundToInt(TotalClicks);

        yield return new WaitForSeconds(20f);
        yield return leaderboard.SubmitScoreRoutine(ScoreYaz);
    }

    public void UpgradedClc()
    {
        UpgradedClicker++;
        PlayerPrefs.SetInt("upgradedClicker", UpgradedClicker);
    }

    public void Start()
    {
        TotalClicks = PlayerPrefs.GetFloat("totalClicks");
        UpgradedClicker = PlayerPrefs.GetInt("upgradedClicker");
        hasUpgrade = PlayerPrefs.GetInt("hasUpgrade");
        autoClicksPerSecond = PlayerPrefs.GetInt("autoClicksPerSecond");

        if (PlayerPrefs.HasKey("dateQuit"))
        {
            welcomePopupShow();
        }
        
        string dateQuitString = PlayerPrefs.GetString("dateQuit", "");
        if (!dateQuitString.Equals("")) 
        {
            DateTime dateQuit = DateTime.Parse(dateQuitString);
            DateTime dateNow = DateTime.Now;
            if(dateNow > dateQuit)
            {
                TimeSpan timespan = dateNow - dateQuit;
                int seconds = (int)timespan.TotalSeconds;
                if(timespan.TotalSeconds > 10800) 
                {
                    seconds = 10800;
                }
                if(seconds > 60) 
                {
                    int minutes = (int)timespan.TotalMinutes;
                    welcomePopupSeconds.text = "YOU WERE AWAY FOR\n" + minutes + " MINUTES";
                }
                else 
                {
                    welcomePopupSeconds.text = "YOU WERE AWAY FOR\n" + seconds + " SECONDS";
                }
                reward = seconds * autoClicksPerSecond;
                rewardText.text = "YOUR REWARD " + reward;
            }

            PlayerPrefs.SetString("dateQuit", "");
        }

    }

    public void OnApplicationPause()
    {
        
    }
    
    private void Update()
    {
        if (TotalClicks > 100000000)
        {
            ClicksTotalText.text = (TotalClicks / 1000).ToString("F")+"Qi";
        }
        else if (TotalClicks > 10000000)
        {
            ClicksTotalText.text = (TotalClicks / 1000).ToString("F")+"QA";
        }
        else if (TotalClicks > 1000000)
        {
            ClicksTotalText.text = (TotalClicks / 1000).ToString("F")+"T";
        }
        else if (TotalClicks > 100000)
        {
            ClicksTotalText.text = (TotalClicks / 1000).ToString("F")+"B";
        }else if (TotalClicks > 10000)
        {
            ClicksTotalText.text = (TotalClicks / 1000).ToString("F")+"M";
        }else if (TotalClicks > 1000)
        {
            ClicksTotalText.text = (TotalClicks / 1000).ToString("F")+"K";
        }else
        {
            ClicksTotalText.text = Mathf.RoundToInt(TotalClicks).ToString();
        }
        
        AutoClcPerSec.text = "Per Second : " + autoClicksPerSecond.ToString("0");
        
        ShowClick=1;
        ShowClick+=UpgradedClicker * comboCarpan;

        if(hasUpgrade == 1)
        {
            TotalClicks += autoClicksPerSecond * Time.deltaTime;
        }

        if (Time.time - lastClickedTime > maxComboDelay)
        {
            noOfClicks = 0;
            comboCarpan = 1;
            comboBar.SetActive(false);

        }
        if(noOfClicks > 0.9f) 
        {
            comboBar.SetActive(true);
        }
        if (noOfClicks > 1f)
        {
            comboCarpan = 2;
        }
        if (noOfClicks > 1.5f)
        {
            comboCarpan = 3;
        }
        if (noOfClicks > 1.9f)
        {
            comboCarpan = 4;
        }
        barImage.fillAmount = noOfClicks - noOfBarClicks;

        DateTime dateQuit = DateTime.Now;
        PlayerPrefs.SetString("dateQuit", dateQuit.ToString());
    }

    public void CoinBK()
    {
        StartCoroutine(_coinAsset.Animasyon());
    }

    public void OtoMatikBir()
    {
        hasUpgrade=1;
        PlayerPrefs.SetInt("hasUpgrade", hasUpgrade);

        autoClicksPerSecond++;
        PlayerPrefs.SetInt("autoClicksPerSecond", autoClicksPerSecond);
    }

    public void OtoMatikIki()
    {
        autoClicksPerSecond+=2;
        PlayerPrefs.SetInt("autoClicksPerSecond", autoClicksPerSecond);
    }

    public void OtoMatikUc()
    {
        autoClicksPerSecond+=3;
        PlayerPrefs.SetInt("autoClicksPerSecond", autoClicksPerSecond);
    }

    public void OtoMatikDort()
    {
        autoClicksPerSecond+=4;
        PlayerPrefs.SetInt("autoClicksPerSecond", autoClicksPerSecond);
    }

    public void OtoMatikBes()
    {
        autoClicksPerSecond+=5;
        PlayerPrefs.SetInt("autoClicksPerSecond", autoClicksPerSecond);
    }

    public void OtoMatikAlti()
    {
        autoClicksPerSecond+=6;
        PlayerPrefs.SetInt("autoClicksPerSecond", autoClicksPerSecond);
    }

    public void welcomePopupShow() 
    {
        welcomePopup.SetActive(true);
    }
    public void welcomePopupHide()
    {
        
        TotalClicks += reward;
        welcomePopup.SetActive(false);
    }

}