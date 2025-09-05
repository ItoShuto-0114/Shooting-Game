using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [Header("BGM")]
    [SerializeField] AudioSource _TitleBGM;
    [SerializeField] AudioSource _ButtleBGM;
    [Header("SE")]
    [SerializeField] AudioSource _seSource;
    [SerializeField] AudioClip _buttonse;
    [SerializeField] AudioClip _Shootse;
    public void PlayTitleBGM() => _TitleBGM.Play();
    public void StopTitleBGM() => _TitleBGM.Stop();
    public void PlayButtleBGM() => _ButtleBGM.Play();
    public void StopButtleBGM() => _ButtleBGM.Stop();
    public void PlayButtonSe() => _seSource.PlayOneShot(_buttonse);
    public void PlayShootSe() => _seSource.PlayOneShot(_Shootse);
    public static SoundManager Instance { get; private set; }
    void Awake()
    {
        // すでに存在している場合は新しいやつを消す（シングルトン）
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // ← シーン遷移しても破棄されない！
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
