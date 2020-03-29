using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableController : MonoBehaviour
{
    [SerializeField] private int tableHeightSize = 20;
    [SerializeField] private int tableBaseSize = 10;
    [SerializeField] private int borders = 1;
    [SerializeField] private int upperMargin = 4;
    [SerializeField] private int limitInitPosition = 10;
    private int limitHeight;
    private int[,] tetrisTable;

    // Set up references
    void Awake()
    {

    }

    // Start is called before the first frame update
    void Start()
    {
        limitHeight = limitInitPosition + borders;
        InitTable();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void ListTable(int[,] table)    // DEBUG
    {
        for (int f = 0; f < tableHeightSize; f++)
        {
            for (int c = 0; c < tableBaseSize; c++)
            {
                Debug.Log(table[f, c]);
            }
        }
    }

    private void InitTable()
    {
        tetrisTable = new int[tableHeightSize + borders + upperMargin, tableBaseSize + borders * 2];
        for (int f = 0; f < tableHeightSize + borders + upperMargin; f++)
        {
            for (int c = 0; c < tableBaseSize + borders * 2; c++)
            {
                if (f == limitHeight)   // barrier
                {
                    tetrisTable[f, c] = -2;
                    Debug.Log("Box(" + f + "," + c + ") values is " + tetrisTable[f, c]);
                }
                else if (f >= tableHeightSize + borders) // margin
                {
                    tetrisTable[f, c] = -3;
                    Debug.Log("Box(" + f + "," + c + ") values is " + tetrisTable[f, c]);
                }
                else if (f < borders || c < borders || c >= tableBaseSize + borders)   // borders
                {
                    tetrisTable[f, c] = -1;
                    Debug.Log("Box(" + f + "," + c + ") values is " + tetrisTable[f, c]);
                }
                else    // empty
                {
                    tetrisTable[f, c] = 0;
                    Debug.Log("Box(" + f + "," + c + ") values is " + tetrisTable[f, c]);
                }
            }
        }
        //ListTable(tetrisTable); // debug
    }

    public Vector2Int GetTableSize()
    {
        Vector2Int output = new Vector2Int(tableHeightSize + borders + upperMargin, tableBaseSize + borders * 2);
        return output;
    }

    public int GetSpecificValue(int f, int c)
    {
        return tetrisTable[f, c];
    }
}
