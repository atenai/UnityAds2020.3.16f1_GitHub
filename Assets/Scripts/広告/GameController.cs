//using System.Collections;
//using System.Collections.Generic;
//using System;
//using UnityEngine;
//using UnityEngine.Events;
//using UnityEngine.Advertisements;
//using UnityEngine.Monetization;

//public class GameController : MonoBehaviour
//{
//    //private string gameIDGoogleplay = "4780860", gameIDAppstore = "4780861";
//    [SerializeField, Header("テストモード")] private bool _testMode;
//    //private const string IosGameId = "2942932";//他人のやつ
//    //private const string AndroidGameId = "2942930";//他人のやつ
//    private const string IosGameId = "4780861";//自分のやつ
//    private const string AndroidGameId = "4780860";//自分のやつ
//    private const string PlacementId = "video";
//    private string _gameId = "";
//    private ShowAdCallbacks _showAdCallbacks;
//    [Header("指定したPlacement IDの広告表示準備ができたら呼ばれるコールバック")]
//    public UnityEvent PlacementContentReadyCallback;
//    [Header("広告の視聴が成功したら呼ばれるコールバック")] public UnityEvent AdFinishedCallback;
//    [Header("広告の視聴をスキップしたら呼ばれるコールバック")] public UnityEvent AdSkippedCallback;
//    [Header("広告の視聴が失敗したら呼ばれるコールバック")] public UnityEvent AdFailedCallback;

//    private void Start()
//    {
//        InitUnityAds();
//    }

//    /// <summary>
//    /// Monetization Service の初期化
//    /// 初期化とコールバックの設定
//    /// </summary>
//    private void InitUnityAds()
//    {
//        if (Monetization.isInitialized || !Monetization.isSupported) return;
//#if UNITY_IOS
//		_gameId = IosGameId;
//#elif UNITY_ANDROID
//        _gameId = AndroidGameId;
//#endif
//        Monetization.Initialize(_gameId, _testMode);
//        Monetization.onPlacementContentReady += OnPlacementContentReady;

//    }

//    /// <summary>
//    /// 指定したPlacement IDの広告表示準備ができたら呼ばれるコールバック
//    /// </summary>
//    /// <param name="sender"></param>
//    /// <param name="e"></param>
//    private void OnPlacementContentReady(object sender, PlacementContentReadyEventArgs e)
//    {
//        if (!e.placementId.Equals(PlacementId)) return;
//        PlacementContentReadyCallback.Invoke();
//    }

//    /// <summary>
//    /// 広告を表示する関数
//    /// </summary>
//    public void ShowVideoAd()
//    {
//        if (!Monetization.IsReady(PlacementId))
//        {
//            Debug.LogFormat("Placement ID:\"{0}\" is not ready", PlacementId);
//            return;
//        }
//        var showAdPlacementContent = Monetization.GetPlacementContent(PlacementId) as ShowAdPlacementContent;
//        showAdPlacementContent?.Show(_showAdCallbacks);
//    }

//    private void OnDestroy()
//    {
//        Monetization.onPlacementContentReady -= OnPlacementContentReady;
//    }
//}
