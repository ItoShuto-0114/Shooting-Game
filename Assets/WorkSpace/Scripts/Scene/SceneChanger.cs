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
        void GoTitle()
        {
            SoundManager.Instance?.PlayButtonSe();
            SceneManager.LoadScene(_TitleScene);
        }
    }
}
