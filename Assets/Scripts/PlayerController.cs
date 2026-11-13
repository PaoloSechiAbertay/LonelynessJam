using JetBrains.Annotations;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

public class PlayerController : MonoBehaviour
{
    public Vector3 mousePos;

    RaycastHit2D raycastHit2D;
    Transform preHoverObject, nextHoverObject;

    public bool mouseDown;

    public TMP_Text descriptionText;
    public int number = 2;

    public Wallet wallet;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void Start()
    {
        GameObject[] gameObjectArray = GameObject.FindGameObjectsWithTag("Sellable");
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

            if (nextHoverObject.gameObject.tag == "Sellable")
            {
                nextHoverObject.GetComponent<SpriteRenderer>().color = Color.red;

                ShowText();

                if (Input.GetMouseButtonDown(0))
                {
                    SellItem();
                }
            }


            //Check if the object hovered before and after are equal to each other, if not, change to normal cursor
            if (preHoverObject && nextHoverObject && preHoverObject.GetEntityId() != nextHoverObject.GetEntityId())
            {
                preHoverObject.GetComponent<SpriteRenderer>().color = Color.white;
                HideText();
            }
        }

        else
        {
            HideText();

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

    public void ShowText()
    {
        descriptionText.gameObject.SetActive(true);
        descriptionText.text = "This sells for " + number + " tokens";
        descriptionText.transform.position = mousePos - new Vector3(-120, 80, 0);
    }

    public void HideText()
    {
        descriptionText.gameObject.SetActive(false);
    }

}

