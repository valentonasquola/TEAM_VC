using UnityEngine;

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
        UIManager.Instance.ShowGameUI();
    }

    public void OnMainMenuButtonClicked()
    {
        GameManager.Instance.SetGameState(GameManager.GameState.MainMenu);
        UIManager.Instance.ShowMainMenu();
    }
}
