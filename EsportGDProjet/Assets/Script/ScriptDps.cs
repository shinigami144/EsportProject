using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptDps : MonoBehaviour
{

    private ClassUnite unite;
    public GameObject projectile;


    private void Start()
    {
        
    }



    public void Tirer(Vector3 ouTirer)
    {
        Vector3 _direction = new Vector3(0, 0, 0);
        for(int i = 0;i< 3; i++) {
            if(ouTirer[i] > transform.position[i])
            {
                _direction[i] = 1;
            }
            else if (ouTirer[i] < transform.position[i])
            {
                _direction[i] = -1;
            }
            else
            {
                _direction[i] = 0;
            }
        }
        _direction.y = 1;
        //Vector3 direction = ouTirer - transform.position;
        Vector3 force = transform.position;
        force.y = 0;
        GameObject p = Instantiate(projectile);
        p.transform.position = force + _direction;
        force = new Vector3(ouTirer.x - transform.position.x, 0, ouTirer.z - transform.position.z);
        p.GetComponent<Rigidbody>().AddForce((ouTirer-transform.position)*5); // reduction au pgcd pour eviter les difference de pousser
        
    }
}
