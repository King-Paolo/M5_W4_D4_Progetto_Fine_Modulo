using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyPatrol : EnemyFSMController
{
    [SerializeField] Transform[] _pathPoints;
    [SerializeField] private float _waitTime;

    private Coroutine _patrolCoroutine;
    private int _currentPos;


    IEnumerator Patrol()
    {
        while (_state == STATE.PATROL)
        {
            if (_pathPoints == null || _pathPoints.Length == 0)
            {
                yield break;
            }

            if (_currentPos >= _pathPoints.Length)
                _currentPos = 0;

            _agent.SetDestination(_pathPoints[_currentPos].position);

            while (_agent.pathPending || _agent.remainingDistance > _agent.stoppingDistance)
            {
                yield return null;
            }

            yield return new WaitForSeconds(_waitTime);

            _currentPos++;
        }
    }

    protected override void PatrolUpdate()
    {
        base.PatrolUpdate();

        if (_patrolCoroutine == null /*&& _state == STATE.PATROL*/)
        {
            _patrolCoroutine = StartCoroutine(Patrol());
            //_agent.speed = _currentSpeed;
        }
    }

    protected override void ChaseUpdate()
    {
        base.ChaseUpdate();

        if (_patrolCoroutine != null)
        {
            StopCoroutine(_patrolCoroutine);
            _patrolCoroutine = null;
        }
    }
    //protected override void OnEnterState(STATE state)
    //{
    //    if (state == STATE.PATROL)
    //    {
    //        _patrolCoroutine = StartCoroutine(Patrol());
    //        _agent.speed = _currentSpeed;
    //    }

    //    if (state == STATE.CHASE)
    //    {
    //        _agent.speed = _currentSpeed * 2;
    //    }
    //}

    //protected override void OnExitState(STATE state)
    //{
    //    if (state != STATE.PATROL && _patrolCoroutine != null)
    //    {
    //        StopCoroutine(_patrolCoroutine);
    //        _patrolCoroutine = null;
    //    }
    //}
}
