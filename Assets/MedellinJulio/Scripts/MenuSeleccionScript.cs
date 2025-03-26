using UnityEngine;
using UnityEngine.SceneManagement; // Para cambiar la escena
using UnityEngine.UI; // Para UI (si es necesario mostrar algo en la pantalla)

public class MenuSeleccionScript : MonoBehaviour
{
    public GameObject object1; // El primer objeto con el que se puede interactuar
    public GameObject object2; // El segundo objeto con el que se puede interactuar
    public float interactionDistance = 2f; // Distancia máxima para interactuar con los objetos
  

    private void Update()
    {
        // Verificar si el jugador está mirando y cerca de alguno de los dos objetos
        if (Input.GetKeyDown(KeyCode.E)) // Tecla para interactuar (puedes cambiarla)
        {
            if (IsPlayerLookingAtObject(object1) && IsPlayerNearObject(object1))
            {
                SceneZombies();
            }
            else if (IsPlayerLookingAtObject(object2) && IsPlayerNearObject(object2))
            {
                SceneCampoTiro();
            }
        }
    }

    // Verifica si el jugador está mirando hacia el objeto
    private bool IsPlayerLookingAtObject(GameObject targetObject)
    {
        RaycastHit hit;
        Vector3 directionToObject = targetObject.transform.position - transform.position;
        if (Physics.Raycast(transform.position, directionToObject.normalized, out hit))
        {
            // Compara si el objeto tocado es el que estamos buscando
            if (hit.collider.gameObject == targetObject)
            {
                return true;
            }
        }
        return false;
    }

    // Verifica si el jugador está cerca del objeto
    private bool IsPlayerNearObject(GameObject targetObject)
    {
        float distance = Vector3.Distance(transform.position, targetObject.transform.position);
        return distance <= interactionDistance;
    }

    // Cargar la siguiente escena
    public void SceneCampoTiro()
    {
        SceneManager.LoadScene("PracticaDeTiroNOVR");
    }

    public void SceneZombies()
    {
        SceneManager.LoadScene("DUNGEON");
    }
}
