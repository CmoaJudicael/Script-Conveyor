using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioClip SonMenu, SonGame;
    public AudioSource _audioSource;
    private void Awake()
    {
        DontDestroyOnLoad(this);
        

    }
    // Start is called before the first frame update
    void Start()
    {
        _audioSource = this.GetComponent<AudioSource>();
    }

    public void SonOnMenu()
    {
        _audioSource.clip = SonMenu;
        _audioSource.Play();
    }
    public void SonInGame()
    {
        _audioSource.clip = SonGame;
        _audioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
