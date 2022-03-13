using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
 public PlayerCaracterController playerCaracterController = null;
    public FollowPosition cameraFollowPosition = null;
    public GameObject Deathscreen = null;
    public GameObject Winscreen = null;
    public ItemCollect Inventory = null;
    public Life lifes = null;

    public Vector3 spawnPoint = new Vector3();

    // Start is called before the first frame update
    void Start()
    {
        this.spawnPoint = this.playerCaracterController.transform.position;
        this.Deathscreen.SetActive(false);
        this.Winscreen.SetActive(false);
    }

    // Update is called once per frame
    public void Die()
    {
        Debug.LogWarning("Player" + this.gameObject.name + " is now dead");
        this.Deathscreen.SetActive(true);

        this.playerCaracterController.enabled = false;

        this.cameraFollowPosition.enabled = false;
        this.playerCaracterController.Rigidbody2D.velocity = Vector3.zero;
    }

    public void Win()
    {
        Debug.LogWarning("Player" + this.gameObject.name + " win");
        this.Winscreen.SetActive(true);

        this.playerCaracterController.enabled = false;

        this.cameraFollowPosition.enabled = false;
        this.playerCaracterController.Rigidbody2D.velocity = Vector3.zero;
    }

    public void Respawn() {
        this.Deathscreen.SetActive(false);
        this.Winscreen.SetActive(false);

        this.playerCaracterController.transform.position = spawnPoint;

        this.playerCaracterController.enabled = true;
        this.cameraFollowPosition.enabled = true;
    }

    public void NextLevel() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +1);
    }

    public void test(){
        Debug.LogWarning("It work !");
    }

 
    
}
