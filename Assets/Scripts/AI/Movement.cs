using FSMMono;
using UnityEngine;

public class Movement : StateMachineBehaviour
{
    Transform player;
    AIAgent agent;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (!player)
            player = GameObject.Find("Player").transform;

        if (!agent)
            agent = animator.GetComponent<AIAgent>();
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (!player || !agent)
            return;

        float curAngle = (player.rotation.eulerAngles.y + agent.OffsetAngle) * Mathf.Deg2Rad;
        agent.MoveTo(player.position + agent.OffsetDistance * new Vector3(Mathf.Sin(curAngle), 0f, Mathf.Cos(curAngle)).normalized);
    }
}
