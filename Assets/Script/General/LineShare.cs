using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class LineShare : MonoBehaviour
{
    // https://dropoutc.com/creation/social/　このサイト見て作った
    public string tweetText;
    public string tweetURL;
    public bool ssStopFlg;

    void start()
    {
    }

    //シェア 
    public void Tweet()
    {
        StartCoroutine(_Tweet());
    }

    public IEnumerator _Tweet()
    {
        if (!ssStopFlg)
        {
            string imagePass = Application.persistentDataPath + "/image.png";
            //前回の画像を消す
            File.Delete(imagePass);
            //新しいスクリーンショット撮影
            ScreenCapture.CaptureScreenshot("image.png");

            //なんかスクショ撮影のラグがあるから終わるまで待機
            while (true)
            {
                if (File.Exists(imagePass))
                    break; yield return null;
            }
            //投稿
            // // SocialConnector.PostMessage(// SocialConnector.ServiceType.Line,tweetText, tweetURL, imagePass);

            try
            {
                // SocialConnector.PostMessage(// SocialConnector.ServiceType.Line, tweetText, tweetURL, imagePass);
                // // SocialConnector.Share(tweetText, tweetURL,imagePass);
            }
            catch (System.Exception e)
            {
                Debug.LogError("Failed to post the tweet: " + e.Message);
            }

        }
        else
        {
            // SocialConnector.PostMessage(// SocialConnector.ServiceType.Line,tweetText, tweetURL);
            // // SocialConnector.Share(tweetText, tweetURL);
            /*
            try
            {
                // SocialConnector.PostMessage(// SocialConnector.ServiceType.Line, tweetText, tweetURL);
            }
            catch (System.Exception e)
            {
                Debug.LogError("Failed to post the tweet: " + e.Message);
            }
            */
        }

    }

    public void SetTweetText(string altText)
    {
        tweetText = altText;
    }

    public void SetTweetURL(string altURL)
    {
        tweetURL = altURL;
    }

    public void SetSSStopFlg()
    {
        ssStopFlg = true;
    }

}
