using UnityEngine;

public class DoorFastInteract : MonoBehaviour
{
    [Header("Impostazioni UI")]
    public GameObject interactionUI; // Trascina qui il Canvas "Premi E"

    [Header("Impostazioni Movimento")]
    [Range(0, 1)] public float doorValue = 0; // Questo è il tuo slider 0-1
    public float speed = 2f; // Velocità di apertura

    private bool isPlayerNearby = false;
    private bool shouldOpen = false;

    void Update()
    {
        // 1. Rileva Pressione Tasto
        if (isPlayerNearby && Input.GetKeyDown(KeyCode.E))
        {
            shouldOpen = !shouldOpen;
        }

        // 2. Muove lo slider 0-1 automaticamente
        float target = shouldOpen ? 1f : 0f;
        doorValue = Mathf.MoveTowards(doorValue, target, speed * Time.deltaTime);

        // 3. Applica il movimento alla rotazione (Esempio: 90 gradi)
        // Modifica 'Y' se la porta deve ruotare diversamente
        transform.localRotation = Quaternion.Euler(0, doorValue * 90f, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNearby = true;
            if (interactionUI != null) interactionUI.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNearby = false;
            if (interactionUI != null) interactionUI.SetActive(false);
        }
    }
}
