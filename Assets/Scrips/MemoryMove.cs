using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MemoryMove : MonoBehaviour
{
    [SerializeField] private GameObject Front;
    [SerializeField] private GameObject Back;


    private bool showingFront = false; 
    // Start is called before the first frame update
    void Start()
    {
        MeshRenderer meshRenderer = GetComponent<MeshRenderer>();
        ShowBack();


        Front.GetComponent<MeshRenderer>().material.color = Color.red;
        Back.GetComponent<MeshRenderer>().material.color = Color.blue;

    }

    [ContextMenu("Flip")]
    public void FlipCard()
    {
        showingFront = !showingFront;
        if (showingFront)
        {
            ShowFront();
        }
        else
        {
            ShowBack();
        }
    }

    void ShowFront()
    {
        transform.rotation = Quaternion.identity;
    }

    void ShowBack()
    {
        transform.rotation = Quaternion.Euler(0, 0, 180);
    }
   
}
