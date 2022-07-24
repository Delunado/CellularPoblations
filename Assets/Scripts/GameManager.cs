using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private WorldGrid _worldGrid;
    
    // Timer
    public float timeLeft = 5.0f;
    private float timer = 0.0f;

    // Update is called once per frame
    void Update()
    {
        // Spawn and individual when timer
        
        if (timer >= timeLeft)
        {
            // Spawn individual
            _worldGrid.GetRandomParcel().FamilyController.CreateIndividual();
            
            // Reset timer
            timer = 0.0f;
            
        } else {
            // Increment timer
            timer += Time.deltaTime;
        }
    }
}
