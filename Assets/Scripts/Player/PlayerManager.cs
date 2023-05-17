using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    //References
    public SpriteRenderer[] HealthUI;
    public GameObject PlayerCharacter;
    public Transform PlayerTransform;
    public GameObject GameOverMenu;
    public Button FirstButtonSelect;
    public CheckpointData CheckpointData;

    //Variables
    public int MaxHealth;
    public int CurrentHealth;
    public Vector2 LastSoftCheckpoint;
    public Vector2 LastHardCheckpoint;
    public float InvulnerabilityTimer;
    public float InvulnerabilityTimerMax;
    public Sprite ActiveHeart;
    public Sprite DeactiveHeart;

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
            HealthUI[0].sprite = ActiveHeart;
            HealthUI[1].sprite = ActiveHeart;
            HealthUI[2].sprite = ActiveHeart;
        }
        else if (CurrentHealth == 2)
        {
            HealthUI[0].sprite = ActiveHeart;
            HealthUI[1].sprite = ActiveHeart;
            HealthUI[2].sprite = DeactiveHeart;
        }
        else if (CurrentHealth == 1)
        {
            HealthUI[0].sprite = ActiveHeart;
            HealthUI[1].sprite = DeactiveHeart;
            HealthUI[2].sprite = DeactiveHeart;
        }
        else 
        {
            HealthUI[0].sprite = DeactiveHeart;
            HealthUI[1].sprite = DeactiveHeart;
            HealthUI[2].sprite = DeactiveHeart;
            GameOver(); 
        }
    }

    void ResetToSoftCheckpoint()
    {
        PlayerTransform.position = LastSoftCheckpoint;
    }

    void ResetToHardCheckpoint()
    {
        //PlayerTransform.position = CheckpointData.HardCheckpointLocation;
        CheckpointData.HardCheckpointLocation = LastHardCheckpoint;
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
        ResetToHardCheckpoint();
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void RetryStartButton()
    {
        CheckpointData.HardCheckpointLocation = new Vector2(-7.06f, 2.49f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
    }

    public void QuitButton()
    {
        Application.Quit();
        Time.timeScale = 1;
    }
}
