using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasScript : MonoBehaviour{

    public Canvas cv;
    private bool isAiming;
    private void Awake() {
        this.cv = GetComponent<Canvas>();
    } 

}
