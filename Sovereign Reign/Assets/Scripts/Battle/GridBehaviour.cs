using System.Data;
using UnityEngine;

public class GridBehaviour : MonoBehaviour
{
    public int rows = 10;
    public int columns = 10;
    public int scale = 1;
    public GameObject gridPrefab;
    public Vector3 leftBottomLocation = new Vector3(0,0,0);
    public GameObject[,] gridArray;
    public int startX = 0;
    public int startY = 0;
    public int endX = 2;
    public int endY = 2;

    private void Awake()
    {
        gridArray = new GameObject[columns, rows];
        if (gridPrefab)
            GenerateGrid();
    }

    void GenerateGrid()
    {
        for(int i = 0; i < columns; i++)
        {
            for (int j = 0; j < rows; j++)
            {
                GameObject obj = Instantiate(gridPrefab, new Vector3 (leftBottomLocation.x+scale*i, leftBottomLocation.y, leftBottomLocation.z + scale * j), Quaternion.identity);
                obj.transform.SetParent(gameObject.transform);
                obj.GetComponent<GridStat>().x = i;
                obj.GetComponent<GridStat>().y = j;
                gridArray[i,j] = obj;

            }
        }
    }
    void InitialSetUp()
    {
        foreach(GameObject obj in gridArray)
        {
            obj.GetComponent<GridStat>().visited = -1;
        }
        gridArray[startX,startY].GetComponent<GridStat>().visited = 0;
    }
    bool TestDurectuib(int x, int y, int step, int direction)
    {
        switch(direction)
        {
            case 1:
                if (y+1 <rows && gridArray[x,y+1] && gridArray[x,y+1].GetComponent<GridStat>().visited == step)
                return true;
                else
                    return false;
            case 2:
                if (x + 1 < columns && gridArray[x+1, y] && gridArray[x + 1, y].GetComponent<GridStat>().visited == step)
                    return true;
                else
                    return false;
            case 3:
                if (y - 1 < -1 && gridArray[x, y - 1] && gridArray[x, y + 1].GetComponent<GridStat>().visited == step)
                    return true;
                else
                    return false;
            case 4:
                if (x-1 >-1 && gridArray[x+1, y] && gridArray[x+1, y].GetComponent<GridStat>().visited == step)
                    return true;
                else
                    return false;
        }
    }
}
