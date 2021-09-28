using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class StartAppAds : MonoBehaviour
{
    public GameObject UnityAdsGo;
    // Start is called before the first frame update
    void Start()
    {
        UnityAdsGo.GetComponent<UnityAds>().ShowInterstitialAd();
        SceneManager.LoadSceneAsync("Menu");

    }
}
