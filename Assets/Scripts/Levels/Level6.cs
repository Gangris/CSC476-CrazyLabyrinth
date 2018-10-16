using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level6 : Level
{
    private int startX = 4; // +1
    private int startY = 0; // +1

    private int[,] layout =
    {
        {-8, 4, 4, 4,9},
        {-8, 3, 4, 4, 9},
        {3, -4, 4, 9, 2},
        {-7, 5,-1, 2, 2},
        {3, 1, 1, 2, 2},
        {3, -1, -1, 4, 2},
        {-7, 5, 5, 5,-6}
    };

    private int endX = 0; // +1
    private int endY = 1; // +1

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
