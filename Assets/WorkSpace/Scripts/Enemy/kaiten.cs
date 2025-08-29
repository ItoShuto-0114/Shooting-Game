using UnityEngine;

public class kaiten : MonoBehaviour
{
    [SerializeField]float _rotationSpeed = 10;
    [SerializeField] Transform _muzzle;
    void Update()
    {
        _muzzle.transform.Rotate(0, 0, _rotationSpeed * Time.deltaTime);
    }
}
