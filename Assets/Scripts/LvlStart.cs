using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LvlStart : MonoBehaviour
{
    [SerializeField] private GameObject startLevel;
    void Start()
    {
        Instantiate(startLevel);
    }
}

