using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab; // Prefab del enemigo a spawnear
    public Transform[] spawnPoints; // Puntos donde aparecerán los enemigos
    public int enemyCount = 4; // Cantidad de enemigos a spawnear
    public float spawnDelay = 2f; // Tiempo de espera entre spawns
    public float detectionRadius = 4f; // Distancia para detectar al jugador

    private bool hasSpawned = false; // Evita que se generen múltiples veces
    private GameObject player; // Referencia al jugador

    private void Start()
    {
        // Busca automáticamente al jugador por su tag "Player"
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !hasSpawned) // Si el jugador toca el trigger
        {
            StartCoroutine(SpawnEnemiesInfinite());
            hasSpawned = true; // Asegura que solo se active una vez
        }
    }

   

    // Verifica si el jugador está dentro del radio de detección
    private bool IsPlayerNearSpawnPoint(Transform spawnPoint)
    {
        if (player == null) return false;

        float distance = Vector3.Distance(player.transform.position, spawnPoint.position);
        return distance <= detectionRadius; // Si el jugador está dentro del rango de ese punto
    }

    private Transform GetAvailableSpawnPoint()
    {
        // Lista de puntos de spawn disponibles
        List<Transform> availableSpawnPoints = new List<Transform>();

        // Filtra los puntos de spawn donde el jugador no está cerca
        foreach (Transform spawnPoint in spawnPoints)
        {
            if (!IsPlayerNearSpawnPoint(spawnPoint))
            {
                availableSpawnPoints.Add(spawnPoint);
            }
        }

        // Si hay puntos disponibles, devuelve uno aleatorio
        if (availableSpawnPoints.Count > 0)
        {
            return availableSpawnPoints[Random.Range(0, availableSpawnPoints.Count)];
        }

        // Si no hay puntos disponibles, devuelve null
        return null;
    }

    //spawneo infinito ---------------------------------------


    private IEnumerator SpawnEnemiesInfinite()
     {
         while (true) // Bucle infinito
         {
            Transform spawnPoint = GetAvailableSpawnPoint();

            if (spawnPoint != null) // Si encontramos un punto disponible
            {
                // Instancia el enemigo en el punto seleccionado
                Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
                Debug.Log("Enemigo generado.");
            }
            else
            {
                Debug.Log("No hay puntos disponibles para spawn.");
            }

            // Espera antes de generar el siguiente enemigo
            yield return new WaitForSeconds(spawnDelay);
        }
    }


    // Spawnea enemigos con un delay, asegurándose de que el jugador no esté cerca
    /*
    private IEnumerator SpawnEnemiesWithCheck()
    {
        int spawned = 0;

        while (spawned < enemyCount)
        {
              Transform spawnPoint = GetAvailableSpawnPoint();

            if (spawnPoint != null) // Si encontramos un punto disponible
            {
                // Instancia el enemigo en el punto seleccionado
                Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
                Debug.Log("Enemigo generado.");
            }
            else
            {
                Debug.Log("No hay puntos disponibles para spawn.");
            }

            // Espera antes de generar el siguiente enemigo
            yield return new WaitForSeconds(spawnDelay);
        }

        Debug.Log($"{enemyCount} enemigos generados.");
    }

    */


}
