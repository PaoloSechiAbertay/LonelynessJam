using UnityEngine;
using System.Collections;

public class WwiseController : MonoBehaviour
{
    public AK.Wwise.Event backgroundAmb;

    public AK.Wwise.Event Amb_MirrorTalk;
    public AK.Wwise.Event Amb_TeddyLaugh;
    public AK.Wwise.Event Amb_PageRustle;
    public AK.Wwise.Event Amb_PopCorn;
    public AK.Wwise.Event Amb_SportWhistle;
    public AK.Wwise.Event Amb_FamilyOutside;

    public AK.Wwise.Event Amb_Rand_Post;
    public AK.Wwise.RTPC Amb_Rand_Volume;

    Coroutine clock;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        backgroundAmb.Post(gameObject);

        clock = StartCoroutine(Clock());

    }

    // Update is called once per frame
    void Update()
    {
        if (clock == null)
        {
            clock = StartCoroutine(Clock());
        }

    }

    IEnumerator Clock()
    {
        yield return new WaitForSeconds(Random.Range(10f, 20f));
        Amb_Rand_Post.Post(gameObject);
        clock = null;
    }
}
