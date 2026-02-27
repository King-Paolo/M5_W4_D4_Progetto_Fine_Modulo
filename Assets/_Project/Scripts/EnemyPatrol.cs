using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyPatrol : EnemyFSMController
{
    [SerializeField] Transform[] _pathPoints;

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

            yield return new WaitForSeconds(5f);

            _currentPos++;
        }
    }

    public override void PatrolUpdate()
    {
        if (!_isPatrolling)
        {
            StartCoroutine(Patrol());
            _isPatrolling = true;
        }
    }
}
