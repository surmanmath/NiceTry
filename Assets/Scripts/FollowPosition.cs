using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPosition : MonoBehaviour
{
    public Transform targertTrasform = null;
    
    void Update() {
        if (this.targertTrasform != null) {
            this.transform.position = new Vector3(this.targertTrasform.position.x, this.targertTrasform.position.y, this.transform.position.z);
        }
    }
}
