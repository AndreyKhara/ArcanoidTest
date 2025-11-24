using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using Zenject;

public class GameManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private GameObject gameOverUI;
    [SerializeField] private GameObject gameWinUI;
    [SerializeField] private AudioClip loseClip;
    [SerializeField] private AudioClip winClip;
    [SerializeField] private AudioSource audioSource;
    [Inject]
    private GameInputAction inputAction; 
    private int blockCount = 0;
    private int score = 0;

    private void Awake()
    {
        //AddScore(0);
        Time.timeScale = 0f;
        Debug.Log(blockCount);
    }
    public void AddBlock()
    {
        blockCount++;
        Debug.Log(blockCount);
    }
    private void DestroyBlock()
    {
        blockCount--;
        Debug.Log(blockCount);
        if (blockCount == 0)
        {
            EndGame(true);
        }
    }

    public void PlayGame()
    {
        Debug.Log("Play Game");
        Time.timeScale = 1.0f;
    }
    public void Restart()
    {
        Debug.Log("restart");
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(0);
    }

    public void Quit()
    {
        Debug.Log ("left the game");
        Application.Quit();
    }

    public void AddScore(int scoreAmount)
    {
        score += scoreAmount;
        DestroyBlock();
        scoreText.text = $"Your Score : {score}";
    }

    public void EndGame(bool win)
    {
        Time.timeScale = 0.0f;
        inputAction.Player.Disable();
        audioSource.loop = false;

        if (win)
        {
            gameWinUI.SetActive(true);
            audioSource.clip = winClip;
        }
        else
        {
            gameOverUI.SetActive(true);
            audioSource.clip = loseClip;
        }

        audioSource.Play();
    }
}
