using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameStatus : MonoBehaviour
{
    [Range(0.1f, 10f)] [SerializeField] float gameSpeed = 1f;
    [SerializeField] int pointsPerBlock = 10; 
    [SerializeField] int currentScore = 0;
    [SerializeField] TextMeshProUGUI scoreText; // scoreText = Game Score
    [SerializeField] bool isAutoPlayEnabled;

    // Start is called before the first frame update

    private void Awake()
    {
        int gameStatusCount = FindObjectsOfType<GameStatus>().Length; // Stores the number of gameStatus object.
        if(gameStatusCount > 1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject); // Don't Destroy when loaded in future.
        }
    }


    void Start()
    {
        scoreText.text = currentScore.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        Time.timeScale = gameSpeed;
    }

    public void ScoreUpdate()
    {
        currentScore = currentScore + pointsPerBlock;
        scoreText.text = currentScore.ToString();
    }

    public void GameReset()
    {
        Destroy(gameObject);
    }

    public bool IsAutoPlayEnabled()
    {
        return isAutoPlayEnabled;
    }
}
