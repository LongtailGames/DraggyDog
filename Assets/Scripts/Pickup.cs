using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public abstract class Pickup : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        OnCollect(other);
        Destroy(gameObject);
    }

    protected abstract void OnCollect(Collider2D other);
}