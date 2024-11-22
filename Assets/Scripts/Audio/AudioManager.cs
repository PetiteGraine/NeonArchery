using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("---- Audio Source ----")]
    [SerializeField] private AudioSource _musicSource;
    [SerializeField] private AudioSource _soundEffectSource;

    [Header("---- Audio Clip ----")]
    public List<AudioClip> Musics = new List<AudioClip>();
    public AudioClip ArrowImpact;
    public AudioClip ArrowLaunch;
    public AudioClip DrawBow;

    private void Start()
    {
        if (PlayerPrefs.HasKey("musicIndex"))
            _musicSource.clip = Musics[PlayerPrefs.GetInt("musicIndex")];
        else _musicSource.clip = Musics[0];

        _musicSource.Play();
    }

    public void PlaySFX(AudioClip clip)
    {
        _soundEffectSource.PlayOneShot(clip);
    }

    public void ChangeMusic(int index)
    {
        _musicSource.clip = Musics[index];
        PlayerPrefs.SetInt("musicIndex", index);
        _musicSource.Play();
    }
}
