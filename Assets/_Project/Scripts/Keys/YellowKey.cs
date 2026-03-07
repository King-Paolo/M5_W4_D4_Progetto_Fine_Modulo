using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YellowKey : Keys
{
    public static event Action OnYellowKeyEquipped;
    protected override void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;

        PlayerInventory inventory = other.GetComponentInParent<PlayerInventory>();

        if (inventory != null)
        {
            inventory.YellowKeyIsEquipped = true;
        }

        OnYellowKeyEquipped?.Invoke();

        base.OnTriggerEnter(other);
    }
}
