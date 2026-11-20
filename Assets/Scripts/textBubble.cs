using TMPro;
using UnityEngine;

public class textBubble : MonoBehaviour
{

    public TMP_Text textBubbleWords;
    int randomNo;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        textBubbleWords.text = "I'm an A.I!";
    }



}
