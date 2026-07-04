using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class GroupManager : MonoBehaviour
{
    [SerializeField] List<Group> groups = new();
    //private FormationSO formation;

    [ContextMenu("Create Group")] // For convenience.
    public Group CreateGroup()
    {
        GameObject obj = new($"Group {groups.Count + 1}");

        obj.transform.parent = this.transform;

        Group group = obj.AddComponent<Group>();

        groups.Add(group);

        return group;
    }
}
