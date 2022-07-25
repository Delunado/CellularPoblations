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

        if (familySize < 6 && familySize > 1)
        {
            CreateIndividual();
        }
        else if (familySize == 6)
        {
            List<ParcelController> neighbours = _parcelController.GetNeighbours();
            int index = Random.Range(0, neighbours.Count);

            //searching for a random non full neighbour
            while (neighbours[index].GetComponent<FamilyController>().isFull() || neighbours.Count == 0)
            {
                neighbours.Remove(neighbours[index]);
                index = Random.Range(0, neighbours.Count);
            }
            //sending an individual to the selected tile
            IndividualController i = Instantiate(individualController, _parcelController.transform.position, Quaternion.identity);
            neighbours[index].GetComponent<FamilyController>().AssignNewIndividual(i);

        }
        else
        {

        }
    }
    public void Reproduce()
    {
        int familySize = _individuals.Count;

        if (familySize < 6 && familySize > 1)
        {
            CreateIndividual();
        }
    }
    public void Send()
    {
        int familySize = _individuals.Count;

        if (familySize == 6)
        {
            List<ParcelController> neighbours = _parcelController.GetNeighbours();
            int index = Random.Range(0, neighbours.Count);

            //searching for a random non full neighbour
            while (neighbours.Count > 0 && neighbours[index].GetComponent<FamilyController>().isFull())
            {
                neighbours.Remove(neighbours[index]);
                index = Random.Range(0, neighbours.Count);
                Debug.Log(index.ToString());
            }
            if (neighbours.Count != 0)
            {
                //sending an individual to the selected tile
                IndividualController i = Instantiate(individualController, _parcelController.transform.position, Quaternion.identity);
                neighbours[index].GetComponent<FamilyController>().AssignNewIndividual(i);
            }
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
    public bool isFull()
    {
        if (_individuals.Count >= 6)
            return true;
        return false;
    }
}