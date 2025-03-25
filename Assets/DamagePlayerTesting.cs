using UnityEngine;

public class DamagePlayerTesting : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.tag);
        if (other.gameObject.tag == "Player")
        {
            GameManager.instance.DmgPlayer(25);
        }
    }
}
