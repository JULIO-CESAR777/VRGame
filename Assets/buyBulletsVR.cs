using UnityEngine;

public class buyBulletsVR : MonoBehaviour
{
    public void BuyBullets() {
        GameManager.instance.BuyBullets(100, 5);
    }
}
