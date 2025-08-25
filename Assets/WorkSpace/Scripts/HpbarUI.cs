using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HpbarUI : MonoBehaviour
{
    [SerializeField] private Transform target;  // プレイヤーのTransform
    [SerializeField] private Vector3 offset = new Vector3(0, -0.5f, 0); // プレイヤーの下に表示

    void Update()
    {
        if (target != null)
        {
            transform.position = target.position + offset;
        }
    }
}
