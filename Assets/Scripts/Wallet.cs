using UnityEngine;
using TMPro;

public class Wallet : MonoBehaviour
{
    public TMP_Text canvasText;

    public int walletTotal;

    void Start()
    {
        walletTotal = 5;
    }

    // Update is called once per frame
    void Update()
    {
        canvasText.text = "Tokens: " + walletTotal;
    }
}
