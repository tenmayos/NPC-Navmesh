using UnityEngine;

public class NPCWander : NPCComponent
{
    public Area Area;

    enum EState
    {
        Wandering,
        Waiting
    }

    [SerializeField] float maxWaitTime = 3f;
    [SerializeField] float maxWaitRandom = 3f;

    [Space(15f)]
    [SerializeField] float maxWanderTime = 5f;

    [Header("Debugging")]
    [SerializeField] EState state = EState.Wandering;
    [SerializeField] float wanderTime = 0f;
    [SerializeField] float waitTime = 0f;

    private void Start()
    {
        if (npc.Wander == false)
        {
            return;
        }

        if (Random.Range(0f, 100f) > 50f)
        {
            ChangeState(EState.Wandering);
        }
        else
        {
            ChangeState(EState.Waiting);
        }
    }
    private void Update()
    {
        if (npc.Wander == false)
            return;

        if (state == EState.Waiting)
        {
            waitTime -= Time.deltaTime;

            if (waitTime < 0f)
            {
                ChangeState(EState.Wandering);
            }
        }
        else if (state == EState.Wandering)
        {
            wanderTime -= Time.deltaTime;

            if (HasArrived() || wanderTime < 0f)
            {
                ChangeState(EState.Waiting);
            }
        }
    }
    void ChangeState(EState newState)
    {
        this.state = newState;
        if (newState == EState.Wandering)
        {
            npc.Agent.isStopped = false;

            SetRandomDestination();

            wanderTime = maxWanderTime;
        }
        else if (newState == EState.Waiting)
        {
            waitTime = maxWaitTime + Random.Range(0f, maxWaitRandom);
            npc.Agent.isStopped = true;
        }
    }
    bool HasArrived() => npc.Agent.remainingDistance <= npc.Agent.stoppingDistance;
    void SetRandomDestination() => npc.Agent.SetDestination(Area.GetRandomPoint());
}
