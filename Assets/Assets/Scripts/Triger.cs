using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Trigger activates when the player enters it
/// </summary>
/// <b>Authors</b>
/// <br>Arad Bozorgmehr (Vrglab)</br>
[RequireComponent(typeof(Rigidbody2D), typeof(BoxCollider2D))]
public class Triger : MonoBehaviour
{

    [Header("Settings")]
    public bool Constant;
    public bool Collidable = false;

    [Header("Unity event's")]
    public UnityEngine.Events.UnityEvent OnTrigger;
    public UnityEngine.Events.UnityEvent OnExit;

    Collider2D col;
    bool Trigger = false;
    bool Triggerext = false;

    void Start()
    {
        GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
        col = GetComponent<Collider2D>();
        col.isTrigger = !Collidable;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Entered(collision);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        Entered(collision);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Exited(collision);
    }


    private void Entered(Collider2D collision)
    {
        if (!Constant)
        {
            if (collision.tag == "Player")
            {
                if (!Trigger)
                {
                    OnTrigger.Invoke();
                    Trigger = true;
                }
            }
        }
        else
        {
            if (collision.tag == "Player")
            {

                OnTrigger.Invoke();
                Trigger = true;

            }
        }
    }

    private void Exited(Collider2D collision)
    {
        if (!Constant)
        {
            if (collision.tag == "Player")
            {
                if (!Triggerext)
                {
                    OnExit.Invoke();
                    Triggerext = true;
                }
            }
        }
        else
        {
            if (collision.tag == "Player")
            {

                OnExit.Invoke();
                Trigger = false;
            }
        }
    }
}
