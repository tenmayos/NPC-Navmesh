using System.Collections.Generic;
using UnityEngine;

public class Group : MonoBehaviour
{
    public bool DrawGizmos = false;

    [SerializeField] List<NPC> members = new List<NPC>();

    public List<NPC> Members => members;

    [SerializeField] public FormationSO Formation;

    public int MemberCount => members.Count;
    public int FollowerCount => Mathf.Max(0, MemberCount - 1);
    public int GetFollowerIndex(NPC npc) => members.IndexOf(npc) - 1;
    public bool IsLeader(NPC npc) => members.IndexOf(npc) == 0;

    public NPC GetLeader()
    {
        if (members.Count >= 1)
            return members[0];

        return null;
    }
    public Vector3 GetPositionInGroup(NPC npc) => Formation.GetPosition(npc, this);

    #region Members Management Methods

    public void AddMember(NPC member)
    {
        members.Add(member);

        member.Group = this;
    }

    public void RemoveMember(NPC member)
    {
        members.Remove(member);

        member.Group = null;
    }

    #endregion
    private void Start()
    {
        foreach (NPC member in members)
        {
            member.Group = this;
        }
    }
    private void Update() // hes looping every frame...
    {
        // Removing dead members.
        for (int i = members.Count - 1; i >= 0; i--)
        {
            if (members[i].Alive == false)
            {
                members[i].Group = null;
                members.RemoveAt(i);
            }
        }
    }
    private void OnDrawGizmos()
    {
        if (Formation == null || MemberCount <= 0 || DrawGizmos == false)
            return;

        foreach (NPC member in members)
        {
            Vector3 position = GetPositionInGroup(member);

            if (IsLeader(member))
                Gizmos.color = Color.red;
            else
                Gizmos.color = Color.green;

            Gizmos.DrawSphere(position, 0.5f);
        }
    }
}
