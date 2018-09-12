using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {
    public static SoundManager Instance;
    public AudioClip GoodGemSound;
    public AudioClip BadGemSound;
    public AudioClip DeathSound;
    public AudioClip TapSound;
    static AudioSource _as;
    public static bool Muted = false;
    private void Awake()
    {
        Instance = this;
        _as = Camera.main.GetComponent<AudioSource>();
    }
    public void Mute()
    {
        Muted = !Muted;
        MusicPlayer.Instance.GetComponent<AudioSource>().volume = Muted ? 0 : 0.75f;
    }
    public static void PlaySound(AudioClip clip)
    {
        if (Muted) return;
        else _as.PlayOneShot(clip);
    }
}
