using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Life : MonoBehaviour
{   
    public int life = 3;

    [SerializeField] private Text Lifes;
    private void OnTriggerEnter2D(Collider2D collider2D){
        if (collider2D.gameObject.CompareTag("Lifes")){
            life--;
            if(life == 0)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                ResetLife();
            }
            else
            {
                Lifes.text = "Lifes : " + life + "/3";
            }
        }
    }

    public void ResetLife(){
        life = 3;
    }
}
