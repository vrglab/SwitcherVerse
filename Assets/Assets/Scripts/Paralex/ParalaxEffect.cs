using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <b>Authors</b>
/// <br>Arad Bozorgmehr (Vrglab)</br>
public class ParalaxEffect : MonoBehaviour
{
    public ParalaxObject[] objs;
    public ParalaxPrefabObject[] Prefabobjs;

    private Transform Main;

    private void Start()
    {
        Main = Camera.main.transform;
        for (int i = 0; i < objs.Length; i++)
        {
            GameObject ParalexObj = new GameObject("Paralexobj: " + objs[i].Image.name);
            ParalexObj.transform.position = objs[i].Position;

            if(objs[i].Staytionary)
            {
                ParalexObj.transform.SetParent(Main);
            }
            else
            {
                ParalexObj.transform.SetParent(transform);
            }
            if(objs[i].animated)
            {
                ParalexObj.AddComponent<Animator>();
                ParalexObj.GetComponent<Animator>().runtimeAnimatorController = objs[i].anim.runtimeAnimatorController;
            }

            ParalexObj.AddComponent<SpriteRenderer>().sprite = objs[i].Image;
            ParalexObj.GetComponent<SpriteRenderer>().material = objs[i].mat;
            ParalexObj.GetComponent<SpriteRenderer>().drawMode = objs[i].spriteDrawMode;
            ParalexObj.GetComponent<SpriteRenderer>().size = objs[i].Size;
            ParalexObj.GetComponent<SpriteRenderer>().sortingOrder = objs[i].renderNumber;
            objs[i].obj = ParalexObj;
            ParalexObj.AddComponent<Paralex>().item = objs[i];
           
        }
        for (int i = 0; i < Prefabobjs.Length; i++)
        {
            GameObject ParalexObj = Prefabobjs[i].Image;
            ParalexObj.transform.position = Prefabobjs[i].Position;
            ParalexObj.GetComponent<SpriteRenderer>().sortingOrder = Prefabobjs[i].renderNumber;
            if (Prefabobjs[i].Staytionary)
            {
                ParalexObj.transform.SetParent(Main);
            }

            ParalexObj.AddComponent<PrefabParalax>().item = Prefabobjs[i];
        }
    }
}

/// <b>Authors</b>
/// <br>Arad Bozorgmehr (Vrglab)</br>
[System.Serializable]
public struct ParalaxObject
{
    public Sprite Image;
    public Material mat;
    public int renderNumber;
    public bool Staytionary;
    public bool Infinite;
    public bool animated;
    public Animator anim;
    public SpriteDrawMode spriteDrawMode;
    public Vector2 Size;
    public Vector2 ParalexEffect;
    public Vector3 Position;
    public GameObject obj { get; set; }
}


/// <b>Authors</b>
/// <br>Arad Bozorgmehr (Vrglab)</br>
[System.Serializable]
public struct ParalaxPrefabObject
{
    public GameObject Image;
    public int renderNumber;
    public bool Staytionary;
    public bool Infinite;
    public Vector2 Size;
    public Vector2 ParalexEffect;
    public Vector3 Position;

}
