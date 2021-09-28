using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Advertisements;
using UnityEngine.Monetization;

public class UnityAds : MonoBehaviour
{
    private string PlayStoreID = "4093873";
    private string BannerID = "Banner";
    private string InterstitialID = "Interstitial";

    [Header("Boolean")]
    public bool TestMode = false;

    private void Awake()
    {
        InitializeAdvertissement();
        Advertisement.Show(BannerID);
        StartCoroutine(ShowBannerWhenInitialized());
    }

    // Start is called before the first frame update 
    void Start()
    {
    }

    IEnumerator ShowBannerWhenInitialized()
    {
        while (!Advertisement.isInitialized)
        {
            yield return new WaitForSeconds(0.5f);
        }
        Advertisement.Banner.SetPosition(BannerPosition.TOP_CENTER);
        Advertisement.Banner.Show(BannerID);
    }
    private void InitializeAdvertissement()
    {
        Advertisement.Initialize(PlayStoreID, TestMode);
        return;
    }
    public void ShowInterstitialAd()
    {
        // Check if UnityAds ready before calling Show method:
        if (Advertisement.IsReady())
        {
            Advertisement.Show();
        }
        else
        {
            Debug.Log("Interstitial ad not ready at the moment! Please try again later!");
        }
    }
    public void HideBanner()
    {
        Advertisement.Banner.Hide();
    }
    public void OnUnityAdsReady(string placementID)
    {
        if (placementID == BannerID)
        {
            Advertisement.Banner.SetPosition(BannerPosition.BOTTOM_CENTER);
            Advertisement.Show(BannerID);
        }
    }    
}
