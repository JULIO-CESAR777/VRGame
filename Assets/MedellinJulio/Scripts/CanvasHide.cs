using UnityEngine;

public class CanvasHide : MonoBehaviour
{
    public GameObject canvasUi;
    public TargetSpawner spawner;


    public void EsconderCanvas()
    {
        // Verificar si canvasUi y spawner est�n asignados antes de intentar usarlos
       
        spawner.SpawnTargets(); 
        canvasUi.SetActive(false);
       
    }

    public void CerrarJuego() { 
        Application.Quit();
    }
}
