using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ScriptMouvementEnnemi : MonoBehaviour
{

    public NavMeshAgent agent;

    void ennemisFollow()
    {
        agent = this.GetComponent<NavMeshAgent>();

        if (agent == null)
        {
            Debug.LogError("Le component NavMeshAgent n'est pas attache a " + gameObject.name);
        }
        else
        {
            MoveToTarget();
        }
    }
    private void MoveToTarget()
    //Fonction qui permet de se diriger vers la cible choisie
    {
        Vector3 targetVector = agent.GetComponent<ScriptCiblageAutre>().TrouvePositonCible();
        //Debug.Log("Monstre numero " + GetComponent<ScriptMonstre>().GetUnite().GetNom() + " : " + targetVector); ;
        agent.SetDestination(targetVector);
    }
    private void Update()
    {

        ennemisFollow();
    }
    private void OnCollisionEnter(Collision collision)
    {
        GetComponent<Rigidbody>().velocity = Vector3.zero;
    }

}