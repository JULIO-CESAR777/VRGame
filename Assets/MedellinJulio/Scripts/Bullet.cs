using UnityEngine;

public class Bullet : MonoBehaviour
{


    private void OnCollisionEnter(Collision objetoGolpeado)
    {
        if (objetoGolpeado.gameObject.CompareTag("Zommbie"))
        {
            print("Zombie Golpeado");
            objetoGolpeado.gameObject.GetComponent<Zombie>().TakeDamage(25);
            Destroy(gameObject);
        }
    }
}
