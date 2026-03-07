using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenDoor : Doors
{
    private void Update()
    {
        if (!_playerInRange || _inventory == null) return;

        if (_inventory.GreenKeyIsEquipped && Input.GetKeyDown(KeyCode.E))
        {
            OpenDoor();
            _inventory.GreenKeyIsEquipped = false;
        }
    }
}
