using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FamilyController : MonoBehaviour
{
    [SerializeField] IndividualController individualController;
    
    private ParcelController _parcelController;

    public void Init(ParcelController parcelController)
    {
        _parcelController = parcelController;
    }
    
    public void CreateIndividual()
    {
        IndividualController i = Instantiate(individualController, _parcelController.transform.position, Quaternion.identity);
        
        i.Birth();
    }
}