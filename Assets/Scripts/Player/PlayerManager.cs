using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    //References
    public GameObject[] HealthUI;
    public GameObject PlayerCharacter;
    public Transform PlayerTransform;

    //Variables
    public int MaxHealth;
    public int CurrentHealth;
    public Vector2 LastSoftCheckpoint;
    public Vector2 LastHardCheckpoint;
    public float InvulnerabilityTimer;
    public float InvulnerabilityTimerMax;

    void Start()
    {
        CurrentHealth = MaxHealth;
    }

    void Update()
    {
        InvulnerabilityTimer -= Time.deltaTime;

        if (CurrentHealth == 3)
        {
            HealthUI[0].SetActive(true);
            HealthUI[1].SetActive(true);
            HealthUI[2].SetActive(true);
        }
        else if (CurrentHealth == 2)
        {
            HealthUI[0].SetActive(true);
            HealthUI[1].SetActive(true);
            HealthUI[2].SetActive(false);
        }
        else if (CurrentHealth == 1)
        {
            HealthUI[0].SetActive(true);
            HealthUI[1].SetActive(false);
            HealthUI[2].SetActive(false);
        }
        else 
        { 
            GameOver(); 
        }
    }

    void ResetToSoftCheckpoint()
    {
        PlayerTransform.position = LastSoftCheckpoint;
    }

    void ResetToHardCheckpoint()
    {
        PlayerTransform.position = LastHardCheckpoint;
    }

    public void RecoverableDamage()
    {
        if(InvulnerabilityTimer < 0)
        {
            CurrentHealth -= 1;
        }
        InvulnerabilityTimer = InvulnerabilityTimerMax;
    }

    public void NonRecoverableDamage()
    {
        if (InvulnerabilityTimer < 0)
        {
            CurrentHealth -= 1;
            ResetToSoftCheckpoint();
        }
        InvulnerabilityTimer = InvulnerabilityTimerMax;
    }

    void SetMaxHealth()
    {
        CurrentHealth = MaxHealth;
    }

    void GameOver()
    {
        //RETRY SCREEN SHIT GOES HERE
        SetMaxHealth();
        ResetToHardCheckpoint();
    }
}
