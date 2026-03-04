using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStatic : EnemyFSMController
{
    [SerializeField] private float _rotationSpeed;
    [SerializeField] private float _maxAngle;
    [SerializeField] private float _waitTime;
    [SerializeField] private Transform _startPosition;

    private Quaternion _startRotation;
    private Quaternion _targetRotation; 
    private Coroutine _patrolCoroutine;

    private void Start()
    {
        _startRotation = transform.rotation;
    }

    protected override void PatrolUpdate()
    {
        base.PatrolUpdate();

        if (_patrolCoroutine == null)
        {
            _targetRotation = _startRotation * Quaternion.Euler(0, _maxAngle, 0);

            _agent.SetDestination(_startPosition.position);
            _patrolCoroutine = StartCoroutine(StaticPatrol());
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

    IEnumerator StaticPatrol()
    {
        while (_state == STATE.PATROL)
        {

            while (Quaternion.Angle(transform.rotation, _targetRotation) > 0.01f)
            {
                transform.rotation = Quaternion.RotateTowards(transform.rotation, _targetRotation, _rotationSpeed * Time.deltaTime);

                yield return null;

            }
            yield return new WaitForSeconds(_waitTime);

            while (Quaternion.Angle(transform.rotation, _startRotation) > 0.01f)
            {
                transform.rotation = Quaternion.RotateTowards(transform.rotation, _startRotation, _rotationSpeed * Time.deltaTime);

                yield return null;
            }
            yield return new WaitForSeconds(_waitTime);
        }
    }
}
