using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTrigger : MonoBehaviour
{
    private string playerTag = "Player";

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag(playerTag))
        {
            OnPlayerEnter2D(other.gameObject);

            Debug.Log("Ha entrado en el trigger");
        }
    }

    public virtual void OnPlayerEnter2D(GameObject playerObject)
    {
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag(playerTag))
        {
            OnPlayerExit2D(other.gameObject);
        }
    }

    public virtual void OnPlayerExit2D(GameObject playerObject)
    {
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag(playerTag))
        {
            OnPlayerStay(other.gameObject);
        }
    }

    public virtual void OnPlayerStay(GameObject playerObject)
    {
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(playerTag))
        {
            OnPlayerEnter2D(collision.gameObject);
        }
    }
}