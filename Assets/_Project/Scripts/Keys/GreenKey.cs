using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenKey : Keys
{
    public static event Action OnGreenKeyEquipped;
    protected override void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;

        PlayerInventory inventory = other.GetComponentInParent<PlayerInventory>();

        if (inventory != null)
        {
            inventory.GreenKeyIsEquipped = true;
        }

        OnGreenKeyEquipped?.Invoke();

        base.OnTriggerEnter(other);
    }
}
