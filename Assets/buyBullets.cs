using UnityEngine;

public class buyBullets : MonoBehaviour
{
    public void Buy() {
        GameManager.instance.losePoints(100);
    }
}
