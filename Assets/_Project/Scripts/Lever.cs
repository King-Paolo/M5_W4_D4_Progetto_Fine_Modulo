using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : MonoBehaviour
{
    [SerializeField] GameObject _interactMenu;

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
        if (!other.CompareTag("Player") || _isPlayerInRange) return;

        _isPlayerInRange = true;

        if (!_isLeverPulled)
        {
            MenuManager.Instance.ShowMenu(_interactMenu, true);
        }

    }
    private void OnTriggerExit(Collider other)
    {
        if (!other.CompareTag("Player")) return;

        _isPlayerInRange = false;
        MenuManager.Instance.ShowMenu(_interactMenu, false);
    }

    private void Update()
    {
        if (_isLeverPulled || !_isPlayerInRange) return;

        if (Input.GetKeyDown(KeyCode.E))
        {
            _anim.SetTrigger("Pull");
            OnLeverPulled?.Invoke();
            _isLeverPulled = true;
            MenuManager.Instance.ShowMenu(_interactMenu, false);
        }
    }
}
