using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YellowDoor : Doors
{
    private void Update()
    {
        if (!_playerInRange || _inventory == null) return;

        if (_inventory.YellowKeyIsEquipped && Input.GetKeyDown(KeyCode.E))
        {
            OpenDoor();
            _inventory.YellowKeyIsEquipped = false;
        }
    }
}
