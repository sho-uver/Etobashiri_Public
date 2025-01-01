using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using PlayFab;
using PlayFab.ClientModels;
public class Saisen : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Text>().text = "金" + PlayerPrefs.GetInt("Saisen",0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
