using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class AudioManager : MonoBehaviour
{
    #region Singleton

    public static AudioManager Instance;

    private void Awake()
    {
        if (Instance != null)
        {
            Debug.Log("More than one AudioManager in scene!");
            Destroy(this.gameObject);
            return;
        }

        Instance = this;

        DontDestroyOnLoad(this.gameObject);
    }

    #endregion

    public List<AudioSource> audioSources;
    public float masterVolume = 1.0f;

    private Dictionary<string, SoundInfo> _soundDictionary;
    private readonly List<AudioSource> _audioSources = new List<AudioSource>(); //Currently playing audio sources
    [SerializeField] private GameObject volumeSlider = null;
    private Slider _slider;
    
    private void Start()
    {
        _soundDictionary = new Dictionary<string, SoundInfo>();
        _slider = volumeSlider.GetComponent<Slider>();
        foreach (var audioSource in audioSources)
        {
            var soundName = audioSource.name;
            var soundInfo = new SoundInfo();
            soundInfo.InitialiseSound(soundName);
            _soundDictionary.Add(soundName,
                soundInfo);
        }
    }

    public void PlaySound(string soundName)
    {
        _soundDictionary[soundName].Reset();
        PlaySound(_soundDictionary[soundName].AudioSource);
    }

    public void StopSound(string soundName)
    {
        _soundDictionary[soundName]
            .AudioSource.Stop();
    }

    public void OnVolumeAdjusted()
    {
        masterVolume = _slider.value;
    }
    

    private void PlaySound(AudioSource audioSource) //Only play sound if it's not already playing
    {
        audioSource.pitch *= (Random.value + 0.5f); //Pitch is default multiplied by random value between 0.5 and 1.5
        audioSource.volume *= masterVolume;
        var shouldPlaySound = true;
        foreach (var aS in _audioSources.Where(aS => aS.clip.name == audioSource.clip.name))
        {
            //Check if already being played
            if (aS.isPlaying)
            {
                shouldPlaySound = false;
                break; //Don't spam audio source with same sound
            }

            //Remove previous audio source
            _audioSources.Remove(aS);
            break;
        }

        if (!shouldPlaySound)
            return;
        //Play audio clip from audio source and add it to audio sources list
        audioSource.Play();
        _audioSources.Add(audioSource);
    }
}