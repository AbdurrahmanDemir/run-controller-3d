using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class newHeroController : MonoBehaviour
{
    GameObject target;
    NavMeshAgent _navMesh;
    gameManager gameManager;
    void Start()
    {
        _navMesh = GetComponent<NavMeshAgent>();
        target = GameObject.FindWithTag("gameManager").GetComponent<gameManager>().heroPos;
        gameManager = GameObject.FindWithTag("gameManager").GetComponent<gameManager>();

    }

    // Update is called once per frame
    void Update()
    {
        _navMesh.SetDestination(target.transform.position);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("pinBox"))
        {
            Vector3 newPos= new Vector3(transform.position.x,.23f,transform.position.z);

            gameManager.heroDeadParcile(newPos);
            gameObject.SetActive(false);
        }

        if (other.CompareTag("saw"))
        {
            Vector3 newPos = new Vector3(transform.position.x, .23f, transform.position.z);

            gameManager.heroDeadParcile(newPos);
            gameObject.SetActive(false);
        }
        if (other.CompareTag("enemy"))
        {
            Vector3 newPos = new Vector3(transform.position.x, .23f, transform.position.z);

            gameManager.heroDeadParcile(newPos,false);
            gameObject.SetActive(false);
        }
    }
}
