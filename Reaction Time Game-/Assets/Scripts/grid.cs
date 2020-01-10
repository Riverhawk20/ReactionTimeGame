using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class grid : MonoBehaviour
{
    public GameObject ExplodeGrid;
    void OnMouseDown(){
        if(GameObject.Find("EventSystem").GetComponent<ReactionGameScript>().game){
            GameObject.Find("EventSystem").GetComponent<ReactionGameScript>().fails++;
            GameObject.Find("EventSystem").GetComponent<ReactionGameScript>().misClicks++;
            Instantiate(ExplodeGrid, transform.position, Quaternion.identity);   
        }
            
    }
}
