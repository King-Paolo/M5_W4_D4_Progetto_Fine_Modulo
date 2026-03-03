using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyFSMController : MonoBehaviour
{
    public enum STATE { PATROL, CHASE };

    [SerializeField] protected STATE _state;
    [SerializeField] protected Transform _target;
    [SerializeField] protected Transform _pov;
    [SerializeField] protected float _viewRange;
    [SerializeField] private float _viewAngle;

    protected NavMeshAgent _agent;
    protected STATE _currentState;

    private float _patrolSpeed = 3.5f;
    private float _chasingSpeed = 7f;
    private float _patrolStoppingDistance = 0;
    private float _chasingStoppingDistance = 1f;
    private float _detectionTime = 1.5f;
    private float _detectionTimer;
    private float _escapeTime = 2.5f;
    private float _escapeTimer;

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
        CheckTransition();

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
    private void CheckTransition()
    {
        if(CanSeePlayer() && _state == STATE.PATROL)
        {
            _escapeTimer = 0;
            _detectionTimer += Time.deltaTime;

            if(_detectionTimer > _detectionTime)
            {
                _state = STATE.CHASE;
                _detectionTimer = 0;
            }
        }

        if(!CanSeePlayer() && _state == STATE.CHASE)
        {
            _detectionTimer = 0;
            _escapeTimer += Time.deltaTime;

            if(_escapeTimer > _escapeTime)
            {
                _state = STATE.PATROL;
                _escapeTimer = 0;
            }
        }
    }

    private bool CanSeePlayer()
    {
        Vector3 direction = _target.position - _pov.position;

        if (Vector3.Distance(_pov.position, _target.position) > _viewRange)
            return false;

        float Angle = Vector3.Angle(_pov.forward, direction);

        if(Angle > _viewAngle)
            return false;

        if(Physics.Raycast(_pov.position, direction.normalized, out RaycastHit hit, _viewRange))
        {
            return hit.collider.CompareTag("Player");
        }

        return false;
    }
}
