using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverUI : MonoBehaviour
{
    public void Show()
    {
        gameObject.SetActive(true);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }
    public void OnRestartButtonClicked()
    {
        GameManager.Instance.SetGameState(GameManager.GameState.Gameplay);
        SceneManager.LoadScene("all_objects");
    }

    public void OnMainMenuButtonClicked()
    {
        GameManager.Instance.SetGameState(GameManager.GameState.MainMenu);
        UIManager.Instance.ShowMainMenu();
    }
}
