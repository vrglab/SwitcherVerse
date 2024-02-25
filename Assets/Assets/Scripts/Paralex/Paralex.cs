using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <b>Authors</b>
/// <br>Arad Bozorgmehr (Vrglab)</br>
public class Paralex : MonoBehaviour
{

    public ParalaxObject item;
    public Transform Main;
    public Vector3 LastCamPos;

    private float TextureUnitx;
    private float TextureUnity;

    private void Start()
    {
        Main = Camera.main.transform;
        LastCamPos = Main.position;
        Texture2D texture = item.Image.texture;
        TextureUnitx = texture.width / item.Image.pixelsPerUnit;
        TextureUnity = texture.height / item.Image.pixelsPerUnit;
    }

    void LateUpdate()
    {
        if (item.Staytionary == false)
        {
            Vector3 deltaMovement = Main.transform.position - LastCamPos;
            transform.position += new Vector3(deltaMovement.x * item.ParalexEffect.x, deltaMovement.y * item.ParalexEffect.y);
            LastCamPos = Main.position;

            if(item.Infinite)
            {
                if (Mathf.Abs(Main.position.x - transform.position.x) >= TextureUnitx)
                {
                    float offeset = (Main.position.x - transform.position.x) % TextureUnitx;
                    transform.position = new Vector3(Main.position.x + offeset, transform.position.y);
                }

                if (Mathf.Abs(Main.position.y - transform.position.y) >= TextureUnity)
                {
                    float offeset = (Main.position.y - transform.position.y) % TextureUnity;
                    transform.position = new Vector3(Main.position.x, transform.position.y + offeset);
                }
            }
        }
    }
}
