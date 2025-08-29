using System.Collections;
using UnityEngine;
public class Enemy1 : MonoBehaviour
{
    [SerializeField]MyGameManager _myGameManager;
    [SerializeField] private Transform _Enemymuzzle;
    [SerializeField] private Transform _Enemymuzzle1;
    [SerializeField] private Transform _Enemymuzzle2;
    [SerializeField] private Transform _Enemymuzzle3;
    [SerializeField] private Transform _Enemymuzzle4;
    [SerializeField] private GameObject _BulletPrefab;
    [SerializeField] private GameObject _BulletPrefab1;
    [SerializeField] private GameObject _BulletPrefab2;
    [SerializeField] private GameObject _BulletPrefab3;
    [SerializeField] private GameObject _BulletPrefab4;
    [SerializeField] private float _BulletSpeed = 10;
    [SerializeField] private float _EnemyAttackInterval = 1;
    [SerializeField] private float _Enemy1MaxHp = 100;
    [SerializeField] float _EnemycurrentHP = 100;
    [SerializeField] RectTransform _EnemyHpBar;
    [SerializeField] float _Width = 100;
    float _timer = 0;
    void Awake()
    {
        if (_myGameManager == null)
            _myGameManager = FindObjectOfType<MyGameManager>();
    }
    void Start()
    {
        _EnemycurrentHP = _Enemy1MaxHp;
        UpdateHpBar();  
    }
    void Update()
    {
        _timer += Time.deltaTime;
        if (_timer >= _EnemyAttackInterval)
        {
            Shoot();
            _timer = 0;
        }
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(_BulletPrefab, _Enemymuzzle.position, _Enemymuzzle.rotation);
        if (bullet.TryGetComponent(out Rigidbody2D rigidBody2D))
        {
            Vector2 velocity = _Enemymuzzle.up * _BulletSpeed; rigidBody2D.velocity = velocity;
        }
        GameObject bullet1 = Instantiate(_BulletPrefab1, _Enemymuzzle1.position, _Enemymuzzle1.rotation);
        if (bullet1.TryGetComponent(out Rigidbody2D rigidBody2D1))
        {
            Vector2 velocity = _Enemymuzzle1.up * _BulletSpeed; rigidBody2D1.velocity = velocity;
        }
        GameObject bullet2 = Instantiate(_BulletPrefab2, _Enemymuzzle2.position, _Enemymuzzle2.rotation);
        if (bullet2.TryGetComponent(out Rigidbody2D rigidBody2D2))
        {
            Vector2 velocity = _Enemymuzzle2.up * _BulletSpeed; rigidBody2D2.velocity = velocity;
        }
        GameObject bullet3 = Instantiate(_BulletPrefab3, _Enemymuzzle3.position, _Enemymuzzle3.rotation);
        if (bullet3.TryGetComponent(out Rigidbody2D rigidBody2D3))
        {
            Vector2 velocity = _Enemymuzzle3.up * _BulletSpeed; rigidBody2D3.velocity = velocity;
        }
        GameObject bullet4 = Instantiate(_BulletPrefab4, _Enemymuzzle4.position, _Enemymuzzle4.rotation);
        if (bullet4.TryGetComponent(out Rigidbody2D rigidBody2D4))
        {
            Vector2 velocity = _Enemymuzzle4.up * _BulletSpeed; rigidBody2D4.velocity = velocity;
        }
    }
    public void PlayertoDamage(int _damage)
    {
        _EnemycurrentHP = Mathf.Max(_EnemycurrentHP - _damage, 0);
        UpdateHpBar();
        if (_EnemycurrentHP <= 0)
        {
            _myGameManager.GameWin();
        }
        Debug.Log(_damage + "ダメージ与えた");
    }
    void UpdateHpBar()
    {
        float ratio = _EnemycurrentHP / _Enemy1MaxHp;
        _EnemyHpBar.sizeDelta = new Vector2(_Width * ratio, _EnemyHpBar.sizeDelta.y);
    }
    void GameWin()
    {
        Debug.Log("勝ち！");
    }
}
