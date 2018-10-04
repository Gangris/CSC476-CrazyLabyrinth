using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level1 : Level
{
    private int startX = 0;
    private int startY = 0;

    private int[,] layout =
    {
        {0, 0, 0},
        {0, 0, 0},
        {0, 0, 0}
    };

    private int endX = 3;
    private int endY = 3;

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
