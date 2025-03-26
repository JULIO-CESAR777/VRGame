using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI; // Para trabajar con UI

public class MenuNoVR : MonoBehaviour
{
    public GameObject pauseMenuUI; // El objeto del men� de pausa (UI)
    public Button resumeButton; // El bot�n para reanudar el juego
    public Button SalirButton; // El bot�n para reiniciar la escena
    public Button MenuButton; // El bot�n para salir al men� principal o cerrar el juego
    public Button SceneZombiesButton;
    private bool isPaused = false; // Para verificar si el juego est� en pausa

    void Start()
    {
        // Aseg�rate de que el men� de pausa est� oculto al inicio
        pauseMenuUI.SetActive(false);

        // Asignar las funciones de los botones
        resumeButton.onClick.AddListener(ResumeGame);
        SalirButton.onClick.AddListener(QuitGame);
        MenuButton.onClick.AddListener(SceneMenuPrincipal);
        SceneZombiesButton.onClick.AddListener(SceneZombies);
    }

    void Update()
    {
        // Si presionas la tecla "Escape", alternar entre pausar y reanudar el juego
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
                ResumeGame();
            else
                PauseGame();
        }
    }

    // Funci�n para pausar el juego
    void PauseGame()
    {
        isPaused = true;
        Time.timeScale = 0f; // Detiene el tiempo (pausa el juego)
        pauseMenuUI.SetActive(true); // Muestra el men� de pausa
    }

    // Funci�n para reanudar el juego
    void ResumeGame()
    {
        isPaused = false;
        Time.timeScale = 1f; // Reanuda el tiempo
        pauseMenuUI.SetActive(false); // Oculta el men� de pausa
    }

    // Funci�n para reiniciar la escena actual
   

    // Funci�n para salir del juego (puedes cargar otra escena si lo deseas)
    void QuitGame()
    {
         Application.Quit(); // Sale del juego en una compilaci�n final

    }


    public void SceneZombies()
    {
        SceneManager.LoadScene("DUNGEON");
    }

    public void SceneTiro()
    {
        SceneManager.LoadScene("PracticaDeTiroNOVR");
    }
    public void SceneMenuPrincipal()
    {
        SceneManager.LoadScene("MenuSeleccion");
    }
}
