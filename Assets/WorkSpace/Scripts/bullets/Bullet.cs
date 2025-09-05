using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] BulletType _bulletType;
    [SerializeField] private int _DamagetoPlayer = 10;
    [SerializeField] private int _DamagetoEnemy = 10;
    [Header("敵の弾だったらtrue、playerの弾だったらfalse")]
    [SerializeField] private bool _Targets = true;
    public enum BulletType
    {
        bullet,
        homingbullet,
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Wall"))
        {
            Destroy(gameObject);  // 弾を消す
        }
        #region プレイヤー、敵の弾
        if (_bulletType == BulletType.bullet)
        {
            if (collision.CompareTag("Enemy") && _Targets == false)
            {
                var Enemy1 = collision.GetComponent<Enemy1>();
                var Enemy2 = collision.GetComponent<Enemy2>();
                var Enemy3 = collision.GetComponent<Enemy3>();
                if (Enemy1 != null)
                {
                    Enemy1.PlayertoDamage(_DamagetoEnemy);
                    Destroy(gameObject);
                }
                if (Enemy2 != null)
                {
                    Enemy2.PlayertoDamage(_DamagetoEnemy);
                    Destroy(gameObject);
                }
                if(Enemy3 != null)
                {
                    Enemy3.PlayertoDamage(_DamagetoEnemy);
                    Destroy(gameObject);
                }

            }
            else if (_bulletType == BulletType.bullet && collision.CompareTag("Player") && _Targets == true)
            {
                var player = collision.GetComponentInParent<PlayerHealth>();
                if (player != null)
                {
                    player.EnemytoPlayerDamage(_DamagetoPlayer);
                    Destroy(gameObject);
                }

            }
            #endregion

            #region プレイヤーホーミング弾
            if (_bulletType == BulletType.homingbullet && collision.CompareTag("Enemy") && _Targets == false)
            {
                var Enemy1 = collision.GetComponentInParent<Enemy1>();
                if (Enemy1 != null)
                {
                    Enemy1.PlayertoDamage(_DamagetoEnemy);
                    Destroy(gameObject);
                }
            }

            #endregion

            #region 敵ホーミング弾
            else if (_bulletType == BulletType.homingbullet && collision.CompareTag("Player") && _Targets == true)
            {
                var player = collision.GetComponentInParent<PlayerHealth>();
                if (player != null)
                {
                    player.EnemytoPlayerDamage(_DamagetoPlayer);
                    Destroy(gameObject);
                }

            }
            #endregion

        }


    }
}
