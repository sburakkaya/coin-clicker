using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinAsset : MonoBehaviour
{
    public Animator kontrol;
    // Start is called before the first frame update
    void Start()
    {
        kontrol = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator Animasyon()
    {
            //kontrol.SetTrigger("KucultBuyut");
            bool clicked = true;
            kontrol.SetBool("Clicked",clicked);
            yield return new WaitForSeconds(0.2f);
            clicked = false;
            kontrol.SetBool("Clicked",clicked);

    }
}
