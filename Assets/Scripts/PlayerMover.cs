using Pathfinding;
using UnityEngine;

// The player is controlled by simple A* destination-setting pathing
public class PlayerMover : AIPath
{
    [Header("Player Properties")]
    [SerializeField] private ShopMenu shopMenu = default;   // reference to shop menu UI

    private Shop targetShop;    // player's current destination shop

    //private readonly float speed = 3f;            // speed of movement (now controlled by A* component)
    private readonly float shopLoadDelay = 0.3f;    // duration to wait before loading the shop menu


    // Set's the player's current navigation destination
        // in_targetShop will be null if a target was set by clicking the empty floor
    public void ResetDestination(Vector3 in_destination, Shop in_targetShop = null)
    {
        destination = in_destination;
        targetShop = in_targetShop;
        SearchPath();
    }

    // Loads the shop menu when the player reaches the shop set as their target
        // Also snaps the player into a fixed position and rotates them to face the shop
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Shop") && collision.GetComponentInParent<Shop>() == targetShop)
        {
            Invoke("LoadShop", shopLoadDelay);
            transform.position = collision.transform.position;
            transform.rotation = collision.transform.rotation;
        }
    }

    // Loads the shop menu UI and nulls TargetShop to stop accidentally re-triggering it again afterwards
    private void LoadShop()
    {
        shopMenu.CurrentShop = targetShop;
        shopMenu.gameObject.SetActive(true);
        targetShop = null;
    }
}
