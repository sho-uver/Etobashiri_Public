using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MugenRoad : MonoBehaviour
{
    public GameObject spring;
    public GameObject summer;
    public GameObject autumn;
    public GameObject winter;
    public GameObject togenkyo;
    public int shiki;
    public int gear;
    public GameObject bomber;
    public GameObject rollingBomber;
    public GameObject pitchBomber;
    public GameObject smallBomber;
    public GameObject fireBomber;
    public GameObject kingBomber;
    public GameObject goldenBomber;
    public GameObject hole;
    public GameObject warp;
    public GameObject lifeThread;
    public GameObject rock;
    public GameObject wood;
    public GameObject bubble;
    public GameObject snowBall;
    public GameObject ice;
    public GameObject wind;
    public GameObject tori;
    public GameObject human;
    public GameObject mure;
    public GameObject amaterasu;
    public GameObject[] castListSpring1;
    public GameObject[] castListSummer1;
    public GameObject[] castListAutumn1;
    public GameObject[] castListWinter1;
    public GameObject[] castListRare;
    public GameObject[] itemList;
    public bool makeToriFlg;
    public int itemListPlus;
    public string prismName;
    public bool makePrismFlg;
    public GameObject prismGold;
    public GameObject prismSilver;
    public GameObject prismTogenkyo;
    public GameObject shoteBomber;
    public GameObject yearPopPre;
    public bool firstYearFlg;

    public GameObject itemSet;
    public bool stopMakeFlg;
    public GameObject goal;
    public int[] sNumList1 = new int[]{10,11,12,13,14,15,16,17,18,22,23,24,26,30,31,32};
    public int[] sNumList2 = new int[]{22,23,24,30,31,32};
    public int[] smNumList1 = new int[]{10,11,12,13,14,15,16,17,18,28,29,30};

    public int[] aNumList1 = new int[]{10,11,12,13,14,15,16,17,18,20,21,22,23,24,25,26,27,28,32,33};

    public int[] wNumList1 = new int[]{10,11,12,13,14,15,16,17,18,20,21,22,23,24,25,26,27,28,32,33,34,35,36,40,41};

    // Start is called before the first frame update
    void Start()
    {
        shiki = 1;
        castListSpring1 = new GameObject[3] {wind, bomber, smallBomber};
        castListSummer1 = new GameObject[5] {wind, bomber, wood, bubble, fireBomber};
        castListAutumn1 = new GameObject[6] {wind, bomber, warp, rock, hole, rollingBomber};
        castListWinter1 = new GameObject[5] {wind, bomber, ice, snowBall, pitchBomber};
        // itemList = new GameObject[6] {wind,tori, mure, amaterasu, prismGold,prismSilver};
        itemList = new GameObject[6] {wind,itemSet, itemSet, itemSet, prismGold,prismSilver};
        castListRare = new GameObject[2] {kingBomber, goldenBomber};
        // MakeStageCast(0);
        if(firstYearFlg){
            Year(0);
        }
        else{
            MakeStageCast(0);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeStage(int num)
    {
        shiki = num;
        switch(shiki)
        {
            case 1:
                spring.SetActive(true);
                summer.SetActive(false);
                autumn.SetActive(false);
                winter.SetActive(false);
                break;
            case 2:
                spring.SetActive(false);
                summer.SetActive(true);
                autumn.SetActive(false);
                winter.SetActive(false);
                break;
            case 3:
                spring.SetActive(false);
                summer.SetActive(false);
                autumn.SetActive(true);
                winter.SetActive(false);
                break;
            case 4:
                spring.SetActive(false);
                summer.SetActive(false);
                autumn.SetActive(false);
                winter.SetActive(true);
                break;

            case 5:
                spring.SetActive(false);
                summer.SetActive(false);
                autumn.SetActive(false);
                winter.SetActive(false);
                togenkyo.SetActive(true); //ここを桃源郷に変える
                break;
        }
    }

    public void MakeStageCast(int num)
    {
        if(stopMakeFlg){return;}
        switch(shiki)
        {
            case 1:
                MakeStageCast1(num);
                break;
            case 2:
                MakeStageCast2(num);
                break;
            case 3:
                MakeStageCast3(num);
                break;
            case 4:
                MakeStageCast4(num);
                break;

            case 5:
                MakeStageCast5();
                return;
                break;
        }
        if(makeToriFlg && !makePrismFlg)
        {
            // itemListPlus = 2;
            if(num == 0)
            {
                Instantiate(itemList[Random.Range(0,1)],transform.position + new Vector3(Random.Range(-1.5f,1.5f), -9.6f,0), Quaternion.identity);
                Instantiate(itemList[1],transform.position + new Vector3(0, -3.2f,0), Quaternion.identity);
                Instantiate(itemList[Random.Range(0,1)],transform.position + new Vector3(Random.Range(-1.5f,1.5f), 3.2f,0), Quaternion.identity);
                makeToriFlg = false;
                return;
            }
            Instantiate(itemList[Random.Range(0,1)],transform.position + new Vector3(Random.Range(-1.5f,1.5f), -9.6f,0), Quaternion.identity);
            Instantiate(itemList[Random.Range(1,4)],transform.position + new Vector3(0, -3.2f,0), Quaternion.identity);
            Instantiate(itemList[Random.Range(0,1)],transform.position + new Vector3(Random.Range(-1.5f,1.5f), 3.2f,0), Quaternion.identity);
            makeToriFlg = false;
        }
        else if(!makeToriFlg && makePrismFlg)
        {
            // itemListPlus = 2;
            switch(prismName)
            {
                case "Gold":
                    Instantiate(itemList[Random.Range(0,1)],transform.position + new Vector3(Random.Range(-1.5f,1.5f), -9.6f,0), Quaternion.identity);
                    Instantiate(itemList[4],transform.position + new Vector3(Random.Range(-1.5f,1.5f), -3.2f,0), Quaternion.identity);
                    Instantiate(itemList[Random.Range(0,1)],transform.position + new Vector3(Random.Range(-1.5f,1.5f), 3.2f,0), Quaternion.identity);
                    break;

                case "Silver":
                    Instantiate(itemList[Random.Range(0,1)],transform.position + new Vector3(Random.Range(-1.5f,1.5f), -9.6f,0), Quaternion.identity);
                    Instantiate(itemList[5],transform.position + new Vector3(Random.Range(-1.5f,1.5f), -3.2f,0), Quaternion.identity);
                    Instantiate(itemList[Random.Range(0,1)],transform.position + new Vector3(Random.Range(-1.5f,1.5f), 3.2f,0), Quaternion.identity);
                    break;
            }
            makePrismFlg = false;
        }
        else if(makeToriFlg && makePrismFlg)
        {
            switch(prismName)
            {
                case "Gold":
                    Instantiate(itemList[Random.Range(1,4)],transform.position + new Vector3(0, -9.6f,0), Quaternion.identity);
                    Instantiate(itemList[Random.Range(0,1)],transform.position + new Vector3(Random.Range(-1.5f,1.5f), -3.2f,0), Quaternion.identity);
                    Instantiate(itemList[4],transform.position + new Vector3(Random.Range(-1.5f,1.5f), 3.2f,0), Quaternion.identity);
                    break;

                case "Silver":
                    Instantiate(itemList[Random.Range(1,4)],transform.position + new Vector3(0, -9.6f,0), Quaternion.identity);
                    Instantiate(itemList[Random.Range(0,1)],transform.position + new Vector3(Random.Range(-1.5f,1.5f), -3.2f,0), Quaternion.identity);
                    Instantiate(itemList[5],transform.position + new Vector3(Random.Range(-1.5f,1.5f), 3.2f,0), Quaternion.identity);
                    break;
            }
            makePrismFlg = false;
            makeToriFlg = false;
        }
        else
        {
            // itemListPlus = 0;
            Instantiate(itemList[Random.Range(0,1)],transform.position + new Vector3(Random.Range(-1.5f,1.5f), -9.6f,0), Quaternion.identity);
            Instantiate(itemList[Random.Range(0,1)],transform.position + new Vector3(Random.Range(-1.5f,1.5f), -3.2f,0), Quaternion.identity);
            Instantiate(itemList[Random.Range(0,1)],transform.position + new Vector3(Random.Range(-1.5f,1.5f), 3.2f,0), Quaternion.identity);
        }

    }

    public void MakeStageCast1(int num)
    {
        /*
        if(num >= 5)
        {
            num = 5;
        }
        */
        int num5 = 0;
        int spawnCount = 0;
        float varPosX = Random.Range(-1.5f,1.5f);
        switch(num)
        {
            case 0:
                int shoteEraseNum = Random.Range(0,3);
                if(shoteEraseNum == 0){
                    Instantiate(shoteBomber,transform.position + new Vector3(Random.Range(-1.5f,1.5f), -6.4f,0), Quaternion.identity);
                }
                else{
                    Instantiate(itemList[0],transform.position + new Vector3(Random.Range(-1.5f,1.5f), -6.4f,0), Quaternion.identity);
                }

                if(shoteEraseNum == 1){
                    Instantiate(shoteBomber,transform.position + new Vector3(Random.Range(-1.5f,1.5f), 0,0), Quaternion.identity);
                }
                else{
                    Instantiate(itemList[0],transform.position + new Vector3(Random.Range(-1.5f,1.5f), 0f,0), Quaternion.identity);
                }

                if(shoteEraseNum == 2){
                    Instantiate(shoteBomber,transform.position + new Vector3(Random.Range(-1.5f,1.5f), 6.4f,0), Quaternion.identity);
                }
                else{
                    Instantiate(itemList[0],transform.position + new Vector3(Random.Range(-1.5f,1.5f), 6.4f,0), Quaternion.identity);
                }
                break;

            case 1:
                Instantiate(castListSpring1[1],transform.position + new Vector3(Random.Range(-1.5f,1.5f), -6.4f,0), Quaternion.identity);
                Instantiate(castListSpring1[Random.Range(0,2)],transform.position + new Vector3(Random.Range(-1.5f,1.5f), 0f,0), Quaternion.identity);
                Instantiate(castListSpring1[Random.Range(0,2)],transform.position + new Vector3(Random.Range(-1.5f,1.5f), 6.4f,0), Quaternion.identity);
                break;

            case 2:
                Instantiate(castListSpring1[2],transform.position + new Vector3(Random.Range(-1.5f,1.5f), -6.4f,0), Quaternion.identity);
                Instantiate(castListSpring1[2],transform.position + new Vector3(Random.Range(-1.5f,1.5f), 0f,0), Quaternion.identity);
                Instantiate(castListSpring1[2],transform.position + new Vector3(Random.Range(-1.5f,1.5f), 6.4f,0), Quaternion.identity);
                break;

            case 3:
                /*
                Instantiate(castListSpring1[2],transform.position + new Vector3(Random.Range(-1.5f,1.5f), -6.4f,0), Quaternion.identity);
                Instantiate(castListSpring1[Random.Range(1,3)],transform.position + new Vector3(Random.Range(-1.5f,1.5f), 0f,0), Quaternion.identity);
                Instantiate(castListSpring1[Random.Range(1,3)],transform.position + new Vector3(Random.Range(-1.5f,1.5f), 6.4f,0), Quaternion.identity);
                */
                
                if(Random.Range(0,3) == 0)
                {
                    num5 = Random.Range(1,33);
                }
                else
                {
                    Instantiate(castListSpring1[2],transform.position + new Vector3(Random.Range(-1.5f,1.5f), -6.4f,0), Quaternion.identity);
                    Instantiate(castListSpring1[Random.Range(1,3)],transform.position + new Vector3(Random.Range(-1.5f,1.5f), 0f,0), Quaternion.identity);
                    Instantiate(castListSpring1[Random.Range(1,3)],transform.position + new Vector3(Random.Range(-1.5f,1.5f), 6.4f,0), Quaternion.identity);
                }
                
                
                break;
            case 4:
                num5 = Random.Range(1,33);
                /*
                Instantiate(castListSpring1[2],transform.position + new Vector3(Random.Range(-1.5f,1.5f), -6.4f,0), Quaternion.identity);
                Instantiate(castListSpring1[Random.Range(1,3)],transform.position + new Vector3(Random.Range(-1.5f,1.5f), 0f,0), Quaternion.identity);
                Instantiate(castListSpring1[Random.Range(1,3)],transform.position + new Vector3(Random.Range(-1.5f,1.5f), 6.4f,0), Quaternion.identity);
                
                if(Random.Range(0,3) == 0)
                {
                    num5 = Random.Range(1,33);
                }
                else
                {
                    Instantiate(castListSpring1[Random.Range(1,3)],transform.position + new Vector3(Random.Range(-1.5f,1.5f), -6.4f,0), Quaternion.identity);
                    Instantiate(castListSpring1[Random.Range(1,3)],transform.position + new Vector3(Random.Range(-1.5f,1.5f), 0f,0), Quaternion.identity);
                    Instantiate(castListSpring1[Random.Range(1,3)],transform.position + new Vector3(Random.Range(-1.5f,1.5f), 6.4f,0), Quaternion.identity);
                }
                */
                break;

            case 5:
                if(Random.Range(0,5) != 0)
                {
                    // 色ボンバーのみ
                    num5 = sNumList1[Random.Range(0,16)];
                }
                else
                {
                    Instantiate(castListSpring1[2],transform.position + new Vector3(Random.Range(-1.5f,1.5f), -6.4f,0), Quaternion.identity);
                    Instantiate(castListSpring1[2],transform.position + new Vector3(Random.Range(-1.5f,1.5f), 0f,0), Quaternion.identity);
                    Instantiate(castListSpring1[2],transform.position + new Vector3(Random.Range(-1.5f,1.5f), 6.4f,0), Quaternion.identity);
                }
                
                break;
                /*
                if(Random.Range(0,5) != 0)
                {
                    num5 = Random.Range(1,33);
                }
                else
                {
                    Instantiate(castListSpring1[Random.Range(1,3)],transform.position + new Vector3(Random.Range(-1.5f,1.5f), -6.4f,0), Quaternion.identity);
                    Instantiate(castListSpring1[Random.Range(1,3)],transform.position + new Vector3(Random.Range(-1.5f,1.5f), 0f,0), Quaternion.identity);
                    Instantiate(castListSpring1[Random.Range(1,3)],transform.position + new Vector3(Random.Range(-1.5f,1.5f), 6.4f,0), Quaternion.identity);    
                }
                */
            case 6:
                num5 = sNumList2[Random.Range(0,6)];
                /*
                Instantiate(castListSpring1[2],transform.position + new Vector3(Random.Range(-1.5f,1.5f), -6.4f,0), Quaternion.identity);
                Instantiate(castListSpring1[2],transform.position + new Vector3(Random.Range(-1.5f,1.5f), 0f,0), Quaternion.identity);
                Instantiate(castListSpring1[2],transform.position + new Vector3(Random.Range(-1.5f,1.5f), 6.4f,0), Quaternion.identity);
                */
                break;

            case 7:
                if(Random.Range(0,5) != 0)
                {
                    num5 = Random.Range(1,33);
                }
                else
                {
                    Instantiate(castListSpring1[Random.Range(1,3)],transform.position + new Vector3(Random.Range(-1.5f,1.5f), -6.4f,0), Quaternion.identity);
                    Instantiate(castListSpring1[Random.Range(1,3)],transform.position + new Vector3(Random.Range(-1.5f,1.5f), 0f,0), Quaternion.identity);
                    Instantiate(castListSpring1[Random.Range(1,3)],transform.position + new Vector3(Random.Range(-1.5f,1.5f), 6.4f,0), Quaternion.identity);    
                }
                break;

            case 8:
                if(Random.Range(0,5) != 0)
                {
                    // 色ボンバーのみ
                    num5 = sNumList1[Random.Range(0,16)];
                }
                else
                {
                    Instantiate(castListSpring1[Random.Range(1,3)],transform.position + new Vector3(Random.Range(-1.5f,1.5f), -6.4f,0), Quaternion.identity);
                    Instantiate(castListSpring1[Random.Range(1,3)],transform.position + new Vector3(Random.Range(-1.5f,1.5f), 0f,0), Quaternion.identity);
                    Instantiate(castListSpring1[Random.Range(1,3)],transform.position + new Vector3(Random.Range(-1.5f,1.5f), 6.4f,0), Quaternion.identity);  
                }
                break;

            case 9:
                if(Random.Range(0,5) != 0)
                {
                    // 色ボンバーのみ
                    num5 = sNumList2[Random.Range(0,6)];
                }
                else
                {
                    Instantiate(castListSpring1[2],transform.position + new Vector3(Random.Range(-1.5f,1.5f), -6.4f,0), Quaternion.identity);
                    Instantiate(castListSpring1[2],transform.position + new Vector3(Random.Range(-1.5f,1.5f), 0f,0), Quaternion.identity);
                    Instantiate(castListSpring1[2],transform.position + new Vector3(Random.Range(-1.5f,1.5f), 6.4f,0), Quaternion.identity);
                }
                break;

            case 10:
                num5 = sNumList2[Random.Range(0,6)];
                break;

            case 11:
                num5 = 33;
                break;
        }

        switch(num5)
        {
            case 1:
                Instantiate(castListSpring1[1],transform.position + new Vector3(-1.5f, -6.4f,0), Quaternion.identity);
                Instantiate(castListSpring1[1],transform.position + new Vector3(1.5f, 0f,0), Quaternion.identity);
                Instantiate(castListSpring1[1],transform.position + new Vector3(-1.5f, 6.4f,0), Quaternion.identity);
                break;

            case 2:
                Instantiate(castListSpring1[1],transform.position + new Vector3(1.5f, -6.4f,0), Quaternion.identity);
                Instantiate(castListSpring1[1],transform.position + new Vector3(-1.5f, 0f,0), Quaternion.identity);
                Instantiate(castListSpring1[1],transform.position + new Vector3(1.5f, 6.4f,0), Quaternion.identity);
                break;

            case 3:
                float posX3 = Random.Range(-1.5f,1.5f);
                Instantiate(castListSpring1[1],transform.position + new Vector3(posX3, -6.4f,0), Quaternion.identity);
                Instantiate(castListSpring1[1],transform.position + new Vector3(posX3, 0f,0), Quaternion.identity);
                Instantiate(castListSpring1[1],transform.position + new Vector3(posX3, 6.4f,0), Quaternion.identity);
                break;

            case 4:
                Instantiate(castListSpring1[1],transform.position + new Vector3(1.5f, -6.4f,0), Quaternion.identity);
                Instantiate(castListSpring1[1],transform.position + new Vector3(0, 0f,0), Quaternion.identity);
                Instantiate(castListSpring1[1],transform.position + new Vector3(-1.5f, 6.4f,0), Quaternion.identity);
                break;
                
            case 5:
                Instantiate(castListSpring1[1],transform.position + new Vector3(-1.5f, -6.4f,0), Quaternion.identity);
                Instantiate(castListSpring1[1],transform.position + new Vector3(0, 0f,0), Quaternion.identity);
                Instantiate(castListSpring1[1],transform.position + new Vector3(1.5f, 6.4f,0), Quaternion.identity);
                break;

            case 6:
                Instantiate(castListSpring1[1],transform.position + new Vector3(1.5f, -6.4f,0), Quaternion.identity);
                Instantiate(castListSpring1[1],transform.position + new Vector3(1.5f, 0f,0), Quaternion.identity);
                Instantiate(castListSpring1[1],transform.position + new Vector3(-1.5f, 6.4f,0), Quaternion.identity);
                break;

            case 7:
                Instantiate(castListSpring1[1],transform.position + new Vector3(-1.5f, -6.4f,0), Quaternion.identity);
                Instantiate(castListSpring1[1],transform.position + new Vector3(-1.5f, 0f,0), Quaternion.identity);
                Instantiate(castListSpring1[1],transform.position + new Vector3(1.5f, 6.4f,0), Quaternion.identity);
                break;

            case 8:
                Instantiate(castListSpring1[1],transform.position + new Vector3(1.5f, -6.4f,0), Quaternion.identity);
                Instantiate(castListSpring1[1],transform.position + new Vector3(-1.5f, 0f,0), Quaternion.identity);
                Instantiate(castListSpring1[1],transform.position + new Vector3(-1.5f, 6.4f,0), Quaternion.identity);
                break;

            case 9:
                Instantiate(castListSpring1[1],transform.position + new Vector3(-1.5f, -6.4f,0), Quaternion.identity);
                Instantiate(castListSpring1[1],transform.position + new Vector3(1.5f, 0f,0), Quaternion.identity);
                Instantiate(castListSpring1[1],transform.position + new Vector3(1.5f, 6.4f,0), Quaternion.identity);
                break;

            case 10:
                Instantiate(castListSpring1[2],transform.position + new Vector3(-1.5f, -6.4f,0), Quaternion.identity);
                Instantiate(castListSpring1[2],transform.position + new Vector3(1.5f, 0f,0), Quaternion.identity);
                Instantiate(castListSpring1[2],transform.position + new Vector3(-1.5f, 6.4f,0), Quaternion.identity);
                break;

            case 11:
                Instantiate(castListSpring1[2],transform.position + new Vector3(1.5f, -6.4f,0), Quaternion.identity);
                Instantiate(castListSpring1[2],transform.position + new Vector3(-1.5f, 0f,0), Quaternion.identity);
                Instantiate(castListSpring1[2],transform.position + new Vector3(1.5f, 6.4f,0), Quaternion.identity);
                break;

            case 12:
                float posX12 = Random.Range(-1.5f,1.5f);
                Instantiate(castListSpring1[2],transform.position + new Vector3(posX12, -6.4f,0), Quaternion.identity);
                Instantiate(castListSpring1[2],transform.position + new Vector3(posX12, 0f,0), Quaternion.identity);
                Instantiate(castListSpring1[2],transform.position + new Vector3(posX12, 6.4f,0), Quaternion.identity);
                break;

            case 13:
                Instantiate(castListSpring1[2],transform.position + new Vector3(1.5f, -6.4f,0), Quaternion.identity);
                Instantiate(castListSpring1[2],transform.position + new Vector3(0, 0f,0), Quaternion.identity);
                Instantiate(castListSpring1[2],transform.position + new Vector3(-1.5f, 6.4f,0), Quaternion.identity);
                break;
                
            case 14:
                Instantiate(castListSpring1[2],transform.position + new Vector3(-1.5f, -6.4f,0), Quaternion.identity);
                Instantiate(castListSpring1[2],transform.position + new Vector3(0, 0f,0), Quaternion.identity);
                Instantiate(castListSpring1[2],transform.position + new Vector3(1.5f, 6.4f,0), Quaternion.identity);
                break;

            case 15:
                Instantiate(castListSpring1[2],transform.position + new Vector3(1.5f, -6.4f,0), Quaternion.identity);
                Instantiate(castListSpring1[2],transform.position + new Vector3(1.5f, 0f,0), Quaternion.identity);
                Instantiate(castListSpring1[2],transform.position + new Vector3(-1.5f, 6.4f,0), Quaternion.identity);
                break;

            case 16:
                Instantiate(castListSpring1[2],transform.position + new Vector3(-1.5f, -6.4f,0), Quaternion.identity);
                Instantiate(castListSpring1[2],transform.position + new Vector3(-1.5f, 0f,0), Quaternion.identity);
                Instantiate(castListSpring1[2],transform.position + new Vector3(1.5f, 6.4f,0), Quaternion.identity);
                break;

            case 17:
                Instantiate(castListSpring1[2],transform.position + new Vector3(1.5f, -6.4f,0), Quaternion.identity);
                Instantiate(castListSpring1[2],transform.position + new Vector3(-1.5f, 0f,0), Quaternion.identity);
                Instantiate(castListSpring1[2],transform.position + new Vector3(-1.5f, 6.4f,0), Quaternion.identity);
                break;

            case 18:
                Instantiate(castListSpring1[2],transform.position + new Vector3(-1.5f, -6.4f,0), Quaternion.identity);
                Instantiate(castListSpring1[2],transform.position + new Vector3(1.5f, 0f,0), Quaternion.identity);
                Instantiate(castListSpring1[2],transform.position + new Vector3(1.5f, 6.4f,0), Quaternion.identity);
                break;
            
            case 19:
                float posX4 = Random.Range(-1.5f,1.5f);
                Instantiate(castListSpring1[1],transform.position + new Vector3(posX4, -3.2f,0), Quaternion.identity);
                Instantiate(castListSpring1[1],transform.position + new Vector3(posX4, 0f,0), Quaternion.identity);
                Instantiate(castListSpring1[1],transform.position + new Vector3(posX4, 1.6f,0), Quaternion.identity);
                Instantiate(castListSpring1[1],transform.position + new Vector3(posX4, 3.2f,0), Quaternion.identity);
                Instantiate(castListSpring1[1],transform.position + new Vector3(posX4, 4.8f,0), Quaternion.identity);
                Instantiate(castListSpring1[1],transform.position + new Vector3(posX4, 6.4f,0), Quaternion.identity);
                break;

            case 20:
                Instantiate(castListSpring1[1],transform.position + new Vector3(-1.5f, 0f,0), Quaternion.identity);
                Instantiate(castListSpring1[1],transform.position + new Vector3(-0.75f, 1.6f,0), Quaternion.identity);
                Instantiate(castListSpring1[1],transform.position + new Vector3(0, 3.2f,0), Quaternion.identity);
                Instantiate(castListSpring1[1],transform.position + new Vector3(0.75f, 4.8f,0), Quaternion.identity);
                Instantiate(castListSpring1[1],transform.position + new Vector3(1.5f, 6.4f,0), Quaternion.identity);
                break;

            case 21:
                Instantiate(castListSpring1[1],transform.position + new Vector3(1.5f, 0f,0), Quaternion.identity);
                Instantiate(castListSpring1[1],transform.position + new Vector3(0.75f, 1.6f,0), Quaternion.identity);
                Instantiate(castListSpring1[1],transform.position + new Vector3(0, 3.2f,0), Quaternion.identity);
                Instantiate(castListSpring1[1],transform.position + new Vector3(-0.75f, 4.8f,0), Quaternion.identity);
                Instantiate(castListSpring1[1],transform.position + new Vector3(-1.5f, 6.4f,0), Quaternion.identity);
                break;

            case 22:
                float posX5 = Random.Range(-1.5f,1.5f);
                Instantiate(castListSpring1[2],transform.position + new Vector3(posX5, -3.2f,0), Quaternion.identity);
                Instantiate(castListSpring1[2],transform.position + new Vector3(posX5, 0f,0), Quaternion.identity);
                Instantiate(castListSpring1[2],transform.position + new Vector3(posX5, 1.6f,0), Quaternion.identity);
                Instantiate(castListSpring1[2],transform.position + new Vector3(posX5, 3.2f,0), Quaternion.identity);
                Instantiate(castListSpring1[2],transform.position + new Vector3(posX5, 4.8f,0), Quaternion.identity);
                Instantiate(castListSpring1[2],transform.position + new Vector3(posX5, 6.4f,0), Quaternion.identity);
                break;

            case 23:
                Instantiate(castListSpring1[2],transform.position + new Vector3(-1.5f, 0f,0), Quaternion.identity);
                Instantiate(castListSpring1[2],transform.position + new Vector3(-0.75f, 1.6f,0), Quaternion.identity);
                Instantiate(castListSpring1[2],transform.position + new Vector3(0, 3.2f,0), Quaternion.identity);
                Instantiate(castListSpring1[2],transform.position + new Vector3(0.75f, 4.8f,0), Quaternion.identity);
                Instantiate(castListSpring1[2],transform.position + new Vector3(1.5f, 6.4f,0), Quaternion.identity);
                break;

            case 24:
                Instantiate(castListSpring1[2],transform.position + new Vector3(1.5f, 0f,0), Quaternion.identity);
                Instantiate(castListSpring1[2],transform.position + new Vector3(0.75f, 1.6f,0), Quaternion.identity);
                Instantiate(castListSpring1[2],transform.position + new Vector3(0, 3.2f,0), Quaternion.identity);
                Instantiate(castListSpring1[2],transform.position + new Vector3(-0.75f, 4.8f,0), Quaternion.identity);
                Instantiate(castListSpring1[2],transform.position + new Vector3(-1.5f, 6.4f,0), Quaternion.identity);
                break;

            case 25:
                Instantiate(castListSpring1[Random.Range(1,3)],transform.position + new Vector3(Random.Range(-1.5f,1.5f), -6.4f,0), Quaternion.identity);
                Instantiate(castListRare[Random.Range(0,2)],transform.position + new Vector3(Random.Range(-1.5f,1.5f), 0f,0), Quaternion.identity);
                Instantiate(castListSpring1[Random.Range(1,3)],transform.position + new Vector3(Random.Range(-1.5f,1.5f), 6.4f,0), Quaternion.identity);
                break;

            case 26:
                Instantiate(castListSpring1[2],transform.position + new Vector3(Random.Range(-1.5f,1.5f), -6.4f,0), Quaternion.identity);
                Instantiate(castListRare[Random.Range(0,2)],transform.position + new Vector3(Random.Range(-1.5f,1.5f), 0f,0), Quaternion.identity);
                Instantiate(castListSpring1[2],transform.position + new Vector3(Random.Range(-1.5f,1.5f), 6.4f,0), Quaternion.identity);   
                break;

            case 27:
                float posX27 = Random.Range(-1.5f,1.5f);
                if(Random.Range(0,2) == 1)
                {
                    Instantiate(castListSpring1[1],transform.position + new Vector3(posX27, -3.2f,0), Quaternion.identity);
                    spawnCount++;
                }
                if(Random.Range(0,2) == 1)
                {
                    Instantiate(castListSpring1[1],transform.position + new Vector3(posX27, 0f,0), Quaternion.identity);
                    spawnCount++;
                }
                if(Random.Range(0,2) == 1)
                {
                    Instantiate(castListSpring1[1],transform.position + new Vector3(posX27, 1.6f,0), Quaternion.identity);
                    spawnCount++;
                }
                if(Random.Range(0,2) == 1)
                {
                    Instantiate(castListSpring1[1],transform.position + new Vector3(posX27, 3.2f,0), Quaternion.identity);
                    spawnCount++;
                }
                if(Random.Range(0,2) == 1)
                {
                    Instantiate(castListSpring1[1],transform.position + new Vector3(posX27, 4.8f,0), Quaternion.identity);
                    spawnCount++;
                }
                if(Random.Range(0,2) == 1)
                {
                    Instantiate(castListSpring1[1],transform.position + new Vector3(posX27, 6.4f,0), Quaternion.identity);
                    spawnCount++;
                }
                if(spawnCount < 3)
                {
                    Instantiate(castListSpring1[1],transform.position + new Vector3(posX27, 3.2f,0), Quaternion.identity);
                    Instantiate(castListSpring1[1],transform.position + new Vector3(posX27, 4.8f,0), Quaternion.identity);
                    Instantiate(castListSpring1[1],transform.position + new Vector3(posX27, 6.4f,0), Quaternion.identity);

                }
                break;

            case 28:
                if(Random.Range(0,2) == 1)
                {
                    Instantiate(castListSpring1[1],transform.position + new Vector3(-1.5f, 0f,0), Quaternion.identity);
                    spawnCount++;
                }
                if(Random.Range(0,2) == 1)
                {
                    Instantiate(castListSpring1[1],transform.position + new Vector3(-0.75f, 1.6f,0), Quaternion.identity);
                    spawnCount++;
                }
                if(Random.Range(0,2) == 1)
                {
                    Instantiate(castListSpring1[1],transform.position + new Vector3(0, 3.2f,0), Quaternion.identity);
                    spawnCount++;
                }
                if(Random.Range(0,2) == 1)
                {
                    Instantiate(castListSpring1[1],transform.position + new Vector3(0.75f, 4.8f,0), Quaternion.identity);
                    spawnCount++;
                }
                if(Random.Range(0,2) == 1)
                {
                    Instantiate(castListSpring1[1],transform.position + new Vector3(1.5f, 6.4f,0), Quaternion.identity);
                    spawnCount++;
                }
                if(spawnCount < 3)
                {
                    Instantiate(castListSpring1[1],transform.position + new Vector3(0, 3.2f,0), Quaternion.identity);
                    Instantiate(castListSpring1[1],transform.position + new Vector3(0.75f, 4.8f,0), Quaternion.identity);
                    Instantiate(castListSpring1[1],transform.position + new Vector3(1.5f, 6.4f,0), Quaternion.identity);

                }
                break;

            case 29:
                if(Random.Range(0,2) == 1)
                {
                    Instantiate(castListSpring1[1],transform.position + new Vector3(1.5f, 0f,0), Quaternion.identity);
                    spawnCount++;
                }
                if(Random.Range(0,2) == 1)
                {
                    Instantiate(castListSpring1[1],transform.position + new Vector3(0.75f, 1.6f,0), Quaternion.identity);
                    spawnCount++;
                }
                if(Random.Range(0,2) == 1)
                {
                    Instantiate(castListSpring1[1],transform.position + new Vector3(0, 3.2f,0), Quaternion.identity);
                    spawnCount++;
                }
                if(Random.Range(0,2) == 1)
                {
                    Instantiate(castListSpring1[1],transform.position + new Vector3(-0.75f, 4.8f,0), Quaternion.identity);
                    spawnCount++;
                }
                if(Random.Range(0,2) == 1)
                {
                    Instantiate(castListSpring1[1],transform.position + new Vector3(-1.5f, 6.4f,0), Quaternion.identity);
                    spawnCount++;
                }
                if(spawnCount < 3)
                {
                    Instantiate(castListSpring1[1],transform.position + new Vector3(0, 3.2f,0), Quaternion.identity);
                    Instantiate(castListSpring1[1],transform.position + new Vector3(-0.75f, 4.8f,0), Quaternion.identity);
                    Instantiate(castListSpring1[1],transform.position + new Vector3(-1.5f, 6.4f,0), Quaternion.identity);
                }
                break;

            case 30:
                float posX30 = Random.Range(-1.5f,1.5f);
                if(Random.Range(0,2) == 1)
                {
                    Instantiate(castListSpring1[2],transform.position + new Vector3(posX30, -3.2f,0), Quaternion.identity);
                    spawnCount++;
                }
                if(Random.Range(0,2) == 1)
                {
                    Instantiate(castListSpring1[2],transform.position + new Vector3(posX30, 0f,0), Quaternion.identity);
                    spawnCount++;
                }
                if(Random.Range(0,2) == 1)
                {
                    Instantiate(castListSpring1[2],transform.position + new Vector3(posX30, 1.6f,0), Quaternion.identity);
                    spawnCount++;
                }
                if(Random.Range(0,2) == 1)
                {
                    Instantiate(castListSpring1[2],transform.position + new Vector3(posX30, 3.2f,0), Quaternion.identity);
                    spawnCount++;
                }
                if(Random.Range(0,2) == 1)
                {
                    Instantiate(castListSpring1[2],transform.position + new Vector3(posX30, 4.8f,0), Quaternion.identity);
                    spawnCount++;
                }
                if(Random.Range(0,2) == 1)
                {
                    Instantiate(castListSpring1[2],transform.position + new Vector3(posX30, 6.4f,0), Quaternion.identity);
                    spawnCount++;
                }
                if(spawnCount < 3)
                {
                    Instantiate(castListSpring1[2],transform.position + new Vector3(posX30, 3.2f,0), Quaternion.identity);
                    Instantiate(castListSpring1[2],transform.position + new Vector3(posX30, 4.8f,0), Quaternion.identity);
                    Instantiate(castListSpring1[2],transform.position + new Vector3(posX30, 6.4f,0), Quaternion.identity);
                }
                break;

            case 31:
                if(Random.Range(0,2) == 1)
                {
                    Instantiate(castListSpring1[2],transform.position + new Vector3(-1.5f, 0f,0), Quaternion.identity);
                    spawnCount++;
                }
                if(Random.Range(0,2) == 1)
                {
                    Instantiate(castListSpring1[2],transform.position + new Vector3(-0.75f, 1.6f,0), Quaternion.identity);
                    spawnCount++;
                }
                if(Random.Range(0,2) == 1)
                {
                    Instantiate(castListSpring1[2],transform.position + new Vector3(0, 3.2f,0), Quaternion.identity);
                    spawnCount++;
                }
                if(Random.Range(0,2) == 1)
                {
                    Instantiate(castListSpring1[2],transform.position + new Vector3(0.75f, 4.8f,0), Quaternion.identity);
                    spawnCount++;
                }
                if(Random.Range(0,2) == 1)
                {
                    Instantiate(castListSpring1[2],transform.position + new Vector3(1.5f, 6.4f,0), Quaternion.identity);
                    spawnCount++;
                }
                if(spawnCount < 3)
                {
                    Instantiate(castListSpring1[2],transform.position + new Vector3(0, 3.2f,0), Quaternion.identity);
                    Instantiate(castListSpring1[2],transform.position + new Vector3(0.75f, 4.8f,0), Quaternion.identity);
                    Instantiate(castListSpring1[2],transform.position + new Vector3(1.5f, 6.4f,0), Quaternion.identity);
                }
                break;

            case 32:
                if(Random.Range(0,2) == 1)
                {
                    Instantiate(castListSpring1[2],transform.position + new Vector3(1.5f, 0f,0), Quaternion.identity);
                    spawnCount++;
                }
                if(Random.Range(0,2) == 1)
                {
                    Instantiate(castListSpring1[2],transform.position + new Vector3(0.75f, 1.6f,0), Quaternion.identity);
                    spawnCount++;
                }
                if(Random.Range(0,2) == 1)
                {
                    Instantiate(castListSpring1[2],transform.position + new Vector3(0, 3.2f,0), Quaternion.identity);
                    spawnCount++;
                }
                if(Random.Range(0,2) == 1)
                {
                    Instantiate(castListSpring1[2],transform.position + new Vector3(-0.75f, 4.8f,0), Quaternion.identity);
                    spawnCount++;
                }
                if(Random.Range(0,2) == 1)
                {
                    Instantiate(castListSpring1[2],transform.position + new Vector3(-1.5f, 6.4f,0), Quaternion.identity);
                    spawnCount++;
                }
                if(spawnCount < 3)
                {
                    Instantiate(castListSpring1[2],transform.position + new Vector3(0, 3.2f,0), Quaternion.identity);
                    Instantiate(castListSpring1[2],transform.position + new Vector3(-0.75f, 4.8f,0), Quaternion.identity);
                    Instantiate(castListSpring1[2],transform.position + new Vector3(-1.5f, 6.4f,0), Quaternion.identity);
                }
                break;

            case 33:
                Instantiate(castListRare[0],transform.position + new Vector3(-1.5f, -6.4f,0), Quaternion.identity);
                Instantiate(castListRare[0],transform.position + new Vector3(1.5f, 0f,0), Quaternion.identity);
                Instantiate(castListRare[0],transform.position + new Vector3(-1.5f, 6.4f,0), Quaternion.identity);
                break;
        }
    }

    public void MakeStageCast2(int num)
    {
        /*
        if(num >= 5)
        {
            num = 5;
        }
        */
        int num5 = 0;
        
        switch(num)
        {
            case 0:
                int shoteEraseNum = Random.Range(0,3);
                if(shoteEraseNum == 0){
                    Instantiate(shoteBomber,transform.position + new Vector3(Random.Range(-1.5f,1.5f), -6.4f,0), Quaternion.identity);
                }
                else{
                    Instantiate(castListSummer1[2],transform.position + new Vector3(Random.Range(-1.5f,1.5f), -6.4f,0), Quaternion.identity);;
                }

                if(shoteEraseNum == 1){
                    Instantiate(shoteBomber,transform.position + new Vector3(Random.Range(-1.5f,1.5f), 0,0), Quaternion.identity);
                }
                else{
                    Instantiate(castListSummer1[2],transform.position + new Vector3(Random.Range(-1.5f,1.5f), 0f,0), Quaternion.identity);;
                }

                if(shoteEraseNum == 2){
                    Instantiate(shoteBomber,transform.position + new Vector3(Random.Range(-1.5f,1.5f), 6.4f,0), Quaternion.identity);
                }
                else{
                    Instantiate(castListSummer1[2],transform.position + new Vector3(Random.Range(-1.5f,1.5f), 6.4f,0), Quaternion.identity);;
                }
                break;

            case 1:
                Instantiate(castListSummer1[Random.Range(1,4)],transform.position + new Vector3(Random.Range(-1.5f,1.5f), -6.4f,0), Quaternion.identity);
                Instantiate(castListSummer1[Random.Range(1,4)],transform.position + new Vector3(Random.Range(-1.5f,1.5f), 0f,0), Quaternion.identity);
                Instantiate(castListSummer1[Random.Range(1,4)],transform.position + new Vector3(Random.Range(-1.5f,1.5f), 6.4f,0), Quaternion.identity);
                break;

            case 2:
                Instantiate(castListSummer1[4],transform.position + new Vector3(Random.Range(-1.5f,1.5f), -6.4f,0), Quaternion.identity);
                Instantiate(castListSummer1[4],transform.position + new Vector3(Random.Range(-1.5f,1.5f), 0f,0), Quaternion.identity);
                Instantiate(castListSummer1[4],transform.position + new Vector3(Random.Range(-1.5f,1.5f), 6.4f,0), Quaternion.identity);
                break;

            case 3:
                /*
                Instantiate(castListSummer1[4],transform.position + new Vector3(Random.Range(-1.5f,1.5f), -6.4f,0), Quaternion.identity);
                Instantiate(castListSummer1[Random.Range(3,5)],transform.position + new Vector3(Random.Range(-1.5f,1.5f), 0f,0), Quaternion.identity);
                Instantiate(castListSummer1[Random.Range(1,5)],transform.position + new Vector3(Random.Range(-1.5f,1.5f), 6.4f,0), Quaternion.identity);
                */
                if(Random.Range(0,3) == 0)
                {
                    num5 = Random.Range(1,31);
                }
                else
                {
                    Instantiate(castListSummer1[4],transform.position + new Vector3(Random.Range(-1.5f,1.5f), -6.4f,0), Quaternion.identity);
                Instantiate(castListSummer1[Random.Range(3,5)],transform.position + new Vector3(Random.Range(-1.5f,1.5f), 0f,0), Quaternion.identity);
                Instantiate(castListSummer1[Random.Range(1,5)],transform.position + new Vector3(Random.Range(-1.5f,1.5f), 6.4f,0), Quaternion.identity);
                }
                
                break;

            case 4:
                num5 = Random.Range(1,31);
                /*
                Instantiate(castListSummer1[4],transform.position + new Vector3(Random.Range(-1.5f,1.5f), -6.4f,0), Quaternion.identity);
                Instantiate(castListSummer1[Random.Range(3,5)],transform.position + new Vector3(Random.Range(-1.5f,1.5f), 0f,0), Quaternion.identity);
                Instantiate(castListSummer1[Random.Range(3,5)],transform.position + new Vector3(Random.Range(-1.5f,1.5f), 6.4f,0), Quaternion.identity);
                /*
                if(Random.Range(0,3) == 0)
                {
                    num5 = Random.Range(1,31);
                }
                else
                {
                    Instantiate(castListSummer1[Random.Range(1,5)],transform.position + new Vector3(Random.Range(-1.5f,1.5f), -6.4f,0), Quaternion.identity);
                    Instantiate(castListSummer1[Random.Range(1,5)],transform.position + new Vector3(Random.Range(-1.5f,1.5f), 0f,0), Quaternion.identity);
                    Instantiate(castListSummer1[Random.Range(1,5)],transform.position + new Vector3(Random.Range(-1.5f,1.5f), 6.4f,0), Quaternion.identity);
                }
                */
                break;

            case 5:
                /*
                Instantiate(castListSummer1[4],transform.position + new Vector3(Random.Range(-1.5f,1.5f), -6.4f,0), Quaternion.identity);
                Instantiate(castListSummer1[Random.Range(2,5)],transform.position + new Vector3(Random.Range(-1.5f,1.5f), 0f,0), Quaternion.identity);
                Instantiate(castListSummer1[Random.Range(2,5)],transform.position + new Vector3(Random.Range(-1.5f,1.5f), 6.4f,0), Quaternion.identity);
                */
                if(Random.Range(0,5) != 0)
                {
                    num5 = smNumList1[Random.Range(0,12)];
                }
                else
                {
                    Instantiate(castListSummer1[Random.Range(2,5)],transform.position + new Vector3(Random.Range(-1.5f,1.5f), -6.4f,0), Quaternion.identity);
                    Instantiate(castListSummer1[Random.Range(2,5)],transform.position + new Vector3(Random.Range(-1.5f,1.5f), 0f,0), Quaternion.identity);
                    Instantiate(castListSummer1[Random.Range(2,5)],transform.position + new Vector3(Random.Range(-1.5f,1.5f), 6.4f,0), Quaternion.identity);
                }
                
                break;

            case 6:
                if(Random.Range(0,5) == 0)
                {
                    num5 = Random.Range(1,31);
                }
                else
                {
                    Instantiate(castListSummer1[Random.Range(1,5)],transform.position + new Vector3(Random.Range(-1.5f,1.5f), -6.4f,0), Quaternion.identity);
                    Instantiate(castListSummer1[Random.Range(1,5)],transform.position + new Vector3(Random.Range(-1.5f,1.5f), 0f,0), Quaternion.identity);
                    Instantiate(castListSummer1[Random.Range(1,5)],transform.position + new Vector3(Random.Range(-1.5f,1.5f), 6.4f,0), Quaternion.identity);
                }
                break;

            case 7:
                Instantiate(castListSummer1[Random.Range(3,5)],transform.position + new Vector3(Random.Range(-1.5f,1.5f), -6.4f,0), Quaternion.identity);
                Instantiate(castListSummer1[Random.Range(3,5)],transform.position + new Vector3(Random.Range(-1.5f,1.5f), 0f,0), Quaternion.identity);
                Instantiate(castListSummer1[Random.Range(3,5)],transform.position + new Vector3(Random.Range(-1.5f,1.5f), 6.4f,0), Quaternion.identity);
                break;

            case 8:
                if(Random.Range(0,5) == 0)
                {
                    num5 = Random.Range(1,31);
                }
                else
                {
                    Instantiate(castListSummer1[Random.Range(1,5)],transform.position + new Vector3(Random.Range(-1.5f,1.5f), -6.4f,0), Quaternion.identity);
                    Instantiate(castListSummer1[Random.Range(1,5)],transform.position + new Vector3(Random.Range(-1.5f,1.5f), 0f,0), Quaternion.identity);
                    Instantiate(castListSummer1[Random.Range(1,5)],transform.position + new Vector3(Random.Range(-1.5f,1.5f), 6.4f,0), Quaternion.identity);
                }
                break;

            case 9:
                Instantiate(castListSummer1[4],transform.position + new Vector3(Random.Range(-1.5f,1.5f), -6.4f,0), Quaternion.identity);
                Instantiate(castListSummer1[4],transform.position + new Vector3(Random.Range(-1.5f,1.5f), 0f,0), Quaternion.identity);
                Instantiate(castListSummer1[4],transform.position + new Vector3(Random.Range(-1.5f,1.5f), 6.4f,0), Quaternion.identity);
                break;

            case 10:
                Instantiate(castListSummer1[Random.Range(3,5)],transform.position + new Vector3(Random.Range(-1.5f,1.5f), -6.4f,0), Quaternion.identity);
                Instantiate(castListSummer1[Random.Range(3,5)],transform.position + new Vector3(Random.Range(-1.5f,1.5f), 0f,0), Quaternion.identity);
                Instantiate(castListSummer1[Random.Range(3,5)],transform.position + new Vector3(Random.Range(-1.5f,1.5f), 6.4f,0), Quaternion.identity);
                break;

            case 11:
                num5 = 31;
                break;
        }

        switch(num5)
        {

            case 1:
                Instantiate(castListSummer1[1],transform.position + new Vector3(-1.5f, -6.4f,0), Quaternion.identity);
                Instantiate(castListSummer1[1],transform.position + new Vector3(1.5f, 0f,0), Quaternion.identity);
                Instantiate(castListSummer1[1],transform.position + new Vector3(-1.5f, 6.4f,0), Quaternion.identity);
                break;

            case 2:
                Instantiate(castListSummer1[1],transform.position + new Vector3(1.5f, -6.4f,0), Quaternion.identity);
                Instantiate(castListSummer1[1],transform.position + new Vector3(-1.5f, 0f,0), Quaternion.identity);
                Instantiate(castListSummer1[1],transform.position + new Vector3(1.5f, 6.4f,0), Quaternion.identity);
                break;

            case 3:
                float posX3 = Random.Range(-1.5f,1.5f);
                Instantiate(castListSummer1[1],transform.position + new Vector3(posX3, -6.4f,0), Quaternion.identity);
                Instantiate(castListSummer1[1],transform.position + new Vector3(posX3, 0f,0), Quaternion.identity);
                Instantiate(castListSummer1[1],transform.position + new Vector3(posX3, 6.4f,0), Quaternion.identity);
                break;

            case 4:
                Instantiate(castListSummer1[1],transform.position + new Vector3(1.5f, -6.4f,0), Quaternion.identity);
                Instantiate(castListSummer1[1],transform.position + new Vector3(0, 0f,0), Quaternion.identity);
                Instantiate(castListSummer1[1],transform.position + new Vector3(-1.5f, 6.4f,0), Quaternion.identity);
                break;
                
            case 5:
                Instantiate(castListSummer1[1],transform.position + new Vector3(-1.5f, -6.4f,0), Quaternion.identity);
                Instantiate(castListSummer1[1],transform.position + new Vector3(0, 0f,0), Quaternion.identity);
                Instantiate(castListSummer1[1],transform.position + new Vector3(1.5f, 6.4f,0), Quaternion.identity);
                break;

            case 6:
                Instantiate(castListSummer1[1],transform.position + new Vector3(1.5f, -6.4f,0), Quaternion.identity);
                Instantiate(castListSummer1[1],transform.position + new Vector3(1.5f, 0f,0), Quaternion.identity);
                Instantiate(castListSummer1[1],transform.position + new Vector3(-1.5f, 6.4f,0), Quaternion.identity);
                break;

            case 7:
                Instantiate(castListSummer1[1],transform.position + new Vector3(-1.5f, -6.4f,0), Quaternion.identity);
                Instantiate(castListSummer1[1],transform.position + new Vector3(-1.5f, 0f,0), Quaternion.identity);
                Instantiate(castListSummer1[1],transform.position + new Vector3(1.5f, 6.4f,0), Quaternion.identity);
                break;

            case 8:
                Instantiate(castListSummer1[1],transform.position + new Vector3(1.5f, -6.4f,0), Quaternion.identity);
                Instantiate(castListSummer1[1],transform.position + new Vector3(-1.5f, 0f,0), Quaternion.identity);
                Instantiate(castListSummer1[1],transform.position + new Vector3(-1.5f, 6.4f,0), Quaternion.identity);
                break;

            case 9:
                Instantiate(castListSummer1[1],transform.position + new Vector3(-1.5f, -6.4f,0), Quaternion.identity);
                Instantiate(castListSummer1[1],transform.position + new Vector3(1.5f, 0f,0), Quaternion.identity);
                Instantiate(castListSummer1[1],transform.position + new Vector3(1.5f, 6.4f,0), Quaternion.identity);
                break;

            case 10:
                Instantiate(castListSummer1[4],transform.position + new Vector3(-1.5f, -6.4f,0), Quaternion.identity);
                Instantiate(castListSummer1[4],transform.position + new Vector3(1.5f, 0f,0), Quaternion.identity);
                Instantiate(castListSummer1[4],transform.position + new Vector3(-1.5f, 6.4f,0), Quaternion.identity);
                break;

            case 11:
                Instantiate(castListSummer1[4],transform.position + new Vector3(1.5f, -6.4f,0), Quaternion.identity);
                Instantiate(castListSummer1[4],transform.position + new Vector3(-1.5f, 0f,0), Quaternion.identity);
                Instantiate(castListSummer1[4],transform.position + new Vector3(1.5f, 6.4f,0), Quaternion.identity);
                break;

            case 12:
                float posX12 = Random.Range(-1.5f,1.5f);
                Instantiate(castListSummer1[4],transform.position + new Vector3(posX12, -6.4f,0), Quaternion.identity);
                Instantiate(castListSummer1[4],transform.position + new Vector3(posX12, 0f,0), Quaternion.identity);
                Instantiate(castListSummer1[4],transform.position + new Vector3(posX12, 6.4f,0), Quaternion.identity);
                break;

            case 13:
                Instantiate(castListSummer1[4],transform.position + new Vector3(1.5f, -6.4f,0), Quaternion.identity);
                Instantiate(castListSummer1[4],transform.position + new Vector3(0, 0f,0), Quaternion.identity);
                Instantiate(castListSummer1[4],transform.position + new Vector3(-1.5f, 6.4f,0), Quaternion.identity);
                break;
                
            case 14:
                Instantiate(castListSummer1[4],transform.position + new Vector3(-1.5f, -6.4f,0), Quaternion.identity);
                Instantiate(castListSummer1[4],transform.position + new Vector3(0, 0f,0), Quaternion.identity);
                Instantiate(castListSummer1[4],transform.position + new Vector3(1.5f, 6.4f,0), Quaternion.identity);
                break;

            case 15:
                Instantiate(castListSummer1[4],transform.position + new Vector3(1.5f, -6.4f,0), Quaternion.identity);
                Instantiate(castListSummer1[4],transform.position + new Vector3(1.5f, 0f,0), Quaternion.identity);
                Instantiate(castListSummer1[4],transform.position + new Vector3(-1.5f, 6.4f,0), Quaternion.identity);
                break;

            case 16:
                Instantiate(castListSummer1[4],transform.position + new Vector3(-1.5f, -6.4f,0), Quaternion.identity);
                Instantiate(castListSummer1[4],transform.position + new Vector3(-1.5f, 0f,0), Quaternion.identity);
                Instantiate(castListSummer1[4],transform.position + new Vector3(1.5f, 6.4f,0), Quaternion.identity);
                break;

            case 17:
                Instantiate(castListSummer1[4],transform.position + new Vector3(1.5f, -6.4f,0), Quaternion.identity);
                Instantiate(castListSummer1[4],transform.position + new Vector3(-1.5f, 0f,0), Quaternion.identity);
                Instantiate(castListSummer1[4],transform.position + new Vector3(-1.5f, 6.4f,0), Quaternion.identity);
                break;

            case 18:
                Instantiate(castListSummer1[4],transform.position + new Vector3(-1.5f, -6.4f,0), Quaternion.identity);
                Instantiate(castListSummer1[4],transform.position + new Vector3(1.5f, 0f,0), Quaternion.identity);
                Instantiate(castListSummer1[4],transform.position + new Vector3(1.5f, 6.4f,0), Quaternion.identity);
                break;

            case 19:
                Instantiate(castListSummer1[3],transform.position + new Vector3(-1.5f, -6.4f,0), Quaternion.identity);
                Instantiate(castListSummer1[3],transform.position + new Vector3(1.5f, 0f,0), Quaternion.identity);
                Instantiate(castListSummer1[3],transform.position + new Vector3(-1.5f, 6.4f,0), Quaternion.identity);
                break;

            case 20:
                Instantiate(castListSummer1[3],transform.position + new Vector3(1.5f, -6.4f,0), Quaternion.identity);
                Instantiate(castListSummer1[3],transform.position + new Vector3(-1.5f, 0f,0), Quaternion.identity);
                Instantiate(castListSummer1[3],transform.position + new Vector3(1.5f, 6.4f,0), Quaternion.identity);
                break;

            case 21:
                float posX21 = Random.Range(-1.5f,1.5f);
                Instantiate(castListSummer1[3],transform.position + new Vector3(posX21, -6.4f,0), Quaternion.identity);
                Instantiate(castListSummer1[3],transform.position + new Vector3(posX21, 0f,0), Quaternion.identity);
                Instantiate(castListSummer1[3],transform.position + new Vector3(posX21, 6.4f,0), Quaternion.identity);
                break;

            case 22:
                Instantiate(castListSummer1[3],transform.position + new Vector3(1.5f, -6.4f,0), Quaternion.identity);
                Instantiate(castListSummer1[3],transform.position + new Vector3(0, 0f,0), Quaternion.identity);
                Instantiate(castListSummer1[3],transform.position + new Vector3(-1.5f, 6.4f,0), Quaternion.identity);
                break;
                
            case 23:
                Instantiate(castListSummer1[3],transform.position + new Vector3(-1.5f, -6.4f,0), Quaternion.identity);
                Instantiate(castListSummer1[3],transform.position + new Vector3(0, 0f,0), Quaternion.identity);
                Instantiate(castListSummer1[3],transform.position + new Vector3(1.5f, 6.4f,0), Quaternion.identity);
                break;

            case 24:
                Instantiate(castListSummer1[3],transform.position + new Vector3(1.5f, -6.4f,0), Quaternion.identity);
                Instantiate(castListSummer1[3],transform.position + new Vector3(1.5f, 0f,0), Quaternion.identity);
                Instantiate(castListSummer1[3],transform.position + new Vector3(-1.5f, 6.4f,0), Quaternion.identity);
                break;

            case 25:
                Instantiate(castListSummer1[3],transform.position + new Vector3(-1.5f, -6.4f,0), Quaternion.identity);
                Instantiate(castListSummer1[3],transform.position + new Vector3(-1.5f, 0f,0), Quaternion.identity);
                Instantiate(castListSummer1[3],transform.position + new Vector3(1.5f, 6.4f,0), Quaternion.identity);
                break;

            case 26:
                Instantiate(castListSummer1[3],transform.position + new Vector3(1.5f, -6.4f,0), Quaternion.identity);
                Instantiate(castListSummer1[3],transform.position + new Vector3(-1.5f, 0f,0), Quaternion.identity);
                Instantiate(castListSummer1[3],transform.position + new Vector3(-1.5f, 6.4f,0), Quaternion.identity);
                break;

            case 27:
                Instantiate(castListSummer1[3],transform.position + new Vector3(-1.5f, -6.4f,0), Quaternion.identity);
                Instantiate(castListSummer1[3],transform.position + new Vector3(1.5f, 0f,0), Quaternion.identity);
                Instantiate(castListSummer1[3],transform.position + new Vector3(1.5f, 6.4f,0), Quaternion.identity);
                break;

            case 28:
                Instantiate(castListSummer1[3],transform.position + new Vector3(0, -6.4f,0), Quaternion.identity);
                Instantiate(castListSummer1[4],transform.position + new Vector3(0, 0f,0), Quaternion.identity);
                Instantiate(castListSummer1[3],transform.position + new Vector3(0, 6.4f,0), Quaternion.identity);
                break;

            case 29:
                Instantiate(castListSummer1[4],transform.position + new Vector3(Random.Range(-1.5f,1.5f), -6.4f,0), Quaternion.identity);
                Instantiate(castListRare[Random.Range(0,2)],transform.position + new Vector3(Random.Range(-1.5f,1.5f), 0f,0), Quaternion.identity);
                Instantiate(castListSummer1[4],transform.position + new Vector3(Random.Range(-1.5f,1.5f), 6.4f,0), Quaternion.identity);
                break;

            case 30:
                Instantiate(castListSummer1[4],transform.position + new Vector3(Random.Range(-1.5f,1.5f), -6.4f,0), Quaternion.identity);
                Instantiate(castListRare[Random.Range(0,2)],transform.position + new Vector3(Random.Range(-1.5f,1.5f), 0f,0), Quaternion.identity);
                Instantiate(castListSummer1[4],transform.position + new Vector3(Random.Range(-1.5f,1.5f), 6.4f,0), Quaternion.identity);   
                break;

            case 31:
                Instantiate(castListSummer1[Random.Range(2,4)],transform.position + new Vector3(-1.5f, -6.4f,0), Quaternion.identity);
                Instantiate(castListRare[0],transform.position + new Vector3(1.5f, 0f,0), Quaternion.identity);
                Instantiate(castListRare[0],transform.position + new Vector3(-1.5f, 6.4f,0), Quaternion.identity);
                break;
        }
    }

    public void MakeStageCast3(int num)
    {
        /*
        if(num >= 5)
        {
            num = 5;
        }
        */
        int num5 = 0;
        int spawnCount = 0;
        float varPosX = Random.Range(-1.5f,1.5f);
        switch(num)
        {
            case 0:
                int shoteEraseNum = Random.Range(0,3);
                if(shoteEraseNum != 0){
                    Instantiate(shoteBomber,transform.position + new Vector3(Random.Range(-1.5f,1.5f), -6.4f,0), Quaternion.identity);
                }
                else{
                    Instantiate(castListAutumn1[3],transform.position + new Vector3(Random.Range(-1.5f,1.5f), -6.4f,0), Quaternion.identity);;
                }

                if(shoteEraseNum != 1){
                    Instantiate(shoteBomber,transform.position + new Vector3(Random.Range(-1.5f,1.5f), 0,0), Quaternion.identity);
                }
                else{
                    Instantiate(castListAutumn1[3],transform.position + new Vector3(Random.Range(-1.5f,1.5f), 0f,0), Quaternion.identity);;
                }

                if(shoteEraseNum != 2){
                    Instantiate(shoteBomber,transform.position + new Vector3(Random.Range(-1.5f,1.5f), 6.4f,0), Quaternion.identity);
                }
                else{
                    Instantiate(castListAutumn1[3],transform.position + new Vector3(Random.Range(-1.5f,1.5f), 6.4f,0), Quaternion.identity);;
                }
                break;

            case 1:
                Instantiate(castListAutumn1[Random.Range(1,4)],transform.position + new Vector3(Random.Range(-1.5f,1.5f), -6.4f,0), Quaternion.identity);
                Instantiate(castListAutumn1[Random.Range(1,4)],transform.position + new Vector3(Random.Range(-1.5f,1.5f), 0f,0), Quaternion.identity);
                Instantiate(castListAutumn1[Random.Range(1,4)],transform.position + new Vector3(Random.Range(-1.5f,1.5f), 6.4f,0), Quaternion.identity);
                break;

            case 2:
                Instantiate(castListAutumn1[Random.Range(4,6)],transform.position + new Vector3(Random.Range(-1.5f,1.5f), -6.4f,0), Quaternion.identity);
                Instantiate(castListAutumn1[Random.Range(4,6)],transform.position + new Vector3(Random.Range(-1.5f,1.5f), 0f,0), Quaternion.identity);
                Instantiate(castListAutumn1[Random.Range(4,6)],transform.position + new Vector3(Random.Range(-1.5f,1.5f), 6.4f,0), Quaternion.identity);
                break;

            case 3:
                /*
                Instantiate(castListAutumn1[2],transform.position + new Vector3(Random.Range(-1.5f,1.5f), -6.4f,0), Quaternion.identity);
                Instantiate(castListAutumn1[Random.Range(1,6)],transform.position + new Vector3(Random.Range(-1.5f,1.5f), 0f,0), Quaternion.identity);
                Instantiate(castListAutumn1[Random.Range(1,6)],transform.position + new Vector3(Random.Range(-1.5f,1.5f), 6.4f,0), Quaternion.identity);
                */                
                if(Random.Range(0,3) != 0)
                {
                    num5 = Random.Range(1,37);
                }
                else
                {
                    Instantiate(castListAutumn1[Random.Range(1,6)],transform.position + new Vector3(Random.Range(-1.5f,1.5f), -6.4f,0), Quaternion.identity);
                    Instantiate(castListAutumn1[Random.Range(1,6)],transform.position + new Vector3(Random.Range(-1.5f,1.5f), 0f,0), Quaternion.identity);
                    Instantiate(castListAutumn1[Random.Range(1,6)],transform.position + new Vector3(Random.Range(-1.5f,1.5f), 6.4f,0), Quaternion.identity);
                }
                
                break;

            case 4:
                num5 = Random.Range(1,37);
                /*
                Instantiate(castListAutumn1[2],transform.position + new Vector3(Random.Range(-1.5f,1.5f), -6.4f,0), Quaternion.identity);
                Instantiate(castListAutumn1[Random.Range(1,6)],transform.position + new Vector3(Random.Range(-1.5f,1.5f), 0f,0), Quaternion.identity);
                Instantiate(castListAutumn1[Random.Range(4,6)],transform.position + new Vector3(Random.Range(-1.5f,1.5f), 6.4f,0), Quaternion.identity);
                /*
                if(Random.Range(0,3) == 0)
                {
                    num5 = Random.Range(1,37);
                }
                else
                {
                    Instantiate(castListAutumn1[Random.Range(1,6)],transform.position + new Vector3(Random.Range(-1.5f,1.5f), -6.4f,0), Quaternion.identity);
                    Instantiate(castListAutumn1[Random.Range(1,6)],transform.position + new Vector3(Random.Range(-1.5f,1.5f), 0f,0), Quaternion.identity);
                    Instantiate(castListAutumn1[Random.Range(1,6)],transform.position + new Vector3(Random.Range(-1.5f,1.5f), 6.4f,0), Quaternion.identity);
                }
                */
                break;
            case 5:
                
                if(Random.Range(0,5) != 0)
                {
                    num5 = aNumList1[Random.Range(0,20)];
                }
                else
                {
                    Instantiate(castListAutumn1[Random.Range(2,6)],transform.position + new Vector3(Random.Range(-1.5f,1.5f), -6.4f,0), Quaternion.identity);
                    Instantiate(castListAutumn1[Random.Range(2,6)],transform.position + new Vector3(Random.Range(-1.5f,1.5f), 0f,0), Quaternion.identity);
                    Instantiate(castListAutumn1[Random.Range(2,6)],transform.position + new Vector3(Random.Range(-1.5f,1.5f), 6.4f,0), Quaternion.identity);
                }
                
                break;

            case 6:
                    Instantiate(castListAutumn1[4],transform.position + new Vector3(Random.Range(-1.5f,1.5f), -6.4f,0), Quaternion.identity);
                    Instantiate(castListAutumn1[4],transform.position + new Vector3(Random.Range(-1.5f,1.5f), 0f,0), Quaternion.identity);
                    Instantiate(castListAutumn1[4],transform.position + new Vector3(Random.Range(-1.5f,1.5f), 6.4f,0), Quaternion.identity);
                break;

            case 7:
                if(Random.Range(0,3) != 0)
                {
                    num5 = Random.Range(1,37);
                }
                else
                {
                    Instantiate(castListAutumn1[Random.Range(1,6)],transform.position + new Vector3(Random.Range(-1.5f,1.5f), -6.4f,0), Quaternion.identity);
                    Instantiate(castListAutumn1[Random.Range(1,6)],transform.position + new Vector3(Random.Range(-1.5f,1.5f), 0f,0), Quaternion.identity);
                    Instantiate(castListAutumn1[Random.Range(1,6)],transform.position + new Vector3(Random.Range(-1.5f,1.5f), 6.4f,0), Quaternion.identity);
                }
                break;

            case 8:
                Instantiate(castListAutumn1[Random.Range(4,6)],transform.position + new Vector3(Random.Range(-1.5f,1.5f), -6.4f,0), Quaternion.identity);
                Instantiate(castListAutumn1[2],transform.position + new Vector3(Random.Range(-1.5f,1.5f), 0f,0), Quaternion.identity);
                Instantiate(castListAutumn1[Random.Range(4,6)],transform.position + new Vector3(Random.Range(-1.5f,1.5f), 6.4f,0), Quaternion.identity);
                break;

            case 9:
                if(Random.Range(0,3) != 0)
                {
                    num5 = Random.Range(1,37);
                }
                else
                {
                    Instantiate(castListAutumn1[Random.Range(1,6)],transform.position + new Vector3(Random.Range(-1.5f,1.5f), -6.4f,0), Quaternion.identity);
                    Instantiate(castListAutumn1[Random.Range(1,6)],transform.position + new Vector3(Random.Range(-1.5f,1.5f), 0f,0), Quaternion.identity);
                    Instantiate(castListAutumn1[Random.Range(1,6)],transform.position + new Vector3(Random.Range(-1.5f,1.5f), 6.4f,0), Quaternion.identity);
                }
                break;

            case 10:
                Instantiate(castListAutumn1[2],transform.position + new Vector3(Random.Range(-1.5f,1.5f), -6.4f,0), Quaternion.identity);
                Instantiate(castListAutumn1[Random.Range(4,6)],transform.position + new Vector3(Random.Range(-1.5f,1.5f), 0f,0), Quaternion.identity);
                Instantiate(castListAutumn1[2],transform.position + new Vector3(Random.Range(-1.5f,1.5f), 6.4f,0), Quaternion.identity);
                
                break;

            case 11:
                num5 = 37;
                break;
        }

        switch(num5)
        {
            case 1:
                Instantiate(castListAutumn1[1],transform.position + new Vector3(-1.5f, -6.4f,0), Quaternion.identity);
                Instantiate(castListAutumn1[1],transform.position + new Vector3(1.5f, 0f,0), Quaternion.identity);
                Instantiate(castListAutumn1[1],transform.position + new Vector3(-1.5f, 6.4f,0), Quaternion.identity);
                break;

            case 2:
                Instantiate(castListAutumn1[1],transform.position + new Vector3(1.5f, -6.4f,0), Quaternion.identity);
                Instantiate(castListAutumn1[1],transform.position + new Vector3(-1.5f, 0f,0), Quaternion.identity);
                Instantiate(castListAutumn1[1],transform.position + new Vector3(1.5f, 6.4f,0), Quaternion.identity);
                break;

            case 3:
                float posX3 = Random.Range(-1.5f,1.5f);
                Instantiate(castListAutumn1[1],transform.position + new Vector3(posX3, -6.4f,0), Quaternion.identity);
                Instantiate(castListAutumn1[1],transform.position + new Vector3(posX3, 0f,0), Quaternion.identity);
                Instantiate(castListAutumn1[1],transform.position + new Vector3(posX3, 6.4f,0), Quaternion.identity);
                break;

            case 4:
                Instantiate(castListAutumn1[1],transform.position + new Vector3(1.5f, -6.4f,0), Quaternion.identity);
                Instantiate(castListAutumn1[1],transform.position + new Vector3(0, 0f,0), Quaternion.identity);
                Instantiate(castListAutumn1[1],transform.position + new Vector3(-1.5f, 6.4f,0), Quaternion.identity);
                break;
                
            case 5:
                Instantiate(castListAutumn1[1],transform.position + new Vector3(-1.5f, -6.4f,0), Quaternion.identity);
                Instantiate(castListAutumn1[1],transform.position + new Vector3(0, 0f,0), Quaternion.identity);
                Instantiate(castListAutumn1[1],transform.position + new Vector3(1.5f, 6.4f,0), Quaternion.identity);
                break;

            case 6:
                Instantiate(castListAutumn1[1],transform.position + new Vector3(1.5f, -6.4f,0), Quaternion.identity);
                Instantiate(castListAutumn1[1],transform.position + new Vector3(1.5f, 0f,0), Quaternion.identity);
                Instantiate(castListAutumn1[1],transform.position + new Vector3(-1.5f, 6.4f,0), Quaternion.identity);
                break;

            case 7:
                Instantiate(castListAutumn1[1],transform.position + new Vector3(-1.5f, -6.4f,0), Quaternion.identity);
                Instantiate(castListAutumn1[1],transform.position + new Vector3(-1.5f, 0f,0), Quaternion.identity);
                Instantiate(castListAutumn1[1],transform.position + new Vector3(1.5f, 6.4f,0), Quaternion.identity);
                break;

            case 8:
                Instantiate(castListAutumn1[1],transform.position + new Vector3(1.5f, -6.4f,0), Quaternion.identity);
                Instantiate(castListAutumn1[1],transform.position + new Vector3(-1.5f, 0f,0), Quaternion.identity);
                Instantiate(castListAutumn1[1],transform.position + new Vector3(-1.5f, 6.4f,0), Quaternion.identity);
                break;

            case 9:
                Instantiate(castListAutumn1[1],transform.position + new Vector3(-1.5f, -6.4f,0), Quaternion.identity);
                Instantiate(castListAutumn1[1],transform.position + new Vector3(1.5f, 0f,0), Quaternion.identity);
                Instantiate(castListAutumn1[1],transform.position + new Vector3(1.5f, 6.4f,0), Quaternion.identity);
                break;

            case 10:
                Instantiate(castListAutumn1[4],transform.position + new Vector3(-1.5f, -6.4f,0), Quaternion.identity);
                Instantiate(castListAutumn1[4],transform.position + new Vector3(1.5f, 0f,0), Quaternion.identity);
                Instantiate(castListAutumn1[4],transform.position + new Vector3(-1.5f, 6.4f,0), Quaternion.identity);
                break;

            case 11:
                Instantiate(castListAutumn1[4],transform.position + new Vector3(1.5f, -6.4f,0), Quaternion.identity);
                Instantiate(castListAutumn1[4],transform.position + new Vector3(-1.5f, 0f,0), Quaternion.identity);
                Instantiate(castListAutumn1[4],transform.position + new Vector3(1.5f, 6.4f,0), Quaternion.identity);
                break;

            case 12:
                float posX12 = Random.Range(-1.5f,1.5f);
                Instantiate(castListAutumn1[4],transform.position + new Vector3(posX12, -6.4f,0), Quaternion.identity);
                Instantiate(castListAutumn1[4],transform.position + new Vector3(posX12, 0f,0), Quaternion.identity);
                Instantiate(castListAutumn1[4],transform.position + new Vector3(posX12, 6.4f,0), Quaternion.identity);
                break;

            case 13:
                Instantiate(castListAutumn1[4],transform.position + new Vector3(1.5f, -6.4f,0), Quaternion.identity);
                Instantiate(castListAutumn1[4],transform.position + new Vector3(0, 0f,0), Quaternion.identity);
                Instantiate(castListAutumn1[4],transform.position + new Vector3(-1.5f, 6.4f,0), Quaternion.identity);
                break;
                
            case 14:
                Instantiate(castListAutumn1[4],transform.position + new Vector3(-1.5f, -6.4f,0), Quaternion.identity);
                Instantiate(castListAutumn1[4],transform.position + new Vector3(0, 0f,0), Quaternion.identity);
                Instantiate(castListAutumn1[4],transform.position + new Vector3(1.5f, 6.4f,0), Quaternion.identity);
                break;

            case 15:
                Instantiate(castListAutumn1[4],transform.position + new Vector3(1.5f, -6.4f,0), Quaternion.identity);
                Instantiate(castListAutumn1[4],transform.position + new Vector3(1.5f, 0f,0), Quaternion.identity);
                Instantiate(castListAutumn1[4],transform.position + new Vector3(-1.5f, 6.4f,0), Quaternion.identity);
                break;

            case 16:
                Instantiate(castListAutumn1[4],transform.position + new Vector3(-1.5f, -6.4f,0), Quaternion.identity);
                Instantiate(castListAutumn1[4],transform.position + new Vector3(-1.5f, 0f,0), Quaternion.identity);
                Instantiate(castListAutumn1[4],transform.position + new Vector3(1.5f, 6.4f,0), Quaternion.identity);
                break;

            case 17:
                Instantiate(castListAutumn1[4],transform.position + new Vector3(1.5f, -6.4f,0), Quaternion.identity);
                Instantiate(castListAutumn1[4],transform.position + new Vector3(-1.5f, 0f,0), Quaternion.identity);
                Instantiate(castListAutumn1[4],transform.position + new Vector3(-1.5f, 6.4f,0), Quaternion.identity);
                break;

            case 18:
                Instantiate(castListAutumn1[4],transform.position + new Vector3(-1.5f, -6.4f,0), Quaternion.identity);
                Instantiate(castListAutumn1[4],transform.position + new Vector3(1.5f, 0f,0), Quaternion.identity);
                Instantiate(castListAutumn1[4],transform.position + new Vector3(1.5f, 6.4f,0), Quaternion.identity);
                break;

            case 19:
                Instantiate(castListAutumn1[5],transform.position + new Vector3(-1.5f, -6.4f,0), Quaternion.identity);
                Instantiate(castListAutumn1[5],transform.position + new Vector3(1.5f, 0f,0), Quaternion.identity);
                Instantiate(castListAutumn1[5],transform.position + new Vector3(-1.5f, 6.4f,0), Quaternion.identity);
                break;

            case 20:
                Instantiate(castListAutumn1[5],transform.position + new Vector3(1.5f, -6.4f,0), Quaternion.identity);
                Instantiate(castListAutumn1[5],transform.position + new Vector3(-1.5f, 0f,0), Quaternion.identity);
                Instantiate(castListAutumn1[5],transform.position + new Vector3(1.5f, 6.4f,0), Quaternion.identity);
                break;

            case 21:
                float posX21 = Random.Range(-1.5f,1.5f);
                Instantiate(castListAutumn1[5],transform.position + new Vector3(posX21, -6.4f,0), Quaternion.identity);
                Instantiate(castListAutumn1[5],transform.position + new Vector3(posX21, 0f,0), Quaternion.identity);
                Instantiate(castListAutumn1[5],transform.position + new Vector3(posX21, 6.4f,0), Quaternion.identity);
                break;

            case 22:
                Instantiate(castListAutumn1[5],transform.position + new Vector3(1.5f, -6.4f,0), Quaternion.identity);
                Instantiate(castListAutumn1[5],transform.position + new Vector3(0, 0f,0), Quaternion.identity);
                Instantiate(castListAutumn1[5],transform.position + new Vector3(-1.5f, 6.4f,0), Quaternion.identity);
                break;
                
            case 23:
                Instantiate(castListAutumn1[5],transform.position + new Vector3(-1.5f, -6.4f,0), Quaternion.identity);
                Instantiate(castListAutumn1[5],transform.position + new Vector3(0, 0f,0), Quaternion.identity);
                Instantiate(castListAutumn1[5],transform.position + new Vector3(1.5f, 6.4f,0), Quaternion.identity);
                break;

            case 24:
                Instantiate(castListAutumn1[5],transform.position + new Vector3(1.5f, -6.4f,0), Quaternion.identity);
                Instantiate(castListAutumn1[5],transform.position + new Vector3(1.5f, 0f,0), Quaternion.identity);
                Instantiate(castListAutumn1[5],transform.position + new Vector3(-1.5f, 6.4f,0), Quaternion.identity);
                break;

            case 25:
                Instantiate(castListAutumn1[5],transform.position + new Vector3(-1.5f, -6.4f,0), Quaternion.identity);
                Instantiate(castListAutumn1[5],transform.position + new Vector3(-1.5f, 0f,0), Quaternion.identity);
                Instantiate(castListAutumn1[5],transform.position + new Vector3(1.5f, 6.4f,0), Quaternion.identity);
                break;

            case 26:
                Instantiate(castListAutumn1[5],transform.position + new Vector3(1.5f, -6.4f,0), Quaternion.identity);
                Instantiate(castListAutumn1[5],transform.position + new Vector3(-1.5f, 0f,0), Quaternion.identity);
                Instantiate(castListAutumn1[5],transform.position + new Vector3(-1.5f, 6.4f,0), Quaternion.identity);
                break;

            case 27:
                Instantiate(castListAutumn1[5],transform.position + new Vector3(-1.5f, -6.4f,0), Quaternion.identity);
                Instantiate(castListAutumn1[5],transform.position + new Vector3(1.5f, 0f,0), Quaternion.identity);
                Instantiate(castListAutumn1[5],transform.position + new Vector3(1.5f, 6.4f,0), Quaternion.identity);
                break;

            case 28:
                Instantiate(castListAutumn1[4],transform.position + new Vector3(0, -6.4f,0), Quaternion.identity);
                Instantiate(castListAutumn1[5],transform.position + new Vector3(0, 0f,0), Quaternion.identity);
                Instantiate(castListAutumn1[4],transform.position + new Vector3(0, 6.4f,0), Quaternion.identity);
                break;

            case 29:
                float posX29 = Random.Range(-1.5f,1.5f);
                Instantiate(castListAutumn1[1],transform.position + new Vector3(posX29, -3.2f,0), Quaternion.identity);
                Instantiate(castListAutumn1[1],transform.position + new Vector3(posX29, 0f,0), Quaternion.identity);
                Instantiate(castListAutumn1[1],transform.position + new Vector3(posX29, 1.6f,0), Quaternion.identity);
                Instantiate(castListAutumn1[1],transform.position + new Vector3(posX29, 3.2f,0), Quaternion.identity);
                Instantiate(castListAutumn1[1],transform.position + new Vector3(posX29, 4.8f,0), Quaternion.identity);
                Instantiate(castListAutumn1[1],transform.position + new Vector3(posX29, 6.4f,0), Quaternion.identity);
                break;

            case 30:
                Instantiate(castListAutumn1[1],transform.position + new Vector3(-1.5f, 0f,0), Quaternion.identity);
                Instantiate(castListAutumn1[1],transform.position + new Vector3(-0.75f, 1.6f,0), Quaternion.identity);
                Instantiate(castListAutumn1[1],transform.position + new Vector3(0, 3.2f,0), Quaternion.identity);
                Instantiate(castListAutumn1[1],transform.position + new Vector3(0.75f, 4.8f,0), Quaternion.identity);
                Instantiate(castListAutumn1[1],transform.position + new Vector3(1.5f, 6.4f,0), Quaternion.identity);
                break;

            case 31:
                Instantiate(castListAutumn1[1],transform.position + new Vector3(1.5f, 0f,0), Quaternion.identity);
                Instantiate(castListAutumn1[1],transform.position + new Vector3(0.75f, 1.6f,0), Quaternion.identity);
                Instantiate(castListAutumn1[1],transform.position + new Vector3(0, 3.2f,0), Quaternion.identity);
                Instantiate(castListAutumn1[1],transform.position + new Vector3(-0.75f, 4.8f,0), Quaternion.identity);
                Instantiate(castListAutumn1[1],transform.position + new Vector3(-1.5f, 6.4f,0), Quaternion.identity);
                break;
            
            case 32:
                Instantiate(castListAutumn1[5],transform.position + new Vector3(Random.Range(-1.5f,1.5f), -6.4f,0), Quaternion.identity);
                Instantiate(castListRare[Random.Range(0,2)],transform.position + new Vector3(Random.Range(-1.5f,1.5f), 0f,0), Quaternion.identity);
                Instantiate(castListAutumn1[5],transform.position + new Vector3(Random.Range(-1.5f,1.5f), 6.4f,0), Quaternion.identity);
                break;

            case 33:
                Instantiate(castListAutumn1[5],transform.position + new Vector3(Random.Range(-1.5f,1.5f), -6.4f,0), Quaternion.identity);
                Instantiate(castListRare[Random.Range(0,2)],transform.position + new Vector3(Random.Range(-1.5f,1.5f), 0f,0), Quaternion.identity);
                Instantiate(castListAutumn1[5],transform.position + new Vector3(Random.Range(-1.5f,1.5f), 6.4f,0), Quaternion.identity);   
                break;

            case 34:
                float posX34 = Random.Range(-1.5f,1.5f);
                if(Random.Range(0,2) == 1)
                {
                    Instantiate(castListAutumn1[1],transform.position + new Vector3(posX34, -3.2f,0), Quaternion.identity);
                    spawnCount++;
                }
                if(Random.Range(0,2) == 1)
                {
                    Instantiate(castListAutumn1[1],transform.position + new Vector3(posX34, 0f,0), Quaternion.identity);
                    spawnCount++;
                }
                if(Random.Range(0,2) == 1)
                {
                    Instantiate(castListAutumn1[1],transform.position + new Vector3(posX34, 1.6f,0), Quaternion.identity);
                    spawnCount++;
                }
                if(Random.Range(0,2) == 1)
                {
                    Instantiate(castListAutumn1[1],transform.position + new Vector3(posX34, 3.2f,0), Quaternion.identity);
                    spawnCount++;
                }
                if(Random.Range(0,2) == 1)
                {
                    Instantiate(castListAutumn1[1],transform.position + new Vector3(posX34, 4.8f,0), Quaternion.identity);
                    spawnCount++;
                }
                if(Random.Range(0,2) == 1)
                {
                    Instantiate(castListAutumn1[1],transform.position + new Vector3(posX34, 6.4f,0), Quaternion.identity);
                    spawnCount++;
                }
                if(spawnCount < 3)
                {
                    Instantiate(castListAutumn1[1],transform.position + new Vector3(posX34, 3.2f,0), Quaternion.identity);
                    Instantiate(castListAutumn1[1],transform.position + new Vector3(posX34, 4.8f,0), Quaternion.identity);
                    Instantiate(castListAutumn1[1],transform.position + new Vector3(posX34, 6.4f,0), Quaternion.identity);
                }
                break;

            case 35:
                if(Random.Range(0,2) == 1)
                {
                    Instantiate(castListAutumn1[1],transform.position + new Vector3(-1.5f, 0f,0), Quaternion.identity);
                    spawnCount++;
                }
                if(Random.Range(0,2) == 1)
                {
                    Instantiate(castListAutumn1[1],transform.position + new Vector3(-0.75f, 1.6f,0), Quaternion.identity);
                    spawnCount++;
                }
                if(Random.Range(0,2) == 1)
                {
                    Instantiate(castListAutumn1[1],transform.position + new Vector3(0, 3.2f,0), Quaternion.identity);
                    spawnCount++;
                }
                if(Random.Range(0,2) == 1)
                {
                    Instantiate(castListAutumn1[1],transform.position + new Vector3(0.75f, 4.8f,0), Quaternion.identity);
                    spawnCount++;
                }
                if(Random.Range(0,2) == 1)
                {
                    Instantiate(castListAutumn1[1],transform.position + new Vector3(1.5f, 6.4f,0), Quaternion.identity);
                    spawnCount++;
                }
                if(spawnCount < 3)
                {
                    Instantiate(castListAutumn1[1],transform.position + new Vector3(0, 3.2f,0), Quaternion.identity);
                    Instantiate(castListAutumn1[1],transform.position + new Vector3(0.75f, 4.8f,0), Quaternion.identity);
                    Instantiate(castListAutumn1[1],transform.position + new Vector3(1.5f, 6.4f,0), Quaternion.identity);
                }
                break;

            case 36:
                if(Random.Range(0,2) == 1)
                {
                    Instantiate(castListAutumn1[1],transform.position + new Vector3(1.5f, 0f,0), Quaternion.identity);
                    spawnCount++;
                }
                if(Random.Range(0,2) == 1)
                {
                    Instantiate(castListAutumn1[1],transform.position + new Vector3(0.75f, 1.6f,0), Quaternion.identity);
                    spawnCount++;
                }
                if(Random.Range(0,2) == 1)
                {
                    Instantiate(castListAutumn1[1],transform.position + new Vector3(0, 3.2f,0), Quaternion.identity);
                    spawnCount++;
                }
                if(Random.Range(0,2) == 1)
                {
                    Instantiate(castListAutumn1[1],transform.position + new Vector3(-0.75f, 4.8f,0), Quaternion.identity);
                    spawnCount++;
                }
                if(Random.Range(0,2) == 1)
                {
                    Instantiate(castListAutumn1[1],transform.position + new Vector3(-1.5f, 6.4f,0), Quaternion.identity);
                    spawnCount++;
                }
                if(spawnCount < 3)
                {
                    Instantiate(castListAutumn1[1],transform.position + new Vector3(0, 3.2f,0), Quaternion.identity);
                    Instantiate(castListAutumn1[1],transform.position + new Vector3(-0.75f, 4.8f,0), Quaternion.identity);
                    Instantiate(castListAutumn1[1],transform.position + new Vector3(-1.5f, 6.4f,0), Quaternion.identity);

                }
                break;

            case 37:
                Instantiate(castListAutumn1[2],transform.position + new Vector3(-1.5f, -6.4f,0), Quaternion.identity);
                Instantiate(castListRare[0],transform.position + new Vector3(1.5f, 0f,0), Quaternion.identity);
                Instantiate(castListRare[0],transform.position + new Vector3(-1.5f, 6.4f,0), Quaternion.identity);
                break;
        }
    }

    public void MakeStageCast4(int num)
    {
        /*
        if(num >= 5)
        {
            num = 5;
        }
        */
        int num5 = 0;
        int spawnCount = 0;
        float varPosX = Random.Range(-1.5f,1.5f);
        switch(num)
        {
            case 0:
                int shoteEraseNum = Random.Range(0,3);
                if(shoteEraseNum != 0){
                    Instantiate(shoteBomber,transform.position + new Vector3(Random.Range(-1.5f,1.5f), -6.4f,0), Quaternion.identity);
                }
                else{
                    Instantiate(castListWinter1[2],transform.position + new Vector3(Random.Range(-1.5f,1.5f), -6.4f,0), Quaternion.identity);;
                }

                if(shoteEraseNum != 1){
                    Instantiate(shoteBomber,transform.position + new Vector3(Random.Range(-1.5f,1.5f), 0,0), Quaternion.identity);
                }
                else{
                    Instantiate(castListWinter1[2],transform.position + new Vector3(Random.Range(-1.5f,1.5f), 0f,0), Quaternion.identity);;
                }

                if(shoteEraseNum != 2){
                    Instantiate(shoteBomber,transform.position + new Vector3(Random.Range(-1.5f,1.5f), 6.4f,0), Quaternion.identity);
                }
                else{
                    Instantiate(castListWinter1[2],transform.position + new Vector3(Random.Range(-1.5f,1.5f), 6.4f,0), Quaternion.identity);;
                }
                
                break;
                
            case 1:
                Instantiate(castListWinter1[Random.Range(1,3)],transform.position + new Vector3(Random.Range(-1.5f,1.5f), -6.4f,0), Quaternion.identity);
                Instantiate(castListWinter1[Random.Range(1,3)],transform.position + new Vector3(Random.Range(-1.5f,1.5f), 0f,0), Quaternion.identity);
                Instantiate(castListWinter1[Random.Range(1,3)],transform.position + new Vector3(Random.Range(-1.5f,1.5f), 6.4f,0), Quaternion.identity);
                break;

            case 2:
                Instantiate(castListWinter1[Random.Range(3,5)],transform.position + new Vector3(Random.Range(-1.5f,1.5f), -6.4f,0), Quaternion.identity);
                Instantiate(castListWinter1[Random.Range(3,5)],transform.position + new Vector3(Random.Range(-1.5f,1.5f), 0f,0), Quaternion.identity);
                Instantiate(castListWinter1[Random.Range(3,5)],transform.position + new Vector3(Random.Range(-1.5f,1.5f), 6.4f,0), Quaternion.identity);
                break;

            case 3:
                if(Random.Range(0,5) == 0)
                {
                    num5 = Random.Range(1,43);
                }
                else
                {
                    Instantiate(castListWinter1[Random.Range(1,5)],transform.position + new Vector3(Random.Range(-1.5f,1.5f), -6.4f,0), Quaternion.identity);
                    Instantiate(castListWinter1[Random.Range(1,5)],transform.position + new Vector3(Random.Range(-1.5f,1.5f), 0f,0), Quaternion.identity);
                    Instantiate(castListWinter1[Random.Range(1,5)],transform.position + new Vector3(Random.Range(-1.5f,1.5f), 6.4f,0), Quaternion.identity);
                }
                break;

            case 4:
                num5 = Random.Range(1,43);
                break;

            case 5:
                if(Random.Range(0,5) != 0)
                {
                    num5 = wNumList1[Random.Range(0,25)];
                }
                else
                {
                    Instantiate(castListWinter1[Random.Range(2,5)],transform.position + new Vector3(Random.Range(-1.5f,1.5f), -6.4f,0), Quaternion.identity);
                    Instantiate(castListWinter1[Random.Range(2,5)],transform.position + new Vector3(Random.Range(-1.5f,1.5f), 0f,0), Quaternion.identity);
                    Instantiate(castListWinter1[Random.Range(2,5)],transform.position + new Vector3(Random.Range(-1.5f,1.5f), 6.4f,0), Quaternion.identity);
                }
                
                break;

            case 6:
                if(Random.Range(0,2) == 0)
                {
                    num5 = Random.Range(1,43);
                }
                else
                {
                    Instantiate(castListWinter1[Random.Range(1,5)],transform.position + new Vector3(Random.Range(-1.5f,1.5f), -6.4f,0), Quaternion.identity);
                    Instantiate(castListWinter1[Random.Range(1,5)],transform.position + new Vector3(Random.Range(-1.5f,1.5f), 0f,0), Quaternion.identity);
                    Instantiate(castListWinter1[Random.Range(1,5)],transform.position + new Vector3(Random.Range(-1.5f,1.5f), 6.4f,0), Quaternion.identity);
                }
                break;

            case 7:
                Instantiate(castListWinter1[3],transform.position + new Vector3(Random.Range(-1.5f,1.5f), -6.4f,0), Quaternion.identity);
                Instantiate(castListWinter1[3],transform.position + new Vector3(Random.Range(-1.5f,1.5f), 0f,0), Quaternion.identity);
                Instantiate(castListWinter1[3],transform.position + new Vector3(Random.Range(-1.5f,1.5f), 6.4f,0), Quaternion.identity);
                break;

            case 8:
                if(Random.Range(0,2) == 0)
                {
                    num5 = Random.Range(1,43);
                }
                else
                {
                    Instantiate(castListWinter1[Random.Range(1,5)],transform.position + new Vector3(Random.Range(-1.5f,1.5f), -6.4f,0), Quaternion.identity);
                    Instantiate(castListWinter1[Random.Range(1,5)],transform.position + new Vector3(Random.Range(-1.5f,1.5f), 0f,0), Quaternion.identity);
                    Instantiate(castListWinter1[Random.Range(1,5)],transform.position + new Vector3(Random.Range(-1.5f,1.5f), 6.4f,0), Quaternion.identity);
                }
                break;
            
            case 9:
                Instantiate(castListWinter1[Random.Range(3,5)],transform.position + new Vector3(Random.Range(-1.5f,1.5f), -6.4f,0), Quaternion.identity);
                Instantiate(castListWinter1[Random.Range(3,5)],transform.position + new Vector3(Random.Range(-1.5f,1.5f), 0f,0), Quaternion.identity);
                Instantiate(castListWinter1[Random.Range(3,5)],transform.position + new Vector3(Random.Range(-1.5f,1.5f), 6.4f,0), Quaternion.identity);
                break;

            case 10:
                Instantiate(castListWinter1[Random.Range(3,5)],transform.position + new Vector3(Random.Range(-1.5f,1.5f), -6.4f,0), Quaternion.identity);
                Instantiate(castListWinter1[Random.Range(3,5)],transform.position + new Vector3(Random.Range(-1.5f,1.5f), 0f,0), Quaternion.identity);
                Instantiate(castListWinter1[Random.Range(3,5)],transform.position + new Vector3(Random.Range(-1.5f,1.5f), 6.4f,0), Quaternion.identity);
                break;
            
            case 11:
                num5 = 43; 
                
                break;
        }

        switch(num5)
        {
            case 1:
                Instantiate(castListWinter1[1],transform.position + new Vector3(-1.5f, -6.4f,0), Quaternion.identity);
                Instantiate(castListWinter1[1],transform.position + new Vector3(1.5f, 0f,0), Quaternion.identity);
                Instantiate(castListWinter1[1],transform.position + new Vector3(-1.5f, 6.4f,0), Quaternion.identity);
                break;

            case 2:
                Instantiate(castListWinter1[1],transform.position + new Vector3(1.5f, -6.4f,0), Quaternion.identity);
                Instantiate(castListWinter1[1],transform.position + new Vector3(-1.5f, 0f,0), Quaternion.identity);
                Instantiate(castListWinter1[1],transform.position + new Vector3(1.5f, 6.4f,0), Quaternion.identity);
                break;

            case 3:
                float posX3 = Random.Range(-1.5f,1.5f);
                Instantiate(castListWinter1[1],transform.position + new Vector3(posX3, -6.4f,0), Quaternion.identity);
                Instantiate(castListWinter1[1],transform.position + new Vector3(posX3, 0f,0), Quaternion.identity);
                Instantiate(castListWinter1[1],transform.position + new Vector3(posX3, 6.4f,0), Quaternion.identity);
                break;

            case 4:
                Instantiate(castListWinter1[1],transform.position + new Vector3(1.5f, -6.4f,0), Quaternion.identity);
                Instantiate(castListWinter1[1],transform.position + new Vector3(0, 0f,0), Quaternion.identity);
                Instantiate(castListWinter1[1],transform.position + new Vector3(-1.5f, 6.4f,0), Quaternion.identity);
                break;
                
            case 5:
                Instantiate(castListWinter1[1],transform.position + new Vector3(-1.5f, -6.4f,0), Quaternion.identity);
                Instantiate(castListWinter1[1],transform.position + new Vector3(0, 0f,0), Quaternion.identity);
                Instantiate(castListWinter1[1],transform.position + new Vector3(1.5f, 6.4f,0), Quaternion.identity);
                break;

            case 6:
                Instantiate(castListWinter1[1],transform.position + new Vector3(1.5f, -6.4f,0), Quaternion.identity);
                Instantiate(castListWinter1[1],transform.position + new Vector3(1.5f, 0f,0), Quaternion.identity);
                Instantiate(castListWinter1[1],transform.position + new Vector3(-1.5f, 6.4f,0), Quaternion.identity);
                break;

            case 7:
                Instantiate(castListWinter1[1],transform.position + new Vector3(-1.5f, -6.4f,0), Quaternion.identity);
                Instantiate(castListWinter1[1],transform.position + new Vector3(-1.5f, 0f,0), Quaternion.identity);
                Instantiate(castListWinter1[1],transform.position + new Vector3(1.5f, 6.4f,0), Quaternion.identity);
                break;

            case 8:
                Instantiate(castListWinter1[1],transform.position + new Vector3(1.5f, -6.4f,0), Quaternion.identity);
                Instantiate(castListWinter1[1],transform.position + new Vector3(-1.5f, 0f,0), Quaternion.identity);
                Instantiate(castListWinter1[1],transform.position + new Vector3(-1.5f, 6.4f,0), Quaternion.identity);
                break;

            case 9:
                Instantiate(castListWinter1[1],transform.position + new Vector3(-1.5f, -6.4f,0), Quaternion.identity);
                Instantiate(castListWinter1[1],transform.position + new Vector3(1.5f, 0f,0), Quaternion.identity);
                Instantiate(castListWinter1[1],transform.position + new Vector3(1.5f, 6.4f,0), Quaternion.identity);
                break;

            case 10:
                Instantiate(castListWinter1[4],transform.position + new Vector3(-1.5f, -6.4f,0), Quaternion.identity);
                Instantiate(castListWinter1[4],transform.position + new Vector3(1.5f, 0f,0), Quaternion.identity);
                Instantiate(castListWinter1[4],transform.position + new Vector3(-1.5f, 6.4f,0), Quaternion.identity);
                break;

            case 11:
                Instantiate(castListWinter1[4],transform.position + new Vector3(1.5f, -6.4f,0), Quaternion.identity);
                Instantiate(castListWinter1[4],transform.position + new Vector3(-1.5f, 0f,0), Quaternion.identity);
                Instantiate(castListWinter1[4],transform.position + new Vector3(1.5f, 6.4f,0), Quaternion.identity);
                break;

            case 12:
                float posX12 = Random.Range(-1.5f,1.5f);
                Instantiate(castListWinter1[4],transform.position + new Vector3(posX12, -6.4f,0), Quaternion.identity);
                Instantiate(castListWinter1[4],transform.position + new Vector3(posX12, 0f,0), Quaternion.identity);
                Instantiate(castListWinter1[4],transform.position + new Vector3(posX12, 6.4f,0), Quaternion.identity);
                break;

            case 13:
                Instantiate(castListWinter1[4],transform.position + new Vector3(1.5f, -6.4f,0), Quaternion.identity);
                Instantiate(castListWinter1[4],transform.position + new Vector3(0, 0f,0), Quaternion.identity);
                Instantiate(castListWinter1[4],transform.position + new Vector3(-1.5f, 6.4f,0), Quaternion.identity);
                break;
                
            case 14:
                Instantiate(castListWinter1[4],transform.position + new Vector3(-1.5f, -6.4f,0), Quaternion.identity);
                Instantiate(castListWinter1[4],transform.position + new Vector3(0, 0f,0), Quaternion.identity);
                Instantiate(castListWinter1[4],transform.position + new Vector3(1.5f, 6.4f,0), Quaternion.identity);
                break;

            case 15:
                Instantiate(castListWinter1[4],transform.position + new Vector3(1.5f, -6.4f,0), Quaternion.identity);
                Instantiate(castListWinter1[4],transform.position + new Vector3(1.5f, 0f,0), Quaternion.identity);
                Instantiate(castListWinter1[4],transform.position + new Vector3(-1.5f, 6.4f,0), Quaternion.identity);
                break;

            case 16:
                Instantiate(castListWinter1[4],transform.position + new Vector3(-1.5f, -6.4f,0), Quaternion.identity);
                Instantiate(castListWinter1[4],transform.position + new Vector3(-1.5f, 0f,0), Quaternion.identity);
                Instantiate(castListWinter1[4],transform.position + new Vector3(1.5f, 6.4f,0), Quaternion.identity);
                break;

            case 17:
                Instantiate(castListWinter1[4],transform.position + new Vector3(1.5f, -6.4f,0), Quaternion.identity);
                Instantiate(castListWinter1[4],transform.position + new Vector3(-1.5f, 0f,0), Quaternion.identity);
                Instantiate(castListWinter1[4],transform.position + new Vector3(-1.5f, 6.4f,0), Quaternion.identity);
                break;

            case 18:
                Instantiate(castListWinter1[4],transform.position + new Vector3(-1.5f, -6.4f,0), Quaternion.identity);
                Instantiate(castListWinter1[4],transform.position + new Vector3(1.5f, 0f,0), Quaternion.identity);
                Instantiate(castListWinter1[4],transform.position + new Vector3(1.5f, 6.4f,0), Quaternion.identity);
                break;

            case 19:
                Instantiate(castListWinter1[3],transform.position + new Vector3(-1.5f, -6.4f,0), Quaternion.identity);
                Instantiate(castListWinter1[3],transform.position + new Vector3(1.5f, 0f,0), Quaternion.identity);
                Instantiate(castListWinter1[3],transform.position + new Vector3(-1.5f, 6.4f,0), Quaternion.identity);
                break;

            case 20:
                Instantiate(castListWinter1[3],transform.position + new Vector3(1.5f, -6.4f,0), Quaternion.identity);
                Instantiate(castListWinter1[3],transform.position + new Vector3(-1.5f, 0f,0), Quaternion.identity);
                Instantiate(castListWinter1[3],transform.position + new Vector3(1.5f, 6.4f,0), Quaternion.identity);
                break;

            case 21:
                float posX21 = Random.Range(-1.5f,1.5f);
                Instantiate(castListWinter1[3],transform.position + new Vector3(posX21, -6.4f,0), Quaternion.identity);
                Instantiate(castListWinter1[3],transform.position + new Vector3(posX21, 0f,0), Quaternion.identity);
                Instantiate(castListWinter1[3],transform.position + new Vector3(posX21, 6.4f,0), Quaternion.identity);
                break;

            case 22:
                Instantiate(castListWinter1[3],transform.position + new Vector3(1.5f, -6.4f,0), Quaternion.identity);
                Instantiate(castListWinter1[3],transform.position + new Vector3(0, 0f,0), Quaternion.identity);
                Instantiate(castListWinter1[3],transform.position + new Vector3(-1.5f, 6.4f,0), Quaternion.identity);
                break;
                
            case 23:
                Instantiate(castListWinter1[3],transform.position + new Vector3(-1.5f, -6.4f,0), Quaternion.identity);
                Instantiate(castListWinter1[3],transform.position + new Vector3(0, 0f,0), Quaternion.identity);
                Instantiate(castListWinter1[3],transform.position + new Vector3(1.5f, 6.4f,0), Quaternion.identity);
                break;

            case 24:
                Instantiate(castListWinter1[3],transform.position + new Vector3(1.5f, -6.4f,0), Quaternion.identity);
                Instantiate(castListWinter1[3],transform.position + new Vector3(1.5f, 0f,0), Quaternion.identity);
                Instantiate(castListWinter1[3],transform.position + new Vector3(-1.5f, 6.4f,0), Quaternion.identity);
                break;

            case 25:
                Instantiate(castListWinter1[3],transform.position + new Vector3(-1.5f, -6.4f,0), Quaternion.identity);
                Instantiate(castListWinter1[3],transform.position + new Vector3(-1.5f, 0f,0), Quaternion.identity);
                Instantiate(castListWinter1[3],transform.position + new Vector3(1.5f, 6.4f,0), Quaternion.identity);
                break;

            case 26:
                Instantiate(castListWinter1[3],transform.position + new Vector3(1.5f, -6.4f,0), Quaternion.identity);
                Instantiate(castListWinter1[3],transform.position + new Vector3(-1.5f, 0f,0), Quaternion.identity);
                Instantiate(castListWinter1[3],transform.position + new Vector3(-1.5f, 6.4f,0), Quaternion.identity);
                break;

            case 27:
                Instantiate(castListWinter1[3],transform.position + new Vector3(-1.5f, -6.4f,0), Quaternion.identity);
                Instantiate(castListWinter1[3],transform.position + new Vector3(1.5f, 0f,0), Quaternion.identity);
                Instantiate(castListWinter1[3],transform.position + new Vector3(1.5f, 6.4f,0), Quaternion.identity);
                break;

            case 28:
                Instantiate(castListWinter1[3],transform.position + new Vector3(0, -6.4f,0), Quaternion.identity);
                Instantiate(castListWinter1[4],transform.position + new Vector3(0, 0f,0), Quaternion.identity);
                Instantiate(castListWinter1[3],transform.position + new Vector3(0, 6.4f,0), Quaternion.identity);
                break;

            case 29:
                float posX29 = Random.Range(-1.5f,1.5f);
                Instantiate(castListWinter1[1],transform.position + new Vector3(posX29, -3.2f,0), Quaternion.identity);
                Instantiate(castListWinter1[1],transform.position + new Vector3(posX29, 0f,0), Quaternion.identity);
                Instantiate(castListWinter1[1],transform.position + new Vector3(posX29, 1.6f,0), Quaternion.identity);
                Instantiate(castListWinter1[1],transform.position + new Vector3(posX29, 3.2f,0), Quaternion.identity);
                Instantiate(castListWinter1[1],transform.position + new Vector3(posX29, 4.8f,0), Quaternion.identity);
                Instantiate(castListWinter1[1],transform.position + new Vector3(posX29, 6.4f,0), Quaternion.identity);
                break;

            case 30:
                Instantiate(castListWinter1[1],transform.position + new Vector3(-1.5f, 0f,0), Quaternion.identity);
                Instantiate(castListWinter1[1],transform.position + new Vector3(-0.75f, 1.6f,0), Quaternion.identity);
                Instantiate(castListWinter1[1],transform.position + new Vector3(0, 3.2f,0), Quaternion.identity);
                Instantiate(castListWinter1[1],transform.position + new Vector3(0.75f, 4.8f,0), Quaternion.identity);
                Instantiate(castListWinter1[1],transform.position + new Vector3(1.5f, 6.4f,0), Quaternion.identity);
                break;

            case 31:
                Instantiate(castListWinter1[1],transform.position + new Vector3(1.5f, 0f,0), Quaternion.identity);
                Instantiate(castListWinter1[1],transform.position + new Vector3(0.75f, 1.6f,0), Quaternion.identity);
                Instantiate(castListWinter1[1],transform.position + new Vector3(0, 3.2f,0), Quaternion.identity);
                Instantiate(castListWinter1[1],transform.position + new Vector3(-0.75f, 4.8f,0), Quaternion.identity);
                Instantiate(castListWinter1[1],transform.position + new Vector3(-1.5f, 6.4f,0), Quaternion.identity);
                break;
            
            case 32:
                float posX5 = Random.Range(-1.5f,1.5f);
                Instantiate(castListWinter1[4],transform.position + new Vector3(posX5, -3.2f,0), Quaternion.identity);
                Instantiate(castListWinter1[4],transform.position + new Vector3(posX5, 0f,0), Quaternion.identity);
                Instantiate(castListWinter1[4],transform.position + new Vector3(posX5, 1.6f,0), Quaternion.identity);
                Instantiate(castListWinter1[4],transform.position + new Vector3(posX5, 3.2f,0), Quaternion.identity);
                Instantiate(castListWinter1[4],transform.position + new Vector3(posX5, 4.8f,0), Quaternion.identity);
                Instantiate(castListWinter1[4],transform.position + new Vector3(posX5, 6.4f,0), Quaternion.identity);
                break;

            case 33:
                Instantiate(castListWinter1[4],transform.position + new Vector3(-1.5f, 0f,0), Quaternion.identity);
                Instantiate(castListWinter1[4],transform.position + new Vector3(-0.75f, 1.6f,0), Quaternion.identity);
                Instantiate(castListWinter1[4],transform.position + new Vector3(0, 3.2f,0), Quaternion.identity);
                Instantiate(castListWinter1[4],transform.position + new Vector3(0.75f, 4.8f,0), Quaternion.identity);
                Instantiate(castListWinter1[4],transform.position + new Vector3(1.5f, 6.4f,0), Quaternion.identity);
                break;

            case 34:
                Instantiate(castListWinter1[4],transform.position + new Vector3(1.5f, 0f,0), Quaternion.identity);
                Instantiate(castListWinter1[4],transform.position + new Vector3(0.75f, 1.6f,0), Quaternion.identity);
                Instantiate(castListWinter1[4],transform.position + new Vector3(0, 3.2f,0), Quaternion.identity);
                Instantiate(castListWinter1[4],transform.position + new Vector3(-0.75f, 4.8f,0), Quaternion.identity);
                Instantiate(castListWinter1[4],transform.position + new Vector3(-1.5f, 6.4f,0), Quaternion.identity);
                break;

            case 35:
                Instantiate(castListWinter1[4],transform.position + new Vector3(Random.Range(-1.5f,1.5f), -6.4f,0), Quaternion.identity);
                Instantiate(castListRare[Random.Range(0,2)],transform.position + new Vector3(Random.Range(-1.5f,1.5f), 0f,0), Quaternion.identity);
                Instantiate(castListWinter1[4],transform.position + new Vector3(Random.Range(-1.5f,1.5f), 6.4f,0), Quaternion.identity);
                break;

            case 36:
                Instantiate(castListWinter1[4],transform.position + new Vector3(Random.Range(-1.5f,1.5f), -6.4f,0), Quaternion.identity);
                Instantiate(castListRare[Random.Range(0,2)],transform.position + new Vector3(Random.Range(-1.5f,1.5f), 0f,0), Quaternion.identity);
                Instantiate(castListWinter1[4],transform.position + new Vector3(Random.Range(-1.5f,1.5f), 6.4f,0), Quaternion.identity);   
                break;

            case 37:
                float posX37 = Random.Range(-1.5f,1.5f);
                if(Random.Range(0,2) == 1)
                {
                    Instantiate(castListWinter1[1],transform.position + new Vector3(posX37, -3.2f,0), Quaternion.identity);
                    spawnCount++;
                }
                if(Random.Range(0,2) == 1)
                {
                    Instantiate(castListWinter1[1],transform.position + new Vector3(posX37, 0f,0), Quaternion.identity);
                    spawnCount++;
                }
                if(Random.Range(0,2) == 1)
                {
                    Instantiate(castListWinter1[1],transform.position + new Vector3(posX37, 1.6f,0), Quaternion.identity);
                    spawnCount++;
                }
                if(Random.Range(0,2) == 1)
                {
                    Instantiate(castListWinter1[1],transform.position + new Vector3(posX37, 3.2f,0), Quaternion.identity);
                    spawnCount++;
                }
                if(Random.Range(0,2) == 1)
                {
                    Instantiate(castListWinter1[1],transform.position + new Vector3(posX37, 4.8f,0), Quaternion.identity);
                    spawnCount++;
                }
                if(Random.Range(0,2) == 1)
                {
                    Instantiate(castListWinter1[1],transform.position + new Vector3(posX37, 6.4f,0), Quaternion.identity);
                    spawnCount++;
                }
                if(spawnCount < 3)
                {
                    Instantiate(castListWinter1[1],transform.position + new Vector3(posX37, 3.2f,0), Quaternion.identity);
                    Instantiate(castListWinter1[1],transform.position + new Vector3(posX37, 4.8f,0), Quaternion.identity);
                    Instantiate(castListWinter1[1],transform.position + new Vector3(posX37, 6.4f,0), Quaternion.identity);

                }
                break;

            case 38:
                if(Random.Range(0,2) == 1)
                {
                    Instantiate(castListWinter1[1],transform.position + new Vector3(-1.5f, 0f,0), Quaternion.identity);
                    spawnCount++;
                }
                if(Random.Range(0,2) == 1)
                {
                    Instantiate(castListWinter1[1],transform.position + new Vector3(-0.75f, 1.6f,0), Quaternion.identity);
                    spawnCount++;
                }
                if(Random.Range(0,2) == 1)
                {
                    Instantiate(castListWinter1[1],transform.position + new Vector3(0, 3.2f,0), Quaternion.identity);
                    spawnCount++;
                }
                if(Random.Range(0,2) == 1)
                {
                    Instantiate(castListWinter1[1],transform.position + new Vector3(0.75f, 4.8f,0), Quaternion.identity);
                    spawnCount++;
                }
                if(Random.Range(0,2) == 1)
                {
                    Instantiate(castListWinter1[1],transform.position + new Vector3(1.5f, 6.4f,0), Quaternion.identity);
                    spawnCount++;
                }
                if(spawnCount < 3)
                {
                    Instantiate(castListWinter1[1],transform.position + new Vector3(0, 3.2f,0), Quaternion.identity);
                    Instantiate(castListWinter1[1],transform.position + new Vector3(0.75f, 4.8f,0), Quaternion.identity);
                    Instantiate(castListWinter1[1],transform.position + new Vector3(1.5f, 6.4f,0), Quaternion.identity);

                }
                break;

            case 39:
                if(Random.Range(0,2) == 1)
                {
                    Instantiate(castListWinter1[1],transform.position + new Vector3(1.5f, 0f,0), Quaternion.identity);
                    spawnCount++;
                }
                if(Random.Range(0,2) == 1)
                {
                    Instantiate(castListWinter1[1],transform.position + new Vector3(0.75f, 1.6f,0), Quaternion.identity);
                    spawnCount++;
                }
                if(Random.Range(0,2) == 1)
                {
                    Instantiate(castListWinter1[1],transform.position + new Vector3(0, 3.2f,0), Quaternion.identity);
                    spawnCount++;
                }
                if(Random.Range(0,2) == 1)
                {
                    Instantiate(castListWinter1[1],transform.position + new Vector3(-0.75f, 4.8f,0), Quaternion.identity);
                    spawnCount++;
                }
                if(Random.Range(0,2) == 1)
                {
                    Instantiate(castListWinter1[1],transform.position + new Vector3(-1.5f, 6.4f,0), Quaternion.identity);
                    spawnCount++;
                }
                if(spawnCount < 3)
                {
                    Instantiate(castListWinter1[1],transform.position + new Vector3(0, 3.2f,0), Quaternion.identity);
                    Instantiate(castListWinter1[1],transform.position + new Vector3(-0.75f, 4.8f,0), Quaternion.identity);
                    Instantiate(castListWinter1[1],transform.position + new Vector3(-1.5f, 6.4f,0), Quaternion.identity);

                }
                break;
            
            case 40:
                float posX40 = Random.Range(-1.5f,1.5f);
                if(Random.Range(0,2) == 1)
                {
                    Instantiate(castListWinter1[4],transform.position + new Vector3(posX40, -3.2f,0), Quaternion.identity);
                    spawnCount++;
                }
                if(Random.Range(0,2) == 1)
                {
                    Instantiate(castListWinter1[4],transform.position + new Vector3(posX40, 0f,0), Quaternion.identity);
                    spawnCount++;
                }
                if(Random.Range(0,2) == 1)
                {
                    Instantiate(castListWinter1[4],transform.position + new Vector3(posX40, 1.6f,0), Quaternion.identity);
                    spawnCount++;
                }
                if(Random.Range(0,2) == 1)
                {
                    Instantiate(castListWinter1[4],transform.position + new Vector3(posX40, 3.2f,0), Quaternion.identity);
                    spawnCount++;
                }
                if(Random.Range(0,2) == 1)
                {
                    Instantiate(castListWinter1[4],transform.position + new Vector3(posX40, 4.8f,0), Quaternion.identity);
                    spawnCount++;
                }
                if(Random.Range(0,2) == 1)
                {
                    Instantiate(castListWinter1[4],transform.position + new Vector3(posX40, 6.4f,0), Quaternion.identity);
                    spawnCount++;
                }
                if(spawnCount < 3)
                {
                    Instantiate(castListWinter1[4],transform.position + new Vector3(posX40, 3.2f,0), Quaternion.identity);
                    Instantiate(castListWinter1[4],transform.position + new Vector3(posX40, 4.8f,0), Quaternion.identity);
                    Instantiate(castListWinter1[4],transform.position + new Vector3(posX40, 6.4f,0), Quaternion.identity);

                }
                break;

            case 41:
                if(Random.Range(0,2) == 1)
                {
                    Instantiate(castListWinter1[4],transform.position + new Vector3(-1.5f, 0f,0), Quaternion.identity);
                    spawnCount++;
                }
                if(Random.Range(0,2) == 1)
                {
                    Instantiate(castListWinter1[4],transform.position + new Vector3(-0.75f, 1.6f,0), Quaternion.identity);
                    spawnCount++;
                }
                if(Random.Range(0,2) == 1)
                {
                    Instantiate(castListWinter1[4],transform.position + new Vector3(0, 3.2f,0), Quaternion.identity);
                    spawnCount++;
                }
                if(Random.Range(0,2) == 1)
                {
                    Instantiate(castListWinter1[4],transform.position + new Vector3(0.75f, 4.8f,0), Quaternion.identity);
                    spawnCount++;
                }
                if(Random.Range(0,2) == 1)
                {
                    Instantiate(castListWinter1[4],transform.position + new Vector3(1.5f, 6.4f,0), Quaternion.identity);
                    spawnCount++;
                }
                if(spawnCount < 3)
                {
                    Instantiate(castListWinter1[4],transform.position + new Vector3(0, 3.2f,0), Quaternion.identity);
                    Instantiate(castListWinter1[4],transform.position + new Vector3(0.75f, 4.8f,0), Quaternion.identity);
                    Instantiate(castListWinter1[4],transform.position + new Vector3(1.5f, 6.4f,0), Quaternion.identity);

                }
                break;

            case 42:
                if(Random.Range(0,2) == 1)
                {
                    Instantiate(castListWinter1[1],transform.position + new Vector3(1.5f, 0f,0), Quaternion.identity);
                    spawnCount++;
                }
                if(Random.Range(0,2) == 1)
                {
                    Instantiate(castListWinter1[1],transform.position + new Vector3(0.75f, 1.6f,0), Quaternion.identity);
                    spawnCount++;
                }
                if(Random.Range(0,2) == 1)
                {
                    Instantiate(castListWinter1[1],transform.position + new Vector3(0, 3.2f,0), Quaternion.identity);
                    spawnCount++;
                }
                if(Random.Range(0,2) == 1)
                {
                    Instantiate(castListWinter1[1],transform.position + new Vector3(-0.75f, 4.8f,0), Quaternion.identity);
                    spawnCount++;
                }
                if(Random.Range(0,2) == 1)
                {
                    Instantiate(castListWinter1[1],transform.position + new Vector3(-1.5f, 6.4f,0), Quaternion.identity);
                    spawnCount++;
                }
                if(spawnCount < 3)
                {
                    Instantiate(castListWinter1[1],transform.position + new Vector3(0, 3.2f,0), Quaternion.identity);
                    Instantiate(castListWinter1[1],transform.position + new Vector3(-0.75f, 4.8f,0), Quaternion.identity);
                    Instantiate(castListWinter1[1],transform.position + new Vector3(-1.5f, 6.4f,0), Quaternion.identity);

                }
                break;

            case 43:
                Instantiate(castListRare[0],transform.position + new Vector3(-1.5f, -6.4f,0), Quaternion.identity);
                Instantiate(castListRare[0],transform.position + new Vector3(1.5f, 0f,0), Quaternion.identity);
                Instantiate(castListWinter1[Random.Range(2,4)],transform.position + new Vector3(-1.5f, 6.4f,0), Quaternion.identity);
                break;
        }
    }

    public void MakeStageCast5()
    {
        GameObject ob1 = Instantiate(prismTogenkyo,transform.position + new Vector3(Random.Range(-1.8f,1.8f), -6.4f,0), Quaternion.identity);
        GameObject ob2 = Instantiate(prismTogenkyo,transform.position + new Vector3(Random.Range(-1.8f,1.8f), 0,0), Quaternion.identity);
        GameObject ob3 = Instantiate(prismTogenkyo,transform.position + new Vector3(Random.Range(-1.8f,1.8f), 6.4f,0), Quaternion.identity);
        /*
        for(int n = 0; n < 6; n++)
        {

            GameObject ob1 = Instantiate(prismTogenkyo,transform.position + new Vector3(Random.Range(-1.8f,1.8f), n*3.2f - 9.6f + 1.6f,0), Quaternion.identity);
            GameObject ob2 = Instantiate(prismTogenkyo,transform.position + new Vector3(0, n*3.2f - 9.6f + 1.6f,0), Quaternion.identity);
            GameObject ob3 = Instantiate(prismTogenkyo,transform.position + new Vector3(1.8f, n*3.2f - 9.6f + 1.6f,0), Quaternion.identity);
        } 
        */
        
    }

    public void MakeTori()
    {
        makeToriFlg = true;
    }

    public void MakePrism(string altPrismName)
    {
        makePrismFlg = true;
        prismName = altPrismName;
    }

    public void Year(int year){
        GameObject yearPop = Instantiate(yearPopPre,transform.position + new Vector3(0, -4f,0), Quaternion.identity);
        yearPop.GetComponent<YearPop>().SetYear(year);
    }
    
    public void StopMake(){
        stopMakeFlg = true;
    }

    public void MakeGoal(){
        GameObject yearPop = Instantiate(yearPopPre,transform.position + new Vector3(0, -4f,0), Quaternion.identity);
        yearPop.GetComponent<YearPop>().SetGoal();
        Instantiate(goal,transform.position + new Vector3(0, 0f,0), Quaternion.identity);
    }
}