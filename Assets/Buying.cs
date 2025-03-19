using UnityEngine;

public class Buying : MonoBehaviour
{
    [SerializeField] private Transform middleScreen;
    private float raycastDistance = 2f;

    //Text
    [SerializeField] private GameObject bulletText;
    private void Update()
    {

        Debug.DrawRay(middleScreen.position, middleScreen.forward * raycastDistance, Color.green);


        RaycastHit hit;
        if (Physics.Raycast(middleScreen.position, middleScreen.forward, out hit, raycastDistance))
        {
            var hitBody = hit.transform.GetComponent<Rigidbody>();
            if (hitBody != null)
            {
                Debug.Log("sexo?");
                bulletText.SetActive(true);
                //hitBody.GetComponent<Target>()?.OnHitTarget();
            }
            else
            {
                Debug.Log("sexo 24");
                bulletText.SetActive(false);
            }
            
        }
    }
}
