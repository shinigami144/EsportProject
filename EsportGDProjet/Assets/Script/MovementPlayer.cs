using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementPlayer : MonoBehaviour
{
    CharacterController controleJoueur;
    public float movementSpeed = 5.0f;
    
    private Vector3 movementDirection= Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        controleJoueur = GetComponent<CharacterController>();

    }

    // Update is called once per frame
    void Update()
    {
        if (controleJoueur.isGrounded)
        {
            movementDirection = new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));
            movementDirection = movementDirection * movementSpeed;
        }
        movementDirection.y -= 10f * Time.deltaTime;
        controleJoueur.Move(movementDirection * Time.deltaTime);
    }
}
