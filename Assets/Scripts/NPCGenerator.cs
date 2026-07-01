using UnityEngine;

public class NPCGenerator : MonoBehaviour
{
    [SerializeField] NPC npcPrefab;
    [SerializeField] Area area;
    [SerializeField] int Count = 15;

    private void Start()
    {
        for (int i = 0; i < Count; i++)
        {
            Vector3 desiredPosition = area.GetRandomPoint();
            var desiredRotation = Quaternion.Euler(0f, Random.Range(0, 360), 9);

            NPC npc = Instantiate(npcPrefab, desiredPosition, desiredRotation);

            npc.GetComponent<NPCWander>().Area = area;
        }
    }
}
