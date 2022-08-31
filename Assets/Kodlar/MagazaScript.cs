using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MagazaScript : MonoBehaviour
{
    public GameObject MagazaEkrani;
    public Clicker clicker;
    [SerializeField] private float ArtiBirFiyat;
    [SerializeField] private float OtoBirFiyat;
    [SerializeField] private float OtoIkiFiyat;
    [SerializeField] private float OtoUcFiyat;
    [SerializeField] private float OtoDortFiyat;
    [SerializeField] private float OtoBesFiyat;
    [SerializeField] private float OtoAltiFiyat;
    [SerializeField] private float OtoYediFiyat;
    public Text clickerElli;
    public Text OtoBirText;
    public Text OtoIkiText;
    public Text OtoUcText;
    public Text OtoDortText;
    public Text OtoBesText;
    public Text OtoAltiText;
    public Text OtoYediText;
    // Start is called before the first frame update
    void Start()
    {

        if (PlayerPrefs.HasKey("ArtiBirFiyat")) 
        {
            ArtiBirFiyat = PlayerPrefs.GetFloat("ArtiBirFiyat");
        }
        if (PlayerPrefs.HasKey("OtoBirFiyat"))
        {
            OtoBirFiyat = PlayerPrefs.GetFloat("OtoBirFiyat");
        }
        if (PlayerPrefs.HasKey("OtoIkiFiyat"))
        {
            OtoIkiFiyat = PlayerPrefs.GetFloat("OtoIkiFiyat");
        }
        if (PlayerPrefs.HasKey("OtoUcFiyat"))
        {
            OtoUcFiyat = PlayerPrefs.GetFloat("OtoUcFiyat");
        }
        if (PlayerPrefs.HasKey("OtoDortFiyat"))
        {
            OtoDortFiyat = PlayerPrefs.GetFloat("OtoDortFiyat");
        }
        if (PlayerPrefs.HasKey("OtoBesFiyat"))
        {
            OtoBesFiyat = PlayerPrefs.GetFloat("OtoBesFiyat");
        }
        if (PlayerPrefs.HasKey("OtoAltiFiyat"))
        {
            OtoAltiFiyat = PlayerPrefs.GetFloat("OtoAltiFiyat");
        }
        
        clickerElli.text = "Clicker : " + ArtiBirFiyat.ToString("F0");
        OtoBirText.text = "Pickaxe : " + OtoBirFiyat.ToString("F0") + "Cps : 1";
        OtoIkiText.text = "Shovel : " + OtoIkiFiyat.ToString("F0") + "Cps : 2";
        OtoUcText.text = "Hammer : " + OtoUcFiyat.ToString("F0") + "Cps : 3";
        OtoDortText.text = "Wheel : " + OtoDortFiyat.ToString("F0") + "Cps : 4";
        OtoBesText.text = "Dynamite : " + OtoBesFiyat.ToString("F0") + "Cps : 5";
        OtoAltiText.text = "Gold Astroid : " + OtoAltiFiyat.ToString("F0") + "Cps : 6";
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void MagazaAc()
    {
        MagazaEkrani.SetActive(true);
    }

    public void MagazaKapat()
    {
        MagazaEkrani.SetActive(false);
    }

    public void ClickerArtiBir()
    {
        if(clicker.TotalClicks>=ArtiBirFiyat)
        {
            clicker.TotalClicks-=ArtiBirFiyat;
            clicker.UpgradedClc();
            ArtiBirFiyat=ArtiBirFiyat+ArtiBirFiyat*30/100;
            PlayerPrefs.SetFloat("ArtiBirFiyat", ArtiBirFiyat);
            
            if (ArtiBirFiyat > 100000000)
            {
                clickerElli.text = "Clicker : " + (ArtiBirFiyat / 1000).ToString("F0") + "Qi" ;
            }
            else if (ArtiBirFiyat > 10000000)
            {
                clickerElli.text = "Clicker : " + (ArtiBirFiyat / 1000).ToString("F0") + "QA";
            }
            else if (ArtiBirFiyat > 1000000)
            {
                clickerElli.text = "Clicker : " + (ArtiBirFiyat / 1000).ToString("F0") + "T" ;
            }
            else if (ArtiBirFiyat > 100000)
            {
                clickerElli.text = "Clicker : " + (ArtiBirFiyat / 1000).ToString("F0") + "B" ;
            }else if (ArtiBirFiyat > 10000)
            {
                clickerElli.text = "Clicker : " + (ArtiBirFiyat / 1000).ToString("F0") + "M" ;
            }else if (ArtiBirFiyat > 1000)
            {
                clickerElli.text = "Clicker : " + (ArtiBirFiyat / 1000).ToString("F0") + "K" ;
            }else
            {
                clickerElli.text = "Clicker : " + ArtiBirFiyat.ToString("F0");
            }
        }
    }

    public void OtoClickerBir()
    {
        if(clicker.TotalClicks>=OtoBirFiyat)
        {
            clicker.TotalClicks-=OtoBirFiyat;
            clicker.OtoMatikBir();
            OtoBirFiyat=OtoBirFiyat+OtoBirFiyat*30/100;
            PlayerPrefs.SetFloat("OtoBirFiyat", OtoBirFiyat);
            
            if (OtoBirFiyat > 100000000)
            {
                OtoBirText.text = "Pickaxe : " + (OtoBirFiyat / 1000).ToString("F0") + "Qi"  + "  Cps : 1";
            }
            else if (OtoBirFiyat > 10000000)
            {
                OtoBirText.text = "Pickaxe : " + (OtoBirFiyat / 1000).ToString("F0") + "QA"  + "  Cps : 1";
            }
            else if (OtoBirFiyat > 1000000)
            {
                OtoBirText.text = "Pickaxe : " + (OtoBirFiyat / 1000).ToString("F0") + "T"  + "  Cps : 1";
            }
            else if (OtoBirFiyat > 100000)
            {
                OtoBirText.text = "Pickaxe : " + (OtoBirFiyat / 1000).ToString("F0") + "B"  + "  Cps : 1";
            }else if (OtoBirFiyat > 10000)
            {
                OtoBirText.text = "Pickaxe : " + (OtoBirFiyat / 1000).ToString("F0") + "M"  + "  Cps : 1";
            }else if (OtoBirFiyat > 1000)
            {
                OtoBirText.text = "Pickaxe : " + (OtoBirFiyat / 1000).ToString("F0") + "K"  + "  Cps : 1";
            }else
            {
                OtoBirText.text = "Pickaxe : " + OtoBirFiyat.ToString("F0")  + "  Cps : 1";
            }
        }
    }

    public void OtoClickerIki()
    {
        if(clicker.TotalClicks>=OtoIkiFiyat)
        {
            clicker.TotalClicks-=OtoIkiFiyat;
            clicker.OtoMatikIki();
            OtoIkiFiyat=OtoIkiFiyat+OtoIkiFiyat*30/100;
            PlayerPrefs.SetFloat("OtoIkiFiyat", OtoIkiFiyat);
            
            if (OtoIkiFiyat > 100000000)
            {
                OtoIkiText.text = "Shovel : " + (OtoIkiFiyat / 1000).ToString("F0") + "Qi" + "Cps : 2";
            }
            else if (OtoIkiFiyat > 10000000)
            {
                OtoIkiText.text = "Shovel : " + (OtoIkiFiyat / 1000).ToString("F0") + "QA" + "Cps : 2";
            }
            else if (OtoIkiFiyat > 1000000)
            {
                OtoIkiText.text = "Shovel : " + (OtoIkiFiyat / 1000).ToString("F0") + "T" + "Cps : 2";
            }
            else if (OtoIkiFiyat > 100000)
            {
                OtoIkiText.text = "Shovel : " + (OtoIkiFiyat / 1000).ToString("F0") + "B" + "Cps : 2";
            }else if (OtoIkiFiyat > 10000)
            {
                OtoIkiText.text = "Shovel : " + (OtoIkiFiyat / 1000).ToString("F0") + "M" + "Cps : 2";
            }else if (OtoIkiFiyat > 1000)
            {
                OtoIkiText.text = "Shovel : " + (OtoIkiFiyat / 1000).ToString("F0") + "K" + "Cps : 2";
            }else
            {
                OtoIkiText.text = "Shovel : " + OtoIkiFiyat.ToString("F0") + "Cps : 2";
            }
        }
    }

    public void OtoClickerUc()
    {
        if(clicker.TotalClicks>=OtoUcFiyat)
        {
            clicker.TotalClicks-=OtoUcFiyat;
            clicker.OtoMatikUc();
            OtoUcFiyat=OtoUcFiyat+OtoUcFiyat*30/100;
            PlayerPrefs.SetFloat("OtoUcFiyat", OtoUcFiyat);
            
            if (OtoUcFiyat > 100000000)
            {
                OtoUcText.text = "Hammer : " + (OtoUcFiyat / 1000).ToString("F0") + "Qi" + "Cps : 3";
            }
            else if (OtoUcFiyat > 10000000)
            {
                OtoUcText.text = "Hammer : " + (OtoUcFiyat / 1000).ToString("F0") + "QA" + "Cps : 3";
            }
            else if (OtoUcFiyat > 1000000)
            {
                OtoUcText.text = "Hammer : " + (OtoUcFiyat / 1000).ToString("F0") + "T" + "Cps : 3";
            }
            else if (OtoUcFiyat > 100000)
            {
                OtoUcText.text = "Hammer : " + (OtoUcFiyat / 1000).ToString("F0") + "B" + "Cps : 3";
            }else if (OtoUcFiyat > 10000)
            {
                OtoUcText.text = "Hammer : " + (OtoUcFiyat / 1000).ToString("F0") + "M" + "Cps : 3";
            }else if (OtoUcFiyat > 1000)
            {
                OtoUcText.text = "Hammer : " + (OtoUcFiyat / 1000).ToString("F0") + "K" + "Cps : 3";
            }else
            {
                OtoUcText.text = "Hammer : " + OtoUcFiyat.ToString("F0") + "Cps : 3";
            }
        }
    }

    public void OtoClickerDort()
    {
        if(clicker.TotalClicks>=OtoDortFiyat)
        {
            clicker.TotalClicks-=OtoDortFiyat;
            clicker.OtoMatikDort();
            OtoDortFiyat=OtoDortFiyat+OtoDortFiyat*30/100;
            PlayerPrefs.SetFloat("OtoDortFiyat", OtoDortFiyat);
            
            if (OtoDortFiyat > 100000000)
            {
                OtoDortText.text = "Wheel : " + (OtoDortFiyat / 1000).ToString("F0") + "Qi" + "Cps : 4";
            }
            else if (OtoDortFiyat > 10000000)
            {
                OtoDortText.text = "Wheel : " + (OtoDortFiyat / 1000).ToString("F0") + "QA"+ "Cps : 4";
            }
            else if (OtoDortFiyat > 1000000)
            {
                OtoDortText.text = "Wheel : " + (OtoDortFiyat / 1000).ToString("F0") + "T"+ "Cps : 4";
            }
            else if (OtoDortFiyat > 100000)
            {
                OtoDortText.text = "Wheel : " + (OtoDortFiyat / 1000).ToString("F0") + "B"+ "Cps : 4";
            }else if (OtoDortFiyat > 10000)
            {
                OtoDortText.text = "Wheel : " + (OtoDortFiyat / 1000).ToString("F0") + "M"+ "Cps : 4";
            }else if (OtoDortFiyat > 1000)
            {
                OtoDortText.text = "Wheel : " + (OtoDortFiyat / 1000).ToString("F0") + "K"+ "Cps : 4";
            }else
            {
                OtoDortText.text = "Wheel : " + OtoDortFiyat.ToString("F0")+ "Cps : 4";
            }
        }
    }

    public void OtoClickerBes()
    {
        if(clicker.TotalClicks>=OtoBesFiyat)
        {
            clicker.TotalClicks-=OtoBesFiyat;
            clicker.OtoMatikBes();
            OtoBesFiyat=OtoBesFiyat+OtoBesFiyat*30/100;
            PlayerPrefs.SetFloat("OtoBesFiyat", OtoBesFiyat);
            
            if (OtoBesFiyat > 100000000)
            {
                OtoBesText.text = "Dynamite : " + (OtoBesFiyat / 1000).ToString("F0") + "Qi"+ "Cps : 5";
            }
            else if (OtoBesFiyat > 10000000)
            {
                OtoBesText.text = "Dynamite : " + (OtoBesFiyat / 1000).ToString("F0") + "QA"+ "Cps : 5";
            }
            else if (OtoBesFiyat > 1000000)
            {
                OtoBesText.text = "Dynamite : " + (OtoBesFiyat / 1000).ToString("F0") + "T"+ "Cps : 5";
            }
            else if (OtoBesFiyat > 100000)
            {
                OtoBesText.text = "Dynamite : " + (OtoBesFiyat / 1000).ToString("F0") + "B"+ "Cps : 5";
            }else if (OtoBesFiyat > 10000)
            {
                OtoBesText.text = "Dynamite : " + (OtoBesFiyat / 1000).ToString("F0") + "M"+ "Cps : 5";
            }else if (OtoBesFiyat > 1000)
            {
                OtoBesText.text = "Dynamite : " + (OtoBesFiyat / 1000).ToString("F0") + "K"+ "Cps : 5";
            }else
            {
                OtoBesText.text = "Dynamite : " + OtoBesFiyat.ToString("F0")+ "Cps : 5";
            }
        }
    }

    public void OtoClickerAlti()
    {
        if(clicker.TotalClicks>=OtoAltiFiyat)
        {
            clicker.TotalClicks-=OtoAltiFiyat;
            clicker.OtoMatikAlti();
            OtoAltiFiyat=OtoAltiFiyat+OtoAltiFiyat*30/100;
            PlayerPrefs.SetFloat("OtoAltiFiyat", OtoAltiFiyat);
            
            if (OtoAltiFiyat > 100000000)
            {
                OtoAltiText.text = "Gold Astroid : " + (OtoAltiFiyat / 1000).ToString("F0") + "Qi"+ "Cps : 6";
            }
            else if (OtoAltiFiyat > 10000000)
            {
                OtoAltiText.text = "Gold Astroid : " + (OtoAltiFiyat / 1000).ToString("F0") + "QA"+ "Cps : 6";
            }
            else if (OtoAltiFiyat > 1000000)
            {
                OtoAltiText.text = "Gold Astroid : " + (OtoAltiFiyat / 1000).ToString("F0") + "T"+ "Cps : 6";
            }
            else if (OtoAltiFiyat > 100000)
            {
                OtoAltiText.text = "Gold Astroid : " + (OtoAltiFiyat / 1000).ToString("F0") + "B"+ "Cps : 6";
            }else if (OtoAltiFiyat > 10000)
            {
                OtoAltiText.text = "Gold Astroid : " + (OtoAltiFiyat / 1000).ToString("F0") + "M"+ "Cps : 6";
            }else if (OtoAltiFiyat > 1000)
            {
                OtoAltiText.text = "Gold Astroid : " + (OtoAltiFiyat / 1000).ToString("F0") + "K"+ "Cps : 6";
            }else
            {
                OtoAltiText.text = "Gold Astroid : " + OtoAltiFiyat.ToString("F0")+ "Cps : 6";
            }
        }
    }

  


}
