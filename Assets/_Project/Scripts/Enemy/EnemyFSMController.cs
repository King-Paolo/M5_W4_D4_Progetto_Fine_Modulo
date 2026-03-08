using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class EnemyFSMController : MonoBehaviour
{
    public enum STATE { PATROL, CHASE };

    [SerializeField] protected STATE _state;
    [SerializeField] protected Transform _target;
    [SerializeField] protected Transform _pov;
    [SerializeField] private float _viewRange;
    [SerializeField] private float _viewAngle;

    protected NavMeshAgent _agent;

    private float _patrolSpeed = 3.5f;
    private float _chasingSpeed = 6f;
    private float _patrolStoppingDistance = 0;
    private float _chasingStoppingDistance = 1.2f;
    private float _detectionTime = 0.5f;
    private float _detectionTimer;
    private float _escapeTime = 2.5f;
    private float _escapeTimer;
    private ConeOfView _cov;

    private void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
        _cov = GetComponent<ConeOfView>();
    }

    private void Update()
    {
        CheckTransition();
        ChangeColorState();

        if (_state == STATE.CHASE)
        {
            float distance = Vector3.Distance(transform.position, _target.position);

            if (distance <= _chasingStoppingDistance)
            {
                GameManager.Instance.GameOver();
            }
        }

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

    private void CheckTransition()
    {
        if (CanSeePlayer() && _state == STATE.PATROL)
        {
            _escapeTimer = 0;
            _detectionTimer += Time.deltaTime;

            if (_detectionTimer > _detectionTime)
            {
                _state = STATE.CHASE;
                _detectionTimer = 0;
            }
        }

        if (!CanSeePlayer() && _state == STATE.CHASE)
        {
            _detectionTimer = 0;
            _escapeTimer += Time.deltaTime;

            if (_escapeTimer > _escapeTime)
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

        if (Angle > _viewAngle)
            return false;

        if (Physics.Raycast(_pov.position, direction.normalized, out RaycastHit hit, _viewRange))
        {
            return hit.collider.CompareTag("Player");
        }
        return false;
    }

    private void ChangeColorState()
    {
        if (_state == STATE.CHASE)
        {
            _cov.SetColor(Color.red);
            return;
        }

        if (CanSeePlayer())
        {
            _cov.SetColor(Color.yellow);
        }
        else
        {
            _cov.SetColor(Color.green);
        }
    }
}
