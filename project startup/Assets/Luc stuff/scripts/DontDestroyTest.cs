using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyTest : MonoBehaviour
{
     public static DontDestroyTest Instance;

        void Awake()
        {
            if (Instance)
                DestroyImmediate(gameObject);
            else
            {
                DontDestroyOnLoad(gameObject);
                Instance = this;
            }
        }
 }
