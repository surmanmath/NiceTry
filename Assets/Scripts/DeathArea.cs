using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathArea : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collider){
        Player player = collider.GetComponentInParent<Player>();
        if(player !=null){
            player.Die();
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = new Color(Color.red.r, Color.red.g, Color.red.b, 0.5f);
        Gizmos.DrawCube(this.transform.position, this.transform.localScale);
    }
}
