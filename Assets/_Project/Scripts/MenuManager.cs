using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public static MenuManager Instance;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
    }

    public void ShowMenu(GameObject menu, bool state)
    {
        if (menu != null)
        {
            menu.SetActive(state);
        }
    }

    public void VictoryMenu(GameObject menu)
    {
        if(menu != null)
        {
            menu.SetActive(true);
        }
    }

    public void PauseMenu(GameObject menu, bool state)
    {
        if (menu != null)
        {
            menu.SetActive(state);
        }
    }

    public void GameOverMenu(GameObject menu)
    {
        if (menu != null)
        {
            menu.SetActive(true);
        }
    }
}
