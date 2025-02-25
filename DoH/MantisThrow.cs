﻿
using UnityEngine;
using UnityEngine.UI;
using Logger = Modding.Logger;
using USceneManager = UnityEngine.SceneManagement.SceneManager;

namespace DoH
{
    internal class MantisThrow : MonoBehaviour
    {
        bool firstAct = false;
        float vxG;
        float vyG;
        float fG;

        void FixedUpdate()
        {
            if (!firstAct)
            {
                var gX = gameObject.transform.GetPositionX();
                firstAct = true;
                if (gX <= 12)
                {
                    vxG = 33f;
                    vyG = -2.2f;
                    fG = -24f;
                    gameObject.transform.SetPosition2D(12f,gameObject.transform.GetPositionY());//SetPosition2D(12f, 32f)
                }
                else if (gX >= 42f)
                {
                    vxG = -33f;
                    vyG = -2.2f;
                    fG = 24f;
                    gameObject.transform.SetPosition2D(42f, gameObject.transform.GetPositionY());
                }
                gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(vxG, vyG);
            }
            if (firstAct)
            {
                gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(fG, 0f));
            }
            if (gameObject.transform.GetPositionX() <= 11f || gameObject.transform.GetPositionX() >= 43f)
            {
                firstAct = false;
                Destroy(gameObject);
                //this.gameObject.SetActive(false);
            }
        }
        private static void Log(object obj)
        {
            Logger.Log("[Mantis Projectile] " + obj);
        }
    }
}
