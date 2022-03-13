using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCaractereAnimations : MonoBehaviour
{
    public PlayerCaracterController playerCaracterController = null;

    public float HorizontalInput {
        get{
            if(playerCaracterController != null){
                return this.playerCaracterController.horizontalInput;
            }
            return 0f;
        }
    }

    public Animator animator = null;

    void LateUpdate() {
        if(this.animator != null) {
            this.animator.SetFloat("Horizontal", Mathf.Abs(this.HorizontalInput));
        }
    }
}
