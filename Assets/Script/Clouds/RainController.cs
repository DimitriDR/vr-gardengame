using System;
using UnityEngine;
using UnityEngine.UI;

public class RainController : MonoBehaviour
{
    public static RainController instance;
    public ParticleSystem rainParticleSystem;
    public AudioSource heavyRainAudio;
    public AudioSource gentleRainAudio;

    public enum Season
    {
        Summer,
        Winter,
        Autumn,
        Spring
    }


    private bool isRaining = false;

    public void Start()
    {
    }

    public void AdjustRainBasedOnSeason(Season currentSeason)
    {
        switch(currentSeason)
        {
            case Season.Summer:
                StopRain();
                SetRainStyle(NoRainStyle(), 0f);
                StopAllAudio();
                break;
            case Season.Winter:
                isRaining = true;
                SetRainStyle(HeavyRainStyle(), FastRainStyle());
                PlayAudio(heavyRainAudio);
                break;
            case Season.Autumn:
                isRaining = true;
                SetRainStyle(NormalRainStyle(), SlowRainStyle());
                PlayAudio(gentleRainAudio);
                break;
            case Season.Spring:
                isRaining = true;
                SetRainStyle(NormalRainStyle(), SlowRainStyle());
                PlayAudio(gentleRainAudio);
                break;


        }
    }
    void StopRain()
    {
        isRaining = false;
        SetRainStyle(NoRainStyle(), 0f);
        StopAllAudio();
    }

    void SetRainStyle(float density, float speed)
    {
        var mainModule = rainParticleSystem.main;
        var emissionModule = rainParticleSystem.emission;

        mainModule.maxParticles = (int)density;
        mainModule.simulationSpeed = speed;
        emissionModule.rateOverTime = density;

        rainParticleSystem.gameObject.SetActive(isRaining);
    }

    void PlayAudio(AudioSource audioSource)
    {
        if (audioSource != null && !audioSource.isPlaying)
        {
            audioSource.Play();
        }
    }

    public void PlayRainHeavy()
    {
        heavyRainAudio.Play();
    }
    public void StopAllAudio()
    {
        if (heavyRainAudio != null && heavyRainAudio.isPlaying)
        {
            heavyRainAudio.Stop();
        }

        if (gentleRainAudio != null && gentleRainAudio.isPlaying)
        {
            gentleRainAudio.Stop();
        }
    }

    float HeavyRainStyle() => 1500f;
    float NormalRainStyle() => 20;
    float FastRainStyle() => 1500f;
    float SlowRainStyle() => 20;
    float NoRainStyle() => 0f;

}
