using UnityEngine;
using System.Collections;

using System;
// using UnityEngine.iOS;
using System.Collections.Generic;

public class DrawLine : MonoBehaviour
{

    public GameObject linePrefab;
    public GameObject linePrefabFirst;
    public GameObject linePrefabLast;
    public float lineLength;
    public float lineWidth;

    private Vector3 touchPos;
    private Vector3 touchPos1;
    public int lineNumber;
    public int layerNumber;
    public bool liberationFlg;
    // public GameObject liberationPower;
    public GameObject player;
    // public bool firstFinger;
    public GameObject hogeki;
    public int hogekiCount;
    public Vector3 startPos;
    public Vector3 endPos;
    public Vector3 startPos1;
    public Vector3 endPos1;
    public bool hogekiFlg;
    public bool hogekiFlg1;
    public Vector3 hogekiStartPos;
    public Vector3 hogekiEndPos;
    public Vector3 hogekiStartPos1;
    public Vector3 hogekiEndPos1;
    public int bokujuCount;
    public bool rankingFlg;
    public static DrawLine instance;
    public float powerTime;
    public bool dashFlg;
    public float acceleration;
    public bool startFlg;
    public AudioClip soundEffect;  // 再生する効果音
    public AudioSource audioSource;
    public GameObject obj;
    public GameObject fude;
    public float demoTime;
    public int lineCount;
    public float scaleUp;
    public GameObject[] objs;
    public Vector3 lineStartPos;
    public float scalePlus;
    public float scaleMulti;

    public void Awake()
    {
        instance = this;
    }

    void Start()
    {
        // Debug.unityLogger.logEnabled = true;
        lineStartPos = new Vector3(0, -100, 0);
        layerNumber = 200;
        if (Input.touchSupported)
        {
            // Debug.Log("タッチ入力に対応している");
        }
        else
        {

            // Debug.Log("タッチ入力に対応していない");
        }
        objs = new GameObject[100];
        for (int i = 0; i < objs.Length; i++)
        {
            if (i % 2 == 0)
            {
                objs[i] = Instantiate(linePrefabFirst, lineStartPos, transform.rotation) as GameObject;
            }
            else
            {
                objs[i] = Instantiate(linePrefabLast, lineStartPos, transform.rotation) as GameObject;
            }
            objs[i].transform.parent = this.transform;
            layerNumber--;
            objs[i].GetComponent<Renderer>().sortingOrder = layerNumber;
            // objs[i].SetActive(false);
        }

    }

    void Update()
    {


        if (!startFlg)
        {
            demoTime += Time.deltaTime;

            return;
        }

        if (bokujuCount <= 0)
        {
            return;
        }
        for (int i = 0; i < Input.touchCount; i++)
        {
            int id = Input.touches[i].fingerId;
            if (id == 0)
            {
                // drawLine(Input.GetTouch(i));
                SPDraw(Input.GetTouch(i));
            }
            else if (id == 1)
            {
                // drawLine1(Input.GetTouch(i));
            }

        }
        if (!Input.touchSupported)
        {
            // drawLine2();
            PCDraw();
        }

    }

    public void SPDraw(Touch touch)
    {
        switch (touch.phase)
        {
            case TouchPhase.Began:
                BeganDraw(touch.position);
                break;

            case TouchPhase.Moved:
                MoveDraw(touch.position);
                break;

            case TouchPhase.Ended:
                EndDraw(touch.position);
                break;
        }
    }

    public void PCDraw()
    {
        if (Input.GetMouseButtonDown(0))
        {
            BeganDraw(Input.mousePosition);
        }

        if (Input.GetMouseButton(0))
        {
            MoveDraw(Input.mousePosition);
        }


        if (Input.GetMouseButtonUp(0))
        {
            EndDraw(Input.mousePosition);
        }
    }

    public void BeganDraw(Vector3 inputPos)
    {
        StartCoroutine("AudioFadeIn");
        touchPos = Camera.main.ScreenToWorldPoint(inputPos);
        touchPos.z = 0;
        fude.SetActive(true);
        fude.transform.position = new Vector3(touchPos.x + 1f, touchPos.y, -4);
        // VibrationMng.ShortVibration();
    }

    public void MoveDraw(Vector3 inputPos)
    {
        startPos = touchPos;
        endPos = Camera.main.ScreenToWorldPoint(inputPos);
        Debug.Log("aa" + Camera.main.ScreenToWorldPoint(inputPos));
        endPos.z = 0;
        fude.transform.position = new Vector3(endPos.x + 1f, endPos.y, -4);
        if (startPos.y > endPos.y)
        {
            return;
        }

        if ((endPos - startPos).magnitude > lineLength)
        {
            Debug.Log(Mathf.Floor((endPos - startPos).magnitude / lineLength));
            float need = Mathf.Floor((endPos - startPos).magnitude / lineLength);
            for (int n = 0; n < need; n++)
            {
                // scaleMulti = (endPos - startPos).sqrMagnitude / lineLength;
                float posPer = (n + 1) / need;
                objs[lineCount].transform.position = startPos + (endPos - startPos) * posPer;

                // objs[lineCount].transform.right = (endPos - startPos).normalized;
                // objs[lineCount].transform.localScale = new Vector3(((endPos - startPos).magnitude + scalePlus) * scaleMulti, lineWidth, lineWidth);
                // objs[lineCount].transform.localScale = new Vector3(lineLength * scaleMulti ,  lineWidth, lineWidth);
                objs[lineCount].GetComponent<Line>().SetLineCount(lineCount);
                objs[lineCount].GetComponent<Line>().SetDir((endPos - startPos).normalized);

                if (lineCount >= objs.Length - 1)
                {
                    lineCount = 0;
                }
                else
                {
                    lineCount++;
                }
            }
            touchPos = endPos;
        }
        // VibrationMng.ShortVibration();
    }

    public void EndDraw(Vector3 inputPos)
    {
        startPos = touchPos;
        endPos = Camera.main.ScreenToWorldPoint(inputPos);
        endPos.z = 0;
        fude.SetActive(false);
        StartCoroutine("AudioFadeOut");
        if (startPos.y > endPos.y)
        {
            return;
        }
        // objs[lineCount].SetActive(true);
        /*
        objs[lineCount].transform.position = (startPos + endPos) / 2;
        objs[lineCount].transform.right = (endPos - startPos).normalized;
        objs[lineCount].transform.localScale = new Vector3(((endPos - startPos).magnitude + scalePlus) * scaleMulti,  lineWidth, lineWidth);
        objs[lineCount].GetComponent<Line>().SetLineCount(lineCount);
        touchPos = endPos;
        if(lineCount >= objs.Length - 1)
        {
            lineCount = 0;
        }
        else
        {
            lineCount++;
        }
        */
    }

    public void StartFlgTrue()
    {
        startFlg = true;
    }

    public void StartFlgFalse()
    {
        startFlg = false;
    }

    void drawLine(Touch touch)
    {
        switch (touch.phase)
        {
            case TouchPhase.Began:
                lineCount++;
                obj = null;
                // audioSource.Play();
                StartCoroutine("AudioFadeIn");
                touchPos = Camera.main.ScreenToWorldPoint(touch.position);
                touchPos.z = 0;
                fude.SetActive(true);
                endPos = touchPos;
                fude.transform.position = new Vector3(endPos.x + 1f, endPos.y, -4);
                layerNumber = 100;
                /*
                obj = Instantiate(linePrefabFirst, transform.position, transform.rotation) as GameObject;
            
            obj.transform.position = touchPos;
            // obj.transform.right = 1;
            

            // obj.transform.localScale = new Vector3(1, lineWidth, lineWidth);
            // obj.transform.localScale = new Vector3((endPos - startPos).magnitude * 1.5f, lineWidth * 0.8f, lineWidth);
            obj.transform.localScale = new Vector3(1.5f, 1.5f, lineWidth);
            obj.GetComponent<Renderer>().sortingOrder = layerNumber + 10;
            obj.transform.parent = this.transform;
            obj.GetComponent<Line>().SetLineCount(lineCount + 10);
            */
                lineCount++;


                break;

            case TouchPhase.Moved:

                // powerTime += Time.deltaTime;
                /*
                if(powerTime > 1f && !dashFlg)
                {
                    VibrationMng.ShortVibration();
                    dashFlg = true;
                }
                */

                startPos = touchPos;
                endPos = Camera.main.ScreenToWorldPoint(touch.position);
                fude.transform.position = new Vector3(endPos.x + 1f, endPos.y, -4);
                endPos.z = 0;
                // ここ1
                if (startPos.y > endPos.y && hogekiCount > 0 && !hogekiFlg)
                {
                    hogekiStartPos = touch.position;
                    hogekiFlg = true;
                    return;
                }
                if (startPos.y > endPos.y)
                {
                    return;
                }

                // Debug.Log(layerNumber);

                if (layerNumber < 50)
                {
                    // Debug.Log("a");
                    // return;
                }

                if ((endPos - startPos).magnitude > 1)
                {
                    // Debug.Log("cloud");
                }
                if ((endPos - startPos).magnitude > lineLength)
                {
                    obj = null;


                    switch (lineNumber)
                    {
                        case 0:
                            obj = Instantiate(linePrefab, transform.position, transform.rotation) as GameObject;
                            lineNumber = 1;
                            break;

                        case 1:
                            obj = Instantiate(linePrefabLast, transform.position, transform.rotation) as GameObject;
                            lineNumber = 0;
                            break;
                    }

                    obj.transform.position = (startPos + endPos) / 2;
                    obj.transform.right = (endPos - startPos).normalized;

                    // obj.transform.localScale = new Vector3(1, lineWidth, lineWidth);
                    obj.transform.localScale = new Vector3((endPos - startPos).magnitude + 0.2f, lineWidth, lineWidth);
                    obj.GetComponent<Renderer>().sortingOrder = layerNumber;

                    obj.transform.parent = this.transform;
                    obj.GetComponent<Line>().SetLineCount(lineCount);


                    touchPos = endPos;
                    layerNumber--;
                }

                break;

            case TouchPhase.Ended:
                startPos = touchPos;
                endPos = Camera.main.ScreenToWorldPoint(touch.position);
                endPos.z = 0;
                StartCoroutine("AudioFadeOut");
                if (startPos.y > endPos.y)
                {
                    return;
                }
                obj = null;
                switch (lineNumber)
                {
                    case 0:
                        obj = Instantiate(linePrefab, transform.position, transform.rotation) as GameObject;
                        lineNumber = 1;
                        break;

                    case 1:
                        obj = Instantiate(linePrefabLast, transform.position, transform.rotation) as GameObject;
                        lineNumber = 0;
                        break;
                }
                obj.transform.position = (startPos + endPos) / 2;
                obj.transform.right = (endPos - startPos).normalized;
                obj.transform.localScale = new Vector3((endPos - startPos).magnitude + 0.2f, lineWidth, lineWidth);
                obj.GetComponent<Renderer>().sortingOrder = layerNumber;
                obj.transform.parent = this.transform;
                obj.GetComponent<Line>().SetLineCount(lineCount);



                obj.SetActive(false);
                powerTime = 0;
                fude.SetActive(false);
                /*
                if(dashFlg)
                {
                    player.GetComponent<Player>().SetAcceleration(acceleration);
                    dashFlg = false;
                }
                */
                if (hogekiCount <= 0 || !hogekiFlg)
                {
                    return;
                }
                // startPos = touchPos;
                hogekiStartPos = Camera.main.ScreenToWorldPoint(hogekiStartPos);
                hogekiStartPos.z = 0;
                hogekiEndPos = Camera.main.ScreenToWorldPoint(touch.position);
                hogekiEndPos.z = 0;
                /*
                if ((endPos - startPos).magnitude < 1)
                {
                    return;
                }
                */
                GameObject hogekiObj = null;
                hogekiObj = Instantiate(hogeki, transform.position, transform.rotation);
                hogekiObj.transform.position = hogekiEndPos;
                hogekiObj.transform.right = (hogekiStartPos - hogekiEndPos).normalized;
                // obj.transform.localScale = new Vector3((endPos - startPos).magnitude, lineWidth, lineWidth);
                // obj.GetComponent<Hogeki>().Shot(new Vector3((endPos - startPos).magnitude, lineWidth, lineWidth));
                if ((hogekiStartPos - hogekiEndPos).magnitude > 3)
                {
                    hogekiObj.GetComponent<Hogeki>().Shot((hogekiStartPos - hogekiEndPos).normalized * 3f * 0.1f, hogekiCount);
                }
                else
                {
                    hogekiObj.GetComponent<Hogeki>().Shot((hogekiStartPos - hogekiEndPos).normalized * (hogekiStartPos - hogekiEndPos).magnitude * 0.1f, hogekiCount);
                }
                hogekiFlg = false;
                // BokujuCountDown();
                break;
        }

    }

    /*
        void drawLine1(Touch touch)
        {
            switch (touch.phase)
            {
                case TouchPhase.Began:
                    touchPos1 = Camera.main.ScreenToWorldPoint(touch.position);
                    touchPos1.z = 0;
                    // layerNumber = 100;
                    break;

                case TouchPhase.Moved:
                    startPos1 = touchPos1;
                    endPos1 = Camera.main.ScreenToWorldPoint(touch.position);
                    endPos1.z = 0;
                    // ここ3
                    if (startPos1.y > endPos1.y && hogekiCount > 0  && !hogekiFlg1)
                    {
                        hogekiStartPos1 = touch.position;
                        hogekiFlg1 = true;
                        return;
                    }
                    else if (startPos1.y > endPos1.y)
                    {
                        return;
                    }
                    if ((endPos1 - startPos1).magnitude > lineLength)
                    {


                        GameObject obj = null;


                        switch(lineNumber)
                        {
                            case 0:
                            obj = Instantiate(linePrefab, transform.position, transform.rotation) as GameObject;
                            lineNumber = 1;

                            break;

                            case 1:
                            obj = Instantiate(linePrefabLast, transform.position, transform.rotation) as GameObject;
                            lineNumber = 0;
                            break;
                        }

                        obj.transform.position = (startPos1 + endPos1) / 2;
                        obj.transform.right = (endPos1 - startPos1).normalized;

                        // obj.transform.localScale = new Vector3(1, lineWidth, lineWidth);
                        obj.transform.localScale = new Vector3((endPos1 - startPos1).magnitude, (endPos1 - startPos1).magnitude, lineWidth);
                        obj.GetComponent<Renderer>().sortingOrder = layerNumber;
                        obj.transform.parent = this.transform;


                        touchPos1 = endPos1;
                        // layerNumber --;
                    }
                    break;

                case TouchPhase.Ended:
                // ここ4
                    // BokujuCountDown();

                    if (hogekiCount <= 0 || !hogekiFlg1)
                    {
                        return;
                    }
                    // startPos = touchPos;
                    hogekiStartPos1 = Camera.main.ScreenToWorldPoint(hogekiStartPos1);
                    hogekiStartPos1.z = 0;
                    hogekiEndPos1 = Camera.main.ScreenToWorldPoint(touch.position);
                    hogekiEndPos1.z = 0;
                    /*
                    if ((endPos - startPos).magnitude < 1)
                    {
                        return;
                    }
                    */
    /*
    GameObject hogekiObj1 = null;
    hogekiObj1 = Instantiate(hogeki, transform.position, transform.rotation);
    hogekiObj1.transform.position = hogekiEndPos1;
    hogekiObj1.transform.right = (hogekiStartPos1 - hogekiEndPos1).normalized;
    // obj.transform.localScale = new Vector3((endPos - startPos).magnitude, lineWidth, lineWidth);
    // obj.GetComponent<Hogeki>().Shot(new Vector3((endPos - startPos).magnitude, lineWidth, lineWidth));
    if((hogekiStartPos1 - hogekiEndPos1).magnitude > 3f)
    {
        hogekiObj1.GetComponent<Hogeki>().Shot((hogekiStartPos1 - hogekiEndPos1).normalized * 3f * 0.1f, hogekiCount);
    }
    else 
    {
        hogekiObj1.GetComponent<Hogeki>().Shot((hogekiStartPos1 - hogekiEndPos1).normalized * (hogekiStartPos1 - hogekiEndPos1).magnitude * 0.1f, hogekiCount);
    }
    hogekiFlg1 = false;
    // BokujuCountDown();
    break;

}

}
*/

    public void drawLine2()
    {
        /*
        if (liberationFlg && Input.GetMouseButtonDown(0))
        {
            Vector2 liberationPowerPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if (liberationPowerPos.y < player.transform.position.y)
            {
                return;
            }

            Instantiate(liberationPower, liberationPowerPos , transform.rotation);
            liberationFlg = false;
        }
        */

        if (Input.GetMouseButtonDown(0))
        {

            // Vector2 cloudPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            /*
            if (player.transform.position.y - 1 > cloudPos.y)
            {
                return;
            }
            */
            // obj = null;
            // audioSource.Play();
            StartCoroutine("AudioFadeIn");
            touchPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            touchPos.z = 0;
            fude.SetActive(true);
            //ここ endPos = touchPos;
            startPos = touchPos;
            fude.transform.position = new Vector3(endPos.x + 1f, endPos.y, -4);
            layerNumber = 100;
            lineCount++;
            /*
            obj = Instantiate(linePrefabFirst, transform.position, transform.rotation) as GameObject;
            
            obj.transform.position = startPos;
            // obj.transform.right = 1;
            

            // obj.transform.localScale = new Vector3(1, lineWidth, lineWidth);
            // obj.transform.localScale = new Vector3((endPos - startPos).magnitude * 1.5f, lineWidth * 0.8f, lineWidth);
            obj.transform.localScale = new Vector3(1.5f, 1.5f, lineWidth);
            obj.GetComponent<Renderer>().sortingOrder = layerNumber + 10;
            obj.transform.parent = this.transform;
            obj.GetComponent<Line>().SetLineCount(lineCount + 10);
            */
            lineCount++;



            // obj.transform.position = touchPos;
            // firstFinger = true;
            /*
            Vector3 startPos = touchPos;
            Vector3 endPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            endPos.z = 0;
            GameObject obj = Instantiate(linePrefab, transform.position, transform.rotation) as GameObject;
            obj.transform.position = (startPos + endPos) / 2;
            obj.transform.right = (endPos - startPos).normalized;
            obj.transform.localScale = new Vector3(1, lineWidth, lineWidth);
            obj.transform.parent = this.transform;
            touchPos = endPos;
            */


        }

        if (Input.GetMouseButton(0))
        {
            /* Touch touch = Input.GetTouch(0);
            if (touch.fingerId != 0)
            {
                return;
            }
            */
            // Vector2 cloudPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            /*
            if (player.transform.position.y - 1 > cloudPos.y)
            {
                touchPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                touchPos.z = 0;
                layerNumber = 100;
                return;
            }
            */

            // powerTime += Time.deltaTime;
            /*
            if(powerTime > 1f && !dashFlg)
            {
                VibrationMng.ShortVibration();
                powerTime = 0;
                dashFlg = true;
            }
            */

            powerTime += Time.deltaTime;
            startPos = touchPos;
            endPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            fude.transform.position = new Vector3(endPos.x + 1f, endPos.y, -4);

            endPos.z = 0;
            // ここ5
            if (startPos.y > endPos.y && hogekiCount > 0 && !hogekiFlg)
            {
                hogekiStartPos = Input.mousePosition;
                hogekiFlg = true;
                return;
            }
            if (startPos.y > endPos.y)
            {
                return;
            }

            // Debug.Log(layerNumber);
            if (layerNumber < 50)
            {
                // Debug.Log("a");
                //return;
            }

            if ((endPos - startPos).magnitude > lineLength)
            {


                obj = null;




                switch (lineNumber)
                {
                    case 0:
                        obj = Instantiate(linePrefab, transform.position, transform.rotation) as GameObject;
                        lineNumber = 1;
                        break;

                    case 1:
                        obj = Instantiate(linePrefabLast, transform.position, transform.rotation) as GameObject;
                        lineNumber = 0;
                        break;
                }

                obj.transform.position = (startPos + endPos) / 2;
                obj.transform.right = (endPos - startPos).normalized;


                // obj.transform.localScale = new Vector3(1, lineWidth, lineWidth);
                // obj.transform.localScale = new Vector3((endPos - startPos).magnitude * 1.5f, lineWidth * 0.8f, lineWidth);
                obj.transform.localScale = new Vector3((endPos - startPos).magnitude + 0.2f, lineWidth, lineWidth);
                obj.GetComponent<Renderer>().sortingOrder = layerNumber;
                obj.transform.parent = this.transform;
                obj.GetComponent<Line>().SetLineCount(lineCount);


                touchPos = endPos;
                layerNumber--;

            }

        }


        if (Input.GetMouseButtonUp(0))
        {
            startPos = touchPos;
            endPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            endPos.z = 0;
            StartCoroutine("AudioFadeOut");
            if (startPos.y > endPos.y)
            {
                return;
            }
            obj = null;
            switch (lineNumber)
            {
                case 0:
                    obj = Instantiate(linePrefab, transform.position, transform.rotation) as GameObject;
                    lineNumber = 1;
                    break;

                case 1:
                    obj = Instantiate(linePrefabLast, transform.position, transform.rotation) as GameObject;
                    lineNumber = 0;
                    break;
            }
            obj.transform.position = (startPos + endPos) / 2;
            obj.transform.right = (endPos - startPos).normalized;
            obj.transform.localScale = new Vector3((endPos - startPos).magnitude + 0.2f, lineWidth, lineWidth);
            obj.GetComponent<Renderer>().sortingOrder = layerNumber;
            obj.transform.parent = this.transform;
            obj.GetComponent<Line>().SetLineCount(lineCount);

            /*
            obj = Instantiate(linePrefabFirst, transform.position, transform.rotation) as GameObject;
            
            obj.transform.position = endPos;
            // obj.transform.right = 1;
            

            // obj.transform.localScale = new Vector3(1, lineWidth, lineWidth);
            // obj.transform.localScale = new Vector3((endPos - startPos).magnitude * 1.5f, lineWidth * 0.8f, lineWidth);
            obj.transform.localScale = new Vector3(1.2f, 1.2f, lineWidth);
            obj.GetComponent<Renderer>().sortingOrder = layerNumber;
            obj.transform.parent = this.transform;
            obj.GetComponent<Line>().SetLineCount(lineCount);
            lineCount ++;
            */

            fude.SetActive(false);
            // obj.SetActive(false);
            powerTime = 0;
            /*
            if(dashFlg)
            {
                player.GetComponent<Player>().SetAcceleration(acceleration);
                dashFlg = false;
            }
            */
            if (hogekiCount <= 0 || !hogekiFlg)
            {
                return;
            }
            // startPos = touchPos;
            hogekiStartPos = Camera.main.ScreenToWorldPoint(hogekiStartPos);
            hogekiStartPos.z = 0;
            hogekiEndPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            hogekiEndPos.z = 0;
            /*
            if ((endPos - startPos).magnitude < 1)
            {
                return;
            }
            */
            GameObject hogekiObj = null;
            hogekiObj = Instantiate(hogeki, transform.position, transform.rotation);
            hogekiObj.transform.position = hogekiEndPos;
            hogekiObj.transform.right = (hogekiStartPos - hogekiEndPos).normalized;
            // obj.transform.localScale = new Vector3((endPos - startPos).magnitude, lineWidth, lineWidth);
            // obj.GetComponent<Hogeki>().Shot(new Vector3((endPos - startPos).magnitude, lineWidth, lineWidth));

            if ((hogekiStartPos - hogekiEndPos).magnitude > 3f)
            {
                hogekiObj.GetComponent<Hogeki>().Shot((hogekiStartPos - hogekiEndPos).normalized * 3f * 0.1f, hogekiCount);
            }
            else
            {
                hogekiObj.GetComponent<Hogeki>().Shot((hogekiStartPos - hogekiEndPos).normalized * (hogekiStartPos - hogekiEndPos).magnitude * 0.1f, hogekiCount);
            }
            /*
            if(hogekiStartPos.y - hogekiEndPos.y > 0)
            {
                hogekiObj.GetComponent<Hogeki>().Shot((hogekiStartPos - hogekiEndPos).normalized * (hogekiStartPos - hogekiEndPos).magnitude * 0.2f, hogekiCount);
            }
            else if (hogekiStartPos.y - hogekiEndPos.y < 0)
            {
                hogekiObj.GetComponent<Hogeki>().Shot((hogekiEndPos - hogekiStartPos).normalized * (hogekiEndPos - hogekiStartPos).magnitude * 0.2f, hogekiCount);
            }
            */
            hogekiFlg = false;
            // BokujuCountDown();

        }
    }

    public void drawLine2_kaminote()
    {
        /*
        if (liberationFlg && Input.GetMouseButtonDown(0))
        {
            Vector2 liberationPowerPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if (liberationPowerPos.y < player.transform.position.y)
            {
                return;
            }

            Instantiate(liberationPower, liberationPowerPos , transform.rotation);
            liberationFlg = false;
        }
        */

        if (Input.GetMouseButtonDown(0))
        {

            // Vector2 cloudPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            /*
            if (player.transform.position.y - 1 > cloudPos.y)
            {
                return;
            }
            */
            obj = null;
            // audioSource.Play();
            StartCoroutine("AudioFadeIn");
            touchPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            touchPos.z = 0;
            layerNumber = 100;
            obj = Instantiate(linePrefabLast, transform.position, transform.rotation) as GameObject;
            obj.transform.position = touchPos;
            // firstFinger = true;
            /*
            Vector3 startPos = touchPos;
            Vector3 endPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            endPos.z = 0;
            GameObject obj = Instantiate(linePrefab, transform.position, transform.rotation) as GameObject;
            obj.transform.position = (startPos + endPos) / 2;
            obj.transform.right = (endPos - startPos).normalized;
            obj.transform.localScale = new Vector3(1, lineWidth, lineWidth);
            obj.transform.parent = this.transform;
            touchPos = endPos;
            */


        }

        if (Input.GetMouseButton(0))
        {
            /* Touch touch = Input.GetTouch(0);
            if (touch.fingerId != 0)
            {
                return;
            }
            */
            // Vector2 cloudPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            /*
            if (player.transform.position.y - 1 > cloudPos.y)
            {
                touchPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                touchPos.z = 0;
                layerNumber = 100;
                return;
            }
            */

            // powerTime += Time.deltaTime;
            /*
            if(powerTime > 1f && !dashFlg)
            {
                VibrationMng.ShortVibration();
                powerTime = 0;
                dashFlg = true;
            }
            */
            /*ここだよ
            powerTime += Time.deltaTime;
            startPos = touchPos;
            endPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            endPos.z = 0;
            // ここ5
            if (startPos.y > endPos.y && hogekiCount > 0 && !hogekiFlg)
            {
                hogekiStartPos = Input.mousePosition;
                hogekiFlg = true;
                return;
            }
            else if (startPos.y > endPos.y)
            {
                // return;
            }

            // Debug.Log(layerNumber);
            if (layerNumber < 50)
            {
                // Debug.Log("a");
                //return;
            }

            if ((endPos - startPos).magnitude > lineLength)
            {

            
                GameObject obj = null;


                switch(lineNumber)
                {
                    case 0:
                    obj = Instantiate(linePrefab, transform.position, transform.rotation) as GameObject;
                    lineNumber = 1;
                    break;

                    case 1:
                    obj = Instantiate(linePrefabLast, transform.position, transform.rotation) as GameObject;
                    lineNumber = 0;
                    break;
                }
                
                obj.transform.position = (startPos + endPos) / 2;
                obj.transform.right = (endPos - startPos).normalized;

                // obj.transform.localScale = new Vector3(1, lineWidth, lineWidth);
                obj.transform.localScale = new Vector3((endPos - startPos).magnitude, lineWidth, lineWidth);
                obj.GetComponent<Renderer>().sortingOrder = layerNumber;
                obj.transform.parent = this.transform;


                touchPos = endPos;
                layerNumber --;
            }
            ここだよ*/


            obj.transform.position = (touchPos + endPos) / 2;
            endPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            endPos.z = 0;
            obj.transform.right = (endPos - touchPos).normalized;
            obj.transform.localScale = new Vector3(lineWidth, (endPos - touchPos).magnitude, lineWidth);
            obj.GetComponent<Renderer>().sortingOrder = layerNumber;
            obj.transform.parent = this.transform;
        }


        if (Input.GetMouseButtonUp(0))
        {
            // ここ6
            // BokujuCountDown();
            // Invoke("AudioStop",0.4f);
            // audioSource.Stop();
            StartCoroutine("AudioFadeOut");
            obj.SetActive(false);
            powerTime = 0;
            /*
            if(dashFlg)
            {
                player.GetComponent<Player>().SetAcceleration(acceleration);
                dashFlg = false;
            }
            */
            if (hogekiCount <= 0 || !hogekiFlg)
            {
                return;
            }
            // startPos = touchPos;
            hogekiStartPos = Camera.main.ScreenToWorldPoint(hogekiStartPos);
            hogekiStartPos.z = 0;
            hogekiEndPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            hogekiEndPos.z = 0;
            /*
            if ((endPos - startPos).magnitude < 1)
            {
                return;
            }
            */
            GameObject hogekiObj = null;
            hogekiObj = Instantiate(hogeki, transform.position, transform.rotation);
            hogekiObj.transform.position = hogekiEndPos;
            hogekiObj.transform.right = (hogekiStartPos - hogekiEndPos).normalized;
            // obj.transform.localScale = new Vector3((endPos - startPos).magnitude, lineWidth, lineWidth);
            // obj.GetComponent<Hogeki>().Shot(new Vector3((endPos - startPos).magnitude, lineWidth, lineWidth));

            if ((hogekiStartPos - hogekiEndPos).magnitude > 3f)
            {
                hogekiObj.GetComponent<Hogeki>().Shot((hogekiStartPos - hogekiEndPos).normalized * 3f * 0.1f, hogekiCount);
            }
            else
            {
                hogekiObj.GetComponent<Hogeki>().Shot((hogekiStartPos - hogekiEndPos).normalized * (hogekiStartPos - hogekiEndPos).magnitude * 0.1f, hogekiCount);
            }
            /*
            if(hogekiStartPos.y - hogekiEndPos.y > 0)
            {
                hogekiObj.GetComponent<Hogeki>().Shot((hogekiStartPos - hogekiEndPos).normalized * (hogekiStartPos - hogekiEndPos).magnitude * 0.2f, hogekiCount);
            }
            else if (hogekiStartPos.y - hogekiEndPos.y < 0)
            {
                hogekiObj.GetComponent<Hogeki>().Shot((hogekiEndPos - hogekiStartPos).normalized * (hogekiEndPos - hogekiStartPos).magnitude * 0.2f, hogekiCount);
            }
            */
            hogekiFlg = false;
            // BokujuCountDown();

        }


        /*
        if (Input.GetMouseButtonUp(0))
        {
            touchPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            touchPos.z = 0;
            Vector3 startPos = touchPos;
            Vector3 endPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            endPos.z = 0;
            GameObject obj = Instantiate(linePrefabLast, transform.position, transform.rotation) as GameObject;
            obj.transform.position = (startPos + endPos) / 2;
            obj.transform.right = (endPos - startPos).normalized;
            obj.transform.localScale = new Vector3(1, lineWidth, lineWidth);
            obj.transform.parent = this.transform;
            touchPos = endPos;
        }
        */

    }

    public void HogekiCountUp()
    {
        hogekiCount++;
    }

    /*
    void drawLine1(Vector2 pos)
    {
        /*
        if (liberationFlg && Input.GetMouseButtonDown(0))
        {
            Vector2 liberationPowerPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if (liberationPowerPos.y < player.transform.position.y)
            {
                return;
            }

            Instantiate(liberationPower, liberationPowerPos , transform.rotation);
            liberationFlg = false;
        }
        

        if (Input.GetMouseButtonDown(0))
        {

            Vector2 cloudPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            /*
            if (player.transform.position.y - 1 > cloudPos.y)
            {
                return;
            }
            
            touchPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            touchPos.z = 0;
            layerNumber = 100;
            // firstFinger = true;
            /*
            Vector3 startPos = touchPos;
            Vector3 endPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            endPos.z = 0;
            GameObject obj = Instantiate(linePrefab, transform.position, transform.rotation) as GameObject;
            obj.transform.position = (startPos + endPos) / 2;
            obj.transform.right = (endPos - startPos).normalized;
            obj.transform.localScale = new Vector3(1, lineWidth, lineWidth);
            obj.transform.parent = this.transform;
            touchPos = endPos;
            
        }
        

        if (Input.GetMouseButton(0))
        {
            Touch touch = Input.GetTouch(0);
            if (touch.fingerId != 0)
            {
                return;
            }
            Vector2 cloudPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            /*
            if (player.transform.position.y - 1 > cloudPos.y)
            {
                touchPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                touchPos.z = 0;
                layerNumber = 100;
                return;
            }
            

            Vector3 startPos = touchPos;
            Vector3 endPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            endPos.z = 0;
            
            if ((endPos - startPos).magnitude > lineLength)
            {

            
                GameObject obj = null;


                switch(lineNumber)
                {
                    case 0:
                    obj = Instantiate(linePrefab, transform.position, transform.rotation) as GameObject;
                    lineNumber = 1;
                    break;

                    case 1:
                    obj = Instantiate(linePrefabLast, transform.position, transform.rotation) as GameObject;
                    lineNumber = 0;
                    break;
                }
                
                obj.transform.position = (startPos + endPos) / 2;
                obj.transform.right = (endPos - startPos).normalized;

                // obj.transform.localScale = new Vector3(1, lineWidth, lineWidth);
                obj.transform.localScale = new Vector3((endPos - startPos).magnitude, lineWidth, lineWidth);
                obj.GetComponent<Renderer>().sortingOrder = layerNumber;
                obj.transform.parent = this.transform;


                touchPos = endPos;
                layerNumber --;
            }
            
        }



        /*
        if (Input.GetMouseButtonUp(0))
        {
            touchPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            touchPos.z = 0;
            Vector3 startPos = touchPos;
            Vector3 endPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            endPos.z = 0;
            GameObject obj = Instantiate(linePrefabLast, transform.position, transform.rotation) as GameObject;
            obj.transform.position = (startPos + endPos) / 2;
            obj.transform.right = (endPos - startPos).normalized;
            obj.transform.localScale = new Vector3(1, lineWidth, lineWidth);
            obj.transform.parent = this.transform;
            touchPos = endPos;
        }
        

    }
    */

    public void LiberationFlgTrue()
    {
        liberationFlg = true;
    }

    public void BokujuCountUp(int num)
    {
        bokujuCount += num;
        if (rankingFlg)
        {
            GameSystem.instance.SetBokujuCount(bokujuCount);
        }
        else
        {
            GameSystemTrick.instance.SetBokujuCount(bokujuCount);
        }


    }

    public void BokujuCountDown()
    {
        bokujuCount--;

        if (rankingFlg)
        {
            GameSystem.instance.SetBokujuCount(bokujuCount);
        }
        else
        {
            GameSystemTrick.instance.SetBokujuCount(bokujuCount);
        }
    }

    public bool GetRankingFlg()
    {
        return rankingFlg;
    }

    public void AudioStop()
    {
        // audioSource.Stop();
        StartCoroutine("AudioFadeOut");
    }

    IEnumerator AudioFadeIn()
    {
        // audioSource.Play();
        audioSource.volume += 0.005f;
        if (audioSource.volume >= 0.02f)
        {
            audioSource.volume = 0.02f;
        }
        yield return new WaitForSeconds(0.1f);
        audioSource.volume += 0.005f;
        if (audioSource.volume >= 0.02f)
        {
            audioSource.volume = 0.02f;
        }
        yield return new WaitForSeconds(0.1f);
        audioSource.volume += 0.005f;
        if (audioSource.volume >= 0.02f)
        {
            audioSource.volume = 0.02f;
        }
        yield return new WaitForSeconds(0.1f);
        audioSource.volume += 0.005f;
        if (audioSource.volume >= 0.02f)
        {
            audioSource.volume = 0.02f;
        }

    }

    IEnumerator AudioFadeOut()
    {
        audioSource.volume -= 0.0025f;
        yield return new WaitForSeconds(0.1f);
        audioSource.volume -= 0.0025f;
        yield return new WaitForSeconds(0.1f);
        audioSource.volume -= 0.0025f;
        yield return new WaitForSeconds(0.1f);
        audioSource.volume -= 0.0025f;
        yield return new WaitForSeconds(0.1f);
        audioSource.volume -= 0.0025f;
        yield return new WaitForSeconds(0.1f);
        audioSource.volume -= 0.0025f;
        yield return new WaitForSeconds(0.1f);
        audioSource.volume -= 0.0025f;
        yield return new WaitForSeconds(0.1f);
        audioSource.volume -= 0.0025f;
        //audioSource.Stop();
    }


}