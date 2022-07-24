using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DG.Tweening;
using UnityEngine;

public class ParcelController : MonoBehaviour
{
    [SerializeField] private FamilyController familyController;
    public FamilyController FamilyController => familyController;

    [Header("Patter Formations")] [SerializeField]
    private Transform singleFormation;

    [SerializeField] private Transform doubleFormation;
    [SerializeField] private Transform tripleFormation;
    [SerializeField] private Transform quadFormation;
    [SerializeField] private Transform pentaFormation;
    [SerializeField] private Transform hexaFormation;

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

    public List<Vector3> GetFormationPositions(int individualsNumber)
    {
        List<Vector3> positions = new List<Vector3>();

        Transform chosenFormation = individualsNumber switch
        {
            1 => singleFormation,
            2 => doubleFormation,
            3 => tripleFormation,
            4 => quadFormation,
            5 => pentaFormation,
            6 => hexaFormation,
            _ => throw new ArgumentException("Invalid number of individuals")
        };

        positions.AddRange(from Transform t in chosenFormation select t.position);

        return positions;
    }
}