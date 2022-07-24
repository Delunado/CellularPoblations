using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class ParcelController : MonoBehaviour
{
    [SerializeField] private FamilyController familyController;
    public FamilyController FamilyController => familyController;

    List<ParcelController> neighbours = new List<ParcelController>();

    private void Start()
    {
        familyController.Init(this);
    }

    public void AddNeighbour(ParcelController parcel)
    {
        neighbours.Add(parcel);
    }

    public List<ParcelController> GetNeighbours()
    {
        return neighbours;
    }
}