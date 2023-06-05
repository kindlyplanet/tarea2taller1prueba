using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public GameObject gameOverMenu;
    public GameObject player;

    private void Start()
    {
        gameOverMenu.SetActive(false);
    }

    public void GameOverMenu()
    {
        player.SetActive(false); // Desactiva el jugador para detener su movimiento
        gameOverMenu.SetActive(true); // Muestra el men� de Game Over
        Time.timeScale = 0f; // Pausa el tiempo del juego
    }

    public void RestartLevel()
    {
        Time.timeScale = 1f; // Reanuda el tiempo del juego
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // Reinicia el nivel actual
    }

    public void GoToMainMenu()
    {
        Time.timeScale = 1f; // Reanuda el tiempo del juego
        SceneManager.LoadScene("MainMenu"); // Carga la escena del men� principal
    }

    public void QuitGame()
    {
        Debug.Log("Quitting game...");
        Application.Quit(); // Sale de la aplicaci�n
    }
}
