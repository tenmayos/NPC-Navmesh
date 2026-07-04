using UnityEngine;

[CreateAssetMenu(fileName = "ColumnFormation", menuName = "Scriptable Objects/ColumnFormation")]
public class ColumnFormation : FormationSO
{
    [SerializeField] float Spacing = 3f;

    public override Vector3 GetPosition(NPC npc, Group group)
    {
        if (group.IsLeader(npc))
        {
            return npc.Position;
        }

        NPC leader = group.GetLeader();

        Vector3 position = leader.Position - leader.Direction * Spacing * group.Members.IndexOf(npc);
        //return position;
        return AdjustPosition(position, leader.Position);
    }
}
