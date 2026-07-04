using UnityEngine;
using UnityEngine.AI;

public class Area : MonoBehaviour
{
    public float Radius = 20f;
    public float maxDistance = 2f;
    public Vector3 GetRandomPoint()
    {
        var randomDirection = Random.insideUnitSphere * Radius;
        randomDirection.y = 0;

        // Converting it to Vector3:
        Vector3 randomPoint = transform.position + randomDirection;
        Vector3 finalPosition = transform.position;

        if (NavMesh.SamplePosition(randomPoint, out NavMeshHit navHit, maxDistance, 1))
        {
            finalPosition = navHit.position;
        }

        return finalPosition;
    }

    [Header("Debugging")]
    [SerializeField] private Color areaColor = Color.blue;
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = areaColor;
        Gizmos.DrawWireSphere(transform.position, Radius);
    }
}
