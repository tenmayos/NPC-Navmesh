using UnityEngine;

[CreateAssetMenu(fileName = "ConvoyFormation", menuName = "Scriptable Objects/ConvoyFormation")]
public class ConvoyFormation : FormationSO
{
    [SerializeField] float spacing = 3f;
    public override Vector3 GetPosition(NPC npc, Group group)
    {
        if (group.IsLeader(npc))
        {
            return npc.Position;
        }

        int memberIndex = group.Members.IndexOf(npc);

        // The "leader" is the group member infront of this npc.
        NPC leader = group.Members[memberIndex - 1];

        float distanceToLeader = Vector3.Distance(npc.Position, leader.Position);

        if (distanceToLeader < spacing)
        {
            return npc.Position;
        }
        else
        {
            Vector3 directionToLeader = (npc.Position - leader.Position).normalized;

            Vector3 targetPosition = leader.Position + directionToLeader * spacing;

            return AdjustPosition(targetPosition, leader.Position);
        }
    }
}
