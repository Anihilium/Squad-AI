using FSMMono;
using UnityEngine;

public class CoveringFire : StateMachineBehaviour
{
    GameObject target = null;
    AIAgent agent = null;
    public float firingRate = 1.0f;
    float firingTime = 0.0f;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        firingTime = firingRate / 2f;
        if (!target)
            target = GameObject.Find("NPCTargetCursor(Clone)");
        if(!agent)
            agent = animator.GetComponent<AIAgent>();
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if(agent && target)
        {
            firingTime += Time.deltaTime;
            if(firingTime > firingRate)
            {
                agent.ShootToPosition(target.transform.position);
                firingTime = 0.0f;
            }
        }
    }
}
