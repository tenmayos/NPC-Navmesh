using UnityEngine;

[CreateAssetMenu(fileName = "CircleFormation", menuName = "Scriptable Objects/CircleFormation")]
public class CircleFormation : FormationSO
{
    [SerializeField] float radius = 3f;

    public override Vector3 GetPosition(NPC npc, Group group)
    {
        if (group.IsLeader(npc))
        {
            return npc.Position;
        }

        NPC leader = group.GetLeader();

        float angle = group.GetFollowerIndex(npc) * 360f / group.FollowerCount;

        Vector3 positionOnCircle = leader.Position + Quaternion.Euler(0, angle, 0) * leader.Direction * radius;

        return AdjustPosition(positionOnCircle, leader.Position);
    }
}
