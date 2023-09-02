using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSelect : MonoBehaviour
{
    public GameObject[] skins;
    public int SelectedCharacter;

    private void Awake()
    {
        SelectedCharacter = PlayerPrefs.GetInt("SelectedCharacter",0);
        foreach(GameObject player in skins)
            player.SetActive(false);

        skins[SelectedCharacter].SetActive(true);
    }

    public void ChangeNext()
    {
        skins[SelectedCharacter].SetActive(false);
        SelectedCharacter++;
        if(SelectedCharacter == skins.Length)
            SelectedCharacter = 0;
        
        skins[SelectedCharacter].SetActive(true);
        PlayerPrefs.SetInt("SelectedCharacter", SelectedCharacter);
    }

    public void ChangePrevious()
    {
        skins[SelectedCharacter].SetActive(false);
        SelectedCharacter--;
        if(SelectedCharacter == -1)
            SelectedCharacter = skins.Length -1;
        
        skins[SelectedCharacter].SetActive(true);
        PlayerPrefs.SetInt("SelectedCharacter", SelectedCharacter);
    }
}
