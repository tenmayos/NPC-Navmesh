using UnityEngine;

public class NPCAnimator : NPCComponent
{
    private void Update()
    {
        npc.Animator.SetFloat("Speed", npc.CurrentSpeed);
    }
}
