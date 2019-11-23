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
            // RIEN POUR L INSTANT
        }
        else if (GetComponent<ScriptHealer>() != null)
        {
            GetComponent<ScriptHealer>().PoserPiege(positionAttaquer);
        }
        else if(GetComponent<ScriptDps>())
        {
            GetComponent<ScriptDps>().Tirer(positionAttaquer);
        }
    }

    private void ActiveAction(GameObject objetAttaquer)
    {
        if (GetComponent<ScriptTank>() != null)
        {
            GetComponent<ScriptTank>().Taunt(objetAttaquer);
        }
        else if (GetComponent<ScriptHealer>() != null)
        {
            GetComponent<ScriptHealer>().Heal(objetAttaquer);
        }
        else if(GetComponent<ScriptDps>())
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
                if (toucherRayon.collider.name == "Plane")
                {
                    ActiveAction(toucherRayon.point);
                }
                else
                {
                    ActiveAction(toucherRayon.collider.gameObject);
                }
            } 
        } 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
}
