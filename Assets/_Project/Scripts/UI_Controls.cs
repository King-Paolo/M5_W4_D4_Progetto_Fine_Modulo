using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Controls : MonoBehaviour
{
    [SerializeField] private GameObject _controlsMenu;

    private void Start()
    {
        MenuManager.Instance.ShowMenu(_controlsMenu, true);
    }

    private void OnTriggerExit(Collider other)
    {
        if (!other.CompareTag("Player")) return;

        MenuManager.Instance.ShowMenu(_controlsMenu, false);
    }
}
