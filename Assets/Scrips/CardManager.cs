using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        MemoryMove[] cards = GetComponentsInChildren<MemoryMove>();

        for (int i = 0; i < cards.Length; i++)
        {
            cards[i].FlipCard();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
