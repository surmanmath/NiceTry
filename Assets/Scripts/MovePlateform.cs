using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlateform : MonoBehaviour
{
public Transform startPosition = null;
    public Transform stopPosition =null;
    public float moveSpeed = 1.0f;

    public float percentage = 0.0f; //0.0 <-> 1.0

    public bool moveDirection = true;

    public Rigidbody2D Rigidbody2D = null;

    void Update() {
        if (moveDirection) {
            this.percentage = Mathf.Clamp01(this.percentage + this.moveSpeed * Time.deltaTime);
            if(this.percentage == 1.0f){
                this.moveDirection = !this.moveDirection;
            }
        }
        else {
            this.percentage = Mathf.Clamp01(this.percentage - this.moveSpeed * Time.deltaTime);
            if(this.percentage == 0.0f){
                this.moveDirection = !this.moveDirection;
            }
        }
    }

    void FixedUpdate() {
        if(this.Rigidbody2D != null) {
            Vector2 newposition = Vector2.Lerp(this.startPosition.position, this.stopPosition.position, this.percentage);
            this.Rigidbody2D.MovePosition(newposition);
        }
    }

    void OnDrawGizmos() {
        Gizmos.DrawLine(this.startPosition.position,this.stopPosition.position);
    }
}
