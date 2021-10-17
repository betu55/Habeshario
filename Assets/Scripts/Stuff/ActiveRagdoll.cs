using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveRagdoll : MonoBehaviour
{

    [SerializeField] private Transform targetLimb;
    [SerializeField] private ConfigurableJoint myConfigJoint;
    Quaternion targetInitialRotation;
    // Start is called before the first frame update
    void Start(){
        this.myConfigJoint = this.GetComponent<ConfigurableJoint>();
        this.targetInitialRotation = this.targetLimb.transform.localRotation;
    }

    // Update is called once per frame
    void Update(){
    }
    private void FixedUpdate() {
        this.myConfigJoint.targetRotation = CopyRotation();
    }

    private Quaternion CopyRotation(){
        return Quaternion.Inverse(this.targetLimb.localRotation) * this.targetInitialRotation;
    }
}
