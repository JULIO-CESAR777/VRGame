using NaughtyAttributes;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI; // Para trabajar con UI

public class MenuNoVR : MonoBehaviour
{
    public GameObject pauseMenuUI;  // El menú de pausa
    public Button resumeButton;     // Botón de reanudar
    public Button SalirButton;      // Botón de salir
    public Button MenuButton;       // Botón para el menú principal
    public Button SceneZombiesButton;  // Botón para la escena de zombies
    public Button SceneTiroButton;   // Botón para la escena de tiro
   

    private bool isPaused = false; // Para verificar si el juego está en pausa

    void Start()
    {
        // Asegúrate de que el menú de pausa está oculto al inicio
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

            SceneZombiesButton.gameObject.SetActive(false);  // Aquí desactivamos el botón

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

    // Función para pausar el juego
    public void PauseGame()
    {
        isPaused = true;
        Time.timeScale = 0f; // Detiene el tiempo (pausa el juego)
        pauseMenuUI.SetActive(true); // Muestra el menú de pausa
        Cursor.visible = true;
    }

    // Función para reanudar el juego
    public void ResumeGame()
    {
        Debug.Log("Resumirentrar");
        isPaused = false;
        Time.timeScale = 1f; // Reanuda el tiempo
        pauseMenuUI.SetActive(false); // Oculta el menú de pausa
        Cursor.visible = false;
        Debug.Log("Resumir");
        
    }

    // Función para reiniciar la escena actual
   

    // Función para salir del juego (puedes cargar otra escena si lo deseas)
    public void QuitGame()
    {
         Application.Quit(); // Sale del juego en una compilación final
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
