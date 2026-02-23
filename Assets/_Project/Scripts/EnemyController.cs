using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    [SerializeField] NavMeshAgent _enemyAgent;
    [SerializeField] Transform[] _pathPoints;

    private int _currentPos;

    private void Start()
    {
        _enemyAgent = GetComponent<NavMeshAgent>();
        StartCoroutine(PathRoll());
    }

    IEnumerator PathRoll()
    {
        while (true)
        {
            if (_pathPoints == null || _pathPoints.Length == 0)
            {
                yield break;
            }

            if (_currentPos >= _pathPoints.Length)
                _currentPos = 0;

            _enemyAgent.SetDestination(_pathPoints[_currentPos].position);

            while (_enemyAgent.pathPending || _enemyAgent.remainingDistance > _enemyAgent.stoppingDistance)
            {
                yield return null;
            }

            yield return new WaitForSeconds(5f);

            _currentPos++;
        }
    }
}
