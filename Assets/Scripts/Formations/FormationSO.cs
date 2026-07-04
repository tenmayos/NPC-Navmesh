using UnityEngine;
using UnityEngine.AI;

[CreateAssetMenu(fileName = "Formation", menuName = "Scriptable Objects/Formation")]
public abstract class FormationSO : ScriptableObject
{
    public abstract Vector3 GetPosition(NPC npc, Group group);

    protected Vector3 AdjustPosition(Vector3 position, Vector3 leaderPosition)
    {
        if (NavMesh.Raycast(leaderPosition, position, out NavMeshHit hit, NavMesh.AllAreas))
        {
            return hit.position;
        }
        return position;
    }
}
