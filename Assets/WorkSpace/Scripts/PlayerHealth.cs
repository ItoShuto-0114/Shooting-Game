using UnityEngine.UI;
using UnityEngine;
public class PlayerHealth : MonoBehaviour
{
    [SerializeField] Image _image;
    [SerializeField] float _maxHP = 100;
    [SerializeField] float _currentHP = 100;
    void Start()
    {
        //HP�̏�����
        _currentHP = _maxHP;
    }
    public void EnemytoPlayerDamage(int _damage)
    {
        //0�������Ȃ��悤�ɂ���
        _currentHP = Mathf.Max(_currentHP - _damage, 0);
        //fillAmount�ɑ��
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
        //_maxHP������Ȃ��悤�ɂ���
       // _currentHP = Mathf.Min(_currentHP + _changeValue, _maxHP);

        //fillAmount�ɑ��
        //_image.fillAmount = _currentHP / _maxHP;

        //Debug.Log($"HP�̊���:{_currentHP / _maxHP}");
   //}
}
