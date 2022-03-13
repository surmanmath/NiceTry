using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollect : MonoBehaviour
{   
    public int coin = 0;

    [SerializeField] private Text coinText;
    private void OnTriggerEnter2D(Collider2D collider2D){
        if (collider2D.gameObject.CompareTag("Coin")){
            Destroy(collider2D.gameObject);
            coin++;
            coinText.text = "Coins : " + coin + "/5";
        }
    }

    public void ResetCoin(){
        coin = 0;
    }
}
