using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    Animator _animator;
    
    /// <summary>プレイヤーの移動判定に使用</summary>
    Rigidbody _rb;
    
    void Start()
    {
        _animator = GetComponent<Animator>();
        _rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //animatorのSpeedにプレイヤーの移動速度をセットする
        _animator.SetFloat("Speed", _rb.velocity.magnitude);
    }
}



