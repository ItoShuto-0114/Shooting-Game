using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class StageSelectScene : MonoBehaviour
{
    [SerializeField] string _Stage1Scene;
    [SerializeField] string _Stage2Scene;
    [SerializeField] string _Stage3Scene;
    [SerializeField] Button _Stage1button;
    [SerializeField] Button _Stage2button;
    [SerializeField] Button _Stage3button;
    [SerializeField] Image _image;
    float _duration = 1.0f;
    void Start()
    {
        _image.gameObject.SetActive(false);
        _Stage1button.onClick.AddListener(() => FadeStart(_Stage1Scene));
        _Stage2button.onClick.AddListener(() => FadeStart(_Stage2Scene));
        _Stage3button.onClick.AddListener(() => FadeStart(_Stage3Scene));
    }
        void FadeStart(string sceneName)
        {
        SoundManager.Instance?.StopTitleBGM();
            SoundManager.Instance?.PlayButtonSe();
            StartCoroutine(Fadeout(sceneName));
        }
        IEnumerator Fadeout(string sceneName)
        {
            _image.gameObject.SetActive(true);
            Color c = _image.color;
            c.a = 0;
            _image.color = c;
            for (float t = 0; t < _duration; t += Time.deltaTime)
            {
                c.a = Mathf.Lerp(0f, 1f, t / _duration);
                _image.color = c;
                yield return null;
            }
            SceneManager.LoadScene(sceneName);
        }
    }
