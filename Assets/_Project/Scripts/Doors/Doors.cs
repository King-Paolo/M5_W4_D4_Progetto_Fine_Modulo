using System.Collections;
using System.Collections.Generic;
using Unity.AI.Navigation;
using UnityEngine;

public class Doors : MonoBehaviour
{
    [SerializeField] private NavMeshSurface _navMeshSurface;

    private Animator _anim;
    protected bool _playerInRange;
    protected PlayerInventory _inventory;

    private void Awake()
    {
        _anim = GetComponent<Animator>();
        //_navMeshSurface = GetComponentInParent<NavMeshSurface>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;

        _inventory = other.GetComponentInParent<PlayerInventory>();
        _playerInRange = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (!other.CompareTag("Player")) return;

        _playerInRange = false;
        _inventory = null;
    }

    public void OpenDoor()
    {
        _anim.SetTrigger("Open");
        _navMeshSurface.UpdateNavMesh(_navMeshSurface.navMeshData);
    }
}
