using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Shop : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    public Sprite BakerSprite { get; set; }         // baker sprite associated with this shop (randomly assigned)
    public List<Trade> Trades { get; set; }         // list of trades associated with this shop
    public Trade.ShopLayout Layout { get; set; }    // layout display format

    [SerializeField] private GameObject proximityTrigger = default;     // reference to trigger collider to detect player
    [SerializeField] private GameObject highlight = default;            // reference to highlight effect
    [SerializeField] private PlayerMover player = default;              // reference to player


    private void Awake()
    {
        Trades = new List<Trade>();
    }

    // Sets this shop as the current one, which will be brought up when the player enters the proximity trigger, and
        // sets it to be the player's new destination
        // Also pulses the proximity trigger in case the player is already too close for OnTriggerEnter to be called
    public void OnPointerClick(PointerEventData eventData)
    {
        player.ResetDestination(proximityTrigger.transform.position, this);
        proximityTrigger.SetActive(false);
        proximityTrigger.SetActive(true);
    }

    // Highlights shop sprite on hover
    public void OnPointerEnter(PointerEventData eventData)
    {
        highlight.SetActive(true);
    }

    // Un-highlights shop sprite on un-hover
    public void OnPointerExit(PointerEventData eventData)
    {
        highlight.SetActive(false);
    }
}
