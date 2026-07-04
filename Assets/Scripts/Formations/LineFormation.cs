using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

[CreateAssetMenu(fileName = "LineFormation", menuName = "Scriptable Objects/LineFormation")]
public class LineFormation : FormationSO
{
    [SerializeField] float verticalSpacing = 3f;
    [SerializeField] float horizontalSpacing = 3f;
    public override Vector3 GetPosition(NPC npc, Group group)
    {
        if (group.IsLeader(npc))
        {
            return npc.Position;
        }

        NPC leader = group.GetLeader();

        Vector3 leaderRight = Vector3.Cross(Vector3.up, leader.Direction).normalized;

        Vector3 lineMiddle = leader.Position - leader.Direction * verticalSpacing; // Line middle.

        float formationWidth = (group.FollowerCount - 1) * horizontalSpacing;

        Vector3 leftMostFollower = lineMiddle - leaderRight * formationWidth * 0.5f;

        Vector3 positionOnLine = leftMostFollower + (leaderRight * horizontalSpacing * group.GetFollowerIndex(npc));

        return AdjustPosition(positionOnLine, leader.Position);
    }
}
