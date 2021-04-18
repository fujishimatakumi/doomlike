using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//エラーを発生させないようにするため
[RequireComponent(typeof(AudioSource))]
public class SEPlayer : MonoBehaviour
{
    /// <summary>
    ///　再生されるSEの配列
    /// </summary>
    [SerializeField] AudioClip[] _seClips;
    AudioSource _audio;

    void Start()
    {
        _audio = GetComponent<AudioSource>();
    }

    /// <summary>
    /// SEの中からランダムに再生する
    /// </summary>
    //TODO:連続して呼ばれたら再生中のSEを止める
    public void PlaySE()
    {
        if (_seClips.Length == 0) return;

        int seIndex = Random.Range(0, _seClips.Length);
        _audio.PlayOneShot(_seClips[seIndex]);
    }


}
