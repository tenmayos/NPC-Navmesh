using UnityEngine;

public class NPCGroupMember : NPCComponent
{
    private void Update()
    {
        if (npc.Group == null)
        {
            npc.Wander = true;
            return;
        }

        if (npc.Group.IsLeader(npc))
        {
            npc.Wander = true;
        }
        else
        {
            Vector3 position = npc.Group.GetPositionInGroup(npc);

            npc.Agent.SetDestination(position);
            npc.Agent.isStopped = false;

            npc.Wander = false;
        }
    }
}
