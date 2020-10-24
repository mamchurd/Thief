using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(BoxCollider2D))]
public class Door : MonoBehaviour
{
    [SerializeField] private UnityEvent _thiethInHouse;
    [SerializeField] private UnityEvent _thiethLiveHouse;

    private BoxCollider2D _boxCollider;

    private void Start()
    {
        _boxCollider = GetComponent<BoxCollider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out Player player))
        {
            if (_boxCollider.bounds.center.x - collision.bounds.center.x > 0)
            {
                _thiethInHouse?.Invoke();
            }          
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out Player player))
        {
            if (_boxCollider.bounds.center.x - collision.bounds.center.x > 0)
            {
                _thiethLiveHouse?.Invoke();
            } 
        }
    }
}
