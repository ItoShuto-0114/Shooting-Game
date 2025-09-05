using System.Collections;
using UnityEngine;

public class Lazer : MonoBehaviour
{
    [SerializeField] Transform _Minionmuzzle; // レーザーの発射口
    [SerializeField] float _minAngle = 120f;  // 左端の角度
    [SerializeField] float _maxAngle = 210f;  // 右端の角度
    [SerializeField] float _speed = 0.5f;     // 往復スピード（小さいほどゆっくり）

    void Update()
    {
        // 0～1をゆっくり往復する値
        float t = Mathf.PingPong(Time.time * _speed, 1f);

        // minAngle ↔ maxAngle を往復
        float angle = Mathf.Lerp(_minAngle, _maxAngle, t);

        // マズルをその角度に設定
        _Minionmuzzle.localRotation = Quaternion.Euler(0, 0, angle);
    }
}
