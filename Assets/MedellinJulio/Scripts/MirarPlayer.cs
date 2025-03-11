using UnityEngine;

public class MirarPlayer : MonoBehaviour
{
    public Transform player;  // Referencia al transform del jugador.

    void Update()
    {
        if (player != null)
        {
            // Obt�n la direcci�n hacia el jugador pero invertida.
            Vector3 direction = transform.position - player.position;
            direction.y = 0;  // No queremos que rote en el eje Y (solo en el plano horizontal).

            // Si la direcci�n no es cero, rota hacia el jugador.
            if (direction != Vector3.zero)
            {
                Quaternion rotation = Quaternion.LookRotation(direction);
                transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * 5f);  // Ajusta la velocidad de rotaci�n con el par�metro 5f.
            }
        }
    }
}
