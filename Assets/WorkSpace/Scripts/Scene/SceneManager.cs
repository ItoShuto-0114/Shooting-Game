using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class MySceneManager : MonoBehaviour
{
    [SerializeField] string _SelectScene;
    [SerializeField] Button _Startbutton;
    [SerializeField] Button _Exitbutton;
    [SerializeField] private Button _Settingbutton;
    [SerializeField] Image _image;
    void Start()
    {
        _Startbutton.onClick.AddListener(SceneChange);
        //_Exitbutton.onClick.AddListener(SceneChange);
        //_Settingbutton.onClick.AddListener(_SettingScene);
    }

    void SceneChange()
    {
        SceneManager.LoadScene(_SelectScene);
    }
}
