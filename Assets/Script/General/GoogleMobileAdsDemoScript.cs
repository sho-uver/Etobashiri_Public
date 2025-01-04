using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GoogleMobileAds.Api;
using UnityEngine.SceneManagement;
/*
using UnityEngine.iOS;
using UnityEngine.Apple;
using Unity.Advertisement.IosSupport;
*/

public class GoogleMobileAdsDemoScript : MonoBehaviour
{
    BannerView bannerView;
    // These ad units are configured to always serve test ads.
#if UNITY_ANDROID
    private string adUnitIdInterstitial = "ca-app-pub-9162858272254492/4968114042";
#elif UNITY_IPHONE
    private string adUnitIdInterstitial = "ca-app-pub-9162858272254492/6538452913";
#else
    private string adUnitIdInterstitial = "unused";
#endif

    private InterstitialAd interstitialAd;
    public GameObject blackCanvas;
    public BlackCanvas bcScript;
    public float adTime;
    public float muteTime;
    public bool muteFlg;

    public void Awake()
    {

        /*
        string idfa = Device.advertisingIdentifier;
        Debug.Log("IDFA: " + idfa);
        getIDFA();
        */
        blackCanvas = GameObject.FindWithTag("BlackCanvas");
        // When true all events raised by GoogleMobileAds will be raised
        // on the Unity main thread. The default value is false.
        MobileAds.RaiseAdEventsOnUnityMainThread = true;
        // Initialize the Google Mobile Ads SDK.
        MobileAds.Initialize(initStatus => { });
        // MobileAds.SetApplicationVolume(1.0f); // 音量を最大に設定
        // MobileAds.SetApplicationMuted(false); // ミュートを無効化
        // AudioListener.pause = false;

        /*
        RequestConfiguration requestConfiguration =
        new RequestConfiguration.Builder()
        .SetSameAppKeyEnabled(true).build();
        MobileAds.SetRequestConfiguration(requestConfiguration);

        // Initialize the Google Mobile Ads SDK.
        MobileAds.Initialize(HandleInitCompleteAction);
        */

        RequestBanner();

        if (SceneManager.GetActiveScene().name == "Menu")
        {

            return;
        }
        LoadInterstitialAd();

        /*
        if(PlayerPrefs.GetInt("FirstManual",0) == 0)
        {
            PlayerPrefs.SetInt("AdCounter", 0);
            blackCanvas.GetComponent<BlackCanvas>().SetAdFlgTrue();
            blackCanvas.GetComponent<BlackCanvas>().StartFlgTrue();
            return;
        }
        */

        blackCanvas.GetComponent<BlackCanvas>().SetAdFlgTrue();
        blackCanvas.GetComponent<BlackCanvas>().StartFlgTrue();


        // ここ変えてるShowAd();
        /*
        RegisterEventHandlers(interstitialAd);
        interstitialAd.Destroy();
        RegisterReloadHandler(interstitialAd);
        */

    }

    /*
    private IEnumerator getIDFA()
    {
        // まだ許可ダイアログを表示したことがない場合
        if ( ATTrackingStatusBinding.GetAuthorizationTrackingStatus() ==
                ATTrackingStatusBinding.AuthorizationTrackingStatus.NOT_DETERMINED )
            {
                // 許可ダイアログを表示します
                ATTrackingStatusBinding.RequestAuthorizationTracking();

                // 許可ダイアログで「App にトラッキングしないように要求」か
                // 「トラッキングを許可」のどちらかが選択されるまで待機します
                while ( ATTrackingStatusBinding.GetAuthorizationTrackingStatus() ==
                        ATTrackingStatusBinding.AuthorizationTrackingStatus.NOT_DETERMINED )
                {
                    yield return null;
                }
            }

            // IDFA（広告 ID）をログ出力します
            // トラッキングが許可されている場合は IDFA が文字列で出力されます
            // 許可されていない場合は「00000000-0000-0000-0000-000000000000」が出力されます  
            Debug.Log( Device.advertisingIdentifier );
    }
    */
    /*
    void Update()
    {
        AudioListener.pause = false;
        
        if(muteFlg)
        {
            AudioListener.pause = false;
            muteTime -= Time.deltaTime;
            if(muteTime < 0)
            {
                muteFlg = false;
            }
        }
        
    }
    */

    public void MuteByAds()
    {
        muteFlg = true;
        muteTime = 3;
    }

    public void ShowInterstitial()
    {
        int adCounter = PlayerPrefs.GetInt("AdCounter", 0);
        if (PlayerPrefs.GetInt("神春夏秋冬並木", 0) != 1)
        {
            if (adCounter == 30)
            {
#if UNITY_ANDROID
                ShowAd();
#elif UNITY_IPHONE
                UnityEngine.iOS.Device.RequestStoreReview();
#else
                ShowAd();
#endif

                PlayerPrefs.SetInt("AdCounter", 0); //Androidの時に直す
            }
            else
            {
                ShowAd();
                adCounter++;
                PlayerPrefs.SetInt("AdCounter", adCounter);
            }
        }
    }


    private void RequestBanner()
    {
#if UNITY_ANDROID
            string adUnitIdBanner = "ca-app-pub-9162858272254492/6734862910";
#elif UNITY_IPHONE
            string adUnitIdBanner = "ca-app-pub-9162858272254492/4255038535";
#else
        string adUnitIdBanner = "unexpected_platform";
#endif
        // MobileAds.SetApplicationVolume(1.0f); // 音量を最大に設定
        // MobileAds.SetApplicationMuted(false); // ミュートを無効化
        // AudioListener.pause = false;
        // Create a 320x50 banner at the top of the screen.
        bannerView = new BannerView(adUnitIdBanner, AdSize.Banner, AdPosition.Bottom);
        // MuteByAds();
        // Create an empty ad request.
        AdRequest request = new AdRequest();
        // Load the banner with the request.
        bannerView.LoadAd(request);
        // AudioListener.pause = false;
    }


    /// <summary>
    /// Loads the interstitial ad.
    /// </summary>
    public void LoadInterstitialAd()
    {
        // Clean up the old ad before loading a new one.
        if (interstitialAd != null)
        {
            interstitialAd.Destroy();
            interstitialAd = null;
        }

        Debug.Log("Loading the interstitial ad.");

        // create our request used to load the ad.
        var adRequest = new AdRequest();
        adRequest.Keywords.Add("unity-admob-sample");

        // send the request to load the ad.
        InterstitialAd.Load(adUnitIdInterstitial, adRequest,
            (InterstitialAd ad, LoadAdError error) =>
            {
                // if error is not null, the load request failed.
                if (error != null || ad == null)
                {
                    Debug.LogError("interstitial ad failed to load an ad " +
                                    "with error : " + error);
                    return;
                }

                Debug.Log("Interstitial ad loaded with response : "
                            + ad.GetResponseInfo());

                interstitialAd = ad;
            });
    }

    public void ShowAd()
    {
        // MobileAds.SetApplicationVolume(1.0f); // 音量を最大に設定
        // MobileAds.SetApplicationMuted(false); // ミュートを無効化
        // AudioListener.pause = false;
        if (interstitialAd != null && interstitialAd.CanShowAd())
        {
            Debug.Log("Showing interstitial ad.");
            blackCanvas.GetComponent<BlackCanvas>().SetAdFlgTrue();
            blackCanvas.GetComponent<BlackCanvas>().StartFlgTrue();
            interstitialAd.Show();
            // AudioListener.pause = false;
        }
        else
        {
            Debug.LogError("Interstitial ad is not ready yet.");
            blackCanvas.GetComponent<BlackCanvas>().StartFlgFalse();
            adTime += 0.01f;
            if (adTime > 7)
            {
                // UnityEngine.iOS.Device.RequestStoreReview();
                blackCanvas.GetComponent<BlackCanvas>().SetAdFlgTrue();
                blackCanvas.GetComponent<BlackCanvas>().StartFlgTrue();
            }
            else
            {
                Invoke("ShowAd", 0.01f);
            }


        }
    }

    private void RegisterEventHandlers(InterstitialAd ad)
    {
        // Raised when the ad is estimated to have earned money.
        ad.OnAdPaid += (AdValue adValue) =>
        {
            Debug.Log(string.Format("Interstitial ad paid {0} {1}.",
                adValue.Value,
                adValue.CurrencyCode));
        };
        // Raised when an impression is recorded for an ad.
        ad.OnAdImpressionRecorded += () =>
        {
            Debug.Log("Interstitial ad recorded an impression.");
        };
        // Raised when a click is recorded for an ad.
        ad.OnAdClicked += () =>
        {
            Debug.Log("Interstitial ad was clicked.");
        };
        // Raised when an ad opened full screen content.
        ad.OnAdFullScreenContentOpened += () =>
        {
            Debug.Log("Interstitial ad full screen content opened.");
        };
        // Raised when the ad closed full screen content.
        ad.OnAdFullScreenContentClosed += () =>
        {
            Debug.Log("Interstitial ad full screen content closed.");
        };
        // Raised when the ad failed to open full screen content.
        ad.OnAdFullScreenContentFailed += (AdError error) =>
        {
            Debug.LogError("Interstitial ad failed to open full screen content " +
                        "with error : " + error);
        };
    }

    private void RegisterReloadHandler(InterstitialAd ad)
    {
        // Raised when the ad closed full screen content.
        ad.OnAdFullScreenContentClosed += () =>
        {
            Debug.Log("Interstitial Ad full screen content closed.");

            // Reload the ad so that we can show another as soon as possible.
            LoadInterstitialAd();
        };
        // Raised when the ad failed to open full screen content.
        ad.OnAdFullScreenContentFailed += (AdError error) =>
        {
            Debug.LogError("Interstitial ad failed to open full screen content " +
                        "with error : " + error);

            // Reload the ad so that we can show another as soon as possible.
            LoadInterstitialAd();
        };
    }
}
