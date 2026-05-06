using UnityEngine;
using UnityEngine.AI; 

public class NemicoInseguitore : MonoBehaviour
{
    public Transform giocatore; 
    private NavMeshAgent agente;

    void Start()
    {
        agente = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        if (giocatore != null)
        {
            agente.SetDestination(giocatore.position);
        }
    }
}
