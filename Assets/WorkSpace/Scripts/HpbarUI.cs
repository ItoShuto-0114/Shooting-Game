using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HpbarUI : MonoBehaviour
{
    [SerializeField] private Transform target;  // �v���C���[��Transform
    [SerializeField] private Vector3 offset = new Vector3(0, -0.5f, 0); // �v���C���[�̉��ɕ\��

    void Update()
    {
        if (target != null)
        {
            transform.position = target.position + offset;
        }
    }
}
