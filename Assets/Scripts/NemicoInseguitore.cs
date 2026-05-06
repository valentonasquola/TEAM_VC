using UnityEngine;
using UnityEngine.AI; 

public class NemicoInseguitore : MonoBehaviour
{
    public Transform giocatore; 
    private NavMeshAgent agente;
    [SerializeField] private float speed = 0.1f;

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
