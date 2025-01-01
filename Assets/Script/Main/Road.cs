using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Road : MonoBehaviour
{
    public float positionY;
    public GameObject player;
    // 6行分のエネミーリストを作成する。
    [SerializeField]
    private GameObject[] enemyList1; 
    private GameObject[] enemyList2; 
    private GameObject[] enemyList3; 
    private GameObject[] enemyList4; 
    private GameObject[] enemyList5; 
    private GameObject[] enemyList6; 
    // 6行分の敵、アイテム、障害物、エンプティリストを入れる。
    [SerializeField]
    private GameObject[] otherAppearanceList1; 
    private GameObject[] otherAppearanceList2; 
    private GameObject[] otherAppearanceList3; 
    private GameObject[] otherAppearanceList4; 
    private GameObject[] otherAppearanceList5; 
    // private GameObject[] otherAppearanceList6; 
    // 6行分のGameObject変数を作成する。
    private GameObject  appearance1;
    private GameObject  appearance2;
    private GameObject  appearance3;
    private GameObject  appearance4;
    private GameObject  appearance5;
    // private GameObject  appearance6;

    [SerializeField]
    private GameObject bomber1, rollingBomber1, hole1, warp1, lifeThread1, empty1, obstacle1, tori1, shiroTori1, hude1;
    [SerializeField]
    private GameObject bomber2, rollingBomber2, hole2, warp2, lifeThread2, empty2, obstacle2, tori2, shiroTori2, hude2;
    [SerializeField]
    private GameObject bomber3, rollingBomber3, hole3, warp3, lifeThread3, empty3, obstacle3, tori3, shiroTori3, hude3;
    [SerializeField]
    private GameObject bomber4, rollingBomber4, hole4, warp4, lifeThread4, empty4, obstacle4, tori4, shiroTori4, hude4;
    [SerializeField]
    private GameObject bomber5, rollingBomber5, hole5, warp5, lifeThread5, empty5, obstacle5, tori5, shiroTori5, hude5;
    // [SerializeField]
    // private GameObject bomber6, rollingBomber6, hole6, lifeThread6, empty6, obstacle6, tori6, shiroTori6;
    

    public int gear;
    public bool itemAppearFlg;
    public int stageNumber;
    public float appearancePositionX;
    public Vector3 appearance1SavedPosition;
    // gearが上がった時に上記二つのリストの中身を変更する。

    // Start is called before the first frame update
    void Start()
    {
        // transform.position = new Vector3(0, positionY, 1);
        gear = 1;
        enemyList1 = new GameObject[1] {bomber1};
        enemyList2 = new GameObject[1] {bomber2};
        enemyList3 = new GameObject[1] {bomber3};
        enemyList4 = new GameObject[1] {bomber4};
        enemyList5 = new GameObject[1] {bomber5};

        // テスト用
        /*
        enemyList1 = new GameObject[1] {warp1};
        enemyList2 = new GameObject[1] {warp2};
        enemyList3 = new GameObject[1] {warp3};
        enemyList4 = new GameObject[1] {warp4};
        enemyList5 = new GameObject[1] {warp5};
        */

        // enemyList6 = new GameObject[1] {bomber6};
        otherAppearanceList1 = new GameObject[5] {lifeThread1, shiroTori1, empty1, tori1, hude1};
        otherAppearanceList2 = new GameObject[5] {lifeThread2, shiroTori2, empty2, tori2, hude2};
        otherAppearanceList3 = new GameObject[5] {lifeThread3, shiroTori3, empty3, tori3, hude3};
        otherAppearanceList4 = new GameObject[5] {lifeThread4, shiroTori4, empty4, tori4, hude4};
        otherAppearanceList5 = new GameObject[5] {lifeThread5, shiroTori5, empty5, tori5, hude5};
        // otherAppearanceList6 = new GameObject[4] {lifeThread6, shiroTori6, empty6, tori6};
        
        /*
        enemyList1 = new GameObject[2] {bomber1, empty1};
        enemyList2 = new GameObject[2] {bomber2, empty2};
        enemyList3 = new GameObject[2] {bomber3, empty3};
        enemyList4 = new GameObject[2] {bomber4, empty4};
        enemyList5 = new GameObject[2] {bomber5, empty5};
        enemyList6 = new GameObject[2] {bomber6, empty6};
        */
        // appearance1 = bomber1;
        // appearance1SavedPosition = appearance1.transform.position;


    }

    // Update is called once per frame
    void Update()
    {
        
        if(player.transform.position.y - transform.position.y > 19.2f)
        {
            /*
            appearance1.SetActive(true);
            appearance1.transform.position = appearance1SavedPosition;
            appearance1.SetActive(false);
            */
            positionY += 57.6f;
            transform.position = new Vector3(0, positionY, 1);
            stageNumber = Random.Range(0,100);
            if(stageNumber <= 69 || gear < 4)
            {
                SetActiveFalseAppearance();
                MakeAppearance();
            }
            else if(stageNumber >= 70)
            {
                SetActiveFalseAppearance();
                MakeStage();
            }
        }

        
    }

    public void ActiveItemAppearFlg()
    {
        itemAppearFlg = true;
    }

    public void InActiveItemAppearFlg()
    {
        itemAppearFlg = false;
    }

    public void GearUp()
    {
        gear++;
        switch(gear)
        {
            case 1:
                enemyList1 = new GameObject[4] {bomber1, rollingBomber1, hole1, warp1};
                enemyList2 = new GameObject[4] {bomber2, rollingBomber2, hole2, warp2};
                enemyList3 = new GameObject[4] {bomber3, rollingBomber3, hole3, warp3};
                enemyList4 = new GameObject[4] {bomber4, rollingBomber4, hole4, warp4};
                enemyList5 = new GameObject[4] {bomber5, rollingBomber5, hole5, warp5};
                // enemyList6 = new GameObject[3] {bomber6, rollingBomber6, hole6};
                otherAppearanceList1 = new GameObject[6] {lifeThread1, shiroTori1, empty1, obstacle1, tori1, hude1};
                otherAppearanceList2 = new GameObject[6] {lifeThread2, shiroTori2, empty2, obstacle2, tori2, hude2};
                otherAppearanceList3 = new GameObject[6] {lifeThread3, shiroTori3, empty3, obstacle3, tori3, hude3};
                otherAppearanceList4 = new GameObject[6] {lifeThread4, shiroTori4, empty4, obstacle4, tori4, hude4};
                otherAppearanceList5 = new GameObject[6] {lifeThread5, shiroTori5, empty5, obstacle5, tori5, hude5};
                // otherAppearanceList6 = new GameObject[4] {lifeThread6, shiroTori6, empty6, tori6};
                break;
            
            case 2:
                enemyList1 = new GameObject[1] {bomber1};
                enemyList2 = new GameObject[1] {bomber2};
                enemyList3 = new GameObject[1] {bomber3};
                enemyList4 = new GameObject[1] {bomber4};
                enemyList5 = new GameObject[1] {bomber5};
                // enemyList6 = new GameObject[1] {bomber6};
                otherAppearanceList1 = new GameObject[6] {lifeThread1, shiroTori1, empty1, obstacle1, tori1, hude1};
                otherAppearanceList2 = new GameObject[6] {lifeThread2, shiroTori2, empty2, obstacle2, tori2, hude2};
                otherAppearanceList3 = new GameObject[6] {lifeThread3, shiroTori3, empty3, obstacle3, tori3, hude3};
                otherAppearanceList4 = new GameObject[6] {lifeThread4, shiroTori4, empty4, obstacle4, tori4, hude4};
                otherAppearanceList5 = new GameObject[6] {lifeThread5, shiroTori5, empty5, obstacle5, tori5, hude5};
                // otherAppearanceList6 = new GameObject[5] {lifeThread6, shiroTori6, empty6, obstacle6, tori6};
                break;

            case 3:
                enemyList1 = new GameObject[2] {bomber1, rollingBomber1};
                enemyList2 = new GameObject[2] {bomber2, rollingBomber2};
                enemyList3 = new GameObject[2] {bomber3, rollingBomber3};
                enemyList4 = new GameObject[2] {bomber4, rollingBomber4};
                enemyList5 = new GameObject[2] {bomber5, rollingBomber5};
                // enemyList6 = new GameObject[2] {bomber6, rollingBomber6};
                otherAppearanceList1 = new GameObject[6] {lifeThread1, shiroTori1, empty1, obstacle1, tori1, hude1};
                otherAppearanceList2 = new GameObject[6] {lifeThread2, shiroTori2, empty2, obstacle2, tori2, hude2};
                otherAppearanceList3 = new GameObject[6] {lifeThread3, shiroTori3, empty3, obstacle3, tori3, hude3};
                otherAppearanceList4 = new GameObject[6] {lifeThread4, shiroTori4, empty4, obstacle4, tori4, hude4};
                otherAppearanceList5 = new GameObject[6] {lifeThread5, shiroTori5, empty5, obstacle5, tori5, hude5};
                // otherAppearanceList6 = new GameObject[5] {lifeThread6, shiroTori6, empty6, obstacle6, tori6};
                break;

            case 4:
                enemyList1 = new GameObject[2] {bomber1, rollingBomber1};
                enemyList2 = new GameObject[2] {bomber2, rollingBomber2};
                enemyList3 = new GameObject[2] {bomber3, rollingBomber3};
                enemyList4 = new GameObject[2] {bomber4, rollingBomber4};
                enemyList5 = new GameObject[2] {bomber5, rollingBomber5};
                // enemyList6 = new GameObject[2] {bomber6, rollingBomber6};
                otherAppearanceList1 = new GameObject[6] {lifeThread1, shiroTori1, empty1, obstacle1, tori1, hude1};
                otherAppearanceList2 = new GameObject[6] {lifeThread2, shiroTori2, empty2, obstacle2, tori2, hude2};
                otherAppearanceList3 = new GameObject[6] {lifeThread3, shiroTori3, empty3, obstacle3, tori3, hude3};
                otherAppearanceList4 = new GameObject[6] {lifeThread4, shiroTori4, empty4, obstacle4, tori4, hude4};
                otherAppearanceList5 = new GameObject[6] {lifeThread5, shiroTori5, empty5, obstacle5, tori5, hude5};
                // otherAppearanceList6 = new GameObject[5] {lifeThread6, shiroTori6, empty6, obstacle6, tori6};

                break;
            
            case 5:
                enemyList1 = new GameObject[2] {bomber1, rollingBomber1};
                enemyList2 = new GameObject[2] {bomber2, rollingBomber2};
                enemyList3 = new GameObject[2] {bomber3, rollingBomber3};
                enemyList4 = new GameObject[2] {bomber4, rollingBomber4};
                enemyList5 = new GameObject[2] {bomber5, rollingBomber5};
                // enemyList6 = new GameObject[2] {bomber6, rollingBomber6};
                otherAppearanceList1 = new GameObject[6] {lifeThread1, shiroTori1, empty1, obstacle1, tori1, hude1};
                otherAppearanceList2 = new GameObject[6] {lifeThread2, shiroTori2, empty2, obstacle2, tori2, hude2};
                otherAppearanceList3 = new GameObject[6] {lifeThread3, shiroTori3, empty3, obstacle3, tori3, hude3};
                otherAppearanceList4 = new GameObject[6] {lifeThread4, shiroTori4, empty4, obstacle4, tori4, hude4};
                otherAppearanceList5 = new GameObject[6] {lifeThread5, shiroTori5, empty5, obstacle5, tori5, hude5};
                // otherAppearanceList6 = new GameObject[5] {lifeThread6, shiroTori6, empty6, obstacle6, tori6};
                break;

            case 6:
                enemyList1 = new GameObject[4] {bomber1, rollingBomber1, hole1, warp1};
                enemyList2 = new GameObject[2] {bomber2, rollingBomber2};
                enemyList3 = new GameObject[2] {bomber3, rollingBomber3};
                enemyList4 = new GameObject[2] {bomber4, rollingBomber4};
                enemyList5 = new GameObject[2] {bomber5, rollingBomber5};
                // enemyList6 = new GameObject[2] {bomber6, rollingBomber6};
                otherAppearanceList1 = new GameObject[6] {lifeThread1, shiroTori1, empty1, obstacle1, tori1, hude1};
                otherAppearanceList2 = new GameObject[6] {lifeThread2, shiroTori2, empty2, obstacle2, tori2, hude2};
                otherAppearanceList3 = new GameObject[6] {lifeThread3, shiroTori3, empty3, obstacle3, tori3, hude3};
                otherAppearanceList4 = new GameObject[6] {lifeThread4, shiroTori4, empty4, obstacle4, tori4, hude4};
                otherAppearanceList5 = new GameObject[6] {lifeThread5, shiroTori5, empty5, obstacle5, tori5, hude5};
                // otherAppearanceList6 = new GameObject[5] {lifeThread6, shiroTori6, empty6, obstacle6, tori6};
                break;            

            case 7:
                enemyList1 = new GameObject[4] {bomber1, rollingBomber1, hole1, warp1};
                enemyList2 = new GameObject[4] {bomber2, rollingBomber2, hole2, warp2};
                enemyList3 = new GameObject[2] {bomber3, rollingBomber3};
                enemyList4 = new GameObject[2] {bomber4, rollingBomber4};
                enemyList5 = new GameObject[2] {bomber5, rollingBomber5};
                // enemyList6 = new GameObject[2] {bomber6, rollingBomber6};
                otherAppearanceList1 = new GameObject[6] {lifeThread1, shiroTori1, empty1, obstacle1, tori1, hude1};
                otherAppearanceList2 = new GameObject[6] {lifeThread2, shiroTori2, empty2, obstacle2, tori2, hude2};
                otherAppearanceList3 = new GameObject[6] {lifeThread3, shiroTori3, empty3, obstacle3, tori3, hude3};
                otherAppearanceList4 = new GameObject[6] {lifeThread4, shiroTori4, empty4, obstacle4, tori4, hude4};
                otherAppearanceList5 = new GameObject[6] {lifeThread5, shiroTori5, empty5, obstacle5, tori5, hude5};
                // otherAppearanceList6 = new GameObject[5] {lifeThread6, shiroTori6, empty6, obstacle6, tori6};
                break;
            
            case 8:
                enemyList1 = new GameObject[4] {bomber1, rollingBomber1, hole1, warp1};
                enemyList2 = new GameObject[4] {bomber2, rollingBomber2, hole2, warp2};
                enemyList3 = new GameObject[4] {bomber3, rollingBomber3, hole3, warp3};
                enemyList4 = new GameObject[2] {bomber4, rollingBomber4};
                enemyList5 = new GameObject[2] {bomber5, rollingBomber5};
                // enemyList6 = new GameObject[2] {bomber6, rollingBomber6};
                otherAppearanceList1 = new GameObject[6] {lifeThread1, shiroTori1, empty1, obstacle1, tori1, hude1};
                otherAppearanceList2 = new GameObject[6] {lifeThread2, shiroTori2, empty2, obstacle2, tori2, hude2};
                otherAppearanceList3 = new GameObject[6] {lifeThread3, shiroTori3, empty3, obstacle3, tori3, hude3};
                otherAppearanceList4 = new GameObject[6] {lifeThread4, shiroTori4, empty4, obstacle4, tori4, hude4};
                otherAppearanceList5 = new GameObject[6] {lifeThread5, shiroTori5, empty5, obstacle5, tori5, hude5};
                // otherAppearanceList6 = new GameObject[5] {lifeThread6, shiroTori6, empty6, obstacle6, tori6};
                break;

            case 9:
                enemyList1 = new GameObject[4] {bomber1, rollingBomber1, hole1, warp1};
                enemyList2 = new GameObject[4] {bomber2, rollingBomber2, hole2, warp2};
                enemyList3 = new GameObject[4] {bomber3, rollingBomber3, hole3, warp3};
                enemyList4 = new GameObject[4] {bomber4, rollingBomber4, hole4, warp4};
                enemyList5 = new GameObject[2] {bomber5, rollingBomber5};
                // enemyList6 = new GameObject[2] {bomber6, rollingBomber6};
                otherAppearanceList1 = new GameObject[6] {lifeThread1, shiroTori1, empty1, obstacle1, tori1, hude1};
                otherAppearanceList2 = new GameObject[6] {lifeThread2, shiroTori2, empty2, obstacle2, tori2, hude2};
                otherAppearanceList3 = new GameObject[6] {lifeThread3, shiroTori3, empty3, obstacle3, tori3, hude3};
                otherAppearanceList4 = new GameObject[6] {lifeThread4, shiroTori4, empty4, obstacle4, tori4, hude4};
                otherAppearanceList5 = new GameObject[6] {lifeThread5, shiroTori5, empty5, obstacle5, tori5, hude5};
                // otherAppearanceList6 = new GameObject[5] {lifeThread6, shiroTori6, empty6, obstacle6, tori6};
                break;

            case 10:
                enemyList1 = new GameObject[4] {bomber1, rollingBomber1, hole1, warp1};
                enemyList2 = new GameObject[4] {bomber2, rollingBomber2, hole2, warp2};
                enemyList3 = new GameObject[4] {bomber3, rollingBomber3, hole3, warp3};
                enemyList4 = new GameObject[4] {bomber4, rollingBomber4, hole4, warp4};
                enemyList5 = new GameObject[4] {bomber5, rollingBomber5, hole5, warp5};
                // enemyList6 = new GameObject[3] {bomber6, rollingBomber6, hole6};
                otherAppearanceList1 = new GameObject[6] {lifeThread1, shiroTori1, empty1, obstacle1, tori1, hude1};
                otherAppearanceList2 = new GameObject[6] {lifeThread2, shiroTori2, empty2, obstacle2, tori2, hude2};
                otherAppearanceList3 = new GameObject[6] {lifeThread3, shiroTori3, empty3, obstacle3, tori3, hude3};
                otherAppearanceList4 = new GameObject[6] {lifeThread4, shiroTori4, empty4, obstacle4, tori4, hude4};
                otherAppearanceList5 = new GameObject[6] {lifeThread5, shiroTori5, empty5, obstacle5, tori5, hude5};
                // otherAppearanceList6 = new GameObject[5] {lifeThread6, shiroTori6, empty6, obstacle6, tori6};
                break;
        }
    }
    // gearによってswitchし、それぞれの中でエネミーとその他の配置を決める

    public void MakeAppearance()
    {
        /*
        if(appearance1 != null && appearance1.activeInHierarchy)
        {
            if(appearance1.tag == "Enemy")
            {
                GameSystem.instance.LostLife(appearance1.GetComponent<Enemy>().attackPoint);
            }
            appearance1.SetActive(false);
        }

        if(appearance2 != null && appearance2.activeInHierarchy)
        {
            if(appearance2.tag == "Enemy")
            {
                GameSystem.instance.LostLife(appearance2.GetComponent<Enemy>().attackPoint);
            }
            appearance2.SetActive(false);

        }

        if(appearance3 != null && appearance3.activeInHierarchy)
        {
            if(appearance3.tag == "Enemy")
            {
                GameSystem.instance.LostLife(appearance3.GetComponent<Enemy>().attackPoint);
            }
            appearance3.SetActive(false);

        } 
        
        if(appearance4 != null && appearance4.activeInHierarchy)
        {
            if(appearance4.tag == "Enemy")
            {
                GameSystem.instance.LostLife(appearance4.GetComponent<Enemy>().attackPoint);
            }
            appearance4.SetActive(false);

        }
        
        if(appearance5 != null && appearance5.activeInHierarchy)
        {
            if(appearance5.tag == "Enemy")
            {
                GameSystem.instance.LostLife(appearance5.GetComponent<Enemy>().attackPoint);
            }
            appearance5.SetActive(false);

        }
        
        if(appearance6 != null && appearance6.activeInHierarchy)
        {
            if(appearance6.tag == "Enemy")
            {
                GameSystem.instance.LostLife(appearance6.GetComponent<Enemy>().attackPoint);
            }
            appearance6.SetActive(false);

        }
        */
        
        

        appearance1 = null;
        appearance2 = null;
        appearance3 = null;
        appearance4 = null;
        appearance5 = null;
        // appearance6 = null;

        if(Random.Range(0,100) < gear * 9 || Random.Range(0,100) < 30)
        {
            appearance1 = enemyList1[Random.Range(0, enemyList1.Length)];
            // appearance1.GetComponent<Enemy>().SetBomFlgFalse();
        }

        if(Random.Range(0,100) < gear * 9 || Random.Range(0,100) < 30)
        {
            appearance2 = enemyList2[Random.Range(0, enemyList2.Length)];
            // appearance2.GetComponent<Enemy>().SetBomFlgFalse();
        }

        if(Random.Range(0,100) < gear * 9 || Random.Range(0,100) < 30)
        {
            appearance3 = enemyList3[Random.Range(0, enemyList3.Length)];
            // appearance3.GetComponent<Enemy>().SetBomFlgFalse();
        }

        if(Random.Range(0,100) < gear * 9 || Random.Range(0,100) < 30)
        {
            appearance4 = enemyList4[Random.Range(0, enemyList4.Length)];
            // appearance4.GetComponent<Enemy>().SetBomFlgFalse();
        }

        if(Random.Range(0,100) < gear * 9 || Random.Range(0,100) < 30)
        {
            appearance5 = enemyList5[Random.Range(0, enemyList5.Length)];
            // appearance5.GetComponent<Enemy>().SetBomFlgFalse();
        }

        if(Random.Range(0,100) < gear * 9 || Random.Range(0,100) < 30)
        {
            // appearance6 = enemyList6[Random.Range(0, enemyList6.Length)];
        }


        /*
        switch(gear)
        {

            
            case 1:
                switch(Random.Range(1,10))
                {
                    case 1:
                        appearance1 = enemyList1[Random.Range(0, enemyList1.Length)];
                        appearance3 = enemyList3[Random.Range(0, enemyList3.Length)];
                        break;

                    case 2:
                        appearance1 = enemyList1[Random.Range(0, enemyList1.Length)];
                        appearance4 = enemyList4[Random.Range(0, enemyList4.Length)];
                        break;

                    case 3:
                        appearance1 = enemyList1[Random.Range(0, enemyList1.Length)];
                        appearance5 = enemyList5[Random.Range(0, enemyList5.Length)];
                        break;

                    case 4:
                        appearance1 = enemyList1[Random.Range(0, enemyList1.Length)];
                        appearance6 = enemyList6[Random.Range(0, enemyList6.Length)];
                        break;

                    case 5:
                        appearance2 = enemyList2[Random.Range(0, enemyList2.Length)];
                        appearance4 = enemyList4[Random.Range(0, enemyList4.Length)];
                        break;

                    case 6:
                        appearance2 = enemyList2[Random.Range(0, enemyList2.Length)];
                        appearance5 = enemyList5[Random.Range(0, enemyList5.Length)];
                        break;

                    case 7:
                        appearance2 = enemyList2[Random.Range(0, enemyList2.Length)];
                        appearance6 = enemyList6[Random.Range(0, enemyList6.Length)];
                        break;
                        
                    case 8:
                        appearance3 = enemyList3[Random.Range(0, enemyList3.Length)];
                        appearance5 = enemyList5[Random.Range(0, enemyList5.Length)];
                        break;

                    case 9:
                        appearance3 = enemyList3[Random.Range(0, enemyList3.Length)];
                        appearance6 = enemyList6[Random.Range(0, enemyList6.Length)];  
                        break;
                                            
                }
                break;

            case 2:
                switch(Random.Range(1,11))
                {
                    case 1:
                        appearance1 = enemyList1[Random.Range(0, enemyList1.Length)];
                        appearance3 = enemyList3[Random.Range(0, enemyList3.Length)];
                        break;

                    case 2:
                        appearance1 = enemyList1[Random.Range(0, enemyList1.Length)];
                        appearance4 = enemyList4[Random.Range(0, enemyList4.Length)];
                        break;

                    case 3:
                        appearance1 = enemyList1[Random.Range(0, enemyList1.Length)];
                        appearance5 = enemyList5[Random.Range(0, enemyList5.Length)];
                        break;

                    case 4:
                        appearance1 = enemyList1[Random.Range(0, enemyList1.Length)];
                        appearance6 = enemyList6[Random.Range(0, enemyList6.Length)];
                        break;

                    case 5:
                        appearance2 = enemyList2[Random.Range(0, enemyList2.Length)];
                        appearance4 = enemyList4[Random.Range(0, enemyList4.Length)];
                        break;

                    case 6:
                        appearance2 = enemyList2[Random.Range(0, enemyList2.Length)];
                        appearance5 = enemyList5[Random.Range(0, enemyList5.Length)];
                        break;

                    case 7:
                        appearance2 = enemyList2[Random.Range(0, enemyList2.Length)];
                        appearance6 = enemyList6[Random.Range(0, enemyList6.Length)];
                        break;
                        
                    case 8:
                        appearance3 = enemyList3[Random.Range(0, enemyList3.Length)];
                        appearance5 = enemyList5[Random.Range(0, enemyList5.Length)];
                        break;

                    case 9:
                        appearance3 = enemyList3[Random.Range(0, enemyList3.Length)];
                        appearance6 = enemyList6[Random.Range(0, enemyList6.Length)];  
                        break;

                    case 10:
                    appearance1 = enemyList1[Random.Range(0, enemyList1.Length)];
                    appearance3 = enemyList3[Random.Range(0, enemyList3.Length)];
                    appearance5 = enemyList5[Random.Range(0, enemyList5.Length)];
                    break;
                                            
                }
                break;

            case 3:
                switch(Random.Range(1,12))
                {
                    case 1:
                        appearance1 = enemyList1[Random.Range(0, enemyList1.Length)];
                        appearance3 = enemyList3[Random.Range(0, enemyList3.Length)];
                        break;

                    case 2:
                        appearance1 = enemyList1[Random.Range(0, enemyList1.Length)];
                        appearance4 = enemyList4[Random.Range(0, enemyList4.Length)];
                        break;

                    case 3:
                        appearance1 = enemyList1[Random.Range(0, enemyList1.Length)];
                        appearance5 = enemyList5[Random.Range(0, enemyList5.Length)];
                        break;

                    case 4:
                        appearance1 = enemyList1[Random.Range(0, enemyList1.Length)];
                        appearance6 = enemyList6[Random.Range(0, enemyList6.Length)];
                        break;

                    case 5:
                        appearance2 = enemyList2[Random.Range(0, enemyList2.Length)];
                        appearance4 = enemyList4[Random.Range(0, enemyList4.Length)];
                        break;

                    case 6:
                        appearance2 = enemyList2[Random.Range(0, enemyList2.Length)];
                        appearance5 = enemyList5[Random.Range(0, enemyList5.Length)];
                        break;

                    case 7:
                        appearance2 = enemyList2[Random.Range(0, enemyList2.Length)];
                        appearance6 = enemyList6[Random.Range(0, enemyList6.Length)];
                        break;
                        
                    case 8:
                        appearance3 = enemyList3[Random.Range(0, enemyList3.Length)];
                        appearance5 = enemyList5[Random.Range(0, enemyList5.Length)];
                        break;

                    case 9:
                        appearance3 = enemyList3[Random.Range(0, enemyList3.Length)];
                        appearance6 = enemyList6[Random.Range(0, enemyList6.Length)];  
                        break;

                    case 10:
                        appearance1 = enemyList1[Random.Range(0, enemyList1.Length)];
                        appearance3 = enemyList3[Random.Range(0, enemyList3.Length)];
                        appearance5 = enemyList5[Random.Range(0, enemyList5.Length)];
                        break;

                    case 11:
                        appearance1 = enemyList1[Random.Range(0, enemyList1.Length)];
                        appearance3 = enemyList3[Random.Range(0, enemyList3.Length)];
                        appearance6 = enemyList6[Random.Range(0, enemyList6.Length)];
                        break;
                                            
                }
                break;

            case 4:
                switch(Random.Range(1,13))
                {
                    case 1:
                        appearance1 = enemyList1[Random.Range(0, enemyList1.Length)];
                        appearance3 = enemyList3[Random.Range(0, enemyList3.Length)];
                        break;

                    case 2:
                        appearance1 = enemyList1[Random.Range(0, enemyList1.Length)];
                        appearance4 = enemyList4[Random.Range(0, enemyList4.Length)];
                        break;

                    case 3:
                        appearance1 = enemyList1[Random.Range(0, enemyList1.Length)];
                        appearance5 = enemyList5[Random.Range(0, enemyList5.Length)];
                        break;

                    case 4:
                        appearance1 = enemyList1[Random.Range(0, enemyList1.Length)];
                        appearance6 = enemyList6[Random.Range(0, enemyList6.Length)];
                        break;

                    case 5:
                        appearance2 = enemyList2[Random.Range(0, enemyList2.Length)];
                        appearance4 = enemyList4[Random.Range(0, enemyList4.Length)];
                        break;

                    case 6:
                        appearance2 = enemyList2[Random.Range(0, enemyList2.Length)];
                        appearance5 = enemyList5[Random.Range(0, enemyList5.Length)];
                        break;

                    case 7:
                        appearance2 = enemyList2[Random.Range(0, enemyList2.Length)];
                        appearance6 = enemyList6[Random.Range(0, enemyList6.Length)];
                        break;
                        
                    case 8:
                        appearance3 = enemyList3[Random.Range(0, enemyList3.Length)];
                        appearance5 = enemyList5[Random.Range(0, enemyList5.Length)];
                        break;

                    case 9:
                        appearance3 = enemyList3[Random.Range(0, enemyList3.Length)];
                        appearance6 = enemyList6[Random.Range(0, enemyList6.Length)];  
                        break;

                    case 10:
                        appearance1 = enemyList1[Random.Range(0, enemyList1.Length)];
                        appearance3 = enemyList3[Random.Range(0, enemyList3.Length)];
                        appearance5 = enemyList5[Random.Range(0, enemyList5.Length)];
                        break;

                    case 11:
                        appearance1 = enemyList1[Random.Range(0, enemyList1.Length)];
                        appearance3 = enemyList3[Random.Range(0, enemyList3.Length)];
                        appearance6 = enemyList6[Random.Range(0, enemyList6.Length)];
                        break;

                    case 12:
                        appearance1 = enemyList1[Random.Range(0, enemyList1.Length)];
                        appearance4 = enemyList4[Random.Range(0, enemyList4.Length)];
                        appearance6 = enemyList6[Random.Range(0, enemyList6.Length)];
                        break;
                                            
                }
                break;

            case 5:
                switch(Random.Range(1,14))
                {
                    case 1:
                        appearance1 = enemyList1[Random.Range(0, enemyList1.Length)];
                        appearance3 = enemyList3[Random.Range(0, enemyList3.Length)];
                        break;

                    case 2:
                        appearance1 = enemyList1[Random.Range(0, enemyList1.Length)];
                        appearance4 = enemyList4[Random.Range(0, enemyList4.Length)];
                        break;

                    case 3:
                        appearance1 = enemyList1[Random.Range(0, enemyList1.Length)];
                        appearance5 = enemyList5[Random.Range(0, enemyList5.Length)];
                        break;

                    case 4:
                        appearance1 = enemyList1[Random.Range(0, enemyList1.Length)];
                        appearance6 = enemyList6[Random.Range(0, enemyList6.Length)];
                        break;

                    case 5:
                        appearance2 = enemyList2[Random.Range(0, enemyList2.Length)];
                        appearance4 = enemyList4[Random.Range(0, enemyList4.Length)];
                        break;

                    case 6:
                        appearance2 = enemyList2[Random.Range(0, enemyList2.Length)];
                        appearance5 = enemyList5[Random.Range(0, enemyList5.Length)];
                        break;

                    case 7:
                        appearance2 = enemyList2[Random.Range(0, enemyList2.Length)];
                        appearance6 = enemyList6[Random.Range(0, enemyList6.Length)];
                        break;
                        
                    case 8:
                        appearance3 = enemyList3[Random.Range(0, enemyList3.Length)];
                        appearance5 = enemyList5[Random.Range(0, enemyList5.Length)];
                        break;

                    case 9:
                        appearance3 = enemyList3[Random.Range(0, enemyList3.Length)];
                        appearance6 = enemyList6[Random.Range(0, enemyList6.Length)];  
                        break;

                    case 10:
                        appearance1 = enemyList1[Random.Range(0, enemyList1.Length)];
                        appearance3 = enemyList3[Random.Range(0, enemyList3.Length)];
                        appearance5 = enemyList5[Random.Range(0, enemyList5.Length)];
                        break;

                    case 11:
                        appearance1 = enemyList1[Random.Range(0, enemyList1.Length)];
                        appearance3 = enemyList3[Random.Range(0, enemyList3.Length)];
                        appearance6 = enemyList6[Random.Range(0, enemyList6.Length)];
                        break;

                    case 12:
                        appearance1 = enemyList1[Random.Range(0, enemyList1.Length)];
                        appearance4 = enemyList4[Random.Range(0, enemyList4.Length)];
                        appearance6 = enemyList6[Random.Range(0, enemyList6.Length)];
                        break;
                    
                    case 13:
                        appearance2 = enemyList2[Random.Range(0, enemyList2.Length)];
                        appearance4 = enemyList4[Random.Range(0, enemyList4.Length)];
                        appearance6 = enemyList6[Random.Range(0, enemyList6.Length)];
                        break;
                    
                }
                break;

            case 6:
                switch(Random.Range(1,13))
                {
                    case 1:
                        appearance1 = enemyList1[Random.Range(0, enemyList1.Length)];
                        appearance3 = enemyList3[Random.Range(0, enemyList3.Length)];
                        break;

                    case 2:
                        appearance1 = enemyList1[Random.Range(0, enemyList1.Length)];
                        appearance4 = enemyList4[Random.Range(0, enemyList4.Length)];
                        break;

                    case 3:
                        appearance1 = enemyList1[Random.Range(0, enemyList1.Length)];
                        appearance5 = enemyList5[Random.Range(0, enemyList5.Length)];
                        break;

                    case 4:
                        appearance1 = enemyList1[Random.Range(0, enemyList1.Length)];
                        appearance6 = enemyList6[Random.Range(0, enemyList6.Length)];
                        break;

                    case 5:
                        appearance2 = enemyList2[Random.Range(0, enemyList2.Length)];
                        appearance4 = enemyList4[Random.Range(0, enemyList4.Length)];
                        break;

                    case 6:
                        appearance2 = enemyList2[Random.Range(0, enemyList2.Length)];
                        appearance5 = enemyList5[Random.Range(0, enemyList5.Length)];
                        break;

                    case 7:
                        appearance2 = enemyList2[Random.Range(0, enemyList2.Length)];
                        appearance6 = enemyList6[Random.Range(0, enemyList6.Length)];
                        break;
                        
                    case 8:
                        appearance3 = enemyList3[Random.Range(0, enemyList3.Length)];
                        appearance5 = enemyList5[Random.Range(0, enemyList5.Length)];
                        break;

                    case 9:
                        appearance2 = enemyList2[Random.Range(0, enemyList2.Length)];
                        appearance4 = enemyList4[Random.Range(0, enemyList4.Length)];
                        appearance6 = enemyList6[Random.Range(0, enemyList6.Length)];
                        break;

                    case 10:
                        appearance1 = enemyList1[Random.Range(0, enemyList1.Length)];
                        appearance3 = enemyList3[Random.Range(0, enemyList3.Length)];
                        appearance5 = enemyList5[Random.Range(0, enemyList5.Length)];
                        break;

                    case 11:
                        appearance1 = enemyList1[Random.Range(0, enemyList1.Length)];
                        appearance3 = enemyList3[Random.Range(0, enemyList3.Length)];
                        appearance6 = enemyList6[Random.Range(0, enemyList6.Length)];
                        break;

                    case 12:
                        appearance1 = enemyList1[Random.Range(0, enemyList1.Length)];
                        appearance4 = enemyList4[Random.Range(0, enemyList4.Length)];
                        appearance6 = enemyList6[Random.Range(0, enemyList6.Length)];
                        break;
                    
                }
                break;

            case 7:
                switch(Random.Range(1,11))
                {
                    case 1:
                        appearance1 = enemyList1[Random.Range(0, enemyList1.Length)];
                        appearance3 = enemyList3[Random.Range(0, enemyList3.Length)];
                        break;

                    case 2:
                        appearance1 = enemyList1[Random.Range(0, enemyList1.Length)];
                        appearance4 = enemyList4[Random.Range(0, enemyList4.Length)];
                        break;

                    case 3:
                        appearance1 = enemyList1[Random.Range(0, enemyList1.Length)];
                        appearance5 = enemyList5[Random.Range(0, enemyList5.Length)];
                        break;

                    case 4:
                        appearance1 = enemyList1[Random.Range(0, enemyList1.Length)];
                        appearance6 = enemyList6[Random.Range(0, enemyList6.Length)];
                        break;

                    case 5:
                        appearance2 = enemyList2[Random.Range(0, enemyList2.Length)];
                        appearance4 = enemyList4[Random.Range(0, enemyList4.Length)];
                        break;

                    case 6:
                        appearance2 = enemyList2[Random.Range(0, enemyList2.Length)];
                        appearance5 = enemyList5[Random.Range(0, enemyList5.Length)];
                        break;

                    case 7:
                        appearance1 = enemyList1[Random.Range(0, enemyList1.Length)];
                        appearance3 = enemyList3[Random.Range(0, enemyList3.Length)];
                        appearance6 = enemyList6[Random.Range(0, enemyList6.Length)];
                        break;

                    case 8:
                        appearance1 = enemyList1[Random.Range(0, enemyList1.Length)];
                        appearance4 = enemyList4[Random.Range(0, enemyList4.Length)];
                        appearance6 = enemyList6[Random.Range(0, enemyList6.Length)];
                        break;

                    case 9:
                        appearance2 = enemyList2[Random.Range(0, enemyList2.Length)];
                        appearance4 = enemyList4[Random.Range(0, enemyList4.Length)];
                        appearance6 = enemyList6[Random.Range(0, enemyList6.Length)];
                        break;

                    case 10:
                        appearance1 = enemyList1[Random.Range(0, enemyList1.Length)];
                        appearance3 = enemyList3[Random.Range(0, enemyList3.Length)];
                        appearance5 = enemyList5[Random.Range(0, enemyList5.Length)];
                        break;
                    
                }
                break;

            case 8:
                switch(Random.Range(1,9))
                {
                    case 1:
                        appearance1 = enemyList1[Random.Range(0, enemyList1.Length)];
                        appearance3 = enemyList3[Random.Range(0, enemyList3.Length)];
                        break;

                    case 2:
                        appearance1 = enemyList1[Random.Range(0, enemyList1.Length)];
                        appearance4 = enemyList4[Random.Range(0, enemyList4.Length)];
                        break;

                    case 3:
                        appearance1 = enemyList1[Random.Range(0, enemyList1.Length)];
                        appearance5 = enemyList5[Random.Range(0, enemyList5.Length)];
                        break;

                    case 4:
                        appearance1 = enemyList1[Random.Range(0, enemyList1.Length)];
                        appearance6 = enemyList6[Random.Range(0, enemyList6.Length)];
                        break;

                    case 5:
                        appearance2 = enemyList2[Random.Range(0, enemyList2.Length)];
                        appearance4 = enemyList4[Random.Range(0, enemyList4.Length)];
                        appearance6 = enemyList6[Random.Range(0, enemyList6.Length)];
                        break;

                    case 6:
                        appearance1 = enemyList1[Random.Range(0, enemyList1.Length)];
                        appearance3 = enemyList3[Random.Range(0, enemyList3.Length)];
                        appearance5 = enemyList5[Random.Range(0, enemyList5.Length)];
                        break;

                    case 7:
                        appearance1 = enemyList1[Random.Range(0, enemyList1.Length)];
                        appearance3 = enemyList3[Random.Range(0, enemyList3.Length)];
                        appearance6 = enemyList6[Random.Range(0, enemyList6.Length)];
                        break;

                    case 8:
                        appearance1 = enemyList1[Random.Range(0, enemyList1.Length)];
                        appearance4 = enemyList4[Random.Range(0, enemyList4.Length)];
                        appearance6 = enemyList6[Random.Range(0, enemyList6.Length)];
                        break;
                    
                }
                break;

            case 9:
                switch(Random.Range(1,7))
                {
                    case 1:
                        appearance1 = enemyList1[Random.Range(0, enemyList1.Length)];
                        appearance3 = enemyList3[Random.Range(0, enemyList3.Length)];
                        break;

                    case 2:
                        appearance1 = enemyList1[Random.Range(0, enemyList1.Length)];
                        appearance4 = enemyList4[Random.Range(0, enemyList4.Length)];
                        break;

                    case 3:
                        appearance1 = enemyList1[Random.Range(0, enemyList1.Length)];
                        appearance3 = enemyList3[Random.Range(0, enemyList3.Length)];
                        appearance6 = enemyList6[Random.Range(0, enemyList6.Length)];
                        break;

                    case 4:
                        appearance1 = enemyList1[Random.Range(0, enemyList1.Length)];
                        appearance4 = enemyList4[Random.Range(0, enemyList4.Length)];
                        appearance6 = enemyList6[Random.Range(0, enemyList6.Length)];
                        break;

                    case 5:
                        appearance2 = enemyList2[Random.Range(0, enemyList2.Length)];
                        appearance4 = enemyList4[Random.Range(0, enemyList4.Length)];
                        appearance6 = enemyList6[Random.Range(0, enemyList6.Length)];
                        break;

                    case 6:
                        appearance1 = enemyList1[Random.Range(0, enemyList1.Length)];
                        appearance3 = enemyList3[Random.Range(0, enemyList3.Length)];
                        appearance5 = enemyList5[Random.Range(0, enemyList5.Length)];
                        break;
                    
                }
                break;

            case 10:
                switch(Random.Range(1,5))
                {
                    case 1:
                        appearance2 = enemyList2[Random.Range(0, enemyList2.Length)];
                        appearance4 = enemyList4[Random.Range(0, enemyList4.Length)];
                        appearance6 = enemyList6[Random.Range(0, enemyList6.Length)];
                        break;

                    case 2:
                        appearance1 = enemyList1[Random.Range(0, enemyList1.Length)];
                        appearance3 = enemyList3[Random.Range(0, enemyList3.Length)];
                        appearance5 = enemyList5[Random.Range(0, enemyList5.Length)];
                        break;
                    case 3:
                        appearance1 = enemyList1[Random.Range(0, enemyList1.Length)];
                        appearance3 = enemyList3[Random.Range(0, enemyList3.Length)];
                        appearance6 = enemyList6[Random.Range(0, enemyList6.Length)];
                        break;

                    case 4:
                        appearance1 = enemyList1[Random.Range(0, enemyList1.Length)];
                        appearance4 = enemyList4[Random.Range(0, enemyList4.Length)];
                        appearance6 = enemyList6[Random.Range(0, enemyList6.Length)];
                        break;
                    
                }
                break;
                
        }
        */

        
        if(appearance1 == null)
        {
            appearance1 = otherAppearanceList1[Random.Range(0, otherAppearanceList1.Length)];
            if((appearance1 == lifeThread1 && !itemAppearFlg) || (appearance1 == shiroTori1 && !itemAppearFlg) || (appearance1 == hude1 && !itemAppearFlg))
            {
                appearance1 = tori1;
            }
            else if(appearance1 == lifeThread1 && itemAppearFlg)
            {
                GameSystem.instance.InActiveItemAppearFlg();
            }
            else if(appearance1 == shiroTori1 && itemAppearFlg)
            {
                GameSystem.instance.InActiveItemAppearFlg();
            }
            else if(appearance1 == hude1 && itemAppearFlg)
            {
                GameSystem.instance.InActiveItemAppearFlg();
            }
        }

        if(appearance2 == null)
        {
            appearance2 = otherAppearanceList2[Random.Range(0, otherAppearanceList2.Length)];
            if((appearance2 == lifeThread2 && !itemAppearFlg) || (appearance2 == shiroTori2 && !itemAppearFlg) || (appearance2 == hude2 && !itemAppearFlg))
            {
                appearance2 = tori2;
            }
            else if(appearance2 == lifeThread2 && itemAppearFlg)
            {
                GameSystem.instance.InActiveItemAppearFlg();
            }
            else if(appearance2 == shiroTori2 && itemAppearFlg)
            {
                GameSystem.instance.InActiveItemAppearFlg();
            }
            else if(appearance2 == hude2 && itemAppearFlg)
            {
                GameSystem.instance.InActiveItemAppearFlg();
            }
        }

        if(appearance3 == null)
        {
            appearance3 = otherAppearanceList3[Random.Range(0, otherAppearanceList3.Length)];
            if((appearance3 == lifeThread3 && !itemAppearFlg) || (appearance3 == shiroTori3 && !itemAppearFlg) || (appearance3 == hude3 && !itemAppearFlg))
            {
                appearance3 = tori3;
            }
            else if(appearance3 == lifeThread3 && itemAppearFlg)
            {
                GameSystem.instance.InActiveItemAppearFlg();
            }
            else if(appearance3 == shiroTori3 && itemAppearFlg)
            {
                GameSystem.instance.InActiveItemAppearFlg();
            }
            else if(appearance3 == hude3 && itemAppearFlg)
            {
                GameSystem.instance.InActiveItemAppearFlg();
            }
        }

        if(appearance4 == null)
        {
            appearance4 = otherAppearanceList4[Random.Range(0, otherAppearanceList4.Length)];
            if((appearance4 == lifeThread4 && !itemAppearFlg) || (appearance4 == shiroTori4 && !itemAppearFlg) || (appearance4 == hude4 && !itemAppearFlg))
            {
                appearance4 = tori4;
            }
            else if(appearance4 == lifeThread4 && itemAppearFlg)
            {
                GameSystem.instance.InActiveItemAppearFlg();
            }
            else if(appearance4 == shiroTori4 && itemAppearFlg)
            {
                GameSystem.instance.InActiveItemAppearFlg();
            }
            else if(appearance4 == hude4 && itemAppearFlg)
            {
                GameSystem.instance.InActiveItemAppearFlg();
            }
        }

        if(appearance5 == null)
        {
            appearance5 = otherAppearanceList5[Random.Range(0, otherAppearanceList5.Length)];
            if((appearance5 == lifeThread5 && !itemAppearFlg) || (appearance5 == shiroTori5 && !itemAppearFlg) || (appearance5 == hude5 && !itemAppearFlg))
            {
                appearance5 = tori5;
            }
            else if(appearance5 == lifeThread5 && itemAppearFlg)
            {
                GameSystem.instance.InActiveItemAppearFlg();
            }
            else if(appearance5 == shiroTori5 && itemAppearFlg)
            {
                GameSystem.instance.InActiveItemAppearFlg();
            }
            else if(appearance5 == hude5 && itemAppearFlg)
            {
                GameSystem.instance.InActiveItemAppearFlg();
            }
        }

        /*
        if(appearance6 == null)
        {
            appearance6 = otherAppearanceList6[Random.Range(0, otherAppearanceList6.Length)];
            if((appearance6 == lifeThread6 && !itemAppearFlg) || (appearance6 == shiroTori6 && !itemAppearFlg))
            {
                appearance6 = tori6;
            }
            else if(appearance6 == lifeThread6 && itemAppearFlg)
            {
                GameSystem.instance.InActiveItemAppearFlg();
            }
            else if(appearance6 == shiroTori6 && itemAppearFlg)
            {
                GameSystem.instance.InActiveItemAppearFlg();
            }
        }
        */

        // toriをemptyに変える
        /*
        if(appearance1 == tori1 && (Random.Range(0,100) < 30 || Random.Range(0,100) < gear * 9))
        {
            appearance1 = empty1;
        }

        if(appearance2 == tori2 && (Random.Range(0,100) < 30 || Random.Range(0,100) < gear * 9))
        {
            appearance2 = empty2;
        }

        if(appearance3 == tori3　&& (Random.Range(0,100) < 30 || Random.Range(0,100) < gear * 9))
        {
            appearance3 = empty3;
        }

        if(appearance4 == tori4 && (Random.Range(0,100) < 30 || Random.Range(0,100) < gear * 9))
        {
            appearance4 = empty4;
        }

        if(appearance5 == tori5 && (Random.Range(0,100) < 30 || Random.Range(0,100) < gear * 9))
        {
            appearance5 = empty5;
        }

        /*
        if(appearance6 == tori6 && (Random.Range(0,100) < 30 || Random.Range(0,100) < gear * 9))
        {
            appearance6 = empty6;
        }
        */
        
        // toriをobstacleに帰る
        if((appearance1 == tori1 && Random.Range(0,100) < gear * 7) || appearance1 == empty1)
        {
            appearance1 = obstacle1;
        }

        if((appearance2 == tori2 && Random.Range(0,100) < gear * 7) || appearance2 == empty2)
        {
            appearance2 = obstacle2;
        }

        if((appearance3 == tori3 && Random.Range(0,100) < gear * 7) || appearance3 == empty3)
        {
            appearance3 = obstacle3;
        }

        if((appearance4 == tori4 && Random.Range(0,100) < gear * 7) || appearance4 == empty4)
        {
            appearance4 = obstacle4;
        }

        if((appearance5 == tori5 && Random.Range(0,100) < gear * 7) || appearance5 == empty5)
        {
            appearance5 = obstacle5;
        }

        /*
        if(appearance6 == tori6 && Random.Range(0,100) < gear * 5)
        {
            appearance6 = obstacle6;
        }
        */



        appearance1.transform.position = new Vector2(Random.Range(-2.1f, 2.1f), -7.6f + positionY);
        appearance2.transform.position = new Vector2(Random.Range(-2.1f, 2.1f), -3.8f + positionY);
        appearance3.transform.position = new Vector2(Random.Range(-2.1f, 2.1f), positionY);
        appearance4.transform.position = new Vector2(Random.Range(-2.1f, 2.1f), 3.8f + positionY);
        appearance5.transform.position = new Vector2(Random.Range(-2.1f, 2.1f), 7.6f + positionY);
        // appearance6.transform.position = new Vector2(Random.Range(-2.1f, 2.1f), appearance6.transform.position.y);

        /*
        if (gear == 1)
        {
            appearance1 = empty1;
            appearance2 = empty2;
            appearance3 = empty3;
            appearance4.transform.position = new Vector2(Random.Range(-1.5f, 1.5f), -4.8f + positionY);
            appearance5.transform.position = new Vector2(Random.Range(-1.5f, 1.5f), 4.8f + positionY);
        }
        */

        if(gear == 1 || gear == 2 || gear == 3)
        {
            appearance1 = empty1;
            appearance2 = empty2;
            appearance3.transform.position = new Vector2(Random.Range(-2.1f, 2.1f), -6.4f + positionY);
            appearance4.transform.position = new Vector2(Random.Range(-2.1f, 2.1f), positionY);
            appearance5.transform.position = new Vector2(Random.Range(-2.1f, 2.1f), 6.4f + positionY);
        }

        if(gear == 4 || gear == 5)
        {
            appearance1 = empty1;
            appearance2.transform.position = new Vector2(Random.Range(-2.1f, 2.1f), -7.2f + positionY);
            appearance3.transform.position = new Vector2(Random.Range(-2.1f, 2.1f), -2.8f + positionY);
            appearance4.transform.position = new Vector2(Random.Range(-2.1f, 2.1f), 2.8f + positionY);
            appearance5.transform.position = new Vector2(Random.Range(-2.1f, 2.1f), 7.2f + positionY);
        }

        appearance1.SetActive(true);
        appearance2.SetActive(true);
        appearance3.SetActive(true);
        appearance4.SetActive(true);
        appearance5.SetActive(true);
        // appearance6.SetActive(true);

        /*
        if(appearance1.tag == "Enemy")
        {
            appearance1.GetComponent<Enemy>().SetBomFlgFalse();
        }

        if(appearance2.tag == "Enemy")
        {
            appearance2.GetComponent<Enemy>().SetBomFlgFalse();
        }

        if(appearance3.tag == "Enemy")
        {
            appearance3.GetComponent<Enemy>().SetBomFlgFalse();
        }

        if(appearance4.tag == "Enemy")
        {
            appearance4.GetComponent<Enemy>().SetBomFlgFalse();
        }

        if(appearance5.tag == "Enemy")
        {
            appearance5.GetComponent<Enemy>().SetBomFlgFalse();
        }
        */
        

    }
    // エネミーの組み合わせをswitch文で作り、乱数で組み合わせを決める。そしてGameObject変数に入れる。
    // if文で中身が空なものを判定し、空であればその他リストに乱数を指定して入れる。
    // それぞれのGameObjectがアイテムかつアイテム出現時間に達していなかったらエンプティを格納する。
    // ランダムでリストの要素を指定し、行ごとの変数に格納
    // どこの行をアクティブにするか判断
    // 何をアクティブにするか判断
    // 列をそれぞれ指定
    // GameObjectをからにする。



    /*
    const float roadChipSize = 19.2f;
    public int currentChipIndex;
    public Transform player;
    public GameObject[] roadChips;
    public int startChipIndex;
    public int preInstantiate;
    public List<GameObject> generatedRoadList = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        currentChipIndex = startChipIndex - 1;
        UpdateRoad(preInstantiate);
    }

    // Update is called once per frame
    void Update()
    {
        // キャラクターの一から現在のステージチップのインデックスを計算
        int playerPositionIndex = (int)(player.position.y / roadChipSize);

        // 次のステージチップに入ったらステージの更新処理を行う。
        if (playerPositionIndex + preInstantiate > currentChipIndex)
        {
            UpdateRoad(playerPositionIndex + preInstantiate);
        }
    }

    public void UpdateRoad(int toChipIndex)
    {
        if (toChipIndex <= currentChipIndex) return;

        // 指定のステージチップまでを作成
        for (int i = currentChipIndex + 1; i <= toChipIndex; i++)
        {
            GameObject roadObject = GenerateRoad(i);

            // 生成したステージチップを管理リストに追加
            generatedRoadList.Add(roadObject);
        }

        // ステージ保持上限ないになるまで古いステージを削除
        while (generatedRoadList.Count > preInstantiate + 2) DestroyOlderStage();
        currentChipIndex = toChipIndex;
    }

    public GameObject GenerateRoad (int chipIndex)
    {
        int nextRoadChip = Random.Range(0, roadChips.Length);

        GameObject roadObject = (GameObject)Instantiate(
            roadChips[nextRoadChip],
            new Vector3(0, 0, chipIndex * roadChipSize),
            Quaternion.indentity
        );
        return roadObject;
    }

    public void DestroyOldestStage()
    {
        GameObject oldRoad = generatedRoadList[0];
        generatedRoadList.RemoveAt(0);
        Destroy(oldRoad);
    }
    */

    public void MakeStage()
    {

        appearance1 = null;
        appearance2 = null;
        appearance3 = null;
        appearance4 = null;
        appearance5 = null;


        switch(Random.Range(0,4))
        {

            // ストレート　ボンバー　岩
            case 0:
            appearance1 = bomber1;
            appearance2 = obstacle2;
            appearance3 = bomber3;
            appearance4 = obstacle4;
            appearance5 = bomber5;
            
            appearancePositionX = Random.Range(-1.5f, 1.5f);

            appearance1.transform.position = new Vector2(appearancePositionX, -7.6f + positionY);
            appearance2.transform.position = new Vector2(appearancePositionX, -3.8f + positionY);
            appearance3.transform.position = new Vector2(appearancePositionX, positionY);
            appearance4.transform.position = new Vector2(appearancePositionX, 3.8f + positionY);
            appearance5.transform.position = new Vector2(appearancePositionX, 7.6f + positionY);
            break;

            case 1:
            appearance1 = bomber1;
            appearance2 = bomber2;
            appearance3 = bomber3;
            appearance4 = bomber4;
            appearance5 = bomber5;

            appearancePositionX = Random.Range(-2.1f, 2.1f);

            appearance1.transform.position = new Vector2(appearancePositionX, -7.6f + positionY);
            appearance2.transform.position = new Vector2(appearancePositionX, -3.8f + positionY);
            appearance3.transform.position = new Vector2(appearancePositionX, positionY);
            appearance4.transform.position = new Vector2(appearancePositionX, 3.8f + positionY);
            appearance5.transform.position = new Vector2(appearancePositionX, 7.6f + positionY);
            break;

            case 2:
            appearance1 = tori1;
            appearance2 = tori2;
            appearance3 = tori3;
            appearance4 = tori4;
            appearance5 = tori5;

            appearancePositionX = Random.Range(-2.1f, 2.1f);

            appearance1.transform.position = new Vector2(appearancePositionX, -7.6f + positionY);
            appearance2.transform.position = new Vector2(appearancePositionX, -3.8f + positionY);
            appearance3.transform.position = new Vector2(appearancePositionX, positionY);
            appearance4.transform.position = new Vector2(appearancePositionX, 3.8f + positionY);
            appearance5.transform.position = new Vector2(appearancePositionX, 7.6f + positionY);
            break;

            case 3:
            appearance1 = obstacle1;
            appearance2 = obstacle2;
            appearance3 = obstacle3;
            appearance4 = obstacle4;
            appearance5 = obstacle5;

            appearancePositionX = Random.Range(-1f, 1f);

            appearance1.transform.position = new Vector2(appearancePositionX, -7.6f + positionY);
            appearance2.transform.position = new Vector2(appearancePositionX, -3.8f + positionY);
            appearance3.transform.position = new Vector2(appearancePositionX, positionY);
            appearance4.transform.position = new Vector2(appearancePositionX, 3.8f + positionY);
            appearance5.transform.position = new Vector2(appearancePositionX, 7.6f + positionY);
            break;

            case 4:
            appearance1 = rollingBomber1;
            appearance2 = rollingBomber2;
            appearance3 = rollingBomber3;
            appearance4 = rollingBomber4;
            appearance5 = rollingBomber5;

            appearancePositionX = Random.Range(-2.1f, 2.1f);

            appearance1.transform.position = new Vector2(appearancePositionX, -7.6f + positionY);
            appearance2.transform.position = new Vector2(appearancePositionX, -3.8f + positionY);
            appearance3.transform.position = new Vector2(appearancePositionX, positionY);
            appearance4.transform.position = new Vector2(appearancePositionX, 3.8f + positionY);
            appearance5.transform.position = new Vector2(appearancePositionX, 7.6f + positionY);
            break;

            case 5:
            appearance1 = rollingBomber1;
            appearance2 = rollingBomber2;
            appearance3 = rollingBomber3;
            appearance4 = rollingBomber4;
            appearance5 = rollingBomber5;

            appearance1.transform.position = new Vector2(-2.1f, -7.6f + positionY);
            appearance2.transform.position = new Vector2(-1f, -3.8f + positionY);
            appearance3.transform.position = new Vector2(0f, positionY);
            appearance4.transform.position = new Vector2(1f, 3.8f + positionY);
            appearance5.transform.position = new Vector2(2.1f, 7.6f + positionY);
            break;

            case 6:
            appearance1 = rollingBomber1;
            appearance2 = rollingBomber2;
            appearance3 = rollingBomber3;
            appearance4 = rollingBomber4;
            appearance5 = rollingBomber5;

            appearance1.transform.position = new Vector2(2.1f, -7.6f + positionY);
            appearance2.transform.position = new Vector2(1f, -3.8f + positionY);
            appearance3.transform.position = new Vector2(0f, positionY);
            appearance4.transform.position = new Vector2(-1f, 3.8f + positionY);
            appearance5.transform.position = new Vector2(-2.1f, 7.6f + positionY);
            break;

            case 7:
            appearance1 = bomber1;
            appearance2 = bomber2;
            appearance3 = bomber3;
            appearance4 = bomber4;
            appearance5 = bomber5;

            appearance1.transform.position = new Vector2(-2.1f, -7.6f + positionY);
            appearance2.transform.position = new Vector2(-1f, -3.8f + positionY);
            appearance3.transform.position = new Vector2(0f, positionY);
            appearance4.transform.position = new Vector2(1f, 3.8f + positionY);
            appearance5.transform.position = new Vector2(2.1f, 7.6f + positionY);
            break;

            case 8:
            appearance1 = bomber1;
            appearance2 = bomber2;
            appearance3 = bomber3;
            appearance4 = bomber4;
            appearance5 = bomber5;

            appearance1.transform.position = new Vector2(2.1f, -7.6f + positionY);
            appearance2.transform.position = new Vector2(1f, -3.8f + positionY);
            appearance3.transform.position = new Vector2(0f, positionY);
            appearance4.transform.position = new Vector2(-1f, 3.8f + positionY);
            appearance5.transform.position = new Vector2(-2.1f, 7.6f + positionY);
            break;



        }

        appearance1.SetActive(true);
        appearance2.SetActive(true);
        appearance3.SetActive(true);
        appearance4.SetActive(true);
        appearance5.SetActive(true);
    }

    public void SetActiveFalseAppearance()
    {
        if(appearance1 != null)
        {
            if(appearance1.activeSelf)
            {
                appearance1.SetActive(false);
            }
        }
        
        if(appearance2 != null)
        {
            if(appearance2.activeSelf)
            {
                appearance2.SetActive(false);
            }
        }

        if(appearance3 != null)
        {
            if(appearance3.activeSelf)
            {
                appearance3.SetActive(false);
            }
        }

        if(appearance4 != null)
        {
            if(appearance4.activeSelf)
            {
                appearance4.SetActive(false);
            }
        }
        if(appearance5 != null)
        {
            if(appearance5.activeSelf)
            {
                appearance5.SetActive(false);
            }
        }
    }
}
