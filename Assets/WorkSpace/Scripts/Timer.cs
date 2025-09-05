using System.Collections;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField]TextMeshProUGUI _TimerText;
    [SerializeField] GameObject _player;
    [SerializeField] GameObject _Enemy;
    void Start()
    {
        _player.SetActive(false);
        _Enemy.SetActive(false);
        StartCoroutine(Countdown());
    }
    IEnumerator Countdown()
    {

        _TimerText.text = "3";
        yield return new WaitForSeconds(1f);

        // 2
        _TimerText.text = "2";
        yield return new WaitForSeconds(1f);

        // 1
        _TimerText.text = "1";
        yield return new WaitForSeconds(1f);

        // START!
        _TimerText.text = "START!";
        yield return new WaitForSeconds(1f);
        _player.SetActive(true);
        _Enemy.SetActive(true);
        SoundManager.Instance?.PlayButtleBGM();
        // è¡Ç∑
        _TimerText.text = "";
    }
}
