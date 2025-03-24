using UnityEngine;

public class medkit : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player") {
            GameManager.instance.HealPlayer(25);
            Destroy(gameObject);
        }
    }
}
