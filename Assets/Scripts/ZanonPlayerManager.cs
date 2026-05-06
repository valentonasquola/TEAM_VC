 using UnityEngine;
using UnityEngine.InputSystem;

public class ZanonPlayerManager : MonoBehaviour
{
    public static ZanonPlayerManager Instance { get; private set; }
    private AttitudeSensor attitudeSensor = null;

    [SerializeField] private InputActionReference touchPositionReference;

    public Vector2 currentMoveInput;

    private void Awake()
    {
        Instance = this;
        currentMoveInput = Vector2.zero;
    }

    private void Update()
    {
        attitudeSensor = AttitudeSensor.current;
        if (attitudeSensor != null)
        {
            if (!attitudeSensor.enabled)
            {
                InputSystem.EnableDevice(attitudeSensor);
            }
        }
    }

    public bool IsGyroEnabled()
    {
        return attitudeSensor != null;
    }

    public Quaternion GetGyroAttitude()
    {
        if (attitudeSensor != null)
        {
            return attitudeSensor.attitude.ReadValue();
        }
        else
        {
            return Quaternion.identity;
        }
    }

    public void OnTouchPress(InputValue inputValue)
    {
        Debug.Log("L'utente ha premuto lo schermo");
        Vector2 touchPosition = touchPositionReference.action.ReadValue<Vector2>();
        Debug.Log("In posizione: " + touchPosition);
    }

    private void OnMove(InputValue value)
    {
        Vector2 moveInput = value.Get<Vector2>();
        Debug.Log("Move Input: " + moveInput);
        currentMoveInput = moveInput;
    }

    public void OnOpen(InputValue value)
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, 2f);

        foreach (Collider hit in colliders)
        {
            // Cerca il componente ApriPorta sull'oggetto colpito o sui suoi genitori
            ApriPorta porta = hit.GetComponentInParent<ApriPorta>();

            if (porta != null)
            {
                // Qui chiama la funzione che apre la porta nel tuo script
                // Supponendo che la funzione si chiami "Interagisci" o simile
                porta.Interact();

                // Se vuoi aprire solo la più vicina ed uscire dal ciclo:
                break;
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, 2f);
    }
}

