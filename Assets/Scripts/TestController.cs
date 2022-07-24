using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestController : MonoBehaviour
{
    [SerializeField] private IndividualController individual;

    // Start is called before the first frame update
    void Start()
    {
        Spawn();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void Spawn()
    {
        IndividualController i = Instantiate(individual, new Vector3(1.5f, 1.5f, 0), Quaternion.identity);
        i.Birth();
        i.MoveTowards(new Vector3(2.5f, 1.5f, 0));
    }

}
