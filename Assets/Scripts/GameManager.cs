using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Cinemachine;

public class GameManager : MonoBehaviour
{
    public CinemachineVirtualCamera VCam;
    public GameObject[] playerPrefabs;
    int characterIndex;
    public static Vector2 checkPoint = new Vector2(-6, 2);

    public static int numberOfPoints = 0;
    public Text pointsText;

    private void Awake()
    {
        characterIndex = PlayerPrefs.GetInt("SelectedCharacter", 0);
        GameObject player = Instantiate(playerPrefabs[characterIndex], checkPoint, Quaternion.identity);
        VCam.m_Follow = player.transform;
    }

    // Update is called once per frame
    void Update()
    {
        pointsText.text = "Points: " + numberOfPoints;
    }
}
