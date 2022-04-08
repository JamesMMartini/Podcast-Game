using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StairDrop : MonoBehaviour
{
    [SerializeField] GameObject[] floors;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            StartCoroutine(DropStairs());
        }
    }

    IEnumerator DropStairs()
    {
        yield return new WaitForSeconds(2f);

        foreach (GameObject floor in floors)
        {
            Destroy(floor);
        }

        yield return new WaitForSeconds(10f);

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
