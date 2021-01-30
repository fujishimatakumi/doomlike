using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GunBase : MonoBehaviour
{
    //１マガジンの弾薬数
    [SerializeField] int m_bulletNum;
    [SerializeField] float m_burstRate;
    [SerializeField] int m_maxBullet;
    [SerializeField] int m_damage;
    [SerializeField] float m_reloadSpeed;
    [SerializeField] Text m_nowBulletText;
    [SerializeField] Text m_nowMaxBulletText;
    int m_nowbullet;
    int m_nowMaxBullet;
    float m_counter;
    bool m_isReload = false;
    bool m_isEmpty = false;
    PlayerControlle m_player;

    private void Start()
    {
        m_player = GetComponent<PlayerControlle>();
        m_nowbullet = m_bulletNum;
        m_nowMaxBullet = m_maxBullet;
        ReflsehTextOnReload();
    }

    //実行中にパラメータを初期化する
    public void InitGun(int bulletnum, float burstRate, int maxBullet, int damage, float relaodSpeed)
    {
        m_bulletNum = bulletnum;
        m_burstRate = burstRate;
        m_maxBullet = maxBullet;
        m_damage = damage;
        m_reloadSpeed = relaodSpeed;
    }

    public void Fire()
    {
        if (m_isEmpty) { return; }
        if (m_counter <= 0)
        {
            m_nowbullet -= 1;
            if (m_nowbullet == 0)
            {
                m_isEmpty = true;
            }
            if (m_player.EnemySclipt)
            {
                m_player.EnemySclipt.Damage(m_damage);
                Debug.Log("hit");
            }
            m_counter = m_burstRate;
            BulletTextReflseh();
        }
        else
        {
            m_counter -= Time.deltaTime;
        }
    }

    public IEnumerator Reload()
    {
        if (m_isReload) { yield break; }
        m_isReload = true;
        float counter = m_reloadSpeed;
        while (counter >= 0)
        {
            counter -= Time.deltaTime;
            yield return null;
        }

        ReloadCalc();

        m_isReload = false;
        m_isEmpty = false;

    }

    public void ReloadCalc()
    {
        //必要な弾の算出
        int needNum = m_bulletNum - m_nowbullet;
        if (m_nowMaxBullet - needNum >= 0)
        {
            m_nowbullet = m_bulletNum;
            m_nowMaxBullet -= needNum;
        }
        else
        {
            m_nowbullet = m_nowMaxBullet;
            m_nowMaxBullet = 0;
        }
        ReflsehTextOnReload();
    }

    public void BulletTextReflseh()
    {
        m_nowBulletText.text = m_nowbullet.ToString() + "/";
    }

    public void ReflsehTextOnReload()
    {
        m_nowBulletText.text = m_nowbullet.ToString() + "/";
        m_nowMaxBulletText.text = m_nowMaxBullet.ToString();
    }

    private void ResetCounter() { m_counter = 0; }
    
}
