using UnityEngine;
using UnityEngine.Rendering;


public class camerafollow : MonoBehaviour
{
    private float smoothTime = 0.5f;
    private Vector3 velocity = Vector3.zero;

    Camera camera;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        camera = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 worldPosition = camera.ScreenToWorldPoint(Input.mousePosition);
        Debug.Log(worldPosition);

        if (worldPosition.x >= 7 || worldPosition.x <= -7 && transform.position.x == -2|| worldPosition.y >= 0 || worldPosition.y <= -3)
        { 
        transform.position = Vector3.SmoothDamp(transform.position, worldPosition, ref velocity, smoothTime);
        }

        MouseCamLock();

    }

    void MouseCamLock()
    {
        if (transform.position.x > 2)
        {
            transform.position = new Vector3(2, transform.position.y, transform.position.z);
        }
        if (transform.position.y > 1)
        {
            transform.position = new Vector3(transform.position.x, 1, transform.position.z);
        }
        if (transform.position.x < -2)
        {
            transform.position = new Vector3(-2, transform.position.y, transform.position.z);
        }
        if (transform.position.y < -4)
        {
            transform.position = new Vector3(transform.position.x, -4, transform.position.z);
        }
        if (transform.position.z > -10)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -10);
        }

    }


}
