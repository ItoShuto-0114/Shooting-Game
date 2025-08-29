using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageSelectScene : MonoBehaviour
{
    [SerializeField] string _Stage1Scene;
    [SerializeField] string _Stage2Scene;
    [SerializeField] string _Stage3Scene;
    [SerializeField] Button _Stage1button;
    [SerializeField] Button _Stage2button;
    [SerializeField] Button _Stage3button;
    void Start()
    {
        _Stage1button.onClick.AddListener(Stage1);
        _Stage2button.onClick.AddListener(Stage2);
        _Stage3button.onClick.AddListener(Stage3);
    }
    void Stage1()
    {
        SceneManager.LoadScene(_Stage1Scene);
    }
    void Stage2()
    {
        SceneManager.LoadScene(_Stage2Scene);
    }
    void Stage3()
    {
        SceneManager.LoadScene(_Stage3Scene);
    }
}
