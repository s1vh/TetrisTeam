﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableController : MonoBehaviour
{
    [SerializeField] private int tableHeightSize = 20;
    [SerializeField] private int tableBaseSize = 10;
    [SerializeField] private int borders = 1;
    [SerializeField] private int upperMargin = 4;
    [SerializeField] private int InitCeilingPosition = 10;
    private int ceiling;
    private Vector2Int[,] tetrisTable;  // x --> block; y --> state static(0)/active(1)
    [SerializeField] private bool fastMode = false;
    [SerializeField] private bool testMode = false;
    private List<int> clearedLines = new List<int>();

    // Set up references
    void Awake()
    {

    }

    // Start is called before the first frame update
    void Start()
    {
        ceiling = InitCeilingPosition + borders;
        InitTable();
    }

    // Update is called once per frame
    void Update()
    {
        if (testMode)   // during WIP only - not intended to work without abnormalities in the playable version
        {
            if (Input.GetKeyDown(KeyCode.X)) { ClearTable(); }
            else if (Input.GetKeyDown(KeyCode.T)) { SpawnTestingBlocks(); }
            else if (Input.GetKeyDown(KeyCode.Alpha1)) { SpawnTetromino(1); }
            else if (Input.GetKeyDown(KeyCode.Alpha2)) { SpawnTetromino(2); }
            else if (Input.GetKeyDown(KeyCode.Alpha3)) { SpawnTetromino(3); }
            else if (Input.GetKeyDown(KeyCode.Alpha4)) { SpawnTetromino(4); }
            else if (Input.GetKeyDown(KeyCode.Alpha5)) { SpawnTetromino(5); }
        }
    }

    private int ClearTable()        // clear table and count used blocks - for testing purposes only!
    {
        int count = 0;
        for (int f = borders; f < tableHeightSize + borders + upperMargin; f++)
        {
            for (int c = borders; c < tableBaseSize + borders; c++)
            {
                if (tetrisTable[f, c].x > 0)
                {
                    if (f < ceiling) { tetrisTable[f, c] = new Vector2Int(0, -1); }
                    else { tetrisTable[f, c] = new Vector2Int(-2, -1); }
                    count++;
                }
            }
        }
        return count;
    }

    private void SpawnTestingBlocks()   // for testing purposes only!
    {
        tetrisTable[10, 1] = new Vector2Int(1, 1);
        tetrisTable[10, 2] = new Vector2Int(1, 1);
        tetrisTable[10, 3] = new Vector2Int(1, 1);
        tetrisTable[10, 4] = new Vector2Int(1, 1);
        tetrisTable[10, 5] = new Vector2Int(1, 1);
        tetrisTable[10, 6] = new Vector2Int(1, 1);
        tetrisTable[10, 7] = new Vector2Int(1, 1);
        tetrisTable[10, 8] = new Vector2Int(1, 1);
        tetrisTable[10, 9] = new Vector2Int(1, 1);
        tetrisTable[9, 10] = new Vector2Int(1, 1);
        Debug.Log("Test blocks have been spawned!");
    }

    private bool SpawnTetromino(int n)  // if false is game over!!
    {
        bool check = true;
        int f = ceiling;
        int c = borders + Mathf.FloorToInt(tableBaseSize * 0.5f) - 1;
        if (tetrisTable[f, c].y == 0) { check = false; }
        else
        {
            switch (n)  // TETROMINO BUILDER
            {
                case 1:
                    if (tetrisTable[f, c].y == 0 || tetrisTable[f + 1, c].y == 0 || tetrisTable[f + 2, c].y == 0 || tetrisTable[f + 3, c].y == 0) { check = false; }
                    else
                    {
                        tetrisTable[f, c]           = new Vector2Int(n, 1);
                        tetrisTable[f + 1, c]       = new Vector2Int(n, 1);
                        tetrisTable[f + 2, c]       = new Vector2Int(n, 1);
                        tetrisTable[f + 3, c]       = new Vector2Int(n, 1);
                    }
                    break;

                case 2:
                    if (tetrisTable[f, c].y == 0 || tetrisTable[f + 1, c].y == 0 || tetrisTable[f, c + 1].y == 0 || tetrisTable[f + 1, c + 1].y == 0) { check = false; }
                    else
                    {
                        tetrisTable[f, c]           = new Vector2Int(n, 1);
                        tetrisTable[f + 1, c]       = new Vector2Int(n, 1);
                        tetrisTable[f, c + 1]       = new Vector2Int(n, 1);
                        tetrisTable[f + 1, c + 1]   = new Vector2Int(n, 1);
                    }
                    break;

                case 3:
                    if (tetrisTable[f, c].y == 0 || tetrisTable[f + 1, c].y == 0 || tetrisTable[f + 1, c - 1].y == 0 || tetrisTable[f + 1, c + 1].y == 0) { check = false; }
                    else
                    {
                        tetrisTable[f, c]           = new Vector2Int(n, 1);
                        tetrisTable[f + 1, c]       = new Vector2Int(n, 1);
                        tetrisTable[f + 1, c - 1]   = new Vector2Int(n, 1);
                        tetrisTable[f + 1, c + 1]   = new Vector2Int(n, 1);
                    }
                    break;

                case 4:
                    if (tetrisTable[f, c].y == 0 || tetrisTable[f + 1, c].y == 0 || tetrisTable[f + 1, c - 1].y == 0 || tetrisTable[f, c + 1].y == 0) { check = false; }
                    else
                    {
                        tetrisTable[f, c]           = new Vector2Int(n, 1);
                        tetrisTable[f + 1, c]       = new Vector2Int(n, 1);
                        tetrisTable[f + 1, c - 1]   = new Vector2Int(n, 1);
                        tetrisTable[f, c + 1]       = new Vector2Int(n, 1);
                    }
                    break;

                case 5:
                    if (tetrisTable[f, c].y == 0 || tetrisTable[f + 1, c].y == 0 || tetrisTable[f, c - 1].y == 0 || tetrisTable[f + 1, c + 1].y == 0) { check = false; }
                    else
                    {
                        tetrisTable[f, c] = new Vector2Int(n, 1);
                        tetrisTable[f + 1, c] = new Vector2Int(n, 1);
                        tetrisTable[f, c - 1] = new Vector2Int(n, 1);
                        tetrisTable[f + 1, c + 1] = new Vector2Int(n, 1);
                    }
                    break;
            }
        }
        if (check) { Debug.Log("Tetromino (" + n + ") has been spawned!"); }
        else { Debug.Log("There's no space to draw tetromino (" + n + ")"); }
        return check;
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
        tetrisTable = new Vector2Int[tableHeightSize + borders + upperMargin, tableBaseSize + borders * 2];
        for (int f = 0; f < tableHeightSize + borders + upperMargin; f++)
        {
            for (int c = 0; c < tableBaseSize + borders * 2; c++)
            {
                if (f >= ceiling)                                                       // current ceiling
                {
                    tetrisTable[f, c] = new Vector2Int(-2, -1);
                    //Debug.Log("Box(" + f + "," + c + ") values is " + tetrisTable[f, c]);
                }
                else if (f >= tableHeightSize + borders)                                // margin
                {
                    tetrisTable[f, c] = new Vector2Int(-3, -1);
                    //Debug.Log("Box(" + f + "," + c + ") values is " + tetrisTable[f, c]);
                }
                else if (f < borders || c < borders || c >= tableBaseSize + borders)   // borders
                {
                    tetrisTable[f, c] = new Vector2Int(-1, -1);
                    //Debug.Log("Box(" + f + "," + c + ") values is " + tetrisTable[f, c]);
                }
                else                                                                    // empty
                {
                    tetrisTable[f, c] = new Vector2Int(0, -1);
                    //Debug.Log("Box(" + f + "," + c + ") values is " + tetrisTable[f, c]);
                }
            }
        }
        //ListTable(tetrisTable); // debug
        Debug.Log(this.gameObject.name + " has been initialized!");
        if (testMode) { SpawnTestingBlocks(); }
    }
    private void StackTetrominoes()
    {
        for (int f = borders; f < tableHeightSize + borders + upperMargin; f++)
        {
            for (int c = borders; c < tableBaseSize + borders; c++)
            {
                if (tetrisTable[f, c].x > 0) { tetrisTable[f, c].y = 0; }
            }
        }
        Debug.Log("Active tetromino has been stacked!");
        ClearLines();   // WIP: manage score here!!!
        // -summon new tetromino at ceiling-
        if (testMode) { SpawnTetromino(Random.Range(1, 6)); }
    }

    private int ClearLines()
    {
        Debug.Log("Trying to clear lines on " + this.gameObject.name + "...");
        int lines = 0;
        for (int f = borders; f < tableHeightSize + borders; f++)
        {
            bool clean = true;
            for (int c = borders; c < tableBaseSize + borders; c++)
            {
                if (tetrisTable[f, c].x < 1) { clean = false; }
            }
            if (clean)
            {
                for (int c = borders; c < tableBaseSize + borders; c++)
                {
                    if (tetrisTable[f, c].y == 0) { tetrisTable[f, c] = new Vector2Int(0, -1); }
                }
                Debug.Log("Line cleared on file #" + f);
                clearedLines.Add(f + 1);
                f = borders;
                lines++;
            }
        }
        return lines;
    }

    private bool PushDown(int height)
    {
        bool pushed = false;
        for (int f = height; f < tableHeightSize + borders + upperMargin; f++)
        {
            bool stop = true;
            for (int c = borders; c < tableBaseSize + borders; c++)
            {
                if (tetrisTable[f, c].y == 0)
                {
                    tetrisTable[f - 1, c] = new Vector2Int(tetrisTable[f, c].x, tetrisTable[f, c].y);
                    tetrisTable[f, c] = new Vector2Int(0, -1);
                    stop = false;
                    pushed = true;
                }
            }
            if (stop) { return pushed; }
        }
        return pushed;
    }

    public bool MoveDown(bool auto)
    {
        if (clearedLines.Count == 0)
        {
            bool moved = true;
            for (int f = borders; f < tableHeightSize + borders + upperMargin && moved; f++)
            {
                for (int c = borders; c < tableBaseSize + borders; c++)
                {
                    if (tetrisTable[f, c].y == 1 && (tetrisTable[f - 1, c].x == -1 || tetrisTable[f - 1, c].y == 0))
                    {
                        moved = false;
                        break;
                    }
                }
            }
            if (moved)
            {
                for (int f = borders; f < tableHeightSize + borders + upperMargin; f++)
                {
                    for (int c = borders; c < tableBaseSize + borders; c++)
                    {
                        if (tetrisTable[f, c].y > 0)
                        {
                            if (moved)
                            {
                                tetrisTable[f - 1, c] = new Vector2Int(tetrisTable[f, c].x, tetrisTable[f, c].y);
                                if (f < ceiling) { tetrisTable[f, c] = new Vector2Int(0, -1); }
                                else { tetrisTable[f, c] = new Vector2Int(-2, -1); }
                            }
                            else
                            {
                                tetrisTable[f, c].y = 0;
                            }
                        }
                    }
                }
                if (fastMode)   // use this only for autostacking when touching the floor, without waiting for next time steep
                {
                    for (int f = borders; f < tableHeightSize + borders + upperMargin && moved; f++)
                    {
                        for (int c = borders; c < tableBaseSize + borders; c++)
                        {
                            if (tetrisTable[f, c].y == 1 && tetrisTable[f - 1, c].x != 0)
                            {
                                moved = false;
                                break;
                            }
                        }
                    }
                    if (!moved)
                    {
                        StackTetrominoes();
                    }
                }
            }
            else
            {
                Debug.Log("Active tetromino can't move down!");
                // -play blocking/stacking sound here-
                StackTetrominoes();
            }
            return moved;
        }
        else if (auto)
        {
            int n = 0;
            foreach (int l in clearedLines)
            {
                PushDown(l - n);
                n++;
            }
            clearedLines.Clear();
        }
        return false;
    }

    public Vector2Int GetTableSize()
    {
        Vector2Int output = new Vector2Int(tableHeightSize + borders + upperMargin, tableBaseSize + borders * 2);
        return output;
    }

    public Vector2Int GetSpecificValue(int f, int c)
    {
        return tetrisTable[f, c];
    }
}
