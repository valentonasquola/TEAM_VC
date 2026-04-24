using UnityEngine;

public class MainMenuUI : MonoBehaviour
{
    public void Show()
    {
        gameObject.SetActive(true);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }

    public void OnStartButtonClicked()
    {
        GameManager.Instance.SetGameState(GameManager.GameState.Gameplay);
        UIManager.Instance.ShowGameUI();
    }
    public void OnExitButtonClicked()
    {
        Application.Quit();
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}
