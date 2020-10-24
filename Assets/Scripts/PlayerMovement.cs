using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speed;

    private Animator _animator;
    
    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.D))
        {
            transform.localRotation = Quaternion.Euler(0, 180, 0);
            transform.Translate(_speed * Time.deltaTime * -1, 0, 0);
            _animator.SetTrigger("Moved");        
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.localRotation = Quaternion.Euler(0, 0, 0);
            transform.Translate(_speed * Time.deltaTime * -1, 0, 0);   
            _animator.SetTrigger("Moved");
        }
    }

}
