using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldGrid : MonoBehaviour
{
    public ParcelController parcelGO;

    [SerializeField] private int gridSizeX;
    [SerializeField] private int gridSizeY;

    private ParcelController[,] worldGrid;

    private void Start()
    {
        //Generate world grid
        worldGrid = new ParcelController[gridSizeX, gridSizeY];

        //Get an offset so the grid is centered on the world
        float offset = (gridSizeX % 2 == 0) ? (gridSizeX / 2) - 0.5f : gridSizeX / 2;

        for (int x = 0; x < gridSizeX; x++)
        {
            for (int y = 0; y < gridSizeY; y++)
            {
                ParcelController parcel = Instantiate(parcelGO,
                    new Vector3(parcelGO.transform.localScale.x * (x - offset),
                        parcelGO.transform.localScale.y * (y - offset), 0), Quaternion.identity);

                parcel.transform.parent = transform;

                parcel.name = "Parcel " + x + " " + y;

                worldGrid[x, y] = parcel;
            }
        }
    }
}