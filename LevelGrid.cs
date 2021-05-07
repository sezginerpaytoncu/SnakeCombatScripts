using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGrid
{
    private int width;
    private int height;
    private Snake snake;

    public LevelGrid(int width, int height)
    {
        this.width = width;
        this.height = height;
    }
    public void Setup(Snake snake)
    {
        this.snake = snake;
    }
}
