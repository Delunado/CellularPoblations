using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class IndividualController : MonoBehaviour
{
    [SerializeField] private float size;
    [SerializeField] private float growingTime;
    [SerializeField] private float speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void MoveTowards(Vector3 finalPosition)
    {
        float movingTime = Vector3.Distance(transform.position, finalPosition)/speed;
        transform.DOMove(finalPosition, movingTime);
    }
    public void Birth()
    {
        transform.localScale = new Vector3(0, 0, 0);
        transform.DOScale(size, growingTime);
    }
}
