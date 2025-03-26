using UnityEngine;

public class TrackText : MonoBehaviour
{
    public Transform jugador;  // Referencia al transform del jugador (puedes arrastrar el jugador en el inspector)

    void Update()
    {
        // Asegúrate de que el texto siempre mire hacia el jugador
        Vector3 direccionHaciaJugador = jugador.position - transform.position;
        direccionHaciaJugador.y = 0f;  // Ignorar la componente Y para que el texto solo gire horizontalmente
        transform.rotation = Quaternion.LookRotation(-direccionHaciaJugador);  // Ajustar la rotación para que mire hacia el jugador
    }
}
