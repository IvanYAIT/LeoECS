using UnityEngine;

public class TransformRange : MonoBehaviour
{
    [SerializeField] private Transform lowerLeft;
    [SerializeField] private Transform upperRight;

    public Vector3 RandomInRange() =>
        new Vector3(
            Random.Range(lowerLeft.position.x, upperRight.position.x),
            (upperRight.position.y + lowerLeft.position.y)/2,
            Random.Range(lowerLeft.position.z, upperRight.position.z)
            );
}