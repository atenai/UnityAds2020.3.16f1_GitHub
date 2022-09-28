using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Advertisements;

public class AdsBanner : MonoBehaviour
{
    //[SerializeField] Button _loadBannerButton;
    //[SerializeField] Button _showBannerButton;
    //[SerializeField] Button _hideBannerButton;

    [SerializeField] BannerPosition _bannerPosition = BannerPosition.BOTTOM_CENTER;

    [SerializeField] string _androidAdUnitId = "Banner_Android";
    [SerializeField] string _iOSAdUnitId = "Banner_iOS";
    string _adUnitId = null;

    void Start()
    {
#if UNITY_IOS
        _adUnitId = _iOSAdUnitId;
#elif UNITY_ANDROID
        _adUnitId = _androidAdUnitId;
#endif
        //�o�i�[�L���̕\���E��\���{�^�����I�t�ɂ���
        //_showBannerButton.interactable = false;
        //_hideBannerButton.interactable = false;

        //�o�i�[�L���̈ʒu���Z�b�g����
        Advertisement.Banner.SetPosition(_bannerPosition);

        //�o�i�[�L���̃��[�h������
        //_loadBannerButton.onClick.AddListener(LoadBanner);
        //�o�i�[�L���̃��[�h�{�^�����I���ɂ���
        //_loadBannerButton.interactable = true;
        
        //�o�i�[�L�������[�h����
        LoadBanner();
    }

    //�o�i�[�L�������[�h����
    public void LoadBanner()
    {
        BannerLoadOptions options = new BannerLoadOptions
        {
            loadCallback = OnBannerLoaded,
            errorCallback = OnBannerError
        };

        //�o�i�[�L�������[�h����
        Advertisement.Banner.Load(_adUnitId, options);
    }

    //�o�i�[�L���̃��[�h�����������ۂɎ��s����
    void OnBannerLoaded()
    {
        Debug.Log("Banner loaded");
        //�o�i�[�L����\������
        ShowBannerAd();

        //_showBannerButton.onClick.AddListener(ShowBannerAd);
        //_hideBannerButton.onClick.AddListener(HideBannerAd);

        //�o�i�[�L���̕\���E��\���{�^�����I���ɂ���
        //_showBannerButton.interactable = true;
        //_hideBannerButton.interactable = true;
    }

    //�o�i�[�L�����G���[�̏ꍇ�Ɏ��s����
    void OnBannerError(string message)
    {
        Debug.Log($"Banner Error: {message}");
    }

    //�o�i�[�L����\������
    void ShowBannerAd()
    {
        BannerOptions options = new BannerOptions
        {
            clickCallback = OnBannerClicked,
            hideCallback = OnBannerHidden,
            showCallback = OnBannerShown
        };

        //�o�i�[�L����\������
        Advertisement.Banner.Show(_adUnitId, options);
    }

    //�o�i�[�L�����\���ɂ���
    void HideBannerAd()
    {
        //�o�i�[�L�����\���ɂ���
        Advertisement.Banner.Hide();
    }

    void OnBannerClicked() { }
    void OnBannerShown() { }
    void OnBannerHidden() { }

    void OnDestroy()
    {
        //_loadBannerButton.onClick.RemoveAllListeners();
        //_showBannerButton.onClick.RemoveAllListeners();
        //_hideBannerButton.onClick.RemoveAllListeners();
    }
}
