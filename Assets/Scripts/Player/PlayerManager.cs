using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    //References
    public GameObject[] HealthUI;
    public GameObject PlayerCharacter;
    public Transform PlayerTransform;
    public GameObject GameOverMenu;
    public Button FirstButtonSelect;

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
        GameOverMenu.SetActive(false);
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
            HealthUI[0].SetActive(false);
            HealthUI[1].SetActive(false);
            HealthUI[2].SetActive(false);
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
        GameOverMenu.SetActive(true);
        FirstButtonSelect.Select();
        Time.timeScale = 0;
        SetMaxHealth();
        //button.Select();
    }

    public void RetryButton()
    {
        GameOverMenu.SetActive(false);
        SetMaxHealth();
        ResetToHardCheckpoint();
        Time.timeScale = 1;
    }

    public void RetryStartButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
    }

    public void QuitButton()
    {
        Application.Quit();
        Time.timeScale = 1;
    }
}
