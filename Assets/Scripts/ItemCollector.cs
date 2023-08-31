using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollector : MonoBehaviour
{
    private int cherries = 0;

    public Text pointsText;

    public AudioSource collectSoundEffect;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Points"))
        {
            collectSoundEffect.Play();
            Destroy(collision.gameObject);
            cherries++;
            pointsText.text = "Points: " + cherries;
        }
    }
}
