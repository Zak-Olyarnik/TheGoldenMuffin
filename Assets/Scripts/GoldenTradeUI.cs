using UnityEngine;
using UnityEngine.UI;

public class GoldenTradeUI : TradeUI
{
    [SerializeField] private Image dividingLine = default;      // reference to the dividing line image UI

    private readonly int[] dividingLineWidths = new int[] { 350, 1050, 1300, 1400 };    // preset lengths of the dividing line depending on the trade buying quantities


    // Updates the UI for displaying the golden shop.  Unlike the base method, this override is only called once, 
        // at game start
    public override void DisplayTrade(Trade in_trade)
    {
        currentTrade = in_trade;
        int currentIndex = 0;
        foreach (DarkMagician.Muffin muffin in currentTrade.Buying.Keys)
        {
            buyQuantities[currentIndex].text = currentTrade.Buying[muffin].ToString("00");
            buyImages[currentIndex].sprite = GetSpriteForItem(muffin);
            buyQuantities[currentIndex].gameObject.transform.parent.gameObject.SetActive(true);
            currentIndex++;
        }
        dividingLine.rectTransform.sizeDelta = new Vector2(dividingLineWidths[currentIndex-1], dividingLine.rectTransform.sizeDelta.y);
    }

    private void OnEnable()
    {
        BuyCheck();
    }
}
