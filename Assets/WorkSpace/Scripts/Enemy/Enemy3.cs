using System.Collections;
using UnityEngine;

public class Enemy3 : MonoBehaviour
{
    [SerializeField] MyGameManager _myGameManager;
    [SerializeField] Transform _Enemy3muzzle;
    [SerializeField] GameObject _BulletPrefab;
    [SerializeField] private float _BulletSpeed = 10;
    [SerializeField] private float _Enemy3AttackInterval = 1;
    [SerializeField] private float _Enemy3MaxHp = 100;
    [SerializeField] float _Enemy3currentHP = 100;
    [SerializeField] RectTransform _Enemy3HpBar;
    [SerializeField] float _Width = 100;
    [SerializeField] GameObject _Minions;
    [SerializeField] GameObject _Minions2;
    [SerializeField] GameObject _Minions3;
    [SerializeField] GameObject _Minions4;
    [SerializeField] Transform _TargetsMinions;
    [SerializeField] Transform _TargetsMinions2;
    int count = 0;
    int count2 = 0;
    float _timer = 0;
    void Awake()
    {
        if (_myGameManager == null)
            _myGameManager = FindObjectOfType<MyGameManager>();
    }
    void Start()
    {
        _Enemy3currentHP = _Enemy3MaxHp;
        UpdateHpBar();
    }
    void OnEnable()
    {
        StartCoroutine(MinionsLoop());
    }

    void UpdateHpBar()
    {
        float ratio = _Enemy3currentHP / _Enemy3MaxHp;
        _Enemy3HpBar.sizeDelta = new Vector2(_Width * ratio, _Enemy3HpBar.sizeDelta.y);
    }
    void Update()
    {
        _timer += Time.deltaTime;
        if (_timer >= _Enemy3AttackInterval)
        {
            Shoot();
            _timer = 0;
        }
    }
    void Shoot()
    {
        GameObject bullet = Instantiate(_BulletPrefab, _Enemy3muzzle.position, _Enemy3muzzle.rotation);
        if (bullet.TryGetComponent(out Rigidbody2D rigidbody2D))
        {
            Vector2 velocity = _Enemy3muzzle.up * _BulletSpeed; rigidbody2D.velocity = velocity;
        }
    }
    public void PlayertoDamage(int _damage)
    {
        _Enemy3currentHP = Mathf.Max(_Enemy3currentHP - _damage, 0);
        UpdateHpBar();
        if (_Enemy3currentHP <= 0)
        {
            _myGameManager.GameWin();
        }
        Debug.Log(_damage + "ƒ_ƒ[ƒW—^‚¦‚½");
    }
    IEnumerator MinionsLoop()
    {
        while (true)
        {
            // ƒpƒ^[ƒ“2‚ð1‰ñA13•bŠÔŠu‚Å
            yield return StartCoroutine(MinionsMode2());
            // ƒpƒ^[ƒ“1‚ð1‰ñA13•bŠÔŠu‚Å
            yield return StartCoroutine(Minions());
        }
    }
    IEnumerator MinionsMode2()
    {
       
            yield return new WaitForSeconds(9f);
            Debug.Log("MinionsMode2: 10•b‚½‚Á‚½‚º‚¢");
            Instantiate(_Minions3, _TargetsMinions.position, _TargetsMinions.rotation);
            Instantiate(_Minions4, _TargetsMinions2.position, _TargetsMinions2.rotation);
        
    }
    IEnumerator Minions()
    {
        
            yield return new WaitForSeconds(11f);
            Debug.Log("Minions: 13•b‚½‚Á‚½‚º‚¢");
            Instantiate(_Minions, _TargetsMinions.position, _TargetsMinions.rotation);
            Instantiate(_Minions2, _TargetsMinions2.position, _TargetsMinions2.rotation);
        
    }
}
