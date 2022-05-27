using UnityEngine;

public class Coin : Pickup
{
    protected override void OnCollect(Collider2D other)
    {
        if (other.TryGetComponent(out Wallet wallet))
        {
            wallet.IncrementCoins();
        }
    }
}