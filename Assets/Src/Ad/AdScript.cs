using System;
using UnityEngine;
using GoogleMobileAds.Api;

namespace Src.ad
{
	public class AdScript : MonoBehaviour
	{
		private InterstitialAd interstitial;
		private RewardedAd     rewarded;

		private string interstitial_ID;
		private string rewarded_ID;


		void Start()
		{
			// TODO : das sind test IDs ... 
			// ebenso in den AdMod settings im Editor noch anpassen, wenn es dann live geht !!!
			interstitial_ID = "ca-app-pub-3940256099942544/1033173712";
			rewarded_ID = "ca-app-pub-3940256099942544/5224354917";

			MobileAds.Initialize(initStatus => { });

			RequestInterstitial();
			RequestRewardedVideo();
		}

		private void RequestInterstitial()
		{
			interstitial = new InterstitialAd(interstitial_ID);
			interstitial.OnAdLoaded += HandleOnAdLoaded;
			AdRequest request = new AdRequest.Builder().Build();
			interstitial.LoadAd(request);
		}

		private void RequestRewardedVideo()
		{
			rewarded = new RewardedAd(rewarded_ID);
			rewarded.OnUserEarnedReward += HandleUserEarnedReward;
			rewarded.OnAdClosed += HandleRewardedAdClosed;
			rewarded.OnAdFailedToShow += HandleRewardedAdFailedToShow;
			AdRequest request = new AdRequest.Builder().Build();
			rewarded.LoadAd(request);
		}

		public void ShowInterstitial()
		{
			if (interstitial.IsLoaded())
			{
				interstitial.Show();
			}

			RequestInterstitial();
		}

		public void ShowRewardedVideo()
		{
			if (rewarded.IsLoaded())
			{
				rewarded.Show();
			}
		}

		private void HandleOnAdLoaded(object sender, EventArgs args)
		{
			//
		}

		private void HandleRewardedAdFailedToShow(object sender, AdErrorEventArgs args)
		{
			RequestRewardedVideo();
		}

		private void HandleRewardedAdClosed(object sender, EventArgs args)
		{
			RequestRewardedVideo();
		}

		private void HandleUserEarnedReward(object sender, Reward args)
		{
			string type   = args.Type;
			double amount = args.Amount;
			MonoBehaviour.print(
				"params : "
				+ amount.ToString() + " " + type);

			RequestRewardedVideo();
		}
	}
}