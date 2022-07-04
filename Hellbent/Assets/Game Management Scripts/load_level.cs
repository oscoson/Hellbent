using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class load_level : MonoBehaviour
{
    public int iLevelToLoad;
    public string sLevelToLoad;



    public bool useIntegerToLoadLevel = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        
    }

    private void OnTriggerEnter2D(Collider2D collision) 
    {
        GameObject collisionGameObject = collision.gameObject;

        if(collisionGameObject.name == "mc")
        {
            LoadScene();

        }
    }

    void LoadScene()
    {
        // conditonal to check if variable to T/F in inspector, if true, load scene at index of iLevelToLoad
        // set to false, load the scene that has the same name as the sLeveltoLoad variable
        if (useIntegerToLoadLevel)
        {        
            if(!(SceneManager.GetActiveScene().name == "Tutorial"))
            {
                DontDestroyOnLoad(GameObject.FindGameObjectWithTag("MainMusic"));
            }
            SceneManager.LoadScene(iLevelToLoad);
        }
        else
        {                   
            SceneManager.LoadScene(sLevelToLoad);
        }
    }
}
