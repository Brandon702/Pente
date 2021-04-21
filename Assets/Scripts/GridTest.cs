using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridTest : MonoBehaviour
{
    public GameObject whiteMarker;
    public GameObject blackMarker;

    Grid grid;

    private void Start()
    {
        grid = new Grid(19, 19, 2.09f, new Vector3(0, 0));
    }

    private void Update()
    {
        grid.GetMouseXY(out int x, out int y);

        if (Input.GetMouseButtonDown(0))
        {
            Vector3 position = grid.GetWorldCellPosition(x, y);
            Instantiate(whiteMarker, position, Quaternion.identity);
            //Instantiate(blackMarker, position, Quaternion.identity);
        }
    }
}
