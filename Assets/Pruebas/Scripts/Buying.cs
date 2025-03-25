using UnityEngine;

public class Buying : MonoBehaviour
{
    
    public Transform puntoClave;  // El punto hacia donde debes mirar
    public GameObject objeto;     // El objeto que debe aparecer
    public float rangoDistancia = 1f; // La distancia en la que el objeto aparece
    public float anguloVisibilidad = 15f; // Ángulo de visibilidad en grados (ejemplo: 30 grados hacia el punto)

    private void Start()
    {
        puntoClave = GameObject.Find("BuyBullets").transform;
        objeto = GameObject.Find("BulletBuyText");
        objeto.SetActive(false);
    }

    void Update()
    {
        // Verificar si estás cerca del punto clave
        float distancia = Vector3.Distance(transform.position, puntoClave.position);

        // Calcular la dirección hacia el punto clave (considerando todos los ejes)
        Vector3 direccionHaciaPunto = (puntoClave.position - transform.position).normalized;

        // Calcular el ángulo entre la dirección de visión del jugador (transform.forward) y la dirección hacia el punto clave
        float angulo = Vector3.Angle(transform.forward, direccionHaciaPunto);  // Calcula el ángulo entre los dos vectores

        // Condición para hacer aparecer el objeto
        if (distancia <= rangoDistancia && angulo <= anguloVisibilidad)
        {
            // Si está cerca y mirando hacia el punto, aparece el objeto
            if (!objeto.activeSelf)
            {
                objeto.SetActive(true);
                if (Input.GetKeyDown(KeyCode.F))
                {
                    Debug.Log("compra balas");
                    GameManager.instance.BuyBullets(100, 5);
                }
            }
        }
        else
        {
            // Si no se cumplen las condiciones, el objeto se oculta
            if (objeto.activeSelf)
            {
                objeto.SetActive(false);
            }
        }
    }
}
