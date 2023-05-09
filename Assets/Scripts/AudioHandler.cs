using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioHandler : MonoBehaviour
{
    public AudioSource JumpAudioSource;
    public AudioSource LandingAudioSource;
    public AudioSource DashAudioSource;
    public AudioSource AttackAudioSource;
    public AudioSource HitAudioSource;
    public AudioSource FrogAudioSource;
    public AudioSource CrocadileAudioSource;
    public AudioSource SplashAudioSource;

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
        //AttackAudioSource.Play();
        DashAudioSource.Play();
    }

    public void HitAudio()
    {
        HitAudioSource.Play();
    }

    public void FrogAudio()
    {
        FrogAudioSource.Play();
    }

    public void CrocadileAudio()
    {
        CrocadileAudioSource.Play();
    }

    public void SplashAudio()
    {
        SplashAudioSource.Play();
    }

}
