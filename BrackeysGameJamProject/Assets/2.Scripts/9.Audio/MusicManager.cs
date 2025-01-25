using System;
using System.Collections;
using System.Collections.Generic;
using FMODUnity;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public StudioEventEmitter levelMusic;
    public static MusicManager instance { get; private set; }

    private void Awake()
    {
        levelMusic = GetComponent<FMODUnity.StudioEventEmitter>();
    }

    private void Start()
    {
        levelMusic.Play();
        DayMusic(true);
        IsPaused(false);
    }

    private void OnDestroy() => levelMusic.Stop();

    public void DayMusic(bool isDay) // false = Night, true = Day
    {
        if (!isDay)
        {
            levelMusic.SetParameter("dayMoment", 0);
        }
        else levelMusic.SetParameter("dayMoment", 1);
    }
    public void IsPaused(bool isPaused)
    {
        if (!isPaused)
        {
            levelMusic.SetParameter("isPaused", 0);
        }
        else
        {
            levelMusic.SetParameter("isPaused", 1);
        }
    }
    public void OnGameStateChanged(int gameState)
    {
        switch (gameState)
        {
            case 0: // Normal
                levelMusic.SetParameter("gameState", 0);
                break;
            case 1: // Ganar
                levelMusic.SetParameter("gameState", 1);
                break;
            case 2: // Perder
                levelMusic.SetParameter("gameState", 2);
                break;
            default:
                throw new ArgumentException("ERROR. OnGameStateChanged() solo debe tener como parámetro los valores 0, 1 o 2.");

        }
    }
}
