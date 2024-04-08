using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField]
    private AudioSource musicSource;
    [SerializeField]
    private Sound[] songs, sounds;
    [SerializeField]
    private float soundVolume, musicVolume;

    // Plays a song from the song array from the musicSource under the supplied name
    public void PlaySong(string songName)
    {
        AudioClip song = Array.Find(songs, song => song.name.Equals(songName)).audioClip;
        musicSource.clip = song;
        musicSource.volume = musicVolume;
        musicSource.Play();
    }

    public void StopSong()
    {
        musicSource.Stop();
    }

    // Plays a sound from the specified source
    public void PlaySound(AudioSource source, string soundName)
    {
        AudioClip sound = Array.Find(sounds, sound => sound.name.Equals(soundName)).audioClip;
        source.volume = soundVolume;
        source.PlayOneShot(sound);
    }
}