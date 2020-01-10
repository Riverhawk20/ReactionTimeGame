using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReactionTarget : MonoBehaviour
{
    float scaleSpeed = .8f;
    bool shrink = false;
    public GameObject Explode;
    float spawnTime;
    public void OnMouseDown(){
        GameObject.Find("EventSystem").GetComponent<ReactionGameScript>().score++;
        Destroy(gameObject);
    }
    void Awake(){
        spawnTime=Time.time;
    }
    
    void Update(){
        // If game is over killself
        if(GameObject.Find("EventSystem").GetComponent<ReactionGameScript>().alive==false){
            Destroy(gameObject);
        }
        //If it gets too small itll add to fail and play death effect
        if(transform.localScale.x <0.1f) {
            GameObject.Find("EventSystem").GetComponent<ReactionGameScript>().fails++;
            Instantiate(Explode, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
        //switch from growing to shrink
        if(transform.localScale.x<=1.0f && shrink==false){
            transform.localScale += Vector3.one * Time.deltaTime * scaleSpeed;
        }
        else{
            shrink=true;
        }
        //shrink if it hit apex at top
        if(shrink) transform.localScale -= Vector3.one * Time.deltaTime * scaleSpeed;
    }
    
}
