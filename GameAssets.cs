using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameAssets : MonoBehaviour
{
    public static GameAssets instanceSprite;

    private void Awake()
    {
        instanceSprite = this;
    }
    public Sprite snakeHeadSprite;
    public Sprite foodSprite;
   
}
