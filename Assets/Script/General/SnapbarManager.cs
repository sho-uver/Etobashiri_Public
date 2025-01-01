using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class SnapbarManager : MonoBehaviour
{
    public static SnapbarManager instance;
    public GameObject snapbarPrefab;
    public Transform canvasTransform;
    private Queue<SnapbarRequest> snapbarQueue = new Queue<SnapbarRequest>();
    private bool isDisplaying = false;
    public float delayTotalTime;

    void start()
    {
        instance = this;
    }

    public void ShowSnapbar(string message, Sprite image, float duration)
    {
        snapbarQueue.Enqueue(new SnapbarRequest(message, image, duration));
        // DisplayNextSnapbar();
        
        if (!isDisplaying)
        {
            DisplayNextSnapbar();
        }
        
    }

    private void DisplayNextSnapbar()
    {
        if (snapbarQueue.Count == 0)
        {
            isDisplaying = false;
            return;
        }

        isDisplaying = true;
        var request = snapbarQueue.Dequeue();
        GameObject snapbar = Instantiate(snapbarPrefab, canvasTransform);
        snapbar.transform.GetChild(1).GetComponent<Image>().sprite = request.Image;
        snapbar.transform.GetChild(2).GetComponent<Text>().text = request.Message;

        float initialY = canvasTransform.GetComponent<RectTransform>().rect.height;
        float targetY = 1000;  // 目標Y位置を上部から少し下がった位置に設定
        snapbar.transform.localPosition = new Vector3(0, initialY, 0);
        snapbar.transform.DOLocalMoveY(targetY, 0.5f).SetEase(Ease.OutCubic);

        StartCoroutine(RemoveSnapbar(snapbar, request.Duration));
    }

    private IEnumerator RemoveSnapbar(GameObject snapbar, float delay)
    {
        // delayTotalTime += delay;
        yield return new WaitForSeconds(delay);
        float endY = canvasTransform.GetComponent<RectTransform>().rect.height;
        snapbar.transform.DOLocalMoveY(endY, 0.5f).SetEase(Ease.InCubic).OnComplete(() =>
        {
            Destroy(snapbar);
            DisplayNextSnapbar();
        });
    }

    private class SnapbarRequest
    {
        public string Message { get; }
        public Sprite Image { get; }
        public float Duration { get; }

        public SnapbarRequest(string message, Sprite image, float duration)
        {
            Message = message;
            Image = image;
            Duration = duration;
        }
    }
}
