using System;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyData",menuName = "ScriptableObject/EnemyData")]
[Serializable]
public class EnemyDataObject :ScriptableObject
{
    [SerializeField]EnemyDataBase[] m_datas;

    public EnemyDataBase GetEnemyData(int level) { return m_datas[level]; }
}
[Serializable]
public class EnemyDataBase
{
    [SerializeField] int m_initHP;
    [SerializeField] int m_score;
    [SerializeField] TargetType m_targetType;
    [SerializeField] GameObject m_target;
    [SerializeField] string m_label;
    public int InitHP => m_initHP;
    public int Score => m_score;
    public Vector3 TargetPos => m_target.transform.position;

    public void SetTarget()
    {
        switch (m_targetType)
        {
            case TargetType.Player:
                m_target = GameObject.FindGameObjectWithTag("Player");
                break;
            default:
                break;
        }
    }
}

public enum TargetType
{ 
    Player
}
