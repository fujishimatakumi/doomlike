using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GunBase : MonoBehaviour
{
    //１マガジンの弾薬数
    [SerializeField] int _bulletNum;
    [SerializeField] float _burstRate;
    [SerializeField] int _maxBullet;
    [SerializeField] int _damage;
    [SerializeField] float _reloadSpeed;
    [SerializeField] Text _nowBulletText;
    [SerializeField] Text _nowMaxBulletText;
    int _nowbullet;
    int _nowMaxBullet;
    float _counter;
    bool _isReload = false;
    bool _isEmpty = false;
    PlayerControlle _player;

    private void Start()
    {
        _player = GetComponent<PlayerControlle>();
        _nowbullet = _bulletNum;
        _nowMaxBullet = _maxBullet;
        ReflsehTextOnReload();
    }

    //実行中にパラメータを初期化する
    public void InitGun(int bulletnum, float burstRate, int maxBullet, int damage, float relaodSpeed)
    {
        _bulletNum = bulletnum;
        _burstRate = burstRate;
        _maxBullet = maxBullet;
        _damage = damage;
        _reloadSpeed = relaodSpeed;
    }

    public void Fire()
    {
        if (_isEmpty) { return; }
        if (_counter <= 0)
        {
            _nowbullet -= 1;
            if (_nowbullet == 0)
            {
                _isEmpty = true;
            }
            if (_player.EnemySclipt)
            {
                _player.EnemySclipt.Damage(_damage);
                Debug.Log("hit");
            }
            _counter = _burstRate;
            BulletTextReflseh();
        }
        else
        {
            _counter -= Time.deltaTime;
        }
    }

    public IEnumerator Reload()
    {
        if (_isReload) { yield break; }
        _isReload = true;
        float counter = _reloadSpeed;
        while (counter >= 0)
        {
            counter -= Time.deltaTime;
            yield return null;
        }

        ReloadCalc();

        _isReload = false;
        _isEmpty = false;

    }

    public void ReloadCalc()
    {
        //必要な弾の算出
        int needNum = _bulletNum - _nowbullet;
        if (_nowMaxBullet - needNum >= 0)
        {
            _nowbullet = _bulletNum;
            _nowMaxBullet -= needNum;
        }
        else
        {
            _nowbullet = _nowMaxBullet;
            _nowMaxBullet = 0;
        }
        ReflsehTextOnReload();
    }

    public void BulletTextReflseh()
    {
        _nowBulletText.text = _nowbullet.ToString() + "/";
    }

    public void ReflsehTextOnReload()
    {
        _nowBulletText.text = _nowbullet.ToString() + "/";
        _nowMaxBulletText.text = _nowMaxBullet.ToString();
    }

    private void ResetCounter() { _counter = 0; }
    
}
