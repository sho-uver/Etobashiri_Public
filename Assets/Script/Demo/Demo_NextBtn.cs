using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Demo_NextBtn : MonoBehaviour
{
    [SerializeField] private Image buttonImage;
    [SerializeField] private float blinkDuration = 0.5f;
    [SerializeField] private Color startColor = Color.white;
    [SerializeField] private Color endColor = new Color(1f, 1f, 1f, 0.5f);

    // Start is called before the first frame update
    void Start()
    {
        if (buttonImage == null)
        {
            buttonImage = GetComponent<Image>();
        }

        StartBlinking();
    }

    private void StartBlinking()
    {
        // 既存のアニメーションをキャンセル
        buttonImage.DOKill();

        // 色の点滅アニメーション
        buttonImage.DOColor(endColor, blinkDuration)
            .SetEase(Ease.InOutSine)
            .SetLoops(-1, LoopType.Yoyo);
    }

    private void OnDestroy()
    {
        buttonImage.DOKill();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
