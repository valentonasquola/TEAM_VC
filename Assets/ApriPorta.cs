using UnityEngine;

public class ApriPorta : MonoBehaviour
{
    [Header("Configuration")]
    [SerializeField] private bool isAutomated = false;
    [SerializeField] private string playerTag = "Player";

    [Header("References")]
    [Tooltip("The pivot object that actually rotates.")]
    [SerializeField] private Transform doorPivot;
    [SerializeField] private Vector3 rotationAxis = Vector3.up;

    [Header("Animation Settings")]
    [SerializeField] private float closedAngle = 0f;
    [SerializeField] private float openAngle = 90f;
    [SerializeField] private float rotationSpeed = 4f;
    [SerializeField] private AnimationCurve movementCurve = AnimationCurve.EaseInOut(0f, 0f, 1f, 1f);
    [SerializeField, Range(0, 1)] private float animationProgress = 0f;

    private bool isOpen = false;
    private bool isAnimating = false;

    private void Update()
    {
        if (!isAnimating) return;

        float target = isOpen ? 1f : 0f;
        animationProgress = Mathf.MoveTowards(animationProgress, target, rotationSpeed * Time.deltaTime);

        ApplyRotation();

        if (!Mathf.Approximately(animationProgress, target)) return;

        isAnimating = false;
    }

    private void ApplyRotation()
    {
        if (doorPivot == null) return;

        float curveValue = movementCurve.Evaluate(animationProgress);
        float currentYAngle = Mathf.Lerp(closedAngle, openAngle, curveValue);
        Vector3 rot = rotationAxis.normalized;
        doorPivot.localRotation = Quaternion.Euler(rot * currentYAngle);
    }

    private void OnValidate()
    {
        ApplyRotation();
    }

    public void Interact()
    {
        // Se è automatica si apre da sola
        if (isAutomated) return;

        isOpen = !isOpen;
        isAnimating = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.name);
        // Se non è automatica, vuol dire che deve aprirsi con un'interazione diversa
        if (!isAutomated) return;

        // Controllo che sia impostato un tag
        if (string.IsNullOrEmpty(playerTag)) return;

        // Deve aprirsi solo quando il player si avvicina alla porta
        if (!other.CompareTag(playerTag)) return;

        isOpen = true;
        isAnimating = true;
    }

    private void OnTriggerExit(Collider other)
    {
        // Se non è automatica, vuol dire che deve chiudersi con un'interazione diversa
        if (!isAutomated) return;

        // Controllo che sia impostato un tag
        if (string.IsNullOrEmpty(playerTag)) return;

        // Deve chiudersi solo quando il player si avvicina alla porta
        if (!other.CompareTag(playerTag)) return;

        isOpen = false;
        isAnimating = true;
    }
}


