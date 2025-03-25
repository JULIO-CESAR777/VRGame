using UnityEngine;

public class buyBullets : MonoBehaviour
{

    public void Buy() {
        GameManager.instance.BuyBullets(100, 5);
    }
}
