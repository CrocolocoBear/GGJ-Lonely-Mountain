using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class StartMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject startMenuUI;
    public GameObject CreditUI;
    public GameObject gameEndUI;
    public GameObject pauseUI;
    public AudioSource music, music2;
    public bool musicOn = true;
    public bool masterOn = true;
    [SerializeField] public PlayerActions playerActions;

    private void Awake()
    {
        playerActions = new PlayerActions();
        StartPause();
    }

    private void Start()
    {

    }

    private void OnEnable()
    {
        playerActions.PlayerMap.Enable();
    }

    private void OnDisable()
    {
        playerActions.PlayerMap.Disable();
    }

    private void Update()
    {
        if (GameIsPaused)
        {
            music.Pause();
            music2.Pause();
        }
        else
        {
            music.UnPause();
            music2.UnPause();
        }
        playerActions.PlayerMap.Pause.performed += _ => PauseGame();
    }


    public void PauseGame()
    {
        if (pauseUI.activeInHierarchy)
        {
            Unpause();
            
        }
        else if (!pauseUI.activeInHierarchy)
        {
            Pausegame();
        }
    }

    public void StartGame()
    {
        startMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }
    
    void StartPause()
    {
        startMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void Unpause()
    {
        pauseUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    void Pausegame()
    {
        pauseUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void EndPause()
    {
        gameEndUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void QuitGame()
    {
        Debug.Log("Quitting Game...");
        Application.Quit();
    }
}
