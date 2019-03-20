using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Family : MonoBehaviour
{
    public GameObject[] mice;

    public double delayMultiplier = 1.2;

    void Update()
    {
        // Jump Button Pressed
        if (Input.GetButtonDown("Jump")) {
            // Add Delay to each family starting with the stop
            for (int i = 0; i < this.mice.Length; i++) {
                Mouse mouse = this.mice[i].GetComponent<Mouse>();
                if (mouse) {
                    mouse.DelayJump(i * this.delayMultiplier);
                }
            }
        }
    }
}
