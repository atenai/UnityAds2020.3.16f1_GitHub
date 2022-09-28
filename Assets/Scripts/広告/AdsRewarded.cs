using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Advertisements;

//�����[�h�L���X�N���v�g
public class AdsRewarded : MonoBehaviour, IUnityAdsLoadListener, IUnityAdsShowListener
{
    [SerializeField] Button _showAdButton;//�{�^���̕ϐ�����闝�R����������݂�������
    [SerializeField] string _androidAuUnitId = "Rewarded_Android";
    [SerializeField] string _iOSAdUnitId = "Rewarded_iOS";
    string _adUnitId = null;

    void Awake()
    {
        //iOS��Android���̍L��ID���擾����
        //���̏ꍇ��Unity�̃G�f�B�^�[��iOS��Android�ɃX�C�b�`���Ă����K�v������(����Ȃ���_adUnitId���擾�ł����G���[�ɂȂ�)
#if UNITY_IOS
        _adUnitId = _iOSAdUnitId;
#elif UNITY_ANDROID
        _adUnitId = _androidAuUnitId;
#endif
        //�����[�h�L���\���{�^�����I�t�ɂ���
        _showAdButton.interactable = false;
    }

    //�����[�h�L�������[�h
    public void LoadAd()
    {
        Debug.Log("Loading Ad: " + _adUnitId);
        //�����[�h�L�������[�h����
        Advertisement.Load(_adUnitId, this);
    }

    //�����[�h�L���𐳏�Ƀ��[�h�ł�����{�^����ǉ�����
    public void OnUnityAdsAdLoaded(string adUnitId)
    {
        Debug.Log("Ad Loaded: " + adUnitId);

        if (adUnitId.Equals(_adUnitId))
        {
            //�{�^�����N���b�N������ShowAd�֐����Ăяo��
            _showAdButton.onClick.AddListener(ShowAd);
             //�����[�h�L���\���{�^�����I���ɂ���
            _showAdButton.interactable = true;
        }
    }

    //�����[�h�L����\������
    public void ShowAd()
    {
        //�����[�h�L���\���{�^�����I�t�ɂ���
        _showAdButton.interactable = false;
        //�����[�h�L����\������
        Advertisement.Show(_adUnitId, this);
    }

    //�����[�h�L���𐳏�ɕ\��������Ɏ��s����
    public void OnUnityAdsShowComplete(string adUnitId, UnityAdsShowCompletionState showCompletionState)
    {
        if(adUnitId.Equals(_adUnitId) && showCompletionState.Equals(UnityAdsShowCompletionState.COMPLETED))
        {
            Debug.Log("Unity Ads Rewarded Ad Completed");

            Debug.Log("<color=red>���Ȃ��̓����[�h�L�����Q�b�g���܂����B</color>");

            //�����[�h�L�������[�h����
            Advertisement.Load(_adUnitId, this);
        }
    }

    //�����[�h�L���̃��[�h�Ɏ��s�����ۂɎ��s����
    public void OnUnityAdsFailedToLoad(string adUnitId, UnityAdsLoadError error, string message)
    {
        Debug.Log($"Error loading Ad Unit {adUnitId}: {error.ToString()} - {message}");
    }

    //�����[�h�L���̕\���Ɏ��s�����ۂɎ��s����
    public void OnUnityAdsShowFailure(string adUnitId, UnityAdsShowError error, string message)
    {
        Debug.Log($"Error showing Ad Unit {adUnitId}: {error.ToString()} - {message}");
    }

    //�����[�h�L���̕\�����X�^�[�g�����ۂɎ��s����
    public void OnUnityAdsShowStart(string adUnitId) { }
    //�����[�h�L���̕\�����N���b�N�����ۂɎ��s����
    public void OnUnityAdsShowClick(string adUnitId) { }

    void OnDestroy()
    {
        //�{�^�����X�i�[��S�ď���
        _showAdButton.onClick.RemoveAllListeners();
    }
}
