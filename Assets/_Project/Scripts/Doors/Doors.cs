using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doors : MonoBehaviour
{
    [SerializeField] private int _keyIDNeeded;

    private Animator _anim;
    private bool _doorIsOpen;

    private void Awake()
    {
        _anim = GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player") || _doorIsOpen) return;

        PlayerInventory inventory = other.GetComponentInParent<PlayerInventory>();

        OpenDoor(inventory);
    }

    private void OpenDoor(PlayerInventory inventory)
    {
        if (inventory == null) return;

        var key = inventory.Keys.Find(t => t.ItemID == _keyIDNeeded);

        if (key != null)
        {
            _anim.SetTrigger("Open");
            _doorIsOpen = true;
            inventory.Keys.Remove(key);
        }
        else
            return;
    }
}
