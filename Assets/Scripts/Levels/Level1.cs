using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level1 : Level
{
    private int startX = 1;
    private int startY = 1;

    private int[,] layout =
    {
        {7, 3, 8},
        {2, 0, 1},
        {6, 4, 5}
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
