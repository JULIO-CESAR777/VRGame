using System.Collections.Generic;
using UnityEngine;
using System.Collections;
public class TargetSpawner : MonoBehaviour
{
    // List of the posible locations of the targets
    public List<Transform> spawnPoints;
    // Number of the targets that have to be in the scene
    public int numberOfTargets = 5;
    // The prefab of the target
    public GameObject targetPrefab;
    // The list of the targets in the scene
    private List<GameObject> targets = new List<GameObject>();

    public void SpawnTargets()
    {
        // A copy of the posible spawns
        List<Transform> availableSpawnPoints = new List<Transform>(spawnPoints); 

        // The creation of the targets
        for (int i = 0; i < numberOfTargets; i++)
        {
            // It chooses one of the posible spawn points
            int randomIndex = Random.Range(0, availableSpawnPoints.Count);
            // Save the position in the variable
            Transform spawnPoint = availableSpawnPoints[randomIndex];

            // Creates the target and it's been added to the list of targets
            GameObject newTarget = Instantiate(targetPrefab, spawnPoint.position, Quaternion.Euler(90f, 90f, 0f));
            targets.Add(newTarget);

            // It removes the spawnpoint at the posible locations
            availableSpawnPoints.RemoveAt(randomIndex);
        }
    }

    public void OnTargetDestroy(GameObject target)
    {
        // Remove the target from the list and erase the object 
        targets.Remove(target);
        Destroy(target);

        // Spawn a new target
        SpawnNewTarget();
    }
    
    private void SpawnNewTarget()
    {
        // Checking if we have less targets that we have to
        if (targets.Count < numberOfTargets)
        {
            // A copy of the posible spawns
            List<Transform> availableSpawnPoints = new List<Transform>(spawnPoints);
            // Eliminating positions
            foreach (var target in targets)
            {
                // We eliminate all the positions that we have already in the scene
                availableSpawnPoints.RemoveAll(spawnPoint => spawnPoint.position == target.transform.position);
            }

            if (availableSpawnPoints.Count > 0)
            {
                // It chooses one of the posible spawn points
                int randomIndex = Random.Range(0, availableSpawnPoints.Count);
                // Save the position in the variable
                Transform spawnPoint = availableSpawnPoints[randomIndex];

                // Creates the target and it's been added to the list of targets
                GameObject newTarget = Instantiate(targetPrefab, spawnPoint.position, Quaternion.Euler(90f, 90f, 0f));
                targets.Add(newTarget);
            }
        }
    }


}
