using UnityEngine;

public class DamagePlayerTesting : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            GameManager.instance.DmgPlayer(25);
            Debug.Log("danio");
        }
    }
}
