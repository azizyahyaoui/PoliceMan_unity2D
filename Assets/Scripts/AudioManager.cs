using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    [SerializeField]
    AudioClip[] audioClips;

    [SerializeField]
    AudioSource audioSource;

    [SerializeField]
    AudioMixerGroup soundEffectMixer;


    private int musicIndex = 0;

    public static AudioManager instance;



    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("AudioManager");
            return;
        }

        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        audioSource.clip = audioClips[0];
        audioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if(!audioSource.isPlaying)
        {
            PlayNextSong();
        }
        
    }

    private void PlayNextSong()
    {
        musicIndex = (musicIndex + 1) % audioClips.Length;
        audioSource.clip = audioClips[musicIndex];
        audioSource.Play();
    }

    public AudioSource PlaySoundAt(AudioClip clip,Vector3 pos)
    {
        GameObject TempGO = new GameObject("TempAudio");
        TempGO.transform.position = pos;
        AudioSource audioSource = TempGO.AddComponent<AudioSource>();
        audioSource.clip = clip;
        audioSource.outputAudioMixerGroup = soundEffectMixer;
        audioSource.Play();
        Destroy(TempGO, clip.length);
        return audioSource;
    }
}
