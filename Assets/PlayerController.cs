using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Vector3 mousePos;

    RaycastHit2D raycastHit2D;
    Transform preHoverObject, nextHoverObject;

    public bool mouseDown;

    public Wallet wallet;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        pointAndClick();

        if (Input.GetMouseButtonDown(0))
        {
            mouseDown = true;
            Debug.Log(mouseDown);
        }
        else
        {
            mouseDown = false;
        }

    }


    void pointAndClick()
    {
        //Getting the Co-ords of the mousePosition in game
        mousePos = Input.mousePosition;
        Ray mouseRay = Camera.main.ScreenPointToRay(mousePos);

        preHoverObject = nextHoverObject;

        //Get a raycast and save the object in 'nextHoverObject'
        raycastHit2D = Physics2D.Raycast(mouseRay.origin, mouseRay.direction);
        nextHoverObject = raycastHit2D ? raycastHit2D.collider.transform : null;

        //if we did hit something
        if (nextHoverObject)
        {
            //Set Cursor mode to hovering

            nextHoverObject.GetComponent<SpriteRenderer>().color = Color.red;

            if (Input.GetMouseButtonDown(0))
            {
                SellItem();
            }



            //Check if the object hovered before and after are equal to each other, if not, change to normal cursor
            if (preHoverObject && nextHoverObject && preHoverObject.GetEntityId() != nextHoverObject.GetEntityId())
            {
                preHoverObject.GetComponent<SpriteRenderer>().color = Color.white;
            }
        }

        else
        {
            if (preHoverObject)
            {
                preHoverObject.GetComponent<SpriteRenderer>().color = Color.white;


            }

        }
    }

        public void SellItem()
        {
        Destroy(nextHoverObject.gameObject);

        wallet.walletTotal += 1;
        }

    }

