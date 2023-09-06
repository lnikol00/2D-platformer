using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Cinemachine;

public class GameManager : MonoBehaviour
{
    public CinemachineVirtualCamera VCam;
    public GameObject[] playerPrefabs;
    int characterIndex;
    public static Vector2 checkPoint = new Vector2(-6, 2);

    public static bool IsGamePaused;
    public GameObject PauseMenuUI;
    public AudioSource playingBackgroungMusic;

    public static int numberOfPoints = 0;
    public Text pointsText;

    private void Start()
    {
        Time.timeScale = 1;
    }

    private void Awake()
    {
        characterIndex = PlayerPrefs.GetInt("SelectedCharacter", 0);
        GameObject player = Instantiate(playerPrefabs[characterIndex], checkPoint, Quaternion.identity);
        VCam.m_Follow = player.transform;
        PauseMenuUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        pointsText.text = "Points: " + numberOfPoints;

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseMenuToggle();
        }
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
        IsGamePaused = false;
    }

    public void ContinuePlaying()
    {
        IsGamePaused = false;
        PauseMenuUI.SetActive(false);
        if (PlayerPrefs.GetInt("sounds", 1) == 1)
        {
                playingBackgroungMusic.UnPause();
        }
        Time.timeScale = 1;
    }

    public void PauseMenuToggle()
    {
        if (!PauseMenuUI.activeSelf)
        {
            IsGamePaused = true;
            Time.timeScale = 0;
            playingBackgroungMusic.Pause();
            PauseMenuUI.SetActive(true);
        }
        else
        {
            IsGamePaused = false;
            PauseMenuUI.SetActive(false);
            if (PlayerPrefs.GetInt("sounds", 1) == 1)
            {
                playingBackgroungMusic.UnPause();
            }
            Time.timeScale = 1;
        }
    }
}
