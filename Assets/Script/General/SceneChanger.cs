using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Advertisements;
using System;

public class SceneChanger : MonoBehaviour
{
    public static SceneChanger instance;
    public DateTime recoverStartTime;
    public GameObject blackCanvas;
    public string name;
    public bool changeSceneFlg;
    public float time;
    // Start is called before the first frame update
    public void Awake()
    {
        // instance = this;
        /*
        if(instance == null)
        {
            instance = this;
        }
        else if(instance != this)
        {
            Destroy(instance);
            instance = this;
        }
        */
        // DontDestroyOnLoad(gameObject);

    }

    void Start()
    {
        if(SceneManager.GetActiveScene().name == "Start"){return;}
        blackCanvas = GameObject.FindWithTag("BlackCanvas");
        BlackCanvasStart(); // check
        
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if(!changeSceneFlg)
        {
            return;
        }
        time += Time.deltaTime;
        if(time > 9f)
        {
            changeSceneFlg = false;
            time = 0;
            ChangeScene();
        }
        */
    }
    
    public void BlackCanvasStart()
    {
        blackCanvas = GameObject.FindWithTag("BlackCanvas"); 
        blackCanvas.GetComponent<BlackCanvas>().StartFlgTrue(); // check
        // Debug.Log("BlackCanvasStart");
    }
    public void BlackCanvasEnd()
    {
        // blackCanvas = GameObject.FindWithTag("BlackCanvas");
        blackCanvas.SetActive(true);
        blackCanvas.GetComponent<BlackCanvas>().EndFlgTrue();
    }

    IEnumerator ChangeScene()
    {
        // Time.timeScale = 1f;
        if(SceneManager.GetActiveScene().name != "Start")
        {
            BlackCanvasEnd(); // check
            yield return new WaitForSecondsRealtime(0.21f);
        }
        
        SceneManager.LoadScene(name);
        // Debug.Log("changeScene");
    }

    public void ChangeScene2()
    {
        SceneManager.LoadScene(name);
    }

/*
    public void ChangeScene()
    {
        // BlackCanvasEnd();
        // yield return new WaitForSecondsRealtime(0.5f);
        SceneManager.LoadScene(name);
    }
*/

    public void ChangeTitle()
    {
        /*
        Time.timeScale = 1f;
        SceneManager.LoadScene("Title");
        */
        name = "Title";
        StartCoroutine(ChangeScene());
    }

    public void ChangeMenu()
    {
        /*
        Time.timeScale = 1f;
        BlackCanvasEnd();
        // StartCoroutine(ChangeScene("Menu"));
        name = "Menu";
        changeSceneFlg = true;
        // SceneManager.LoadScene("Menu");
        */
        name = "Menu";
        StartCoroutine(ChangeScene());
        // ChangeScene2();
    }

    public void ChangeMain()
    {
        /*
        Time.timeScale = 1f;
        Advertisement.Banner.Hide();
        SceneManager.LoadScene("Main");
        */
        name = "Main";
        StartCoroutine(ChangeScene());
    }

    public void ChangeUpbringing()
    {
        name = "Upbringing";
        StartCoroutine(ChangeScene());
    }

    public void ChangeManekiya()
    {
        name = "Manekiya";
        StartCoroutine(ChangeScene());
    }

    public void ChangeTrickMenu()
    {
        /*
        BlackCanvasEnd();
        Time.timeScale = 1f;
        SceneManager.LoadScene("TrickMenu");
        */
        name = "TrickMenu";
        StartCoroutine(ChangeScene());
    }

    public void ChangeMugen()
    {
        name = "Mugen";
        StartCoroutine(ChangeScene());
        // ChangeScene2();
    }

    public void ChangeNonbirisogen()
    {
        name = "Nonbirisogen";
        StartCoroutine(ChangeScene());
        // ChangeScene2();
    }

    public void ChangeTogenkyosekiranun()
    {
        name = "Togenkyosekiranun";
        StartCoroutine(ChangeScene());
        // ChangeScene2();
    }

    public void ChangeTrick1_1()
    {
        // Time.timeScale = 1f;
        // BlackCanvasEnd();
        name = "Trick1_1";
        // changeSceneFlg = true;
        StartCoroutine(ChangeScene());
        // SceneManager.LoadScene("Trick1_1");
    }

    public void ChangeTrick1_2()
    {
        /*
        Time.timeScale = 1f;
        SceneManager.LoadScene("Trick1_2");
        */
        name = "Trick1_2";
        StartCoroutine(ChangeScene());
    }

    public void ChangeTrick1_3()
    {
        /*
        Time.timeScale = 1f;
        SceneManager.LoadScene("Trick1_3");
        */
        name = "Trick1_3";
        StartCoroutine(ChangeScene());
    }

    public void ChangeTrick2_1()
    {
        /*
        Time.timeScale = 1f;
        SceneManager.LoadScene("Trick2_1");
        */
        name = "Trick2_1";
        StartCoroutine(ChangeScene());
    }

    public void ChangeTrick2_2()
    {
        /*
        Time.timeScale = 1f;
        SceneManager.LoadScene("Trick2_2");
        */
        name = "Trick2_2";
        StartCoroutine(ChangeScene());
    }

    public void ChangeTrick2_3()
    {
        /*
        Time.timeScale = 1f;
        SceneManager.LoadScene("Trick2_3");
        */
        name = "Trick2_3";
        StartCoroutine(ChangeScene());
    }

    public void ChangeTrick3_1()
    {
        /*
        Time.timeScale = 1f;
        SceneManager.LoadScene("Trick3_1");
        */
        name = "Trick3_1";
        StartCoroutine(ChangeScene());
    }

    public void ChangeTrick3_2()
    {
        /*
        Time.timeScale = 1f;
        SceneManager.LoadScene("Trick3_2");
        */
        name = "Trick3_2";
        StartCoroutine(ChangeScene());
    }

    public void ChangeTrick3_3()
    {
        /*
        Time.timeScale = 1f;
        SceneManager.LoadScene("Trick3_3");
        */
        name = "Trick3_3";
        StartCoroutine(ChangeScene());
    }
}
