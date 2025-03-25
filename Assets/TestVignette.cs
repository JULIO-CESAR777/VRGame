using System.Collections;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class TestVignette : MonoBehaviour
{
    public float intensity = 0;

    private Volume _volume;  // El volumen con el efecto Vignette
    private Vignette _vignette;

    private void Start()
    {
        // Obtener el componente Volume del objeto en el que se encuentra el script
        _volume = GetComponent<Volume>();

        // Obtener el efecto Vignette dentro del perfil del Volume
        if (_volume.profile.TryGet<Vignette>(out _vignette))
        {
            // Si se encuentra, puedes empezar a modificar las propiedades del efecto
            Debug.Log("Efecto Vignette encontrado y listo para modificar.");
        }
        else
        {
            Debug.LogError("No se encontró el efecto Vignette en el perfil del Volume.");
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q)) {
            StartCoroutine(TakeDmg());
        }
    }

    public IEnumerator TakeDmg() {

        // Definir la intensidad inicial
        float intensity = 0.4f;

        // Habilitar el Vignette y establecer su intensidad
        _vignette.active = true;
        _vignette.intensity.value = intensity;

        // Esperar 0.4 segundos
        yield return new WaitForSeconds(0.4f);

        // Reducir gradualmente la intensidad hasta llegar a 0
        while (intensity > 0)
        {
            intensity -= 0.01f;

            if (intensity < 0)
                intensity = 0;

            _vignette.intensity.value = intensity;

            // Esperar 0.1 segundos entre cada decremento
            yield return new WaitForSeconds(0.1f);
        }

        // Desactivar el Vignette una vez que la intensidad llega a 0
        _vignette.active = false;
        yield break;

    }


}
