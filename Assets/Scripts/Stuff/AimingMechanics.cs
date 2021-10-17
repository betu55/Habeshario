using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class AimingMechanics : MonoBehaviour {

    CinemachineCameraOffset camOff;
    Cinemachine.CinemachineFreeLook cmFreeLookCamera;
    private bool isAiming;
    private Canvas theCanvas;
    private void Start() {
        this.camOff = GetComponent<CinemachineCameraOffset>();
        this.cmFreeLookCamera = GetComponent<Cinemachine.CinemachineFreeLook>();
        camOff.m_Offset.x = .6f;
        this.isAiming = FindObjectOfType<GameManager>().isAiming;
        this.theCanvas = FindObjectOfType<CanvasScript>().cv;
        theCanvas.enabled = false;
    }
    private void Update() {
        // checks if the user is pressing the left mouse button
        if (Input.GetKeyDown(KeyCode.Mouse1)) {
            cmFreeLookCamera.m_Lens.FieldOfView = 36;
            this.isAiming = true;
            theCanvas.enabled = true;
        }
        //checks if user has released the left mouse button
        if (Input.GetKeyUp(KeyCode.Mouse1)) {
            cmFreeLookCamera.m_Lens.FieldOfView = 40;
            this.isAiming = false;
            theCanvas.enabled = false;
        }
        Debug.Log($"Player is aiming:{isAiming}");
    }
}
