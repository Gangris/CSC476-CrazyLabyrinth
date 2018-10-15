using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level1 : Level
{
    private int startX = 0;
    private int startY = 0;

    private int[,] layout =
    {
        {8, 4, 9},
        {3, 1, 2},
        {7, 5, -6}
    };

    private int endX = 2;
    private int endY = 2;

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
