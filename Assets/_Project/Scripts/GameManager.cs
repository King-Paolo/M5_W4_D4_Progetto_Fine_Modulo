using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private AudioClip backgroundMusic;

    private void Start()
    {
        AudioManager.Instance.PlayMusic(backgroundMusic);
    }
}
