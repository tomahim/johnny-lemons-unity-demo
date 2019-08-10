﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Observer : MonoBehaviour {

    public Transform player;
    bool m_IsPlayerInRange;
    public GameEnding gameEnding;

    void OnTriggerEnter (Collider other) {
        Debug.Log("OnTriggerEnter");
        if(other.transform == player) {
            m_IsPlayerInRange = true;
        }
    }
    
    void OnTriggerExit (Collider other) {
        if(other.transform == player) {
            m_IsPlayerInRange = false;
        }
    }

    void Update () {
        if (m_IsPlayerInRange)
        {
            Debug.Log("m_IsPlayerInRange");
            Vector3 direction = player.position - transform.position + Vector3.up;
            Ray ray = new Ray(transform.position, direction);
            RaycastHit raycastHit;

            if(Physics.Raycast(ray, out raycastHit))
            {
                if (raycastHit.collider.transform == player)
                {
                    gameEnding.CaughtPlayer();
                }
            }
        }
    }
}
