using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node  
{
    public bool walkable;
    public Vector3 worldPos;

    public int gCost;
    public int hCost;

    public Node(bool _walkable, Vector3 _worldPos)
    {
        walkable = _walkable;
        worldPos = _worldPos;
    }

    public int fCost
    {
        get
        {
            return gCost + hCost;
        }
    }
}
