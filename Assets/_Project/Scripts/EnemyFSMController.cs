using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyFSMController : MonoBehaviour
{
    public enum STATE { PATROL, CHASE };

    [SerializeField] protected STATE _state;
    [SerializeField] protected Transform _target;

    protected NavMeshAgent _agent;
    protected STATE _currentState;

    private float _patrolSpeed = 3.5f;
    private float _chasingSpeed = 7f;
    private float _patrolStoppingDistance = 0;
    private float _chasingStoppingDistance = 1f;
    private bool _isChasing;

    private void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
    }

    private void Start()
    {
        //_currentState = _state;
        //OnEnterState(_state);
    }

    private void Update()
    {
        //if (_state != _currentState)
        //{
        //    OnExitState(_currentState);
        //    OnEnterState(_state);
        //    _currentState = _state;
        //}


        switch (_state)
        {
            case STATE.PATROL:
                PatrolUpdate();
                break;

            case STATE.CHASE:
                ChaseUpdate();
                break;
        }
    }

    protected virtual void ChaseUpdate()
    {
        _agent.SetDestination(_target.position);
        _agent.speed = _chasingSpeed;
        _agent.stoppingDistance = _chasingStoppingDistance;
    }
    protected virtual void PatrolUpdate() 
    {
        _agent.speed = _patrolSpeed;
        _agent.stoppingDistance = _patrolStoppingDistance;
    }
    //protected virtual void OnEnterState(STATE state) { }
    //protected virtual void OnExitState(STATE state) { }
}
