using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueDoor : Doors
{
    private void Update()
    {
        if (!_playerInRange || _inventory == null) return;

        if (_inventory.BlueKeyIsEquipped && Input.GetKeyDown(KeyCode.E))
        {
            OpenDoor();
            _inventory.BlueKeyIsEquipped = false;
        }
    }
}
