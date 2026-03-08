using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]

[CreateAssetMenu(fileName = "Key", menuName = "Inventory/Key")]
public class SO_KeysItem : ScriptableObject
{
    public string ItemName;
    public string Description;
    public Sprite ItemSprite;
    public int ItemID;

}
