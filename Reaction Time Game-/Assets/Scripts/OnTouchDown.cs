using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnTouchDown : MonoBehaviour
{
    void Update()
    {
        RaycastHit hit = new RaycastHit();
        for (int i = 0; i < Input.touchCount; ++i) {
            if (Input.GetTouch(i).phase.Equals(TouchPhase.Began)) {
                        print("hi");

            // Construct a ray from the current touch coordinates
            Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(i).position);
            if (Physics.Raycast(ray, out hit)) {
                hit.transform.gameObject.SendMessage("OnMouseDown");
                        
              }
           }
       }
    }
}
