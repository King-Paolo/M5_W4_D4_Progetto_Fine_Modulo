using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueKey : Keys
{
    [SerializeField] private SO_KeysItem _keyID;

    public static event Action OnBlueKeyEquipped;
    protected override void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;

        PlayerInventory inventory = other.GetComponentInParent<PlayerInventory>();

        if (inventory != null)
        {
            inventory.Keys.Add(_keyID);
        }

        OnBlueKeyEquipped?.Invoke();

        base.OnTriggerEnter(other);
    }
}
