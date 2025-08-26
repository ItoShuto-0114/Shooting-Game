using UnityEngine.UI;
using UnityEngine;
public class PlayerHealth : MonoBehaviour
{
    [SerializeField] Image _image;
    [SerializeField] float _maxHP = 100;
    [SerializeField] float _currentHP = 100;
    void Start()
    {
        //HP‚Ì‰Šú‰»
        _currentHP = _maxHP;
    }
    public void EnemytoPlayerDamage(int _damage)
    {
        //0‚ğ‰º‰ñ‚ç‚È‚¢‚æ‚¤‚É‚·‚é
        _currentHP = Mathf.Max(_currentHP - _damage, 0);
        //fillAmount‚É‘ã“ü
        _image.fillAmount = _currentHP / _maxHP;
        if(_currentHP <= 0)
        {
            Gameover();
        }
    }
    void Gameover()
    {
        Debug.Log("Gameover");
    }
    //void Heal()
    //{
        //_maxHP‚ğã‰ñ‚ç‚È‚¢‚æ‚¤‚É‚·‚é
       // _currentHP = Mathf.Min(_currentHP + _changeValue, _maxHP);

        //fillAmount‚É‘ã“ü
        //_image.fillAmount = _currentHP / _maxHP;

        //Debug.Log($"HP‚ÌŠ„‡:{_currentHP / _maxHP}");
   //}
}
