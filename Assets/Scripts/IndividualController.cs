using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class IndividualController : MonoBehaviour
{
    [SerializeField] private float size;
    [SerializeField] private float growingTime;
    [SerializeField] private float speed;

    public void MoveTowards(Vector3 finalPosition)
    {
        float movingTime = CalculateMovementTime(finalPosition);

        transform.DOMove(finalPosition, movingTime);
    }

    public void MoveTowardsNewFamily(Vector3 familyPosition, Vector3 formationPosition)
    {
        float movingTimeFamily = CalculateMovementTime(familyPosition);

        transform.DOMove(familyPosition, movingTimeFamily).OnComplete(() => { MoveTowards(formationPosition); });
    }

    private float CalculateMovementTime(Vector3 positionToMove)
    {
        return Vector3.Distance(transform.position, positionToMove) / speed;
    }

    public void Birth()
    {
        transform.localScale = new Vector3(0, 0, 0);
        transform.DOScale(size, growingTime);
    }
}