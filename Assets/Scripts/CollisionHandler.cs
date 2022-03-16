using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] private float reloadDelay = 1f;
    private void OnTriggerEnter(Collider collider) {
        this.gameObject.GetComponent<PlayerController>().enabled = false;
        Invoke("ReloadLevel", reloadDelay);
    }

    private void ReloadLevel()
    {
        int curScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(curScene);
    }
}
