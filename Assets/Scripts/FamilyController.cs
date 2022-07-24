using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FamilyController : MonoBehaviour
{
    [SerializeField] IndividualController individualController;
    
    private ParcelController _parcelController;
    
    private List<IndividualController> _individuals = new List<IndividualController>();

    public void Init(ParcelController parcelController)
    {
        _parcelController = parcelController;
    }

    public void DoStep()
    {
        int familySize = _individuals.Count;

        if (familySize < 6)
        {
            CreateIndividual();
        }
        else
        {
            
        }
    }
    
    public void CreateIndividual()
    {
        IndividualController i = Instantiate(individualController, _parcelController.transform.position, Quaternion.identity);
        
        _individuals.Add(i);
        
        Vector3 newbornFormation = DoFormationNewborn();
        
        i.Birth(() =>
        {
            i.MoveTowards(newbornFormation);
        });
    }

    private void DoFormation()
    {
        List<Vector3> formationPositions = _parcelController.GetFormationPositions(_individuals.Count);

        for (int i = 0; i < _individuals.Count - 1; i++)
        {
            _individuals[i].MoveTowards(formationPositions[i]);
        }
        
        _individuals[^1].MoveTowardsNewFamily(_parcelController.transform.position, formationPositions[^1]);
    }
    
    private Vector3 DoFormationNewborn()
    {
        List<Vector3> formationPositions = _parcelController.GetFormationPositions(_individuals.Count);

        for (int i = 0; i < _individuals.Count - 1; i++)
        {
            _individuals[i].MoveTowards(formationPositions[i]);
        }
        
        return formationPositions[^1];
    }

    public void AssignNewIndividual(IndividualController individual)
    {
        _individuals.Add(individual);
        
        DoFormation();
    }
}