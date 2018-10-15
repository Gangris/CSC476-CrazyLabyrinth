using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level4 : Level
{
    private int startX = 1; // +1
    private int startY = 0; // +1

    private int[,] layout =
    {
        {-8, 4, -9},
        {3, 5, -6},
        {3, 1, -9},
        {-7, 5, 2},
        {-3, 1, 2},
        {-3, 1, -6},
        {-7, -5, -6}
    };

    private int endX = 0; // +1
    private int endY = 5; // +1

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
