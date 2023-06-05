using UnityEngine;

public class GrapplingHook : MonoBehaviour
{
    public GameObject grapplingHookPrefab;
    public Transform shootPoint;
    public float hookSpeed = 10f;
    public float maxDistance = 10f;

    private GameObject currentHook;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (currentHook != null)
            {
                Destroy(currentHook);
            }

            currentHook = Instantiate(grapplingHookPrefab, shootPoint.position, Quaternion.identity);
            currentHook.GetComponent<Rigidbody2D>().velocity = shootPoint.right * hookSpeed;
        }

        if (Input.GetMouseButton(0) && currentHook != null)
        {
            if (Vector2.Distance(transform.position, currentHook.transform.position) > maxDistance)
            {
                Destroy(currentHook);
            }
        }

        if (Input.GetMouseButtonUp(0) && currentHook != null)
        {
            Destroy(currentHook);
        }
    }
}
