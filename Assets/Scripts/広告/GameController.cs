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
//    [SerializeField, Header("�e�X�g���[�h")] private bool _testMode;
//    //private const string IosGameId = "2942932";//���l�̂��
//    //private const string AndroidGameId = "2942930";//���l�̂��
//    private const string IosGameId = "4780861";//�����̂��
//    private const string AndroidGameId = "4780860";//�����̂��
//    private const string PlacementId = "video";
//    private string _gameId = "";
//    private ShowAdCallbacks _showAdCallbacks;
//    [Header("�w�肵��Placement ID�̍L���\���������ł�����Ă΂��R�[���o�b�N")]
//    public UnityEvent PlacementContentReadyCallback;
//    [Header("�L���̎���������������Ă΂��R�[���o�b�N")] public UnityEvent AdFinishedCallback;
//    [Header("�L���̎������X�L�b�v������Ă΂��R�[���o�b�N")] public UnityEvent AdSkippedCallback;
//    [Header("�L���̎��������s������Ă΂��R�[���o�b�N")] public UnityEvent AdFailedCallback;

//    private void Start()
//    {
//        InitUnityAds();
//    }

//    /// <summary>
//    /// Monetization Service �̏�����
//    /// �������ƃR�[���o�b�N�̐ݒ�
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
//    /// �w�肵��Placement ID�̍L���\���������ł�����Ă΂��R�[���o�b�N
//    /// </summary>
//    /// <param name="sender"></param>
//    /// <param name="e"></param>
//    private void OnPlacementContentReady(object sender, PlacementContentReadyEventArgs e)
//    {
//        if (!e.placementId.Equals(PlacementId)) return;
//        PlacementContentReadyCallback.Invoke();
//    }

//    /// <summary>
//    /// �L����\������֐�
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
