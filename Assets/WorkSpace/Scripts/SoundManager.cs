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
        // ���łɑ��݂��Ă���ꍇ�͐V������������i�V���O���g���j
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // �� �V�[���J�ڂ��Ă��j������Ȃ��I
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
