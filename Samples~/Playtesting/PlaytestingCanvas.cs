using UnityEngine;
using DungeonGames.VKGames;
using UnityEngine.UI;
using System.Collections;

namespace DungeonGames.VKGames.Samples
{
    public class PlaytestingCanvas : MonoBehaviour
    {
        [SerializeField] private Text _coinsAmountText;

        private int _coinsAmount = 0;

        public void InitializeSdkButton()
        {
            StartCoroutine(InitializeSDK());
        }

        private IEnumerator InitializeSDK()
        {
            yield return VKGamesSdk.Initialize(onSuccessCallback: OnSDKInitilized);
        }

        private void OnSDKInitilized()
        {
            Debug.Log(VKGamesSdk.Initialized);
        }

        public void ShowInterstitialButton()
        {
            Interstitial.Show();
        }

        public void ShowRewardedAdsButton()
        {
            VideoAd.Show(onRewardedCallback: OnRewardedCallback);
        }

        public void InviteFriendsButton()
        {
            SocialInteraction.InviteFriends(OnRewardedCallback);
        }

        public void AddPlayerToCommunity()
        {
            Community.InviteToDungeonGamesGroup(OnRewardedCallback);
        }

        private void OnRewardedCallback()
        {
            _coinsAmount += 40;
            _coinsAmountText.text = $"{_coinsAmount} coins";
        }

        public void ShowLeaderboardButton()
        {
            Leaderboard.ShowLeaderboard(100);
        }

        public void IapTest()
        {
            InAppPurchase.BuyItem("item_id_123456", OnRewardedCallback, onErrorCallback: () => Debug.Log("alalala"));
        }

        public void ShowBannerAd()
        {
            BannerAd.Show();
        }
    }
}
