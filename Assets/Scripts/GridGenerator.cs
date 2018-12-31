using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridGenerator : MonoBehaviour {

    [SerializeField]
    private int width, height;
    [SerializeField]
    private GameObject gridObject;
    private GameObject[,] grid;
    private GridObject goHolder;

    void Start ()
    {
        grid = new GameObject[width, height];
        GenerateGrid();
    }
	
	private void GenerateGrid()
    {
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                GameObject go = Instantiate(gridObject);
                go.transform.parent = transform.parent;
                go.transform.position = new Vector2(
                    go.transform.position.x + x,
                    go.transform.position.y + y);
                grid[x, y] = go;
                goHolder = go.GetComponent<GridObject>();
                if(goHolder != null)
                {
                    goHolder.Xpos = x;
                    goHolder.Ypos = y;
                    go.name = x + "," + y;
                }
            }
        }
    }
}
