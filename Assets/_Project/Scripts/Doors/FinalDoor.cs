using System.Collections;
using System.Collections.Generic;
using Unity.AI.Navigation;
using UnityEngine;

public class FinalDoor : MonoBehaviour
{
    [SerializeField] private NavMeshSurface _navMeshSurface;

    Animator anim;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        //_navMeshSurface = GetComponentInParent<NavMeshSurface>();
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
        _navMeshSurface.UpdateNavMesh(_navMeshSurface.navMeshData);
    }
}
