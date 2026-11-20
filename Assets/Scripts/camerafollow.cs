using UnityEngine;
using UnityEngine.Rendering;
using System.Collections;
using AK.Wwise;


public class camerafollow : MonoBehaviour
{
    public float smoothTime;
    public Vector3 offset;
    public Vector3 Velocity = Vector3.zero;

    public Vector3 desiredPosition;
    public Vector3 desiredPosition2;

    Coroutine cameraMove;

    public AK.Wwise.Event testsound1;

    Camera camera;

    public GameObject triggerbox1;
    public GameObject triggerbox2;

    public PlayerController playerController;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        camera = GetComponent<Camera>();

    }

    // Update is called once per frame
    void Update()
    {

        if (playerController.nextHoverObject.name == "CameraTriggerbox")
        {
            transform.position = new Vector3(0, -5, -10);
            triggerbox1.SetActive(false);
            triggerbox2.SetActive(true);
        }

        if (playerController.nextHoverObject.name == "Minimize" && Input.GetMouseButtonDown(0))
        {
            transform.position = new Vector3(0, 2.55f, -10);
            triggerbox1.SetActive(true);
            triggerbox2.SetActive(false);

            testsound1.Post(gameObject);
        }

        if (playerController.nextHoverObject.name == "CameraTriggerbox 2")
        {
            transform.position = new Vector3(0, 2.55f, -10);
            triggerbox1.SetActive(true);
            triggerbox2.SetActive(false);
        }
    }

}