using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{
    public GameObject audioSource;
    public GameObject audioSource2;
    public Sprite _sounOnSprite;
    public Sprite _sounOffSprite;
    bool muted;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }
   

    public void MenuMusicVolume()
    {
        muted = !muted;
        PlayerPrefs.SetInt("muted", muted ? 1 : 0);

        muted = PlayerPrefs.GetInt("muted") == 1 ? true : false;

        if (muted)
        {
            audioSource.SetActive(false);
            audioSource2.SetActive(false);
            gameObject.GetComponent<Image>().sprite = _sounOffSprite;
        }
        else if (!muted)
        {
            audioSource.SetActive(true);
            audioSource2.SetActive(true);
            gameObject.GetComponent<Image>().sprite = _sounOnSprite;
        }
    }
}
