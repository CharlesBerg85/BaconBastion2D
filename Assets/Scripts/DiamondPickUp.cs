using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiamondPickUp : MonoBehaviour
{
    [SerializeField] AudioClip diamondPickupsSFX;
    [SerializeField] int diamondValue = 100;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        AudioSource.PlayClipAtPoint(diamondPickupsSFX, Camera.main.transform.position);
        FindObjectOfType<GameSession>().AddToScore(diamondValue);
        Destroy(gameObject);
    }
}
