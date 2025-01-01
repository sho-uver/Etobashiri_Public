using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;
using System.IO;

public class MenuSystem : MonoBehaviour
{
    const string STATISTICS_NAME = "Mugen_ver2.1";
    public static MenuSystem instance;
    public GameObject rankingCanvas;
    public Slider levelSlider;
    public int currentLevelPoint;
    public int nextLevelPoint;
    public int level;
    public int playerprefsLevelPoint;
    public Text stageNameText;
    public Text highScoreText;
    public Text playCount;
    public Text levelText;
    public Text jokyoText;
    public Text moneyText;
    public string stageName;
    public Slider tokuSlider;
    public int stageChangeNo;
    public SceneChanger sceneChanger;
    public int levelPointMainus;
    public int levelPointTotal;
    public int altLevel;
    public int jokyoPoint;
    public GameObject nonbiriGate;
    public GameObject shunkashutoGate;
    public GameObject togenkyoGate;
    public GameObject shrineCanvas;
    public GameObject stampCanvas;
    public SnapbarManager snapbarManager;
    public Sprite omikujiImage;
    public String message;
    public Sprite enImage;
    public GameObject shrineUnacquired2;
    public GameObject shrineUnacquired3;
    public GameObject shrineUnacquired4;
    public GameObject shrineUnacquired5;
    public GameObject shrineUnacquired6;
    public GameObject shrineUnacquired7;
    public GameObject shrineUnacquired8;
    public GameObject shrineUnacquired9;
    public GameObject shrineUnacquired10;
    public GameObject shrineButton2;
    public GameObject shrineButton3;
    public GameObject shrineButton4;
    public GameObject shrineButton5;
    public GameObject shrineButton6;
    public GameObject shrineButton7;
    public GameObject shrineButton8;
    public GameObject shrineButton9;
    public GameObject shrineButton10;
    public LoginBonus loginBonus;
    public int beforeLevel;
    public int afterLevel;
    public Sprite satoruImage;
    public Sprite bonnoImage;


    // Start is called before the first frame update
    void Start()
    {
                        // PlayerPrefs.SetInt("MugenToku", 171166499);
                        // PlayerPrefs.SetInt("Money", 10000);
        instance = this;
        Application.targetFrameRate = 60; 
        /*
        level = 1;
        nextLevelPoint = 2;
        currentLevelPoint = PlayerPrefs.GetInt("Level",0);
        playerprefsLevelPoint = PlayerPrefs.GetInt("Level",0);
        UpdateLevel(0);
        */
        // Login();
        beforeLevel = PlayerPrefs.GetInt("MugenLevel", 108);
        if(PlayerPrefs.GetInt(STATISTICS_NAME, 0) > PlayerPrefs.GetInt(STATISTICS_NAME, 0))
        {
            PlayerPrefs.SetInt(STATISTICS_NAME, PlayerPrefs.GetInt(STATISTICS_NAME, 0));
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /*
    public void ChangeSkillToMure()
    {
        PlayerPrefs.SetString("Skill", "Mure");
    }

    public void ChangeSkillToHogeki()
    {
        PlayerPrefs.SetString("Skill", "Hogeki");
    }

    public void ChangeSkillToChototsumoshin()
    {
        PlayerPrefs.SetString("Skill", "Chototsumoshin");
    }
    

    public void RankingOpen()
    {
        rankingCanvas.SetActive(true);
        GetComponent<Login>().SubmitScore(PlayerPrefs.GetInt("HighScore", 0));
        GetComponent<Login>().RequestLeaderBoard();

    }

    public void RankingClose()
    {
        rankingCanvas.SetActive(false);
    }
    */

    public void Login()
    {
        ChangeStageInfo();
        if(PlayerPrefs.GetString("OmikujiDay","") != DateTime.Today.ToString("d"))
        {
            message = "ご縁神社で\n今日のおみくじが引けます。";
            snapbarManager.ShowSnapbar(message, omikujiImage, 3);
        }
        loginBonus.CheckLogin();
    }

    public void UpdateLevel(int num)
    {
        currentLevelPoint += num;
        playerprefsLevelPoint += num;
        PlayerPrefs.SetInt("Level",playerprefsLevelPoint);
        while(currentLevelPoint >= nextLevelPoint)
        {
            nextLevelPoint = level + level * level;
            currentLevelPoint -= nextLevelPoint;
            level++;
        }
        levelText.text = "段：" + level;
        levelSlider.value = (float)currentLevelPoint / (float)nextLevelPoint;
        /*
        Debug.Log(levelSlider.value);
        Debug.Log(currentLevelPoint / nextLevelPoint);
        Debug.Log(currentLevelPoint);
        Debug.Log(nextLevelPoint);
        */
    }

    public void StageChangeNoPlus()
    {
        stageChangeNo++;
        if(stageChangeNo == 4)
        {
            stageChangeNo = 1;
        }
        ChangeStageInfo();
    }

    public void StageChangeNoMainus()
    {
        stageChangeNo--;
        if(stageChangeNo == 0)
        {
            stageChangeNo = 3;
        }
        ChangeStageInfo();
    }

    public void ChangeStageInfo()
    {

        switch(stageChangeNo)
        {
            case 1:
                stageNameText.text = "のんびり草原";
                highScoreText.text = "最高徳：" + PlayerPrefs.GetInt("NonbirisogenHighScore", 0);
                
                levelPointTotal = PlayerPrefs.GetInt("NonbirisogenToku", 0);
                nonbiriGate.SetActive(true);
                shunkashutoGate.SetActive(false);
                togenkyoGate.SetActive(false);
                break;

            case 2:
                // stageNameText.text = "春夏秋冬並木";
                // playCount.text = "遊んだ回数：" + PlayerPrefs.GetInt("PlayCount", 0) + "回";
                moneyText.text = "所持縁：" + PlayerPrefs.GetInt("Money", 0);
                
                highScoreText.text = "最高徳：" + PlayerPrefs.GetInt(STATISTICS_NAME, 0);
                levelPointTotal = PlayerPrefs.GetInt("MugenToku", 0);

                nonbiriGate.SetActive(false);
                shunkashutoGate.SetActive(true);
                togenkyoGate.SetActive(false);
                break;

            case 3:
                stageNameText.text = "桃源郷積乱雲";    
                highScoreText.text = "最高徳：" + PlayerPrefs.GetInt("TogenkyosekiranunHighScore", 0);
                levelPointTotal = PlayerPrefs.GetInt("TogenkyosekiranunToku", 0);
                nonbiriGate.SetActive(false);
                shunkashutoGate.SetActive(false);
                togenkyoGate.SetActive(true);
                break;
        }

        for(int i = 0;i < 109; i++)
        {
            /*
            if(i < 25)
            {
                levelPointMainus = 100 * (i + 1);
            }
            if(i >= 25 && i < 50)
            {
                levelPointMainus = 200 * (i + 1);
            }
            if(i >= 50 && i < 75)
            {
                levelPointMainus = 500 * (i + 1);
            }
            if(i >= 75 && i < 101)
            {
                levelPointMainus = 1000 * (i + 1);
            }
            if(i >= 101 && i < 108)
            {
                levelPointMainus = 10000 * (i + 1);
            }
            */
            if(i < 10)
            {
                levelPointMainus = 100 * (i + 1);
            }
            if(i >= 10 && i < 20)
            {
                levelPointMainus = 200 * (i + 1);
            }
            if(i >= 20 && i < 30)
            {
                levelPointMainus = 400 * (i + 1);
            }
            if(i >= 30 && i < 40)
            {
                levelPointMainus = 800 * (i + 1);
            }
            if(i >= 40 && i < 50)
            {
                levelPointMainus = 1600 * (i + 1);
            }
            if(i >= 50 && i < 60)
            {
                levelPointMainus = 3200 * (i + 1);
            }
            if(i >= 60 && i < 70)
            {
                levelPointMainus = 6400 * (i + 1);
            }
            if(i >= 70 && i < 80)
            {
                levelPointMainus = 12800 * (i + 1);
            }
            if(i >= 80 && i < 90)
            {
                levelPointMainus = 25600 * (i + 1);
            }
            if(i >= 90 && i < 100)
            {
                levelPointMainus = 51200 * (i + 1);
            }
            if(i >= 100 && i < 108)
            {
                levelPointMainus = 100000 * (i + 1);
            }
            if(i == 108)
            {
                switch(stageChangeNo)
                {
                    case 1:
                        PlayerPrefs.SetInt("NonbirisogenLevel", i);
                        break;

                    case 2:
                        PlayerPrefs.SetInt("ShunkashutonamikiLevel", i);
                        break;

                    case 3:
                        PlayerPrefs.SetInt("TogenkyosekiranunLevel", i);
                        break;
                }
                altLevel = 108 -i;
                levelText.text = "残煩悩：" + altLevel;
                jokyoPoint = levelPointMainus - levelPointTotal;
                jokyoText.text = "解脱";
                tokuSlider.maxValue = 1;
                tokuSlider.value = 1;   
                break;
            }
            if(levelPointTotal >= levelPointMainus)
            {
                levelPointTotal -= levelPointMainus;
            }
            else
            {
                switch(stageChangeNo)
                {
                    case 1:
                        PlayerPrefs.SetInt("NonbirisogenLevel", i);
                        break;

                    case 2:
                        PlayerPrefs.SetInt("ShunkashutonamikiLevel", i);
                        break;

                    case 3:
                        PlayerPrefs.SetInt("TogenkyosekiranunLevel", i);
                        break;
                }
                altLevel = 108 -i;
                levelText.text = "残煩悩：" + altLevel;
                jokyoPoint = levelPointMainus - levelPointTotal;
                jokyoText.text = "次の克服まで："　+ jokyoPoint + "徳";
                tokuSlider.maxValue = levelPointMainus;
                tokuSlider.value = levelPointTotal;
                break;
            }
        }
        PlayerPrefs.SetInt("MugenLevel", altLevel);
        LevelUp();
    }

    public void GoStage()
    {
        switch(stageChangeNo)
        {
            case 1:
                sceneChanger.ChangeNonbirisogen();
                break;

            case 2:
                sceneChanger.ChangeMugen();
                break;

            case 3:
                sceneChanger.ChangeTogenkyosekiranun();
                break;
        }
        
    }

    public void LevelUp()
    {
        afterLevel = PlayerPrefs.GetInt("MugenLevel", 108);
        // Debug.Log(beforeLevel);
        // Debug.Log(afterLevel);
        if(beforeLevel == 0)
        {
            return;
        }
        if(beforeLevel == afterLevel)
        {
            return;
        }
        if(afterLevel == 0)
        {
            message = "解脱完了、おめでとう！\n「悟」のご朱印獲得しました。";
            snapbarManager.ShowSnapbar(message, satoruImage, 3);
            PlayerPrefs.SetInt("MugenLevel", afterLevel);
            PlayerPrefs.SetInt("悟春夏秋冬並木", 1);
            beforeLevel = afterLevel;
        }
        else
        {
            message = "煩悩克服!\n" + "残りの煩悩" + beforeLevel + "→" + afterLevel;
            snapbarManager.ShowSnapbar(message, bonnoImage, 3);
            PlayerPrefs.SetInt("MugenLevel", afterLevel);
            beforeLevel = afterLevel;
        }
        
    }

    /*
    public void DisplayStageInfoNonbirisogen()
    {
        stageNameText.text = "のんびり草原";
        int levelPointMainusNonbirisogen = 0;
        int levelPointTotalNonbirisogen = PlayerPrefs.GetInt("NonbirisogenToku", 0);
        for(int i = 0;i < 109; i++)
        {
            if(i < 25)
            {
                levelPointMainusNonbirisogen = 100 * (i + 1);
            }
            if(i >= 25 && i < 50)
            {
                levelPointMainusNonbirisogen = 200 * (i + 1);
            }
            if(i >= 50 && i < 75)
            {
                levelPointMainusNonbirisogen = 500 * (i + 1);
            }
            if(i >= 75 && i < 101)
            {
                levelPointMainusNonbirisogen = 1000 * (i + 1);
            }
            if(i >= 101 && i < 109)
            {
                levelPointMainusNonbirisogen = 10000 * (i + 1);
            }
            if(levelPointTotalNonbirisogen >= levelPointMainusNonbirisogen)
            {
                levelPointTotalNonbirisogen -= levelPointMainusNonbirisogen;
            }
            else
            {
                highScoreText.text = "最高：" + PlayerPrefs.GetInt("NonbirisogenHighScore", 0);
                int level = 108 -i;
                levelText.text = "残煩悩：" + level;
                int jokyoPoint = levelPointMainusNonbirisogen - levelPointTotalNonbirisogen;
                jokyoText.text = "次の厄徐まで："　+ jokyoPoint + "徳";
                tokuSlider.maxValue = levelPointMainus;
                tokuSlider.value = levelPointTotal;
                PlayerPrefs.SetInt("NonbirisogenLevel", i);
                break;
            }
        }
    }

    public void DisplayStageInfoShunkashuntonamiki()
    {
        stageNameText.text = "のんびり草原";
        int levelPointMainusNonbirisogen = 0;
        int levelPointTotalNonbirisogen = PlayerPrefs.GetInt("NonbirisogenToku", 0);
        for(int i = 0;i < 109; i++)
        {
            if(i < 25)
            {
                levelPointMainusNonbirisogen = 100 * (i + 1);
            }
            if(i >= 25 && i < 50)
            {
                levelPointMainusNonbirisogen = 200 * (i + 1);
            }
            if(i >= 50 && i < 75)
            {
                levelPointMainusNonbirisogen = 500 * (i + 1);
            }
            if(i >= 75 && i < 101)
            {
                levelPointMainusNonbirisogen = 1000 * (i + 1);
            }
            if(i >= 101 && i < 109)
            {
                levelPointMainusNonbirisogen = 10000 * (i + 1);
            }
            if(levelPointTotalNonbirisogen >= levelPointMainusNonbirisogen)
            {
                levelPointTotalNonbirisogen -= levelPointMainusNonbirisogen;
            }
            else
            {
                highScoreText.text = "最高徳：" + PlayerPrefs.GetInt("NonbirisogenHighScore", 0);
                int level = 108 -i;
                levelText.text = "残煩悩：" + level;
                int jokyoPoint = levelPointMainusNonbirisogen - levelPointTotalNonbirisogen;
                jokyoText.text = "次の厄徐まで："　+ jokyoPoint + "徳";
                tokuSlider.value = levelPointTotalNonbirisogen / levelPointMainusNonbirisogen;
                PlayerPrefs.SetInt("NonbirisogenLevel", i);
                break;
            }
        }
    }
    */

    public void DisplayStageInfoTogenkyosekiranun()
    {

    }

    public void OpenShrine()
    {
        shrineCanvas.SetActive(true);
        playCount.text = "遊んだ回数：" + PlayerPrefs.GetInt("PlayCount", 0) + "回";
        if(3 <= PlayerPrefs.GetInt("PlayCount", 0))
        {
            shrineButton2.SetActive(true);
            shrineUnacquired2.SetActive(false);
        }
        if(6 <= PlayerPrefs.GetInt("PlayCount", 0))
        {
            shrineButton3.SetActive(true);
            shrineUnacquired3.SetActive(false);
        }
        if(10 <= PlayerPrefs.GetInt("PlayCount", 0))
        {
            shrineButton4.SetActive(true);
            shrineUnacquired4.SetActive(false);
        }
        if(15 <= PlayerPrefs.GetInt("PlayCount", 0))
        {
            shrineButton5.SetActive(true);
            shrineUnacquired5.SetActive(false);
        }
        if(21 <= PlayerPrefs.GetInt("PlayCount", 0))
        {
            shrineButton6.SetActive(true);
            shrineUnacquired6.SetActive(false);
        }
        if(28 <= PlayerPrefs.GetInt("PlayCount", 0))
        {
            shrineButton7.SetActive(true);
            shrineUnacquired7.SetActive(false);
        }
        if(36 <= PlayerPrefs.GetInt("PlayCount", 0))
        {
            shrineButton8.SetActive(true);
            shrineUnacquired8.SetActive(false);
        }
        if(45 <= PlayerPrefs.GetInt("PlayCount", 0))
        {
            shrineButton9.SetActive(true);
            shrineUnacquired9.SetActive(false);
        }
        if(55 <= PlayerPrefs.GetInt("PlayCount", 0))
        {
            shrineButton10.SetActive(true);
            shrineUnacquired10.SetActive(false);
        }
    }

    public void CloseShrine()
    {
        shrineCanvas.SetActive(false);
    }
    
    public void OpenStamp()
    {
        stampCanvas.SetActive(true);
    }

    public void CloseStamp()
    {
        stampCanvas.SetActive(false);
    }

    public void GoenShrine1()
    {
        int cost = 1000;
        if(cost > PlayerPrefs.GetInt("Money", 0))
        {
            message = "縁が足りません。";
            snapbarManager.ShowSnapbar(message, enImage, 3);
            return;
        }
        PlayerPrefs.SetInt("MugenToku", PlayerPrefs.GetInt("MugenToku", 0) + cost * 1);
        PlayerPrefs.SetInt("Money", PlayerPrefs.GetInt("Money", 0) - cost);
        ChangeStageInfo();
    }

    public void GoenShrine2()
    {
        int cost = 2000;
        if(cost > PlayerPrefs.GetInt("Money", 0))
        {
            message = "縁が足りません。";
            snapbarManager.ShowSnapbar(message, enImage, 3);
            return;
        }
        PlayerPrefs.SetInt("MugenToku", PlayerPrefs.GetInt("MugenToku", 0) + cost * 2);
        PlayerPrefs.SetInt("Money", PlayerPrefs.GetInt("Money", 0) - cost);
        ChangeStageInfo();
    }

    public void GoenShrine3()
    {
        int cost = 3000;
        if(cost > PlayerPrefs.GetInt("Money", 0))
        {
            message = "縁が足りません。";
            snapbarManager.ShowSnapbar(message, enImage, 3);
            return;
        }
        PlayerPrefs.SetInt("MugenToku", PlayerPrefs.GetInt("MugenToku", 0) + cost * 3);
        PlayerPrefs.SetInt("Money", PlayerPrefs.GetInt("Money", 0) - cost);
        ChangeStageInfo();
    }

    public void GoenShrine4()
    {
        int cost = 4000;
        if(cost > PlayerPrefs.GetInt("Money", 0))
        {
            message = "縁が足りません。";
            snapbarManager.ShowSnapbar(message, enImage, 3);
            return;
        }
        PlayerPrefs.SetInt("MugenToku", PlayerPrefs.GetInt("MugenToku", 0) + cost * 4);
        PlayerPrefs.SetInt("Money", PlayerPrefs.GetInt("Money", 0) - cost);
        ChangeStageInfo();
    }

    public void GoenShrine5()
    {
        int cost = 5000;
        if(cost > PlayerPrefs.GetInt("Money", 0))
        {
            message = "縁が足りません。";
            snapbarManager.ShowSnapbar(message, enImage, 3);
            return;
        }
        PlayerPrefs.SetInt("MugenToku", PlayerPrefs.GetInt("MugenToku", 0) + cost * 5);
        PlayerPrefs.SetInt("Money", PlayerPrefs.GetInt("Money", 0) - cost);
        ChangeStageInfo();
    }

    public void GoenShrine6()
    {
        int cost = 6000;
        if(cost > PlayerPrefs.GetInt("Money", 0))
        {
            message = "縁が足りません。";
            snapbarManager.ShowSnapbar(message, enImage, 3);
            return;
        }
        PlayerPrefs.SetInt("MugenToku", PlayerPrefs.GetInt("MugenToku", 0) + cost * 6);
        PlayerPrefs.SetInt("Money", PlayerPrefs.GetInt("Money", 0) - cost);
        ChangeStageInfo();
    }

    public void GoenShrine7()
    {
        int cost = 7000;
        if(cost > PlayerPrefs.GetInt("Money", 0))
        {
            message = "縁が足りません。";
            snapbarManager.ShowSnapbar(message, enImage, 3);
            return;
        }
        PlayerPrefs.SetInt("MugenToku", PlayerPrefs.GetInt("MugenToku", 0) + cost * 7);
        PlayerPrefs.SetInt("Money", PlayerPrefs.GetInt("Money", 0) - cost);
        ChangeStageInfo();
    }

    public void GoenShrine8()
    {
        int cost = 8000;
        if(cost > PlayerPrefs.GetInt("Money", 0))
        {
            message = "縁が足りません。";
            snapbarManager.ShowSnapbar(message, enImage, 3);
            return;
        }
        PlayerPrefs.SetInt("MugenToku", PlayerPrefs.GetInt("MugenToku", 0) + cost * 8);
        PlayerPrefs.SetInt("Money", PlayerPrefs.GetInt("Money", 0) - cost);
        ChangeStageInfo();
    }

    public void GoenShrine9()
    {
        int cost = 9000;
        if(cost > PlayerPrefs.GetInt("Money", 0))
        {
            message = "縁が足りません。";
            snapbarManager.ShowSnapbar(message, enImage, 3);
            return;
        }
        PlayerPrefs.SetInt("MugenToku", PlayerPrefs.GetInt("MugenToku", 0) + cost * 9);
        PlayerPrefs.SetInt("Money", PlayerPrefs.GetInt("Money", 0) - cost);
        ChangeStageInfo();
    }

    public void GoenShrine10()
    {
        int cost = 10000;
        if(cost > PlayerPrefs.GetInt("Money", 0))
        {
            message = "縁が足りません。";
            snapbarManager.ShowSnapbar(message, enImage, 3);
            return;
        }
        PlayerPrefs.SetInt("MugenToku", PlayerPrefs.GetInt("MugenToku", 0) + cost * 10);
        PlayerPrefs.SetInt("Money", PlayerPrefs.GetInt("Money", 0) - cost);
        ChangeStageInfo();
    }

    public void GoenShrine1ALL()
    {
        int cost = 1000;
        if(cost > PlayerPrefs.GetInt("Money", 0))
        {
            message = "縁が足りません。";
            snapbarManager.ShowSnapbar(message, enImage, 3);
            return;
        }
        PlayerPrefs.SetInt("MugenToku", PlayerPrefs.GetInt("MugenToku", 0) + cost * 1);
        PlayerPrefs.SetInt("Money", PlayerPrefs.GetInt("Money", 0) - cost);
        if(PlayerPrefs.GetInt("Money", 0) >= cost)
        {
            GoenShrine1ALL();
        }
        else
        {
            ChangeStageInfo();
        }
        
    }

    public void GoenShrine2ALL()
    {
        int cost = 2000;
        if(cost > PlayerPrefs.GetInt("Money", 0))
        {
            message = "縁が足りません。";
            snapbarManager.ShowSnapbar(message, enImage, 3);
            return;
        }
        PlayerPrefs.SetInt("MugenToku", PlayerPrefs.GetInt("MugenToku", 0) + cost * 2);
        PlayerPrefs.SetInt("Money", PlayerPrefs.GetInt("Money", 0) - cost);
        if(PlayerPrefs.GetInt("Money", 0) >= cost)
        {
            GoenShrine2ALL();
        }
        else
        {
            ChangeStageInfo();
        }
        
    }

    public void GoenShrine3ALL()
    {
        int cost = 3000;
        if(cost > PlayerPrefs.GetInt("Money", 0))
        {
            message = "縁が足りません。";
            snapbarManager.ShowSnapbar(message, enImage, 3);
            return;
        }
        PlayerPrefs.SetInt("MugenToku", PlayerPrefs.GetInt("MugenToku", 0) + cost * 3);
        PlayerPrefs.SetInt("Money", PlayerPrefs.GetInt("Money", 0) - cost);
        if(PlayerPrefs.GetInt("Money", 0) >= cost)
        {
            GoenShrine3ALL();
        }
        else
        {
            ChangeStageInfo();
        }
        
    }

    public void GoenShrine4ALL()
    {
        int cost = 4000;
        if(cost > PlayerPrefs.GetInt("Money", 0))
        {
            message = "縁が足りません。";
            snapbarManager.ShowSnapbar(message, enImage, 3);
            return;
        }
        PlayerPrefs.SetInt("MugenToku", PlayerPrefs.GetInt("MugenToku", 0) + cost * 4);
        PlayerPrefs.SetInt("Money", PlayerPrefs.GetInt("Money", 0) - cost);
        if(PlayerPrefs.GetInt("Money", 0) >= cost)
        {
            GoenShrine4ALL();
        }
        else
        {
            ChangeStageInfo();
        }
        
    }

    public void GoenShrine5ALL()
    {
        int cost = 5000;
        if(cost > PlayerPrefs.GetInt("Money", 0))
        {
            message = "縁が足りません。";
            snapbarManager.ShowSnapbar(message, enImage, 3);
            return;
        }
        PlayerPrefs.SetInt("MugenToku", PlayerPrefs.GetInt("MugenToku", 0) + cost * 5);
        PlayerPrefs.SetInt("Money", PlayerPrefs.GetInt("Money", 0) - cost);
        if(PlayerPrefs.GetInt("Money", 0) >= cost)
        {
            GoenShrine5ALL();
        }
        else
        {
            ChangeStageInfo();
        }
        
    }

    public void GoenShrine6ALL()
    {
        int cost = 6000;
        if(cost > PlayerPrefs.GetInt("Money", 0))
        {
            message = "縁が足りません。";
            snapbarManager.ShowSnapbar(message, enImage, 3);
            return;
        }
        PlayerPrefs.SetInt("MugenToku", PlayerPrefs.GetInt("MugenToku", 0) + cost * 6);
        PlayerPrefs.SetInt("Money", PlayerPrefs.GetInt("Money", 0) - cost);
        if(PlayerPrefs.GetInt("Money", 0) >= cost)
        {
            GoenShrine6ALL();
        }
        else
        {
            ChangeStageInfo();
        }
        
    }

    public void GoenShrine7ALL()
    {
        int cost = 7000;
        if(cost > PlayerPrefs.GetInt("Money", 0))
        {
            message = "縁が足りません。";
            snapbarManager.ShowSnapbar(message, enImage, 3);
            return;
        }
        PlayerPrefs.SetInt("MugenToku", PlayerPrefs.GetInt("MugenToku", 0) + cost * 7);
        PlayerPrefs.SetInt("Money", PlayerPrefs.GetInt("Money", 0) - cost);
        if(PlayerPrefs.GetInt("Money", 0) >= cost)
        {
            GoenShrine7ALL();
        }
        else
        {
            ChangeStageInfo();
        }
        
    }

    public void GoenShrine8ALL()
    {
        int cost = 8000;
        if(cost > PlayerPrefs.GetInt("Money", 0))
        {
            message = "縁が足りません。";
            snapbarManager.ShowSnapbar(message, enImage, 3);
            return;
        }
        PlayerPrefs.SetInt("MugenToku", PlayerPrefs.GetInt("MugenToku", 0) + cost * 8);
        PlayerPrefs.SetInt("Money", PlayerPrefs.GetInt("Money", 0) - cost);
        if(PlayerPrefs.GetInt("Money", 0) >= cost)
        {
            GoenShrine8ALL();
        }
        else
        {
            ChangeStageInfo();
        }
        
    }

    public void GoenShrine9ALL()
    {
        int cost = 9000;
        if(cost > PlayerPrefs.GetInt("Money", 0))
        {
            message = "縁が足りません。";
            snapbarManager.ShowSnapbar(message, enImage, 3);
            return;
        }
        PlayerPrefs.SetInt("MugenToku", PlayerPrefs.GetInt("MugenToku", 0) + cost * 9);
        PlayerPrefs.SetInt("Money", PlayerPrefs.GetInt("Money", 0) - cost);
        if(PlayerPrefs.GetInt("Money", 0) >= cost)
        {
            GoenShrine9ALL();
        }
        else
        {
            ChangeStageInfo();
        }
        
    }

    public void GoenShrine10ALL()
    {
        int cost = 10000;
        if(cost > PlayerPrefs.GetInt("Money", 0))
        {
            message = "縁が足りません。";
            snapbarManager.ShowSnapbar(message, enImage, 3);
            return;
        }
        PlayerPrefs.SetInt("MugenToku", PlayerPrefs.GetInt("MugenToku", 0) + cost * 10);
        PlayerPrefs.SetInt("Money", PlayerPrefs.GetInt("Money", 0) - cost);
        if(PlayerPrefs.GetInt("Money", 0) >= cost)
        {
            GoenShrine10ALL();
        }
        else
        {
            ChangeStageInfo();
        }
        
    }

    public void GetEn(int num)
    {
        message = "ログインボーナスとして" + num + "縁獲得\n明日は今日の倍もらえるよ！";
        snapbarManager.ShowSnapbar(message, enImage, 5);
        PlayerPrefs.SetInt("Money", PlayerPrefs.GetInt("Money", 0) + num);
        
    }

}
