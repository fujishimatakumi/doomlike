using System;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyData",menuName = "ScriptableObject/EnemyData")]
[Serializable]
public class EnemyDataObject :ScriptableObject
{
    [SerializeField]EnemyDataBase[] _datas;

    public EnemyDataBase GetEnemyData(int level) { return _datas[level]; }
}
[Serializable]
public class EnemyDataBase
{
    [SerializeField] int _initHP;
    [SerializeField] int _score;
    [SerializeField] TargetType _targetType;
    [SerializeField] GameObject _target;
    [SerializeField] string _label;
    public int InitHP => _initHP;
    public int Score => _score;
    public Vector3 TargetPos => _target.transform.position;

    public void SetTarget()
    {
        switch (_targetType)
        {
            case TargetType.Player:
                _target = GameObject.FindGameObjectWithTag("Player");
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
