using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int lives, score;
    public TextMeshProUGUI scoreText, livesText;

    public bool gameOver;

    [SerializeField]
    GameObject gameOverPanel;
    
    void Start()
    {
        score = 0;
        lives = 3;
        scoreText.text = "Score: " + score.ToString();
        livesText.text = "Lives: " + lives.ToString();

        gameOverPanel.GetComponent<RectTransform>().localScale = Vector3.zero;
        gameOverPanel.GetComponent<CanvasGroup>().alpha = 0;
    }

    public void UpdateLives(int countLives)
    {
        lives += countLives;

        if (lives <= 0)
        {
            lives = 0;
            GameOver();
        }

        livesText.text = "Lives: " + lives.ToString();
    }

    public void updateScore(int _score)
    {
        score += _score;
        scoreText.text = "Score: " + score.ToString();
    }
    
    void GameOver()
    {
        gameOver = true;

        gameOverPanel.GetComponent<CanvasGroup>().DOFade(1, .5f);
        gameOverPanel.GetComponent<RectTransform>().DOScale(1, .5F);

    }

    public void Replay()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void Quit()
    {
        Application.Quit();
    }

    


}
