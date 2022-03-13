using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickyPlateform : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collider2D){
        if(collider2D.gameObject.name == "Player"){
            Debug.LogWarning("Dessus après if");
            collider2D.gameObject.transform.SetParent(transform);
        }
    }

    private void OnTriggerExit2D(Collider2D collider2D){

        if(collider2D.gameObject.name == "Player"){
            Debug.LogWarning("ailleurs");
            collider2D.gameObject.transform.SetParent(transform);
        }
    }
}
