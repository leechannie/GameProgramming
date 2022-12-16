using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip audioEnd;
    public AudioClip audioMove;
    public AudioClip audioSolve;
    // Start is called before the first frame update
    void Start()
    {
        this.audioSource = GetComponent<AudioSource>();
        audioSource.Play();
    }
    public void PlaySound(string situation){
        switch (situation)
        {
            case"MOVE":
                audioSource.clip = audioMove;
                break;
            case"SOLVE":
                audioSource.clip = audioSolve;
                break;
            case"END":
                audioSource.clip = audioEnd;
                break;
        }
        audioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
