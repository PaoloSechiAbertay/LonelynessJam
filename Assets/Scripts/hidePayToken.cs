using UnityEngine;

public class hidePayToken : MonoBehaviour
{
    public Wallet wallet;

    public GameObject payToken;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (wallet.walletTotal == 0)
        {
            payToken.SetActive(false);
        }
        else
        {
            payToken.SetActive(true);
        }
    }
}
