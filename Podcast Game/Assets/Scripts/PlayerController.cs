using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] Camera gameCamera;

    public void OnInteract(InputValue value)
    {
        Debug.Log("CLICKED");

        PlayerClick();
    }

    void PlayerClick()
    {
        // Raycast and find the object here
        RaycastHit ray;

        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out ray, 10f))
        {
            if (ray.collider.tag == "Interactable")
            {
                ray.collider.gameObject.GetComponent<PuzzleObject>().Activate();
            }
            else if (ray.collider.tag == "Holdable")
            {
                if (!ray.collider.gameObject.GetComponent<HoldableObject>().held)
                {
                    ray.collider.gameObject.transform.SetParent(gameCamera.transform);
                    ray.collider.gameObject.GetComponent<Rigidbody>().isKinematic = true;
                    ray.collider.gameObject.GetComponent<HoldableObject>().held = true;
                }
                else
                {
                    ray.collider.gameObject.transform.SetParent(null);
                    ray.collider.gameObject.GetComponent<Rigidbody>().isKinematic = false;
                    ray.collider.gameObject.GetComponent<HoldableObject>().held = false;
                }
            }
        }
    }
}
