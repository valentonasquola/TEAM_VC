using UnityEngine;
using UnityEngine.SceneManagement; // Fondamentale per cambiare scena

public class PlayerCollision : MonoBehaviour
{
    // Usa "OnCollisionEnter" per fisica classica, "OnTriggerEnter" per Trigger
    private void OnCollisionEnter(Collision collision)
    {
        // Controlla se l'oggetto toccato ha il tag "Enemy"
        if (collision.gameObject.CompareTag("Enemy"))
        {
            // Carica la scena Game Over. Sostituisci "GameOverScene" col nome della tua scena
            SceneManager.LoadScene("GameOver");
        }
    }
}
