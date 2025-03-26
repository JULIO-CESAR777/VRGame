using UnityEngine;
using UnityEngine.SceneManagement;
public class CanvasHide : MonoBehaviour
{
    public GameObject canvasUi;
    public TargetSpawner spawner;


    public void EsconderCanvas()
    {
        // Verificar si canvasUi y spawner están asignados antes de intentar usarlos
       
        spawner.SpawnTargets(); 
        canvasUi.SetActive(false);
       
    }

    public void CerrarJuego() { 
        Application.Quit();
    }

    public void SceneZombiesVR()
    {
        SceneManager.LoadScene("Dungeon VR");
    }

    public void SceneTiroVR()
    {
        SceneManager.LoadScene("PracticaDeTiroVR");
    }


    public void SceneMenuPrincipalVR()
    {
        SceneManager.LoadScene("MenuSeleccion");
    }
}
