using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : MonoBehaviour
{
    public static event Action OnLeverPulled;

    private Animator _anim;
    private bool _isPlayerInRange;
    private bool _isLeverPulled;

    private void Awake()
    {
        _anim = GetComponentInChildren<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _isPlayerInRange = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _isPlayerInRange = false;
        }
    }

    private void Update()
    {
        if (_isLeverPulled) return;

        if (_isPlayerInRange && Input.GetKeyDown(KeyCode.E))
        {
            _anim.SetTrigger("Pull");
            OnLeverPulled?.Invoke();
            _isLeverPulled = true;
        }
    }
}
