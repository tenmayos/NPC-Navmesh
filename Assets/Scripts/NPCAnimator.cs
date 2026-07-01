using UnityEngine;

public class NPCAnimator : NPCComponent
{
    private void Update()
    {
        npc.Animator.SetFloat("Speed", npc.CurrentSpeed);
    }

    public void OnFootstep() // Left here because there is an animation event slapped ontop of the animation itself.
    {

    }
}
