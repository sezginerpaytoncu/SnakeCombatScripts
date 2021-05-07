using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameHandler : MonoBehaviour
{
    [SerializeField] 
    private Snake snake;
    public int GameWidth, GameHeight;
    private LevelGrid levelGrid;

    public GameObject foodGameObject;
    private Vector2Int foodGridPosition;
    private Vector2Int snakeGridPosition;
    private List<Vector2Int> snakeBodyPosition;
    private SceneManager sceneManager;
    private bool snakeDead;

    void Start()
    {
        //levelGrid = new LevelGrid(GameWidth, GameHeight);
        snakeBodyPosition = new List<Vector2Int>();
        sceneManager = FindObjectOfType<SceneManager>();

        snakeDead = false;
        //snake.Setup(levelGrid);
        SpawnFood(); 
    }

    private void Update()
    {
        snakeGridPosition = snake.GetGridPosition();
        snakeBodyPosition = snake.GetBodyPositionList();
        if (snakeDead==false)
            SnakeMoved(snakeGridPosition);
    }

    public void SpawnFood()
    {
        do
        {
            foodGridPosition = new Vector2Int(Random.Range(1, GameWidth - 1), Random.Range(1, GameHeight - 1));
        } while (foodGridPosition == snakeGridPosition);
        Instantiate(foodGameObject, new Vector2(foodGridPosition.x, foodGridPosition.y), Quaternion.identity);
    }
    
    public void SnakeMoved(Vector2Int snakeGridPosition)//Controls for eating food and death
    {
        if (snakeGridPosition == foodGridPosition)
        {
            Destroy(GameObject.FindWithTag("Food"));
            snake.GrowUp();
            SpawnFood();
        }
        //Controlling for eating body OR crashing to borders
        foreach (var item in snakeBodyPosition)
        {
            if (snakeGridPosition == item || snakeGridPosition.x == 0 || snakeGridPosition.x == GameWidth || snakeGridPosition.y == 0 || snakeGridPosition.y == GameHeight) 
            { 
                snakeDead = true;
                sceneManager.GameOver();
            }
        }
    }

    public bool SnakeStatus()
    {
        return snakeDead;
    }


}
