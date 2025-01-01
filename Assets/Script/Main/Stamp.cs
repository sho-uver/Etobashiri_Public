using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Stamp : MonoBehaviour
{
    public GameObject invisible;
    public GameObject stamp;
    public string name;
    public string startName;
    public Text text;
    public GameObject invisibleText;
    public GameObject visibleText;
    // Start is called before the first frame update
    void Start()
    {
        startName = name;
        name += "春夏秋冬並木";
        Display();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnEnable()
    {
        Display();
    }

    public void Display()
    {
        
        /*
        switch(SceneManager.GetActiveScene().name)
        {
            case "Nonbirisogen":
                name += "のんびり草原";
                break;

            case "Mugen":
                name += "春夏秋冬並木";
                break;

            case "Togenkyosekiranun":
                name += "桃源郷積乱雲";
                break;
        }
        */

        if(PlayerPrefs.GetInt(name,0) == 1)
        {
            invisible.SetActive(false);
            invisibleText.SetActive(false);
            visibleText.SetActive(true);

            /*
            switch(name)
            {
                case "猪春夏秋冬並木":
                    break;
                case "犬春夏秋冬並木":
                    break;
                case "鳥春夏秋冬並木":
                    break;
                case "猿春夏秋冬並木":
                    break;
                case "羊春夏秋冬並木":
                    break;
                case "馬春夏秋冬並木":
                    break;
                case "蛇春夏秋冬並木":
                    break;
                case "龍春夏秋冬並木":
                    break;
                case "兎春夏秋冬並木":
                    break;
                case "虎春夏秋冬並木":
                    break;
                case "牛春夏秋冬並木":
                    break;
                case "鼠春夏秋冬並木":
                    break;
            }
            */
        }
        else
        {
            invisibleText.SetActive(true);
            visibleText.SetActive(false);
        }
    }
}
