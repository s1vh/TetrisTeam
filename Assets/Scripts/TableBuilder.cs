﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableBuilder : MonoBehaviour
{
    TableController tableController;
    [SerializeField] private GameObject box;
    private GameObject[] boxArray;
    [SerializeField] private float boxSize = 1f;
    private int height;
    private int edge;
    [SerializeField] private Material borderMat;
    [SerializeField] private Material barrierMat;
    [SerializeField] private Material marginMat;
    [SerializeField] private Material emptyMat;
    [SerializeField] private Material tetromino1;
    private bool test = true;

    // Set up references
    void Awake()
    {
        tableController = this.gameObject.GetComponent<TableController>();
    }

    // Start is called before the first frame update
    void Start()
    {
        boxArray = new GameObject[tableController.GetTableSize().x * tableController.GetTableSize().y];
        box.transform.localScale = new Vector3(boxSize, boxSize, boxSize);
        DrawNewTable();
        //RefreshTable();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void LateUpdate()
    {
        if (test) { RefreshTable(); test = false; }
        //RefreshTable();
    }

    private void DrawNewTable()
    {
        Vector3 anchor = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z);
        height = tableController.GetTableSize().x;
        edge = tableController.GetTableSize().y;
        int i = 0;
        for (int f = 0; f < height; f++)
        {
            anchor = this.transform.position + new Vector3(0f, boxSize * f, 0f);
            for (int c = 0; c < edge; c++)
            {
                boxArray[i] = Instantiate(box, anchor + new Vector3(boxSize * c, 0f, 0f), this.transform.rotation);
                i++;
            }
        }
    }

    private void RefreshTable()
    {
        int i = 0;
        for (int f = 0; f < height; f++)
        {
            for (int c = 0; c < edge; c++)
            {
                if (tableController.GetSpecificValue(f, c) == -3)
                {
                    boxArray[i].GetComponent<Renderer>().material = marginMat;
                    Debug.Log("Box (" + f + "," + c + ") is Cube " + (i) + " and is margin");
                }
                else if (tableController.GetSpecificValue(f, c) == -2)
                {
                    boxArray[i].GetComponent<Renderer>().material = barrierMat;
                    Debug.Log("Box (" + f + "," + c + ") is Cube " + (i) + " and is barrier");
                }
                else if (tableController.GetSpecificValue(f, c) == -1)
                {
                    boxArray[i].GetComponent<Renderer>().material = borderMat;
                    Debug.Log("Box (" + f + "," + c + ") is Cube " + (i) + " and is border");
                }
                else if (tableController.GetSpecificValue(f, c) == 0)
                {
                    boxArray[i].GetComponent<Renderer>().material = emptyMat;
                    Debug.Log("Box (" + f + "," + c + ") is Cube " + (i) + " and is empty");
                }
                else if (tableController.GetSpecificValue(f, c) == 1)
                {
                    boxArray[i].GetComponent<Renderer>().material = tetromino1;
                    Debug.Log("Box (" + f + "," + c + ") is Cube " + (i) + " and is tetromino");
                }
                i++;
            }
        }
    }
}