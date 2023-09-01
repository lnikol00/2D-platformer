using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finnish : MonoBehaviour
{
    AudioSource finishSoundEffect;

    // Start is called before the first frame update
    void Start()
    {
        finishSoundEffect = GetComponent<AudioSource>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            finishSoundEffect.Play();
            // CompleteLevel();
        }
    }

    // void CompleteLevel()
    // {

    // }
}
