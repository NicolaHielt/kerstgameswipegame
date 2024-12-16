using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlassScript : MonoBehaviour
{
    [SerializeField] AudioSource audio;

    [SerializeField] GameObject glass1;
    [SerializeField] GameObject glass2;

    bool glass1In;
    bool glass2In;
    // Start is called before the first frame update

    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == glass1)
        {
            glass1In = true;
        }
        else if (other.gameObject == glass2)
        {
            glass2In = true;
        }

        if (glass1In && glass2In)
        {

            StartCoroutine(EndGame());
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == glass1)
        {
            glass1In = false;
        }
        else if (other.gameObject == glass2)
        {
            glass2In = false;
        }
    }

    IEnumerator EndGame()
    {
        audio.Play();
        yield return new WaitForSeconds(1f);
        GameObject.Find("DontDestroy").GetComponent<DontDestroy>().LoadScene("Kerstboom", 1);
    }
}
