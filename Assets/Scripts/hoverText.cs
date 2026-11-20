using UnityEngine;

public class hoverText : MonoBehaviour
{
    public PlayerController playerController;

    public int number;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (playerController.nextHoverObject.transform.parent.tag == "price1")
        {
            number = 2;
        }

        if (playerController.nextHoverObject.transform.parent.tag == "price2")
        {
            number = 4;
        }

        if (playerController.nextHoverObject.transform.parent.tag == "price3")
        {
            number = 8;
        }
    }
}
