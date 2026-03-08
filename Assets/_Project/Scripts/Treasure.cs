using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class Treasure : MonoBehaviour
{
    [SerializeField] private GameObject _victoryMenu;
    [SerializeField] private float _rotationSpeed;

    private void Start()
    {
        _victoryMenu.SetActive(false);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            MenuManager.Instance.VictoryMenu(_victoryMenu);
    }

    private void Update()
    {
        transform.Rotate(Vector3.up, _rotationSpeed *  Time.deltaTime);
    }
}
