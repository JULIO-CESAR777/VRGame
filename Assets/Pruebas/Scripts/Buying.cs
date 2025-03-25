using UnityEngine;

public class Buying : MonoBehaviour
{
    
    public Transform puntoClave;  // El punto hacia donde debes mirar
    public GameObject objeto;     // El objeto que debe aparecer
    public float rangoDistancia = 1f; // La distancia en la que el objeto aparece
    public float anguloVisibilidad = 15f; // �ngulo de visibilidad en grados (ejemplo: 30 grados hacia el punto)

    private void Start()
    {
        puntoClave = GameObject.Find("BuyBullets").transform;
        objeto = GameObject.Find("BulletBuyText");
        objeto.SetActive(false);
    }

    void Update()
    {
        // Verificar si est�s cerca del punto clave
        float distancia = Vector3.Distance(transform.position, puntoClave.position);

        // Calcular la direcci�n hacia el punto clave (considerando todos los ejes)
        Vector3 direccionHaciaPunto = (puntoClave.position - transform.position).normalized;

        // Calcular el �ngulo entre la direcci�n de visi�n del jugador (transform.forward) y la direcci�n hacia el punto clave
        float angulo = Vector3.Angle(transform.forward, direccionHaciaPunto);  // Calcula el �ngulo entre los dos vectores

        // Condici�n para hacer aparecer el objeto
        if (distancia <= rangoDistancia && angulo <= anguloVisibilidad)
        {
            // Si est� cerca y mirando hacia el punto, aparece el objeto
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
