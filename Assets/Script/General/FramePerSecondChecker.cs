using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FramePerSecondChecker : MonoBehaviour
{
    Text _fpsText;
    float _countTime;
    float _countFrame;

    // Start is called before the first frame update
    void Start()
    {
        Canvas canvas = GetCanvas();
        _fpsText = CreateFPSText(canvas.transform);
        _countTime = 0f;
        _countFrame = 0f;
    }


    // FPS表示用のテキストを配置するキャンパスを取得
    Canvas GetCanvas()
    {
        Canvas canvas = FindObjectOfType<Canvas>();
        if (canvas != null){return canvas; }
        // ゲーム内にキャンバスがなければ生成する
        GameObject canvasObj = new GameObject("Canvas");
        canvas = canvasObj.AddComponent<Canvas>();
        canvas.renderMode = RenderMode.ScreenSpaceOverlay;
        CanvasScaler canvasScaler = canvasObj.AddComponent<CanvasScaler>();
        canvasScaler.uiScaleMode = CanvasScaler.ScaleMode.ScaleWithScreenSize;
        canvasScaler.referenceResolution = new Vector2(Screen.width, Screen.height);
        canvasScaler.screenMatchMode = CanvasScaler.ScreenMatchMode.Expand;
        return canvas;
    }

    //　FPS表示用テキスト生成
    Text CreateFPSText (Transform parent)
    {
        Text fpsText = new GameObject("FPSText").AddComponent<Text>();
        fpsText.transform.SetParent(parent);
        fpsText.font = Resources.GetBuiltinResource<Font>("Arial.ttf");
        fpsText.alignment = TextAnchor.UpperLeft;
        fpsText.fontSize = 20;
        fpsText.transform.SetParent(parent);
        fpsText.rectTransform.anchorMin = Vector2.up;
        fpsText.rectTransform.anchorMax = Vector2.up;
        fpsText.rectTransform.pivot = Vector2.up;
        fpsText.rectTransform.anchoredPosition = new Vector2(10f, -10f);
        fpsText.rectTransform.sizeDelta = new Vector2(120f, 30f);
        return fpsText;
    }

    // Update is called once per frame
    void Update()
    {
        if (_fpsText == null) {return; }
        _countTime += Time.deltaTime;
        _countFrame++;
        if (_countTime < 0.5f){
            //0.5秒経過するまではフレーム数をカウント
            return;
            }
        // 0.5秒後、その期間にカウントされた
        //フレーム数からFPSを計算して表示
        _fpsText.text = "FPS:" + (_countFrame / _countTime).ToString("F2");
        _countTime = 0f;
        _countFrame = 0f;
    }
}
