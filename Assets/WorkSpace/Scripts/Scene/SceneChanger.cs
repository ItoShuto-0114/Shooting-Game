using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneChanger : MonoBehaviour
{
    [SerializeField] Button _Titlebutton;
    [SerializeField] string _TitleScene;
    void Start()
    {
        _Titlebutton.onClick.AddListener(GoTitle);
    }
    void GoTitle()
    {
        SceneManager.LoadScene(_TitleScene);
    }
}
