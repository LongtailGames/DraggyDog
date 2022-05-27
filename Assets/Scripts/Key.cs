using UnityEngine;

public class Key : Pickup
{
    [SerializeField] private GameObject DoorToDisable;

    protected override void OnCollect(Collider2D other)
    {
        if (other.TryGetComponent(out PlayerController wallet))
        {
            DoorToDisable.SetActive(false);
        }
    
    }
}