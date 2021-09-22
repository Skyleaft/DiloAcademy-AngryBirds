﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D col)
    {
        string tag = col.gameObject.tag;
        if (tag == "Bird" || tag == "Obstacle")
        {
            Destroy(col.gameObject);
        }
        if (tag == "Enemy")
        {
            GameController.Instance.CheckGameEnd(col.gameObject);
            Destroy(col.gameObject);
        }
    }
}