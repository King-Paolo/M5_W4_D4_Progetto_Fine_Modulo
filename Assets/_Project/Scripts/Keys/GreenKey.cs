using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenKey : Keys
{
    [SerializeField] private SO_KeysItem _keyID;

    public static event Action OnGreenKeyEquipped;
    protected override void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;

        PlayerInventory inventory = other.GetComponentInParent<PlayerInventory>();

        if (inventory != null)
        {
            inventory.Keys.Add(_keyID);
        }

        OnGreenKeyEquipped?.Invoke();

        base.OnTriggerEnter(other);
    }
}
