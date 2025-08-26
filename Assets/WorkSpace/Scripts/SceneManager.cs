using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class MySceneManager : MonoBehaviour
{
    [SerializeField] string SelectScene;
    [SerializeField] string SettingScene;
    [SerializeField] Button _Startbutton;
    [SerializeField] Button _Exitbutton;
    [SerializeField] private Button _Settingbutton;
    [SerializeField] Image _image;
    void Start()
    {   
            //_image.gameObject.SetActive(false);
        _Startbutton.onClick.AddListener(SceneChange);
        _Exitbutton.onClick.AddListener(SceneChange);
       // _Settingbutton.onClick.AddListener(SettingScene);
    }

    // Update is called once per frame
    void SceneChange()
    {
        SceneManager.LoadScene(SelectScene);
    }
  
}
