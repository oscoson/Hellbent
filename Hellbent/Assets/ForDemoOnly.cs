using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ForDemoOnly : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision) 
    {

        GameObject collisionGameObject = collision.gameObject;

        if(collisionGameObject.name == "mc")
        {
            GameObject.FindGameObjectWithTag("MainMusic").SetActive(false);
            SceneManager.LoadScene(0);

        }
    }
}
