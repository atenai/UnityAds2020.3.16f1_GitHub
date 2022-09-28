using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

//�L���S�̂̏�����
public class AdsInitialize : MonoBehaviour, IUnityAdsInitializationListener
{

    [SerializeField] string _androidGameId;
    [SerializeField] string _iOSGameId;
    [SerializeField] bool _testMode = true;
    private string _gameId;

    [SerializeField] AdsRewarded adsRewardButton;

    void Awake()
    {
        InitializeAds();
    }

    //�L���̏���������
    public void InitializeAds()
    {
        //iOS��Android�̂ǂ���̃v���b�g�t�H�[�������擾���čL��ID���擾����
        _gameId = (Application.platform == RuntimePlatform.IPhonePlayer) ? _iOSGameId : _androidGameId;
        //�L���̏���������(�������ɍL��ID, �������Ƀe�X�g���[�h���ǂ���?, ��O�����͂킩��Ȃ�)
        Advertisement.Initialize(_gameId, _testMode, this);
    }

    //���������������������ۂɎ��s����
    public void OnInitializationComplete()
    {
        Debug.Log("Unity Ads initialization complete");
        //�����[�h�L�������[�h����
        adsRewardButton.LoadAd();
    }

    //���������������s�����ꍇ�Ɏ��s����
    public void OnInitializationFailed(UnityAdsInitializationError error, string message)
    {
        Debug.Log($"Unity Ads Initialization Failed: {error.ToString()} - {message}");
    }
}
