using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartSceneDPS : MonoBehaviour
{

    public int choixScene;
    // Start is called before the first frame update
    void Start()
    {
        choixScene = 2;
    }


    private void FixedUpdate()
    {
        switch (choixScene)
        {
            case 1:
                Debug.Log("SCENE DPS");
                GameObject.FindObjectOfType<ScriptGameManager>().GetComponent<ScriptGameManager>().InitSceneDps();
                choixScene = 4;
                break;
            case 2:
                Debug.Log("SCENE HEALER");
                GameObject.FindObjectOfType<ScriptGameManager>().GetComponent<ScriptGameManager>().InitSceneHealer();
                choixScene = 4;
                break;
            case 3:
                Debug.Log("SCENE TANK");
                GameObject.FindObjectOfType<ScriptGameManager>().GetComponent<ScriptGameManager>().InitSceneTank();
                choixScene = 4;
                break;
            default:
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
