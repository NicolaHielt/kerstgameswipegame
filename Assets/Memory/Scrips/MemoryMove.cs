using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MemoryMove : MonoBehaviour
{
    [SerializeField] private GameObject Front;
    [SerializeField] private GameObject Back;

    CardManager cardManager;
    public string cardName;



    private bool showingFront = true; 
    // Start is called before the first frame update
    void Start()
    {
        MeshRenderer meshRenderer = GetComponent<MeshRenderer>();
        cardManager = GetComponentInParent<CardManager>();
        ShowBack();


        Front.GetComponent<MeshRenderer>().material.color = Color.red;
        Back.GetComponent<MeshRenderer>().material.color = Color.blue;

    }

    private void OnMouseDown()
    {
        cardManager.SelectCard(this);
    }

    [ContextMenu("Flip")]
    public void FlipCard()
    {
        if (showingFront)
        {
            ShowFront();
        }
        else
        {
            ShowBack();
        }
    }

    public void ShowFront()
    {
        showingFront = true;
        transform.rotation = Quaternion.identity;
    }

    public void ShowBack()
    {
        showingFront = false;
        transform.rotation = Quaternion.Euler(0, 0, 180);
    }
   
}
