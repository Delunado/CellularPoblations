using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private WorldGrid _worldGrid;
    FamilyController startFamily;

    // Timer
    public float timeLeft = 5.0f;
    private float timer = 0.0f;

    public float reproduceTime;
    public float sendingTime;
    float _lastReproduction;
    float _lastSendingTime;

    private void Start()
    {

    }
    void Update()
    {
        // Spawn and individual when timer

        /*if (timer >= timeLeft)
        {
            // Spawn individual
            _worldGrid.GetRandomParcel().FamilyController.CreateIndividual();
            
            // Reset timer
            timer = 0.0f;
            
        } else {
            // Increment timer
            timer += Time.deltaTime;
        }*/


        if (Time.time > reproduceTime + _lastReproduction)
        {
            DoStep();
            _lastReproduction = Time.time;
            Invoke("DoStep2", 1f);
        }

        if (Input.GetKeyDown(KeyCode.X))
        {
            if (!startFamily)
                GetStartingFamily();
            RandomSpawn();
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            DoStep();
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            DoStep2();
        }
    }

    public void DoStep()
    {
        foreach (FamilyController family in _worldGrid.GetFamilies())
        {
            family.Reproduce();
        }

    }
    public void DoStep2()
    {
        foreach (FamilyController family in _worldGrid.GetFamilies())
        {
            family.Send();
        }
    }

    //test spawning function
    void RandomSpawn()
    {
        startFamily.CreateIndividual();

    }
    void GetStartingFamily()
    {
        startFamily = _worldGrid.GetRandomParcel().GetComponent<FamilyController>();
    }
}
