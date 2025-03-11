using TMPro;
using UnityEngine;

public class WesternManager : MonoBehaviour
{
    public TextMeshPro marcador;
    public int puntosPorDestruccion = 10;

    private int puntos = 0;
    private void Awake()
    {
        marcador = GameObject.Find("marcador").GetComponent<TextMeshPro>();

    }

    public void SumarPuntos()
    {

        puntos = puntosPorDestruccion + puntos; // Añadir los puntoss
        marcador.text = "Puntos: " + puntos; // Actualizar el marcador en la UI
        Debug.Log(marcador.text);
    }









}
