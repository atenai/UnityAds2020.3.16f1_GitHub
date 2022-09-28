using UnityEngine;
using UnityEngine.Advertisements;

public class AdsInterstitial : MonoBehaviour, IUnityAdsLoadListener, IUnityAdsShowListener
{
    [SerializeField] string _androidAdUnitId = "Interstitial_Android";
    [SerializeField] string _iOSAdUnitId = "Interstitial_iOS";
    string _adUnitId;

    void Awake()
    {
        //iOS��Android�̂ǂ���̃v���b�g�t�H�[�������擾���čL��ID���擾����
        _adUnitId = (Application.platform == RuntimePlatform.IPhonePlayer) ? _iOSAdUnitId : _androidAdUnitId;
    }

    //�C���^�[�X�e�[�V���i���L�������[�h����
    public void LoadAd()
    {
        Debug.Log("Loading Ad: " + _adUnitId);
        //�C���^�[�X�e�[�V���i���L�������[�h
        Advertisement.Load(_adUnitId, this);
    }

    //�C���^�[�X�e�[�V���i���L����\������
    public void ShowAd()
    {
        Debug.Log("Showing Ad: " + _adUnitId);
        //�C���^�[�X�e�[�V���i���L����\��
        Advertisement.Show(_adUnitId, this);
    }

    //�C���^�[�X�e�[�V���i���L���𐳏�Ƀ��[�h�ł����ꍇ�Ɏ��s����
    public void OnUnityAdsAdLoaded(string adUnitId)
    {

    }

    //�C���^�[�X�e�[�V���i���L���̃��[�h�Ɏ��s�����ꍇ�Ɏ��s����
    public void OnUnityAdsFailedToLoad(string adUnitId, UnityAdsLoadError error, string message)
    {
        Debug.Log($"Error loading Ad Unit: {adUnitId} - {error.ToString()} - {message}");
    }

    //�C���^�[�X�e�[�V���i���L���̕\���Ɏ��s�����ꍇ�Ɏ��s����
    public void OnUnityAdsShowFailure(string adUnitId, UnityAdsShowError error, string message)
    {
        Debug.Log($"Error showing Ad Unit: {adUnitId} - {error.ToString()} - {message}");
    }

    public void OnUnityAdsShowStart(string adUnitId) { }
    public void OnUnityAdsShowClick(string adUnitId) { }

    //�C���^�[�X�e�[�V���i���L���𐳏�ɕ\��������Ɏ��s����
    public void OnUnityAdsShowComplete(string adUnitId, UnityAdsShowCompletionState showCompletionState)
    {
        Debug.Log("<color=blue>���Ȃ��̓C���^�[�X�e�[�V���i���L�����Q�b�g���܂����B</color>");

        //�C���^�[�X�e�[�V���i���L�������[�h
        Advertisement.Load(_adUnitId, this);
    }
}
