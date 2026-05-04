using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance { get; private set; }
    [SerializeField] private MainMenuUI mainMenuUI;
    [SerializeField] private GameUI gameUI;
    [SerializeField] private GameOverUI gameOverUI;

    public void HideAllUI()
    {
        mainMenuUI.Hide();
        gameUI.Hide();
        gameOverUI.Hide();
    }

    void Awake()
    {
        Instance = this;
    }

    public void ShowMainMenu()
    {
        HideAllUI();
        mainMenuUI.Show();
    }

    public void ShowGameUI()
    {
        HideAllUI();
        SceneManager.LoadScene("all_objects");
    }

    public void ShowGameOverUI()
    {
        HideAllUI();
        gameOverUI.Show();
    }
}
