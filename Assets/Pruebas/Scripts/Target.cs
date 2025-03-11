using System;
using UnityEngine;
using UnityEngine.UI; // Necesario para el marcador si usas UI.Text o TextMeshPro
using TMPro; // Para usar TextMeshPro si es el caso
using UnityEngine.Rendering.Universal;
using System.Collections;

public class Target : MonoBehaviour
{
    public TargetSpawner spawner;
    public WesternManager westernManager;
    public GameObject numeroFlotantePrefab; // Prefab para el número flotante
    private GameObject numeroFlotanteInstancia; // Variable para almacenar la instancia del número flotante
    private MeshRenderer meshRenderer;
    private MeshCollider meshCollider;
    private float fadeDuration = 1f; // Duration for fading effect
    private float moveSpeed = 1f; // Speed of movement
    private TextMeshPro meshRendererNumero;

    private void Awake()
    {
        spawner = GameObject.Find("SpawnerTiros").GetComponent<TargetSpawner>();
        westernManager = GameObject.Find("WesternManager").GetComponent<WesternManager>();
        meshRenderer = GetComponent<MeshRenderer>();
        meshCollider = GetComponent<MeshCollider>();
        meshRendererNumero = numeroFlotantePrefab.GetComponent<TextMeshPro>();
    }

    public void OnHitTarget()
    {
        // Sumar los puntos
        westernManager.SumarPuntos();
        SpawnNumeroFlotante();
    }

    public void SpawnNumeroFlotante()
    {
        meshRenderer.enabled = false;
        meshCollider.enabled = false;
        // Instanciar el número flotante y guardarlo en la variable
        numeroFlotanteInstancia = Instantiate(numeroFlotantePrefab, gameObject.transform.position, Quaternion.Euler(0f,-90f,0f));

        // Make it visible
        meshRenderer = numeroFlotanteInstancia.GetComponent<MeshRenderer>();
        meshRenderer.enabled = true;

        // Start moving up and fading out
        StartCoroutine(MoveAndFadeUp());

        // Llamar a la función para destruir el número flotante después de 3 segundos
        Invoke("DestruirNumeroYTarget", 1f);
    }

    public void DestruirNumeroYTarget()
    {
        // Destruir la instancia del número flotante que se creó
        if (numeroFlotanteInstancia != null)
        {
            Destroy(numeroFlotanteInstancia);
        }
        // Llamar al método de destrucción del spawner
        spawner.OnTargetDestroy(gameObject);
    }

    private IEnumerator MoveAndFadeUp()
    {
        float timeElapsed = 0f;

        // Move the number up and fade it out
        while (timeElapsed < fadeDuration)
        {
            // Move up
            numeroFlotanteInstancia.transform.Translate(Vector3.up * moveSpeed * Time.deltaTime);

            // Fade out by modifying alpha
            float alpha = Mathf.Lerp(1, 0f, timeElapsed / fadeDuration);
            meshRendererNumero.color = new Color(meshRendererNumero.color.r, meshRendererNumero.color.g, meshRendererNumero.color.b, meshRendererNumero.color.a);

            timeElapsed += Time.deltaTime;
            yield return null;
        }

        // Ensure the alpha is fully faded to 0
        meshRendererNumero.material.color = new Color(meshRendererNumero.color.r, meshRendererNumero.color.g, meshRendererNumero.color.b, 0f);
    }
}
