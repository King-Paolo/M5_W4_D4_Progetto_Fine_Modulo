using System.Collections;
using System.Collections.Generic;
using Unity.AI.Navigation;
using UnityEngine;

public class FinalDoor : MonoBehaviour
{
    Animator anim;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        Lever.OnLeverPulled += OpenDoor;
    }

    private void OnDisable()
    {
        Lever.OnLeverPulled -= OpenDoor;
    }

    public void OpenDoor()
    {
        anim.SetTrigger("Open");
    }
}
