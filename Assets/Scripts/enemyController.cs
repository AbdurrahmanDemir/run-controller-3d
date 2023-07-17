using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class enemyController : MonoBehaviour
{
    public GameObject attackTarget;
    NavMeshAgent agent;
    bool attackStarted;
    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    public void animationStart()
    {
        GetComponent<Animator>().SetBool("attack", true);
        attackStarted = true;
    }

    private void LateUpdate()
    {
        if (attackStarted)
            agent.SetDestination(attackTarget.transform.position);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("heroes"))
        {
            Vector3 newPos = new Vector3(transform.position.x, .23f, transform.position.z);

            GameObject.FindWithTag("gameManager").GetComponent<gameManager>().heroDeadParcile(newPos,true);
            gameObject.SetActive(false);
        }
    }
}
