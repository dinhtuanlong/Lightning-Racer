using UnityEngine;
using UnityEngine.Advertisements;

public class AdsManager : MonoBehaviour, IUnityAdsInitializationListener, IUnityAdsLoadListener, IUnityAdsShowListener
{
    public static AdsManager instance;
    public bool testMode = true;
    string gameId = "6175834";
    string interstitialAdId = "Interstitial_Android";
    string rewardedAdId = "Rewarded_Android";
    string bannerAdId = "Banner_Android";

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        InitializeAds();
    }

    void InitializeAds()
    {
        Advertisement.Initialize(gameId, testMode, this);
    }

    public void ShowAds()
    {
        Advertisement.Load(interstitialAdId, this);
        Advertisement.Show(interstitialAdId, this);
    }

    public void ShowRewaredAds()
    {
        Advertisement.Load(rewardedAdId, this);
        Advertisement.Show(rewardedAdId, this);
    }

    public void ShowBannerAd()
    {
        Advertisement.Banner.SetPosition(BannerPosition.TOP_CENTER);
        Advertisement.Banner.Load(bannerAdId);
        Advertisement.Banner.Show(bannerAdId);
    }

    public void OnInitializationComplete()
    {
        Debug.Log("Initialized");
    }

    public void OnInitializationFailed(UnityAdsInitializationError error, string message)
    {
        Debug.Log("Initialize Failed");
    }

    public void OnUnityAdsAdLoaded(string placementId)
    {
        Debug.Log("Ads Loaded");
    }

    public void OnUnityAdsFailedToLoad(string placementId, UnityAdsLoadError error, string message)
    {
        Debug.Log("Ads Load Failed");
    }

    public void OnUnityAdsShowFailure(string placementId, UnityAdsShowError error, string message)
    {
        Debug.Log("Ads Failed");
    }

    public void OnUnityAdsShowStart(string placementId)
    {
        Debug.Log("Ads Started");
    }

    public void OnUnityAdsShowClick(string placementId)
    {
        Debug.Log("Ads Clicked");
    }

    public void OnUnityAdsShowComplete(string placementId, UnityAdsShowCompletionState showCompletionState)
    {
        Debug.Log("Ads Completed");
        if (showCompletionState == UnityAdsShowCompletionState.COMPLETED)
        {
            Debug.Log("Reward done");
        }
        GameManager.instance.ReloadLevel();
    }
}
