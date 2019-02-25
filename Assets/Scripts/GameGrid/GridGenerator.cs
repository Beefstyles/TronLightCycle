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
    public Transform gridParent;

    public int Width
    {
        get
        {
            return width;
        }

        set
        {
            width = value;
        }
    }
    public int Height
    {
        get
        {
            return height;
        }

        set
        {
            height = value;
        }
    }

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
                go.transform.parent = gridParent;
                go.transform.position = new Vector2(
                    go.transform.position.x + x,
                    go.transform.position.y + y);
                grid[x, y] = go;
                goHolder = go.GetComponent<GridObject>();
                if (goHolder != null)
                {
                    goHolder.Xpos = x;
                    goHolder.Ypos = y;
                    go.name = x + "," + y;
                    if (x == 0 || y == 0 || x == width - 1 || y == height - 1)
                    {
                        goHolder.IsWall = true;
                        goHolder.SetWallStatus();
                    }
                }
            }
        }
    }
}
