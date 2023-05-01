using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioHandler : MonoBehaviour
{
    public AudioSource JumpAudioSource;
    public AudioSource LandingAudioSource;
    public AudioSource DashAudioSource;
    public AudioSource AttackAudioSource;

    public void JumpAudio()
    {
        JumpAudioSource.Play();
    }

    public void LandingAudio()
    {
        LandingAudioSource.Play();
    }

    public void DashAudio()
    {
        DashAudioSource.Play();
    }

    public void AttackAudio()
    {
        AttackAudioSource.Play();
    }
}
