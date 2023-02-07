using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CrowdController : MonoBehaviour
{
    GameObject[] goalPositions;
    NavMeshAgent agent;
    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        goalPositions = GameObject.FindGameObjectsWithTag("goal");
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();

        // Modificar parametros de Offset
        anim.SetFloat("animOffset", Random.Range(0f, 1f));

        anim.SetFloat("speedMult", Random.Range(0.5f, 2f));

        // Asignamos un destino y cambiamos la animación
        agent.SetDestination(goalPositions[Random.Range(0, goalPositions.Length)].transform.position);
        anim.SetTrigger("isWalking");
    }

    // Update is called once per frame
    void Update()
    {
        if (agent.remainingDistance < 1)
        {
            agent.SetDestination(goalPositions[Random.Range(0, goalPositions.Length)].transform.position);
        }
    }
}
