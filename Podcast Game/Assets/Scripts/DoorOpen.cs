using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class DoorOpen : PuzzleObject
{
    bool open = false;
    float speed = 1f;

    public override void Activate()
    {
        activationTick++;

        if (activationTick >= activationRequirement)
        {
            StartCoroutine(OpenDoor());

            foreach (GameObject gameObject in activatedObjects)
            {
                //gameObject.GetComponent<PuzzleObject>().activated = true;
                gameObject.GetComponent<PuzzleObject>().Activate();
            }
        }
    }

    IEnumerator OpenDoor()
    {
        if (!open)
        {
            Debug.Log("OPENING");
            // Rotate the door to -90 degrees on the y
            float t = 0.0f;
            Vector3 doorStart = transform.localRotation.eulerAngles;
            Vector3 doorEnd = new Vector3(0, -90, 0);
            while (t < 1.0f)
            {
                t += Time.deltaTime * speed * 2;
                transform.localRotation = Quaternion.Euler(Vector3.Lerp(doorStart, doorEnd, t));
                yield return null;
            }

            open = true;
        }
        else
        {
            Debug.Log("CLOSING");
            // Rotate the door to 0 degrees on the y
            float t = 0.0f;
            Vector3 doorStart = transform.localRotation.eulerAngles;
            Vector3 doorEnd = new Vector3(0, 0, 0);
            while (t < 1.0f)
            {
                t += Time.deltaTime * speed * 2;
                transform.localRotation = Quaternion.Euler(Vector3.Lerp(doorStart, doorEnd, t));
                yield return null;
            }

            open = false;
        }
    }
}
