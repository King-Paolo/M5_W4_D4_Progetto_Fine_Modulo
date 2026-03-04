using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConeOfView : MonoBehaviour
{
    [SerializeField] private LineRenderer _lineRenderer;
    [SerializeField] private Transform _pov;
    [SerializeField] private int _segments;
    [SerializeField] private float _viewRange;

    private float _viewAngle = 45;

    private void Update()
    {
        DrawConeOfView();
    }
    public void DrawConeOfView()
    {
        _lineRenderer.positionCount = _segments + 1;

        float startAngle = -_viewAngle;

        Vector3 startingLine = _pov.position;
        Vector3 startingRaycast = _pov.position;
        Vector3 forward = _pov.forward;

        _lineRenderer.SetPosition(0, startingLine);

        float deltaAngle = (2 * _viewAngle) / _segments;

        for (int i = 0; i < _segments; i++)
        {
            float currentAngle = startAngle + deltaAngle * i;

            Vector3 direction = Quaternion.Euler(0, currentAngle, 0) * forward;
            Vector3 point = startingLine + direction * _viewRange;

            if (Physics.Raycast(startingRaycast, direction, out var hitInfo, _viewRange))
            {
                point = hitInfo.point - (startingRaycast - startingLine);
            }
            _lineRenderer.SetPosition(i + 1, point);
        }
    }

    public void SetColor(Color color)
    {
        _lineRenderer.startColor = color;
        _lineRenderer.endColor = color;
    }

    private void OnDrawGizmos()
    {
        if (_pov == null) return;

        Gizmos.color = Color.yellow;

        Vector3 origin = _pov.position;
        float step = (_viewAngle * 2) / _segments;

        for (int i = 0; i < _segments; i++)
        {
            float angle = -_viewAngle + step * i;
            Vector3 direction = Quaternion.Euler(0, angle, 0) * _pov.forward;

            Gizmos.DrawRay(origin, direction *  _viewRange);
        }
    }
}
