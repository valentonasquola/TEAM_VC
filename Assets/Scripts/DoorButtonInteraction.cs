using UnityEngine;

public class InterazionePortaSlider : MonoBehaviour
{
    [Header("UI e Messaggi")]
    public GameObject interactionUI; // Il tuo Canvas "Premi E"

    [Header("Impostazioni Porta")]
    public MonoBehaviour scriptPorta; // Trascina qui lo script della tua porta

    private bool isPlayerNearby = false;
    private bool isOpen = false;

    void Start()
    {
        if (interactionUI != null) interactionUI.SetActive(false);
    }

    void Update()
    {
        if (isPlayerNearby && Input.GetKeyDown(KeyCode.E))
        {
            TogglePorta();
        }
    }

    void TogglePorta()
    {
        isOpen = !isOpen;

        // Qui cerchiamo di dire allo script della porta cosa fare.
        // Se il tuo script ha una funzione per aprire/chiudere, la chiamiamo qui.
        if (isOpen)
            scriptPorta.SendMessage("ApriPorta", SendMessageOptions.DontRequireReceiver);
        else
            scriptPorta.SendMessage("ChiudiPorta", SendMessageOptions.DontRequireReceiver);

        // Se lo script della porta usa solo lo slider, 
        // dovrai dirmi come si chiama lo script per collegarli meglio.
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
