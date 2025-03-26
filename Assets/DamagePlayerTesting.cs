using UnityEngine;

public class DamagePlayerTesting : MonoBehaviour
{
    private Collider triggerCollider;  // Variable para almacenar el objeto que entra en el trigger

    // Funci�n que se llama cuando otro collider entra en el trigger
    private void OnTriggerEnter(Collider other)
    {
        // Almacena el collider del objeto que entra en el trigger
        triggerCollider = other;
    }

    // Funci�n p�blica que har� el da�o al jugador (esta se llamar� desde el evento de la animaci�n)
    public void da�ando()
    {
        // Verifica si el triggerCollider es v�lido y si el objeto es el jugador
        if (triggerCollider != null && triggerCollider.gameObject.CompareTag("Player"))
        {
            GameManager.instance.DmgPlayer(25);  // Llama al m�todo de da�o en el GameManager
            Debug.Log("da�ando al jugador");
        }
        else
        {
            Debug.Log("No se ha producido una colisi�n con el jugador.");
        }
    }
}
