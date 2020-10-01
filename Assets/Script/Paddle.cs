using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    [SerializeField] float screenWidth = 16f;
    [SerializeField] float min_X=1f, max_X=15f;

    GameStatus gameStatus;
    Ball ball;
    void Start()
    {
        gameStatus = FindObjectOfType<GameStatus>();
        ball = FindObjectOfType<Ball>();
    }
    

    // Update is called once per frame
    void Update()
    {             
        Vector2 paddlePos = new Vector2(transform.position.x, transform.position.y); // transform.position.x is the starting position of paddle in x axis. Same for y axis.  
        paddlePos.x = Mathf.Clamp(GetXPos(), min_X, max_X);//Mathf.Clamp limits the mousePosInUnits between min and max.
        transform.position = paddlePos;
    }

    private float GetXPos()
    {
        if(gameStatus.IsAutoPlayEnabled())
        {
            return ball.transform.position.x;
        }
        else
        {
            return Input.mousePosition.x / Screen.width * screenWidth;
        }
    }
}
