using UnityEngine;
public class PlayerHealth : MonoBehaviour
{
    [SerializeField]MyGameManager _myGameManager;
    [Header("HP")]
    [SerializeField] float _maxHP = 100;
    [SerializeField] float _currentHP = 100;
    [SerializeField] RectTransform _PlayerHpBar;
    float _Width = 100;
    [SerializeField] public bool _isdead = false;
    void Awake()
    {
        if (_myGameManager == null)
            _myGameManager = FindObjectOfType<MyGameManager>();
    }
    void Start()
    {
        //HP‚Ì‰Šú‰»
        _currentHP = _maxHP;
        UpdateHpBar();
    }
    public void EnemytoPlayerDamage(int _damage)
    {
        //0‚ğ‰º‰ñ‚ç‚È‚¢‚æ‚¤‚É‚·‚é
        _currentHP = Mathf.Max(_currentHP - _damage, 0);
        UpdateHpBar();
        if (_currentHP <= 0)
        {
            Gameover();
        }
    }
    void UpdateHpBar()
    {
        float ratio = _currentHP / _maxHP;
        _PlayerHpBar.sizeDelta = new Vector2(_Width * ratio, _PlayerHpBar.sizeDelta.y);
    }
    void Gameover()
    {
        _isdead = true;
        _myGameManager.GameOver();
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
