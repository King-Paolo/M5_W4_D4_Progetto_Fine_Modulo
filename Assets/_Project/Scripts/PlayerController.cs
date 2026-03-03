using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{
    [SerializeField] NavMeshAgent _agent;

    private Camera _cam;
    private float _currentSpeed = 3.5f;
    private float _escapeSpeed = 7;

    private void Start()
    {
        _cam = Camera.main;
        _agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            _agent.speed = _escapeSpeed;
        }
        else
        {
            _agent.speed = _currentSpeed;
        }


        if (Input.GetMouseButtonDown(1))
        {
            Ray ray = _cam.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                _agent.SetDestination(hit.point);
            }
        }
    }
}
