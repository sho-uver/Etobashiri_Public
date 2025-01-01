using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Cleaner : MonoBehaviour
{
    public GameObject player;
    public float distance;
    public bool chototsuFlg;
    public GameObject human1;
    public GameObject human2;
    public GameObject human3;
    public GameObject human4;
    public GameObject human5;
    public GameObject human6;
    public GameObject human7;
    public GameObject human8;
    public GameObject human9;
    public GameObject human10;
    public GameObject human11;
    public GameObject human12;
    public GameObject human13;
    public GameObject human14;
    public int humanCounter;
    public int stageLife;
    public Transform object1; // 振動させたい1つ目のゲームオブジェクトのTransform
    public Transform object2; // 振動させたい2つ目のゲームオブジェクトのTransform
    public Transform object3;
    public float duration; // 振動の継続時間
    public float strength; // 振動の強度
    public int vibrato; // 振動の回数

    // Start is called before the first frame update
    void Start()
    {
        humanCounter = Mathf.FloorToInt(PlayerPrefs.GetInt("RestLife",0) / 20) + stageLife;
        HumanSetActiveTrue();
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y > player.transform.position.y - distance)
        {
            return;
        }
        transform.position = new Vector3(0, player.transform.position.y - distance, 0);
    }

    public void SetStageLife(int num)
    {
        stageLife = num;
    }
    
    public void Chototsumoshin()
    {
        chototsuFlg = true;
    }

    public void EndChototsumoshin()
    {
        chototsuFlg = false;
    }

    public void HumanSetActiveTrue()
    {
        if(humanCounter == 14)
        {
            human14.SetActive(true);
        }

        if(humanCounter >= 13)
        {
            human13.SetActive(true);
        }

        if(humanCounter >= 12)
        {
            human12.SetActive(true);
        }

        if(humanCounter >= 11)
        {
            human11.SetActive(true);
        }

        if(humanCounter >= 10)
        {
            human10.SetActive(true);
        }

        if(humanCounter >= 9)
        {
            human9.SetActive(true);
        }

        if(humanCounter >= 8)
        {
            human8.SetActive(true);
        }

        if(humanCounter >= 7)
        {
            human7.SetActive(true);
        }

        if(humanCounter >= 6)
        {
            human6.SetActive(true);
        }

        if(humanCounter >= 5)
        {
            human5.SetActive(true);
        }

        if(humanCounter >= 4)
        {
            human4.SetActive(true);
        }

        if(humanCounter >= 3)
        {
            human3.SetActive(true);
        }

        if(humanCounter >= 2)
        {
            human2.SetActive(true);
        }

        if(humanCounter >= 1)
        {
            human1.SetActive(true);
        }
    }

    public void LostLife()
    {
        if(humanCounter == 14)
        {
            human14.GetComponent<Human>().Lost();
        }
        if(humanCounter == 13)
        {
            human13.GetComponent<Human>().Lost();
        }
        if(humanCounter == 12)
        {
            human12.GetComponent<Human>().Lost();
        }
        if(humanCounter == 11)
        {
            human11.GetComponent<Human>().Lost();
        }
        if(humanCounter == 10)
        {
            human10.GetComponent<Human>().Lost();
        }
        if(humanCounter == 9)
        {
            human9.GetComponent<Human>().Lost();
        }
        if(humanCounter == 8)
        {
            human8.GetComponent<Human>().Lost();
        }
        if(humanCounter == 7)
        {
            human7.GetComponent<Human>().Lost();
        }

        if(humanCounter == 6)
        {
            human6.GetComponent<Human>().Lost();
        }

        if(humanCounter == 5)
        {
            human5.GetComponent<Human>().Lost();
        }

        if(humanCounter == 4)
        {
            human4.GetComponent<Human>().Lost();
        }

        if(humanCounter == 3)
        {
            human3.GetComponent<Human>().Lost();
        }

        if(humanCounter == 2)
        {
            human2.GetComponent<Human>().Lost();
        }

        if(humanCounter == 1)
        {
            human1.GetComponent<Human>().Lost();
        }
        Earthquache();
        humanCounter--;
    }

    
    public void Earthquache()
    {
        // 1つ目のゲームオブジェクトの振動
        object1.DOShakePosition(duration, new Vector3(0, strength, 0), vibrato)
            .OnComplete(() => object1.localPosition = Vector3.zero); // 振動終了後に元の位置に戻る
    }

    public void RebornLife()
    {
        humanCounter++;
        if(humanCounter == 14)
        {
            human14.SetActive(true);
        }

        if(humanCounter == 13)
        {
            human13.SetActive(true);
        }

        if(humanCounter == 12)
        {
            human12.SetActive(true);
        }

        if(humanCounter == 11)
        {
            human11.SetActive(true);
        }

        if(humanCounter == 10)
        {
            human10.SetActive(true);
        }

        if(humanCounter == 9)
        {
            human9.SetActive(true);
        }

        if(humanCounter == 8)
        {
            human8.SetActive(true);
        }

        if(humanCounter == 7)
        {
            human7.SetActive(true);
        }

        if(humanCounter == 6)
        {
            human6.SetActive(true);
        }

        if(humanCounter == 5)
        {
            human5.SetActive(true);
        }

        if(humanCounter == 4)
        {
            human4.SetActive(true);
        }

        if(humanCounter == 3)
        {
            human3.SetActive(true);
        }

        if(humanCounter == 2)
        {
            human2.SetActive(true);
        }

        if(humanCounter == 1)
        {
            human1.SetActive(true);
        }
    }

    
}
