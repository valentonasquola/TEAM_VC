using UnityEngine;
using UnityEngine.AI;

public class MuoviNpc : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    NavMeshAgent agent;
    public Transform targetTransform;

    private void Start()
    {
       agent = GetComponent<NavMeshAgent>();
        Invoke(nameof(ImpostaTarget), 5f);

    }

    void ImpostaTarget()
    {
        agent.SetDestination(targetTransform.position);
        agent.speed = 10;
    }

       
}
