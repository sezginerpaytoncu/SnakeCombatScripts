using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameHandler2 : MonoBehaviour
{
    [SerializeField]
    private Snake3 snake3;
    [SerializeField]
    private Snake2 snake2;
    public int GameWidth, GameHeight;
    private LevelGrid levelGrid;

    public GameObject foodGameObject;
    private Vector2Int foodGridPosition;
    private Vector2Int snake3GridPosition;
    private List<Vector2Int> snake3BodyPosition;
    private Vector2Int snake2GridPosition;
    private List<Vector2Int> snake2BodyPosition;
    private SceneManager sceneManager;
    private bool snake3Dead, snake2Dead;
    private ScoreManager2 scoreManager2;

    void Start()
    {
        snake3BodyPosition = new List<Vector2Int>();
        snake2BodyPosition = new List<Vector2Int>();
        sceneManager = FindObjectOfType<SceneManager>();
        scoreManager2 = FindObjectOfType<ScoreManager2>();

        snake3Dead = false;
        snake2Dead = false;
        SpawnFood();
    }

    private void Update()
    {
        snake3GridPosition = snake3.GetGridPosition();
        snake3BodyPosition = snake3.GetBodyPositionList();
        snake2GridPosition = snake2.GetGridPosition();
        snake2BodyPosition = snake2.GetBodyPositionList();
        if (snake3Dead == false && snake2Dead == false)
        {
            Snake3Moved(snake3GridPosition);
            Snake2Moved(snake2GridPosition);
        }

    }

    public void SpawnFood()
    {
        do
        {
            foodGridPosition = new Vector2Int(Random.Range(1, GameWidth - 1), Random.Range(1, GameHeight - 1));
        } while (foodGridPosition == snake2GridPosition || foodGridPosition == snake3GridPosition);
        Instantiate(foodGameObject, new Vector2(foodGridPosition.x, foodGridPosition.y), Quaternion.identity);
    }

    public void Snake3Moved(Vector2Int snake3GridPosition)//Controls for eating food and death
    {
        if (snake3GridPosition == foodGridPosition)
        {
            Destroy(GameObject.FindWithTag("Food"));
            snake3.GrowUp();
            SpawnFood();
        }
        //Controlling for eating body OR crashing to borders
        foreach (var item in snake3BodyPosition)
        {
            if (snake3GridPosition == item || snake3GridPosition.x == 0 || snake3GridPosition.x == GameWidth || snake3GridPosition.y == 0 || snake3GridPosition.y == GameHeight)
            {
                snake3Dead = true;
                scoreManager2.WriteFinalScores(snake2Dead, snake3Dead);
                sceneManager.GameOver2();
            }
            if (snake2GridPosition == item)
            {
                snake2Dead = true;
                scoreManager2.WriteFinalScores(snake2Dead, snake3Dead);
                sceneManager.GameOver2();
            }
        }
    }

    public void Snake2Moved(Vector2Int snake2GridPosition)//Controls for eating food and death
    {
        if (snake2GridPosition == foodGridPosition)
        {
            Destroy(GameObject.FindWithTag("Food"));
            snake2.GrowUp();
            SpawnFood();
        }
        //Controlling for eating body OR crashing to borders
        foreach (var item in snake2BodyPosition)
        {
            if (snake2GridPosition == item || snake2GridPosition.x == 0 || snake2GridPosition.x == GameWidth || snake2GridPosition.y == 0 || snake2GridPosition.y == GameHeight)
            {
                snake2Dead = true;
                scoreManager2.WriteFinalScores(snake2Dead, snake3Dead);
                sceneManager.GameOver2();
            }
            if (snake3GridPosition == item)
            {
                snake3Dead = true;
                scoreManager2.WriteFinalScores(snake2Dead, snake3Dead);
                sceneManager.GameOver2();
            }
        }
    }

    public bool Snake3Status()
    {
        return snake3Dead;
    }
    public bool Snake2Status()
    {
        return snake2Dead;
    }

}
