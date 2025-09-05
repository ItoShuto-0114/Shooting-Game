using System.Collections;
using System.Collections.Generic;
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
}
