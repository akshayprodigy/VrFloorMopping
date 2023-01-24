using System;
using UnityEngine;

public class IntroAudioManager : Singleton<IntroAudioManager>
{
    AudioSource audioSource;
    [SerializeField]
    AudioClip[] audioClips;
    //public Action OnAudioEnd;
    int currentAudioSerialNumber = -1;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    public void PlayNextAudioFile()
    {
        currentAudioSerialNumber++;
        if (currentAudioSerialNumber < audioClips.Length)
        {
            audioSource.clip = audioClips[currentAudioSerialNumber];
            audioSource.Play();
            Invoke("AudioEnd", (audioSource.clip.length + 0.5f));
        }
       
        
    }

    public void AudioEnd()
    {
        IntroSceneManager.instance.OnAudioComplete();
        //OnAudioEnd?.Invoke();
    }
}
