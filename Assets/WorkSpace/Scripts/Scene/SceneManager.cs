using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
public class MySceneManager : MonoBehaviour
{
    [SerializeField] string _SelectScene;
    [SerializeField] Button _Startbutton;
    [SerializeField] Button _Exitbutton;
    [SerializeField] private Button _Settingbutton;
    [SerializeField] Image _image;
    [SerializeField] float duration = 1.0f;
    [SerializeField] SoundManager _soundManager;
    void Start()
    {
        SoundManager.Instance?.PlayTitleBGM();
        Debug.Log("BGM—¬‚µ‚Ä‚Ü‚·");
        _image.gameObject.SetActive(false);
        _Startbutton.onClick.AddListener(SceneChange);
        //_Exitbutton.onClick.AddListener(SceneChange);
        //_Settingbutton.onClick.AddListener(_SettingScene);
    }

    void SceneChange()
    {
        StartCoroutine(Fadeout());
        SoundManager.Instance?.PlayButtonSe();
    }
    IEnumerator Fadeout()
    {
        _image.gameObject.SetActive(true);
        var c = _image.color;
        c.a = 0f;
        for (float t = 0; t < duration; t += Time.deltaTime)
        {
            c.a = Mathf.Lerp(0f, 1f, t / duration);
            _image.color = c;
            yield return null;
        }
        SceneManager.LoadScene(_SelectScene);
    }
}
