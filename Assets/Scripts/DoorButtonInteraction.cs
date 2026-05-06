using UnityEngine;
public class DoorButtonInteraction : MonoBehaviour
{
    using UnityEngine;

    public GameObject interactionUI; // Trascina qui il tuo Canvas
    public Animator doorAnimator;    // Trascina qui l'Animator della porta

    private bool isPlayerNearby = false;

    void Start()
    {
        // Assicurati che l'interfaccia sia spenta all'inizio
        if (interactionUI != null) interactionUI.SetActive(false);
    }

    void Update()
    {
        // Se il giocatore è vicino e preme il tasto E
        if (isPlayerNearby && Input.GetKeyDown(KeyCode.E))
        {
            bool isOpen = doorAnimator.GetBool("isOpen");
            doorAnimator.SetBool("isOpen", !isOpen);
        }
    }

    // Quando il giocatore entra nell'area del BoxCollider (Trigger)
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNearby = true;
            if (interactionUI != null) interactionUI.SetActive(true);
        }
    }

    // Quando il giocatore esce dall'area
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNearby = false;
            if (interactionUI != null) interactionUI.SetActive(false);
        }
    }
}


