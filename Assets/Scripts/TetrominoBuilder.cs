using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TetrominoBuilder : MonoBehaviour
{
    TableController tableController;

    // Set up references
    void Awake()
    {
        tableController = this.gameObject.GetComponent<TableController>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool SpawnTetromino(int tetromino)  // if false is game over!!
    {
        bool check = true;  // if false is game over!!
        Vector2Int[,] table = tableController.GetTable();
        int f = tableController.GetTableData().x;
        int c = tableController.GetTableData().y + Mathf.FloorToInt(tableController.GetTableData().z * 0.5f) - 1;
        if (tetromino == 0) { tetromino = Random.Range(1, 6); }
        if (table[f, c].y == 0) { check = false; }
        else
        {
            switch (tetromino)  // TETROMINO BUILDER
            {
                case 1:
                    if (table[f, c].y == 0 || table[f + 1, c].y == 0 || table[f + 2, c].y == 0 || table[f + 3, c].y == 0) { check = false; }
                    else
                    {
                        table[f, c] = new Vector2Int(tetromino, 1);
                        table[f + 1, c] = new Vector2Int(tetromino, 1);
                        table[f + 2, c] = new Vector2Int(tetromino, 1);
                        table[f + 3, c] = new Vector2Int(tetromino, 1);
                    }
                    break;

                case 2:
                    if (table[f, c].y == 0 || table[f + 1, c].y == 0 || table[f, c + 1].y == 0 || table[f + 1, c + 1].y == 0) { check = false; }
                    else
                    {
                        table[f, c] = new Vector2Int(tetromino, 1);
                        table[f + 1, c] = new Vector2Int(tetromino, 1);
                        table[f, c + 1] = new Vector2Int(tetromino, 1);
                        table[f + 1, c + 1] = new Vector2Int(tetromino, 1);
                    }
                    break;

                case 3:
                    if (table[f, c].y == 0 || table[f + 1, c].y == 0 || table[f + 1, c - 1].y == 0 || table[f + 1, c + 1].y == 0) { check = false; }
                    else
                    {
                        table[f, c] = new Vector2Int(tetromino, 1);
                        table[f + 1, c] = new Vector2Int(tetromino, 1);
                        table[f + 1, c - 1] = new Vector2Int(tetromino, 1);
                        table[f + 1, c + 1] = new Vector2Int(tetromino, 1);
                    }
                    break;

                case 4:
                    if (table[f, c].y == 0 || table[f + 1, c].y == 0 || table[f + 1, c - 1].y == 0 || table[f, c + 1].y == 0) { check = false; }
                    else
                    {
                        table[f, c] = new Vector2Int(tetromino, 1);
                        table[f + 1, c] = new Vector2Int(tetromino, 1);
                        table[f + 1, c - 1] = new Vector2Int(tetromino, 1);
                        table[f, c + 1] = new Vector2Int(tetromino, 1);
                    }
                    break;

                case 5:
                    if (table[f, c].y == 0 || table[f + 1, c].y == 0 || table[f, c - 1].y == 0 || table[f + 1, c + 1].y == 0) { check = false; }
                    else
                    {
                        table[f, c] = new Vector2Int(tetromino, 1);
                        table[f + 1, c] = new Vector2Int(tetromino, 1);
                        table[f, c - 1] = new Vector2Int(tetromino, 1);
                        table[f + 1, c + 1] = new Vector2Int(tetromino, 1);
                    }
                    break;
            }
        }
        if (check) { Debug.Log("Tetromino (" + tetromino + ") has been spawned!"); }
        else
        {
            Debug.Log("(" + this.gameObject.name + ") GAME OVER: there's no space to draw tetromino (" + tetromino + ")");
            // --start GAME OVER routine HERE--
        }
        return check;
    }
}
