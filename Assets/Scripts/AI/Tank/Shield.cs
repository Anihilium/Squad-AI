using FSMMono;
using UnityEngine;
using UnityEngine.AI;

public class Shield : StateMachineBehaviour
{
    GameObject shield = null;
    Transform player = null;
    AIAgent agent = null;
    NavMeshAgent navMeshAgent = null;
    CheckEnemy checkEnemy = null;

    public float moveSpeedShield;
    float moveSpeedNoShield;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (!shield)
            shield = animator.transform.GetChild(1).gameObject;
        if (!player)
            player = GameObject.Find("Player").transform;
        if (!agent)
            agent = animator.GetComponent<AIAgent>();
        if (!checkEnemy)
            checkEnemy = animator.GetComponent<CheckEnemy>();
        if (!navMeshAgent)
        {
            navMeshAgent = animator.GetComponent<NavMeshAgent>();
            moveSpeedNoShield = navMeshAgent.speed;
        }

        shield.SetActive(true);
        navMeshAgent.speed = moveSpeedShield;
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (!player || !agent)
            return;

        if(checkEnemy.target)
        {
            // Rotation
            animator.transform.forward = checkEnemy.target.transform.position - animator.transform.position;
            animator.transform.forward = new Vector3(animator.transform.forward.x, 0f, animator.transform.forward.z);

            // Position
            agent.MoveTo(player.position + agent.OffsetDistance * animator.transform.forward);
        }
        else
        {
            animator.SetBool("Shield", false);
            animator.SetBool("SupportingFire", false);
        }

    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        shield.SetActive(false);
        navMeshAgent.speed = moveSpeedNoShield;
    }
}
