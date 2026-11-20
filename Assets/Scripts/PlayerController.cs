using JetBrains.Annotations;
using System.Linq;
using TMPro;
using Unity.VisualScripting;
using UnityEditor.Build;
using UnityEngine;
using UnityEngine.Rendering;

public class PlayerController : MonoBehaviour
{
    public Vector3 mousePos;

    RaycastHit2D raycastHit2D;
    public Transform preHoverObject, nextHoverObject;

    public bool mouseDown;

    public TMP_Text descriptionText;
    public TMP_Text loreText;
    public hoverText hoverText;
    public GameObject hoverBackground;

    public Object textBubble;
    public Object playerTextBubble;

    bool textSpawned;

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
        }
        else
        {
            mouseDown = false;
        }

        payToken();
        testPlayer();
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
            if (preHoverObject && nextHoverObject && preHoverObject.GetEntityId() != nextHoverObject.GetEntityId() && preHoverObject.gameObject.tag != "ui")
            {
                preHoverObject.GetComponent<SpriteRenderer>().color = Color.white;
                HideText();
            }
        }

        else
        {
            HideText();

            if (preHoverObject && preHoverObject.gameObject.tag != "ui")
            {
                preHoverObject.GetComponent<SpriteRenderer>().color = Color.white;

            }

        }
    }

        public void SellItem()
        {
        Destroy(nextHoverObject.gameObject);

        wallet.walletTotal += hoverText.number;
        }


    public void testPlayer()
    {
        if (nextHoverObject.parent.name == "playerTest" && Input.GetMouseButtonDown(0))
        {
            Debug.Log("meow");
            spawnPlayerText();
        }
    }

    public void payToken()
    {
        if (nextHoverObject.parent.name == "PayToken" && Input.GetMouseButtonDown(0))
        {
            wallet.walletTotal -= 1;

            spawnAiText();
        }
    }

    public void ShowText()
    {
        descriptionText.gameObject.SetActive(true);
        descriptionText.text = "This sells for " + hoverText.number + " tokens";
        descriptionText.transform.position = mousePos - new Vector3(-120, 80, 0);


        loreText.gameObject.SetActive(true);
        loreText.text = "blah blah blah";
        loreText.transform.position = mousePos - new Vector3(-120, 240, 0);
    }

    public void HideText()
    {
        descriptionText.gameObject.SetActive(false);
        loreText.gameObject.SetActive(false);
        hoverBackground.gameObject.SetActive(false);
    }

    public void spawnAiText()
    {
        if (!textSpawned)
        {
            Instantiate(textBubble, new Vector3(-0.931f, -6, -4.2f), Quaternion.identity);
            textSpawned = true;
        }
        else
        {
            GameObject[] gameObjectArray2 = GameObject.FindGameObjectsWithTag("textBubbles");
            int numberOfBubbles = gameObjectArray2.Length;
            Debug.Log(numberOfBubbles);

            for (int i = 0; i < numberOfBubbles; i++)
            {
                gameObjectArray2[i].transform.position += new Vector3(0, 1, 0);
            }

            if (numberOfBubbles >= 4)
            {

                DestroyImmediate(gameObjectArray2[0], true);
                Debug.Log("destroyed");
            }



            Object textBubblePopup = Instantiate(textBubble, new Vector3(-0.931f, (-6), -4.2f), Quaternion.identity);

        }
    }
        public void spawnPlayerText()
    {
        if (!textSpawned)
        {
            Instantiate(playerTextBubble, new Vector3(2.9f, -6, -4.2f), Quaternion.identity);
            textSpawned = true;
        }
        else
        {
            GameObject[] gameObjectArray2 = GameObject.FindGameObjectsWithTag("textBubbles");
            int numberOfBubbles = gameObjectArray2.Length;
            Debug.Log(numberOfBubbles);

            for (int i = 0; i < numberOfBubbles; i++)
            {
                gameObjectArray2[i].transform.position += new Vector3(0, 1, 0);
            }

            if (numberOfBubbles >= 4)
            {

                DestroyImmediate(gameObjectArray2[0], true);
                Debug.Log("destroyed");
            }



            Object textBubblePopup = Instantiate(playerTextBubble, new Vector3(2.9f, (-6), -4.2f), Quaternion.identity);

        }
    }
    


}

