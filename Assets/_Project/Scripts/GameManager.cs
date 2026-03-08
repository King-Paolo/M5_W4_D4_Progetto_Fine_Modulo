using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [SerializeField] private AudioClip _backgroundMusic;
    [SerializeField] private AudioClip _gameOverMusic;
    [SerializeField] private AudioClip _victoryMusic;
    [SerializeField] private GameObject _pauseMenu;
    [SerializeField] private GameObject _gameOverMenu;
    [SerializeField] private GameObject _victoryMenu;

    private bool _isPaused;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
    }

    private void Start()
    {
        AudioManager.Instance.PlayMusic(_backgroundMusic);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (_isPaused) Resume();
            else Pause();
        }
    }

    public void PlayGame()
    {

        SceneManager.LoadScene(1);
        Time.timeScale = 1;
    }

    public void MainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }

    public void Pause()
    {
        _isPaused = true;
        Time.timeScale = 0f;
        MenuManager.Instance.PauseMenu(_pauseMenu, true);
    }

    public void Resume()
    {
        _isPaused = false;
        Time.timeScale = 1f;
        MenuManager.Instance.PauseMenu(_pauseMenu, false);
    }

    public void GameOver()
    {
        MenuManager.Instance.GameOverMenu(_gameOverMenu);
        AudioManager.Instance.PlayMusic(_gameOverMusic);
        Time.timeScale = 0;
    }

    public void Victory()
    {
        MenuManager.Instance.VictoryMenu(_victoryMenu);
        AudioManager.Instance.PlayMusic(_victoryMusic);
        Time.timeScale = 0;
    }
}
