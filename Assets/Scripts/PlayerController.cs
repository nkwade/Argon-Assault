using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private InputAction movment;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnEnable() {
        movment.Enable();
    }

    private void OnDisable() {
        movment.Disable();
    }

    // Update is called once per frame
    void Update()
    {
        //Old Unity Movement Code
        // float horizontalThrow = Input.GetAxis("Horizontal");
        // float verticalThrow = Input.GetAxis("Vertical");

        float horizontalThrow = movment.ReadValue<Vector2>().x;
        float verticalThrow = movment.ReadValue<Vector2>().y;



    }
}
