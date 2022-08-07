using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;
public class BannarAdd : MonoBehaviour
{
    private BannerView bannerView;

    void Start()
    {
        this.RequestBanner();
    }

    private void RequestBanner()
    {
            string adUnitId = "ca-app-pub-7082454607495989/8848350707";
            this.bannerView = new BannerView(adUnitId, AdSize.Leaderboard, AdPosition.Bottom);
            AdRequest request = new AdRequest.Builder().Build();
            this.bannerView.LoadAd(request);
    }
}
