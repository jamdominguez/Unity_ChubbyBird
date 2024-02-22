using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    public GameObject gameOverText;
    public Text scoreText;
    public bool isGameOver;
    public float scrollSpeed;
    public AudioClip gameOverMusic;
    public float waitTimeToRestart;

    private int score = 0;
    private AudioSource audio;
    private float gameOverTime;

    // Singleton
    public static GameController instance;

    void Awake() {
        if (instance == null) {
            instance = this;
            //DontDestroyOnLoad(this);
        } else {
            Destroy(gameObject);
        }
        audio = GetComponent<AudioSource>();
    }

    private void Update() {
        if (isGameOver && Input.GetMouseButtonDown(0) && LetRestart()) Restart();
    }

    public void ShowGameOver() {
        if (!isGameOver) {
            gameOverText.SetActive(true);
            isGameOver = true;
            audio.Stop();
            audio.clip = gameOverMusic;
            audio.loop = false;
            audio.Play();
            gameOverTime = Time.time;
        }
    }

    bool LetRestart() {
        return Time.time - gameOverTime > waitTimeToRestart;
    }

    void Restart() {
        isGameOver = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void AddPoints(int points) {
        score += points;
        scoreText.text = "Score: " + score;
    }

    private void OnDestroy() {
        if (instance == this) instance = null;
    }
}
