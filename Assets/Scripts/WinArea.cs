using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinArea : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collider){
        Player player = collider.GetComponentInParent<Player>();
        ItemCollect nbcoin = collider.GetComponentInParent<ItemCollect>();
        if(player !=null && nbcoin.coin==5){
            player.Win();
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = new Color(Color.green.r, Color.green.g, Color.green.b, 0.5f);
        Gizmos.DrawCube(this.transform.position, this.transform.localScale);
    }
}
