using UnityEngine;

public class ShopLayoutPage : MonoBehaviour
{
    [SerializeField] private ShopMenu shopMenu = default;       // reference to shop menu UI
    [SerializeField] private TradeUI[] trades = default;        // reference to trade column UI on this page


    // Makes the trades display themselves when this page becomes active
    private void OnEnable()
    {
        for(int i=0; i<trades.Length; i++)
        {
            trades[i].DisplayTrade(shopMenu.CurrentShop.Trades[i]);
        }
    }

    // Turn each trade's button on/off, called when a trade is made on this page
    public void ResetTradeButtons()
    {
        foreach (TradeUI trade in trades)
            trade.BuyCheck();
    }

}
