using UnityEngine;

public class Enemy2 : MonoBehaviour
{
    [SerializeField]MyGameManager _myGameManager;
    [SerializeField] Transform _Enemy2muzzle;
    [SerializeField] GameObject _BulletPrefab;
    [SerializeField] private float _BulletSpeed = 10;
    [SerializeField] private float _Enemy2AttackInterval = 1;
    [SerializeField] private float _Enemy2MaxHp = 100;
    [SerializeField] float _Enemy2currentHP = 100;
    [SerializeField] RectTransform _Enemy2HpBar;
    [SerializeField] float _Width = 100;
    float _timer = 0;
    void Awake()
    {
        if (_myGameManager == null)
            _myGameManager = FindObjectOfType<MyGameManager>();
    }
    void Start()
    {
        _Enemy2currentHP = _Enemy2MaxHp;
        UpdateHpBar();
    }
    void UpdateHpBar()
    {
            float ratio = _Enemy2currentHP / _Enemy2MaxHp;
            _Enemy2HpBar.sizeDelta = new Vector2(_Width * ratio, _Enemy2HpBar.sizeDelta.y);
    }
    void Update()
    {
        _timer += Time.deltaTime;
        if (_timer >= _Enemy2AttackInterval)
        {
            Shoot();
            _timer = 0;
        }
    }
    void Shoot()
    {
        GameObject bullet = Instantiate(_BulletPrefab, _Enemy2muzzle.position, _Enemy2muzzle.rotation);
            if (bullet.TryGetComponent(out Rigidbody2D rigidbody2D))
        {
            Vector2 velocity = _Enemy2muzzle.up * _BulletSpeed; rigidbody2D.velocity = velocity;
        }
    }
    public void PlayertoDamage(int _damage)
    {
        _Enemy2currentHP = Mathf.Max(_Enemy2currentHP - _damage, 0);
        UpdateHpBar();
        if (_Enemy2currentHP <= 0)
        {
            _myGameManager.GameWin();
        }
        Debug.Log(_damage + "ƒ_ƒ[ƒW—^‚¦‚½");
    }
}
