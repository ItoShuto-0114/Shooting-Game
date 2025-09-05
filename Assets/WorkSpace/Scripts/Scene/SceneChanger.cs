using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneChanger : MonoBehaviour
{
    [SerializeField] Button _Titlebutton;
    [SerializeField] string _TitleScene;
    [SerializeField] SoundManager _soundManager;
    void Start()
    {
        _Titlebutton.onClick.AddListener(GoTitle);
        if (_soundManager == null)
            _soundManager = FindObjectOfType<SoundManager>();
    }
    void GoTitle()
    {
        _soundManager.PlayButtonSe();
        SceneManager.LoadScene(_TitleScene);
    }
}
