using UnityEngine;
using GoogleMobileAds.Api;
using System;

// Video: https://www.youtube.com/watch?v=oIluUbRwqcM
// This is the ad initializer script. To call an interstitial ad, go to any script and:
// Add this to the start method of that script:
//AdManager.instance.RequestInterstitial();
// Then, call this from where you want to show the ad:
// Shows the interstitial ad
//AdManager.instance.ShowInterstitial();

// Banner ads have been commented out for this game because I don't think it'll look good in landscape

public class AdManager : MonoBehaviour
{
    public string interstitialAdUnitId;

    //private BannerView bannerAd;
    //static bool bannerAdRequested = false;

    private InterstitialAd interstitial;

    public static AdManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }
    void Start()
    {
        MobileAds.Initialize(InitializationStatus => { });

        //if (bannerAdRequested)
        //    return;

        //this.RequestBanner();
        //bannerAdRequested = true;
    }

    private AdRequest CreateAdRequest()
    {
        return new AdRequest.Builder().Build();
    }

    //private void RequestBanner()
    //{
    //    string adUnitId = "ca-app-pub-3940256099942544/6300978111";
    //    this.bannerAd = new BannerView(adUnitId, AdSize.SmartBanner, AdPosition.Bottom);

    //    // Clean up banner ad before creating a new one.
    //    if (this.bannerAd != null)
    //    {
    //        this.bannerAd.Destroy();
    //    }

    //    // Create a 320x50 banner at the top of the screen.
    //    this.bannerAd = new BannerView(adUnitId, AdSize.SmartBanner, AdPosition.Bottom);

    //    // Load a banner ad.
    //    this.bannerAd.LoadAd(this.CreateAdRequest());
    //}

    public void RequestInterstitial()
    {

        // This is the test interstitialAdUnitId: ca-app-pub-3940256099942544/1033173712

        // Clean up interstitial ad before creating a new one.
        if (this.interstitial != null)
            this.interstitial.Destroy();

        // Create an interstitial.
        this.interstitial = new InterstitialAd(interstitialAdUnitId);

        // Load an interstitial ad.
        this.interstitial.LoadAd(this.CreateAdRequest());
    }

    public void ShowInterstitial()
    {
        if (this.interstitial.IsLoaded())
        {
            interstitial.Show();
        }
        else
        {
            Debug.Log("Inerstitial Ad is not ready yet");
        }
    }

}