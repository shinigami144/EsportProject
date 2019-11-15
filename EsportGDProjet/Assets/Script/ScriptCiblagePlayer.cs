using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptCiblagePlayer : MonoBehaviour
{
    // Start is called before the first frame update
    RaycastHit toucherRayon;
    ScriptGameManager gm;
    void Start()
    {
        
    }

    private void ActiveAction(Vector3 positionAttaquer)
    {
        if( GetComponent<ScriptTank>() != null)
        {
            //
        }
        else if (GetComponent<ScriptHealer>() != null)
        {
            GetComponent<ScriptHealer>().PoserPiege(positionAttaquer);
        }
        else
        {
            GetComponent<ScriptDps>().Tirer(positionAttaquer);
        }
    }

    private void ActiveAction(GameObject objetAttaquer)
    {
        if (GetComponent<ScriptTank>() != null)
        {

        }
        else if (GetComponent<ScriptHealer>() != null)
        {

        }
        else
        {
            GetComponent<ScriptDps>().Tirer(objetAttaquer.transform.position);
        }
    }

    private void FixedUpdate()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray rayon = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(rayon, out toucherRayon)){
                Debug.Log(toucherRayon.collider);
                Debug.Log(toucherRayon.point);
                // collision et position de colision;
                if(toucherRayon.collider.name == "Plane")
                {
                    Debug.Log("Point = " + toucherRayon.point + " Mouse Position " + Input.mousePosition);
                    ActiveAction(toucherRayon.point);

                }
                else
                {

                    ActiveAction(toucherRayon.collider.gameObject);
                }
                // activer action
            }
            
        }
    }
    // Update is called once per frame
    void Update()
    {
    }

    
}
