using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Manager : MonoBehaviour {

    public GameObject player;
    public Text timerText;
    public Text healthText;
    private float timer;
    public int playerHealth;
    public GameObject gameUI;
    public GameObject scoreDisplay;
    public GameObject healthDisplay;
    public GameObject gameOverScreen;
    public Text currentTime;
    public Text bestTime;
    public bool canBeDamaged;
    private GameManager manager;
    private Score score;
    public SpriteRenderer human;
    public SpriteRenderer minecart;
    public Fire fire;
    public bool visible;
    private int currentHealth;
    public AudioSource[] audioSources;

    private void Awake()
    {
        visible = true;
        canBeDamaged = true;
        playerHealth = 3;
        manager = FindObjectOfType<GameManager>();
        score = FindObjectOfType<Score>();
        currentHealth = playerHealth;
        SetAudio();
    }

    private void Update()
    {
        timer += Time.deltaTime;
        string minutes = Mathf.Floor(timer / 60).ToString("00");
        string seconds = (timer % 60).ToString("00");
        timerText.text = minutes + ":" + seconds;
        healthText.text = playerHealth.ToString();
        if(manager != null)
        {
            if (playerHealth <= 0)
            {
                gameUI.SetActive(false);
                scoreDisplay.SetActive(false);
                healthDisplay.SetActive(false);
                gameOverScreen.SetActive(true);

                currentTime.text = timerText.text;
                score.currentScore = currentTime.text;

                if (score.CompareScore())
                    score.SaveScore();

                bestTime.text = score.bestScore;
                playerHealth = 3;

                manager.PauseGame();
            }

            if (playerHealth < currentHealth && !canBeDamaged)
            {
                fire.audioSource.PlayOneShot(fire.clips[1], 0.5f);
                Invoke("Invincible", 5);
                InvokeRepeating("Flash", 0.2f, 0.2f);
                currentHealth = playerHealth;
            }
        }
    }

    void Invincible()
    {
        canBeDamaged = true;
        CancelInvoke("Flash");
        visible = true;
        minecart.enabled = visible;
        human.enabled = visible;
    }

    void Flash()
    {
        visible = !visible;
        minecart.enabled = visible;
        human.enabled = visible;
    }

    void SetAudio()
    {
        foreach(AudioSource source in audioSources)
        {
            source.mute = manager.options.sfx;
        }
    }
}
