using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAnimationController : MonoBehaviour
{
    Animator _animator;
    /// <summary>エネミーのパラメーターを取得するため</summary>
    NavMeshAgent _agent;
    
    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
        _agent = GetComponent<NavMeshAgent>();
    }
    /// <summary>
    /// NavMeshAgentのスピードの値をアニメーターのパラメーターにセットする
    /// </summary>
    private void UpdateSpeedParameters()
    {
        _animator.SetFloat(EnemyStateName.Speed.ToString(), _agent.speed);
    }
    /// <summary>
    /// アニメーターのトリガーパラメーターをオンにする
    /// 外部から呼び出すことを想定している
    /// </summary>
    /// <param name="paramater">オンにするパラメーター</param>
    public void OnActionParamater(EnemyActionParameterName paramater)
    {
        switch (paramater)
        {
            case EnemyActionParameterName.Attack:
                _animator.SetTrigger(EnemyActionParameterName.Attack.ToString());
                break;
            case EnemyActionParameterName.FallingBack:
                _animator.SetTrigger(EnemyActionParameterName.FallingBack.ToString());
                break;
            case EnemyActionParameterName.FallingForward:
                _animator.SetTrigger(EnemyActionParameterName.FallingForward.ToString());
                break;
            default:
                break;
        }
    }
    // Update is called once per frame
    void Update()
    {
        UpdateSpeedParameters();
        //デバック用
        if (Input.GetKeyDown(KeyCode.A))
        {
            OnActionParamater(EnemyActionParameterName.Attack);
        }
        else if (Input.GetKeyDown(KeyCode.B))
        {
            OnActionParamater(EnemyActionParameterName.FallingBack);
        }
        else if (Input.GetKeyDown(KeyCode.F))
        {
            OnActionParamater(EnemyActionParameterName.FallingForward);
        }
    }
}

public enum EnemyStateName
{ 
    Speed
}

public enum EnemyActionParameterName
{ 
    Attack,
    FallingBack,
    FallingForward
}
