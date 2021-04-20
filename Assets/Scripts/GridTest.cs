using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridTest : MonoBehaviour
{
    private void Start()
    {
        Grid grid = new Grid(19, 19, 2.09f, new Vector3(0, 0));
    }
}
