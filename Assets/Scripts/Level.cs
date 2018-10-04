using System.Collections;
using System.Collections.Generic;

public interface Level
{
    int GetStartX();
    int GetStartY();
    int[,] GetLayout();
    int GetEndX();
    int GetEndY();
}