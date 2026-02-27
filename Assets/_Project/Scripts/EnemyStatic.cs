using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStatic : EnemyFSMController
{
  [SerializeField] private float _rotationSpeed;

    private float _currentAngle = 0;
    private float _maxAngle = 90;
    public override void PatrolUpdate()
    {
        {
            if (!_isPatrolling)
            {
                StartCoroutine(StaticPatrol());
                _isPatrolling = true;
            }
        }
    }

    IEnumerator StaticPatrol()
    {
        while (_state == STATE.PATROL)
        {
            while (_currentAngle < _maxAngle)
            {
                float angle = _rotationSpeed * Time.deltaTime;
                transform.Rotate(0, angle, 0);
                _currentAngle += angle;
            }

            yield return new WaitForSeconds(5f);

            while( _currentAngle > 0)
            {
                float angle = (_rotationSpeed * Time.deltaTime);
                transform.Rotate(0, -angle, 0);
                _currentAngle -= angle;
            }

            yield return new WaitForSeconds(5f);
        }
    }
}
