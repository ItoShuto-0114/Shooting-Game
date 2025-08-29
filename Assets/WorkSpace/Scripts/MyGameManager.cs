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
            Destroy(gameObject); // ‚·‚Å‚É‘¶İ‚µ‚Ä‚¢‚éê‡‚Ííœ
            return;
        }
    }
    public void GameWin()
    {
        SceneManager.LoadScene(_GameWinSceneName);
    }
    public void GameOver()
    {
        SceneManager.LoadScene(_GameoverSceneName);
    }
}
