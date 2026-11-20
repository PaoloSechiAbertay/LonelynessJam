using UnityEngine;
using UnityEngine.Rendering;
using System.Collections;


public class camerafollow : MonoBehaviour
{
    public float smoothTime;
    public Vector3 offset;
    public Vector3 Velocity = Vector3.zero;

    public Vector3 desiredPosition;
    public Vector3 desiredPosition2;

    Coroutine cameraMove;

    Camera camera;

    public GameObject triggerbox1;
    public GameObject triggerbox2;

    public PlayerController playerController;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        camera = GetComponent<Camera>();

        desiredPosition = new Vector3(0, 2.55f, -10) + offset;
        desiredPosition2 = new Vector3(0, -5, -10) + offset;

    }

    // Update is called once per frame
    void Update()
    {

        if (playerController.nextHoverObject.name == "CameraTriggerbox")
        {
            StartCoroutine(cameraMove());

        }

        if (playerController.nextHoverObject.name == "CameraTriggerbox 2")
        {
            StartCoroutine(cameraMove2());

        }

        IEnumerator cameraMove()
        {
            yield return null;
            transform.position = Vector3.SmoothDamp(transform.position, desiredPosition, ref Velocity, smoothTime);
            Velocity = new Vector3(0, 10, 0);
            triggerbox1.SetActive(false);
            triggerbox2.SetActive(true);
        }

        IEnumerator cameraMove2()
        {
            yield return null;
            transform.position = Vector3.SmoothDamp(transform.position, desiredPosition2, ref Velocity, smoothTime);
            Velocity = new Vector3(0, 10, 0);
            triggerbox1.SetActive(true);
            triggerbox2.SetActive(false);
        }
    }

}