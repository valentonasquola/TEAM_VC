using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [Header("Movement Settings")]
    [SerializeField, Range(1f, 20f)] private float moveSpeed = 5f;

    void Update()
    {
        // Movimento
        Vector2 currentInput = ZanonPlayerManager.Instance.currentMoveInput;
        if (currentInput == Vector2.zero) return;

        Vector3 moveDirection = new Vector3(currentInput.x, 0f, currentInput.y);
        transform.Translate(moveDirection * (moveSpeed * Time.deltaTime));
    }
}

