using UnityEngine;
using UnityEngine.EventSystems;

public class GymFloor : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private PlayerMover player = default;      // reference to player


    // Reset player's destination when a point on the floor is clicked
    public void OnPointerClick(PointerEventData eventData)
    {
        Vector3 target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        target.z = 0;
        player.ResetDestination(target);
    }
}
