using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controls : MonoBehaviour
{
    public PackOpening packOpening;
    private Vector2 startMousePosition;
    private Vector2 endMousePosition;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            startMousePosition = Input.mousePosition;
        }

        if (Input.GetMouseButtonUp(0))
        {
            endMousePosition = Input.mousePosition;

            if (Vector2.Distance(startMousePosition, endMousePosition) > 100f)
            {
                Debug.Log("Swipe gedetecteerd!");
                packOpening.OpenPack();
            }
        }
    }
}
