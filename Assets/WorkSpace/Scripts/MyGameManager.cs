using UnityEngine;
using UnityEngine.SceneManagement;

public class MyGameManager : MonoBehaviour
{
    public static MyGameManager Instance { get; private set; }
    [SerializeField] string _GameWinSceneName;
    [SerializeField] string _GameoverSceneName;
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject); // ���łɑ��݂��Ă���ꍇ�͍폜
            return;
        }
    }
    public void GameWin()
    {
        SoundManager.Instance?.StopButtleBGM();
        SceneManager.LoadScene(_GameWinSceneName);
    }
    public void GameOver()
    {
        SoundManager.Instance?.StopButtleBGM();
        SceneManager.LoadScene(_GameoverSceneName);
    }
}
