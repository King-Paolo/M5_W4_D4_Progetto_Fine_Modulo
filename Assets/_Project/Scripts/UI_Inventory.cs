using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Inventory : MonoBehaviour
{
    [SerializeField] private GameObject _greenKeyIcon;
    [SerializeField] private GameObject _yellowKeyIcon;
    [SerializeField] private GameObject _blueKeyIcon;

    private void Start()
    {
        _greenKeyIcon.SetActive(false);
        _yellowKeyIcon.SetActive(false);
        _blueKeyIcon.SetActive(false);
    }

    private void OnEnable()
    {
        GreenKey.OnGreenKeyEquipped += ShowGreenKeyIcon;
        YellowKey.OnYellowKeyEquipped += ShowYellowKeyIcon;
        BlueKey.OnBlueKeyEquipped += ShowBlueKeyIcon;
    }

    private void OnDisable()
    {
        GreenKey.OnGreenKeyEquipped -= ShowGreenKeyIcon;
        YellowKey.OnYellowKeyEquipped -= ShowYellowKeyIcon;
        BlueKey.OnBlueKeyEquipped -= ShowBlueKeyIcon;
    }

    private void ShowGreenKeyIcon()
    {
        _greenKeyIcon.SetActive(true);
    }

    private void ShowYellowKeyIcon()
    {
        _yellowKeyIcon.SetActive(true);
    }

    private void ShowBlueKeyIcon()
    {
        _blueKeyIcon.SetActive(true);
    }
}
