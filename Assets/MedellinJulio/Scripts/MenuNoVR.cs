using NaughtyAttributes;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI; // Para trabajar con UI

public class MenuNoVR : MonoBehaviour
{
    public GameObject pauseMenuUI;  // El men� de pausa
    public Button resumeButton;     // Bot�n de reanudar
    public Button SalirButton;      // Bot�n de salir
    public Button MenuButton;       // Bot�n para el men� principal
    public Button SceneZombiesButton;  // Bot�n para la escena de zombies
    public Button SceneTiroButton;   // Bot�n para la escena de tiro
   

    private bool isPaused = false; // Para verificar si el juego est� en pausa

    void Start()
    {
        // Aseg�rate de que el men� de pausa est� oculto al inicio
        pauseMenuUI.SetActive(false);


        resumeButton.onClick.AddListener(ResumeGame);
        SalirButton.onClick.AddListener(QuitGame);
        MenuButton.onClick.AddListener(SceneMenuPrincipal);
        SceneZombiesButton.onClick.AddListener(SceneZombies);
        SceneTiroButton.onClick.AddListener(SceneTiro);

        if (SceneManager.GetActiveScene().name == "DUNGEON")
        {
          
           SceneTiroButton.gameObject.SetActive(false);

        }

        if (SceneManager.GetActiveScene().name == "PracticaDeTiroNOVR")
        {

            SceneZombiesButton.gameObject.SetActive(false);  // Aqu� desactivamos el bot�n

        }
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
    public void PauseGame()
    {
        isPaused = true;
        Time.timeScale = 0f; // Detiene el tiempo (pausa el juego)
        pauseMenuUI.SetActive(true); // Muestra el men� de pausa
        Cursor.visible = true;
    }

    // Funci�n para reanudar el juego
    public void ResumeGame()
    {
        Debug.Log("Resumirentrar");
        isPaused = false;
        Time.timeScale = 1f; // Reanuda el tiempo
        pauseMenuUI.SetActive(false); // Oculta el men� de pausa
        Cursor.visible = false;
        Debug.Log("Resumir");
        
    }

    // Funci�n para reiniciar la escena actual
   

    // Funci�n para salir del juego (puedes cargar otra escena si lo deseas)
    public void QuitGame()
    {
         Application.Quit(); // Sale del juego en una compilaci�n final
        Debug.Log("Salir");
    }


    public void SceneZombies()
    {
        Debug.Log("Zombies");
        SceneManager.LoadScene("DUNGEON");
        
    }

    public void SceneTiro()
    {
        Debug.Log("Tiro");
        SceneManager.LoadScene("PracticaDeTiroNOVR");
       
    }
    public void SceneMenuPrincipal()
    {
        Debug.Log("Principal");
        SceneManager.LoadScene("MenuSeleccion");
       
    }
}
