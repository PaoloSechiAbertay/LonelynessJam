using UnityEngine;

public class camerafollow : MonoBehaviour
{
    private Vector3 offset = new Vector3(0f, 0f, 10f);
    private float smoothTime = 0.01f;
    private Vector3 velocity = Vector3.zero;

    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {


        Vector3 targetPosition = Input.mousePosition + offset;
        Debug.Log(targetPosition);
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);

        MouseCamLock();

    }

    void MouseCamLock()
    {
        if (transform.position.x > 2)
        {
            transform.position = new Vector3(2, transform.position.y, transform.position.z);
        }
        if (transform.position.y > 2)
        {
            transform.position = new Vector3(transform.position.x, 2, transform.position.z);
        }
        if (transform.position.x < -2)
        {
            transform.position = new Vector3(-2, transform.position.y, transform.position.z);
        }
        if (transform.position.y < -2)
        {
            transform.position = new Vector3(transform.position.x, -2, transform.position.z);
        }
        if (transform.position.z > -10)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -10);
        }

    }
}
