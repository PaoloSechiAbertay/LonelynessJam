using System.Linq;
using UnityEngine;

public class hidePayToken : MonoBehaviour
{
    public Wallet wallet;

    public GameObject payToken;

    public WwiseController wwiseController;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (wallet.walletTotal == 0)
        {
            //wwise sound
        }
        else
        {
            //other wwise sounds
        }

        ifNoSellablesThenNoAmb();
        
    }

    public void ifNoSellablesThenNoAmb()
    {

        GameObject[] gameObjectArray = GameObject.FindGameObjectsWithTag("Sellable");
        Debug.Log(gameObjectArray.Length);
        wwiseController.Amb_Rand_Volume.SetGlobalValue(gameObjectArray.Length);
        
    }
}
