﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TomatoHPPickUp : MonoBehaviour
{
    public GameManager gMRef;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Chef"))
        {
            gMRef.audioManagerRef.audioList[5].Play();
            gMRef.SetTomatoHP(gMRef.GetTomatoHP() + 1);
            Destroy(this.gameObject);
        }
    }
}
