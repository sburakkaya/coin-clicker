using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("SceneChance", 2.5f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SceneChance() 
    {
        SceneManager.LoadScene("SampleScene");
    }
}
