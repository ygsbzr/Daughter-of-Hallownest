﻿using System.Collections;
using System.Collections.Generic;
using System.Linq;
using HutongGames.PlayMaker;
using HutongGames.PlayMaker.Actions;
using JetBrains.Annotations;
using Modding;
using UnityEngine;
using UnityEngine.UI;
using Logger = Modding.Logger;
using USceneManager = UnityEngine.SceneManagement.SceneManager;

namespace DoH
{
    internal class FireBatThrow : MonoBehaviour
    {
        void Start()
        {
            try
            {
                gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(Hornet.batDirec*20f, 0f);
                if (Hornet.batDirec > 0)
                {
                    gameObject.transform.rotation = Quaternion.Euler(0, 180f, 0);
                }
                else
                {
                    gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
                }
            }
            catch (System.Exception e)
            {
                Log(e);
            }
        }

        void FixedUpdate()
        {
            //_batReal.transform.localScale = gameObject.transform.localScale;
            
            if (gameObject.transform.GetPositionX() > 40f || gameObject.transform.GetPositionX() < 12f)
            {
                Destroy(gameObject);
            }
        }

        private static void Log(object obj)
        {
            Logger.Log("[Bat Mind] " + obj);
        }
    }
}
