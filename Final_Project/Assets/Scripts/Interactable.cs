using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Interactable : MonoBehaviour
{
    public float radius = 3f;
    bool isFocus = false;
    Transform player;
        bool hasInteracted = false;
    public Transform interactionTransform;
    public KeyCode interactKey = KeyCode.E;
    public UnityEvent interact;
    public virtual void Interact ()

    {
        Debug.Log("Interacting with" + transform.name);
    }

    public void Update()
    {
        if (isFocus && !hasInteracted)
        {
            float distance = Vector3.Distance(player.position, interactionTransform.position);
            if (distance <= radius)
            {
                Debug.Log("Interact");
                Interact();
                hasInteracted = true;
            }
            if (Input.GetKeyDown(interactKey))
            {
                interact.Invoke();
            }
        }

      
    }

    public void OnFocus (Transform playerTranform)
    {
        isFocus = true;
        player = playerTranform;
        hasInteracted = false;
    
    }
    public void OnDefocused ()
    {
        isFocus = false;
        player = null;
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(interactionTransform.position, radius);
    }


}
