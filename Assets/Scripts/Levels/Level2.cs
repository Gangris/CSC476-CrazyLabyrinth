using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level2 : Level
{
    private int startX = 2; // +1
    private int startY = 0; // +1

    private int[,] layout =
    {
        {-8, 4, 4, 4, -9},
        {3, 1, 1, 1, 2},
        {3, 1, 1, 1, 2},
        {3, 1, 1, 1, 2},
        {-7, 5, -5, 5, -6}
    };

    private int endX = 2; // +1
    private int endY = 4; // +1

    public int GetStartX()
    {
        return startX;
    }

    public int GetStartY()
    {
        return startY;
    }

    public int[,] GetLayout()
    {
        return layout;
    }

    public int GetEndX()
    {
        return endX;
    }

    public int GetEndY()
    {
        return endY;
    }
}
