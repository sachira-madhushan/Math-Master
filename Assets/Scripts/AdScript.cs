using System;
using System.Collections;
using System.Collections.Generic;
using GoogleMobileAds.Api;
using UnityEngine;
using TMPro;

public class AdScript : MonoBehaviour {

    
    private RewardedAd rewardedAd;
    private string rewardedAd_ID;

    [SerializeField]
    private TextMeshProUGUI Easy, Medium, Hard;
    void Start () {
        
        rewardedAd_ID = "ca-app-pub-7082454607495989/9278583784";

        
        RequestRewardedVideo ();

    }

    

    private void RequestRewardedVideo () {
        rewardedAd = new RewardedAd (rewardedAd_ID);
        rewardedAd.OnUserEarnedReward += HandleUserEarnedReward;
        rewardedAd.OnAdClosed += HandleRewardedAdClosed;
        rewardedAd.OnAdFailedToShow += HandleRewardedAdFailedToShow;
        AdRequest request = new AdRequest.Builder ().Build ();
        rewardedAd.LoadAd (request);
    }

    

    public void ShowRewardedVideo () {
        if (rewardedAd.IsLoaded ()) {
            rewardedAd.Show ();
        }
    }

    

    public void HandleRewardedAdFailedToShow (object sender, AdErrorEventArgs args) {
        RequestRewardedVideo ();
        print("faild");
    }

    public void HandleRewardedAdClosed (object sender, EventArgs args) {
        RequestRewardedVideo ();
    }

    public void HandleUserEarnedReward (object sender, Reward args) {
        RequestRewardedVideo ();
        PlayerPrefs.SetInt("EasyScore", 0);
        PlayerPrefs.SetInt("MediumScore", 0);
        PlayerPrefs.SetInt("HardScore", 0);
        Easy.text = PlayerPrefs.GetInt("EasyScore", 0).ToString();
        Medium.text = PlayerPrefs.GetInt("MediumScore", 0).ToString();
        Hard.text = PlayerPrefs.GetInt("HardScore", 0).ToString();

    }
}