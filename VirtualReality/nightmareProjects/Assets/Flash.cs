using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class Flash : MonoBehaviour
{
    public bool flikering = false;
    public float delay;


    private void Update()
    {
        if (flikering == false)
        {
            StartCoroutine(Flashing());
        }
    }

    private IEnumerator Flashing()
    {
        flikering = true;
        this.gameObject.GetComponent<Light>().enabled = false;
        delay = Random.Range(0.01F, 0.5F);
        yield return new WaitForSeconds(delay);
        this.gameObject.GetComponent<Light>().enabled = true;
        delay = Random.Range(0.01F, 0.5F);
        yield return new WaitForSeconds(delay);
        flikering = false;
    }
}