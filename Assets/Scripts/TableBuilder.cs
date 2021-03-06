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
    [SerializeField] private Color borderColor;
    [SerializeField] private Color barrierColor;
    [SerializeField] private Color marginColor;
    [SerializeField] private Color emptyColor;
    [SerializeField] private Color tetromino1;
    [SerializeField] private Color tetromino2;
    [SerializeField] private Color tetromino3;
    [SerializeField] private Color tetromino4;
    [SerializeField] private Color tetromino5;

    // Set up references
    void Awake()
    {
        tableController = this.gameObject.GetComponent<TableController>();
    }

    // Start is called before the first frame update
    void Start()
    {
        boxArray = new GameObject[tableController.GetFullTableSize().x * tableController.GetFullTableSize().y];
        box.transform.localScale = new Vector3(boxSize, boxSize, boxSize);
        DrawNewTable();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void LateUpdate()
    {
        RefreshTable();
    }

    private void DrawNewTable()
    {
        Vector3 anchor = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z);
        height = tableController.GetFullTableSize().x;
        edge = tableController.GetFullTableSize().y;
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
                if (tableController.GetSpecificValue(f, c).x == -3)
                {
                    boxArray[i].GetComponent<Renderer>().material.color = marginColor;
                    //Debug.Log("Box (" + f + "," + c + ") is Cube " + (i) + " and is margin");
                }
                else if (tableController.GetSpecificValue(f, c).x == -2)
                {
                    boxArray[i].GetComponent<Renderer>().material.color = barrierColor;
                    //Debug.Log("Box (" + f + "," + c + ") is Cube " + (i) + " and is barrier");
                }
                else if (tableController.GetSpecificValue(f, c).x == -1)
                {
                    boxArray[i].GetComponent<Renderer>().material.color = borderColor;
                    //Debug.Log("Box (" + f + "," + c + ") is Cube " + (i) + " and is border");
                }
                else if (tableController.GetSpecificValue(f, c).x == 0)
                {
                    boxArray[i].GetComponent<Renderer>().material.color = emptyColor;
                    //Debug.Log("Box (" + f + "," + c + ") is Cube " + (i) + " and is empty");
                }
                else if (tableController.GetSpecificValue(f, c).x == 1)
                {
                    boxArray[i].GetComponent<Renderer>().material.color = tetromino1;
                    //Debug.Log("Box (" + f + "," + c + ") is Cube " + (i) + " and is tetromino");
                }
                else if (tableController.GetSpecificValue(f, c).x == 2)
                {
                    boxArray[i].GetComponent<Renderer>().material.color = tetromino2;
                    //Debug.Log("Box (" + f + "," + c + ") is Cube " + (i) + " and is tetromino");
                }
                else if (tableController.GetSpecificValue(f, c).x == 3)
                {
                    boxArray[i].GetComponent<Renderer>().material.color = tetromino3;
                    //Debug.Log("Box (" + f + "," + c + ") is Cube " + (i) + " and is tetromino");
                }
                else if (tableController.GetSpecificValue(f, c).x == 4)
                {
                    boxArray[i].GetComponent<Renderer>().material.color = tetromino4;
                    //Debug.Log("Box (" + f + "," + c + ") is Cube " + (i) + " and is tetromino");
                }
                else if (tableController.GetSpecificValue(f, c).x == 5)
                {
                    boxArray[i].GetComponent<Renderer>().material.color = tetromino5;
                    //Debug.Log("Box (" + f + "," + c + ") is Cube " + (i) + " and is tetromino");
                }
                i++;
            }
        }
    }
}
