using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;
using System;
public class InteratialAdd : MonoBehaviour
{
    private InterstitialAd interstitial_Ad;
    private string interstitial_Ad_ID;
    void Start()
    {
        interstitial_Ad_ID = "ca-app-pub-7082454607495989/4769504897";
        RequestInterstitial();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void RequestInterstitial()
    {
        interstitial_Ad = new InterstitialAd(interstitial_Ad_ID);
        interstitial_Ad.OnAdLoaded += HandleOnAdLoaded;
        AdRequest request = new AdRequest.Builder().Build();
        interstitial_Ad.LoadAd(request);
    }
    public void ShowInterstitial()
    {
        if (interstitial_Ad.IsLoaded())
        {
            interstitial_Ad.Show();
            RequestInterstitial();
        }

    }

    public void HandleOnAdLoaded(object sender, EventArgs args)
    {

    }
}
