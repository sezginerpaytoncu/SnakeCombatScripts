﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snake : MonoBehaviour
{
    private Vector2Int gridMoveDirection;
    private Vector2Int gridPosition;
    private float gridMoveTimer;
    private float gridMoveTimerMax; //lower is faster
    private LevelGrid levelGrid;
    private Vector2 antiBug;
    private bool enableChangeDirection; // for preventing movement bug
    private int snakeBodySize;
    private List<Vector2Int> snakeMovePositionList;
    public GameObject snakeBody;
    private GameHandler gameHandler/* = new GameHandler()*/;
    private GameObject snakeBodyParts;
    private List<GameObject> snakeBodyPartList;
    private ScoreManager scoreManager;// = FindObjectOfType<ScoreManager>();
    private SceneManager sceneManager;
    private bool snakeDead;

    public void Setup(LevelGrid levelGrid)
    {
        this.levelGrid = levelGrid;
    }

   private void Awake()
    {
        snakeDead = false;
        gridMoveTimerMax =0.08f;
        gridPosition = new Vector2Int(10, 10);
        gridMoveTimer = gridMoveTimerMax;
        gridMoveDirection = new Vector2Int(1, 0);

        snakeMovePositionList = new List<Vector2Int>();
        snakeBodySize = 1;
        snakeBodyPartList = new List<GameObject>();
        scoreManager = FindObjectOfType<ScoreManager>();
        gameHandler = FindObjectOfType<GameHandler>();
    }

    private void Update()
    {
        snakeDead = gameHandler.SnakeStatus();
        if (snakeDead == false)
        {
            HandleInput();
            HandleGridMovement();
            MoveBodyParts();
        }
    }


    private void HandleInput()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow) && gridMoveDirection.y != -1 && antiBug!=gridPosition)
        {
            gridMoveDirection.x = 0;
            gridMoveDirection.y = 1;
            transform.rotation = Quaternion.Euler(0, 0, 0);
            antiBug.x = gridPosition.x;
            antiBug.y = gridPosition.y;
        }
        if (Input.GetKeyDown(KeyCode.DownArrow) && gridMoveDirection.y != 1 && antiBug != gridPosition)
        {
            gridMoveDirection.x = 0;
            gridMoveDirection.y = -1;
            transform.rotation = Quaternion.Euler(0, 0, 180);
            antiBug.x = gridPosition.x;
            antiBug.y = gridPosition.y;
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow) && gridMoveDirection.x != 1 && antiBug != gridPosition)
        {
            gridMoveDirection.x = -1;
            gridMoveDirection.y = 0;
            transform.rotation = Quaternion.Euler(0, 0, 90);
            antiBug.x = gridPosition.x;
            antiBug.y = gridPosition.y;
        }
        if (Input.GetKeyDown(KeyCode.RightArrow) && gridMoveDirection.x != -1 && antiBug != gridPosition)
        {
            gridMoveDirection.x = 1;
            gridMoveDirection.y = 0;
            transform.rotation = Quaternion.Euler(0, 0, -90);
            antiBug.x = gridPosition.x;
            antiBug.y = gridPosition.y;
        }
    }

    private void HandleGridMovement()
    {
        gridMoveTimer += Time.deltaTime;
        if (gridMoveTimer >= gridMoveTimerMax)
        {
            gridMoveTimer -= gridMoveTimerMax;
            //adding snake positions to the position list
            snakeMovePositionList.Insert(0, gridPosition);
            //for taking aproppriate number of position according to body size
            if(snakeMovePositionList.Count >= snakeBodySize + 1)
                snakeMovePositionList.RemoveAt(snakeMovePositionList.Count - 1);

            //snake head movement
            gridPosition += gridMoveDirection;
            transform.position = new Vector3(gridPosition.x, gridPosition.y);
        }
    }

    /*private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Border" || collision.tag == "Body")
        {
            sceneManager = FindObjectOfType<SceneManager>();
            sceneManager.GameOver();
        }
    }*/

    public void GrowUp()
    {
        snakeBodyParts = Instantiate(snakeBody, new Vector2(snakeMovePositionList[snakeBodySize - 1].x, snakeMovePositionList[snakeBodySize - 1].y), Quaternion.identity);
        snakeBodyPartList.Insert(snakeBodySize - 1, snakeBodyParts);
        snakeBodySize++;
        gridMoveTimerMax -= 0.001f;
        if (gridMoveTimerMax == 0) //prevent to reach zero
            gridMoveTimerMax = 0.001f;
        Debug.Log("TimerMax: " + gridMoveTimerMax);
        scoreManager.AddScore();
    }

    private void MoveBodyParts()
    {
        for(int i = 0; i < snakeBodySize-1; i++)
        {
            snakeBodyPartList[i].transform.position = new Vector3(snakeMovePositionList[i].x, snakeMovePositionList[i].y);
        }
    }
    public Vector2Int GetGridPosition()
    {
        return gridPosition;
    }

    public List<Vector2Int> GetBodyPositionList()
    {
        return snakeMovePositionList;
    }
}
