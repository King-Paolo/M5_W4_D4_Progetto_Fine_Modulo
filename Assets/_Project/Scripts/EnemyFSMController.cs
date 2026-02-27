using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyFSMController : MonoBehaviour
{
    public enum STATE { PATROL, CHASE };

    [SerializeField] protected STATE _state;
    [SerializeField] protected Transform target;

    protected NavMeshAgent _agent;
    protected bool _isPatrolling;

    private void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        if (_state != STATE.PATROL)
        {
            _isPatrolling = false;
        }

        switch (_state)
        {
            case STATE.PATROL:
                PatrolUpdate();
                break;
            case STATE.CHASE:
                break;
        }
    }

    public virtual void PatrolUpdate()
    { }
}
