using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finnish : MonoBehaviour
{
    AudioSource finishSoundEffect;

    private bool levelCompleted = false;

    // Start is called before the first frame update
    void Start()
    {
        finishSoundEffect = GetComponent<AudioSource>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player") && !levelCompleted)
        {
            finishSoundEffect.Play();
            levelCompleted= true;
            Invoke("CompleteLevel", 2f);
        }
    }

    void CompleteLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +1);
    }
}
