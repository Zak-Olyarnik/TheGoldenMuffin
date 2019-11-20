using UnityEngine;
using UnityEngine.UI;

public class TradeUI : MonoBehaviour
{
    [SerializeField] private ShopMenu shopMenu = default;       // reference to shop menu UI
    [SerializeField] private Text[] sellQuantities = default;   // reference to number text UI
    [SerializeField] private Image[] sellImages = default;      // reference to image UI
    [SerializeField] protected Text[] buyQuantities = default;  // reference to number text UI
    [SerializeField] protected Image[] buyImages = default;     // reference to image UI
    [SerializeField] private Button tradeButton = default;      // reference to button UI
    [SerializeField] private Sprite[] muffinSprites = default;  // reference to list of all possible muffin sprites

    protected Trade currentTrade;   // the trade whose selling and buying groups are currently displayed by this column


    // Updates this column to display a given trade
    public virtual void DisplayTrade(Trade in_trade)
    {
        currentTrade = in_trade;

        // Selling group
        int currentIndex = 0;
        foreach(DarkMagician.Muffin muffin in currentTrade.Selling.Keys)
        {
            sellQuantities[currentIndex].text = currentTrade.Selling[muffin].ToString("00");
            sellImages[currentIndex].sprite = GetSpriteForItem(muffin);
            currentIndex++;
        }

        // Buying group
        currentIndex = 0;
        foreach (DarkMagician.Muffin muffin in currentTrade.Buying.Keys)
        {
            buyQuantities[currentIndex].text = currentTrade.Buying[muffin].ToString("00");
            buyImages[currentIndex].sprite = GetSpriteForItem(muffin);
            buyQuantities[currentIndex].gameObject.transform.parent.gameObject.SetActive(true);
            currentIndex++;
        }
        // Unlike the selling group, the number of muffins here may change with the displayed trade, so turn off any unused UI
        while (currentIndex < buyQuantities.Length)
        {
            buyQuantities[currentIndex].gameObject.transform.parent.gameObject.SetActive(false);
            currentIndex++;
        }

        BuyCheck();
    }

    // Enables the trade button for this trade if the player has the inventory to make it
    public void BuyCheck()
    {
        foreach (DarkMagician.Muffin muffin in currentTrade.Buying.Keys)
        {
            if(shopMenu.PlayerInventory[muffin] < currentTrade.Buying[muffin])
            {
                tradeButton.interactable = false;
                return;
            }
        }
        tradeButton.interactable = true;
    }

    // Returns the corresponding muffin sprite to display
    protected Sprite GetSpriteForItem(DarkMagician.Muffin in_muffin)
    {
        switch(in_muffin)
        {
            case DarkMagician.Muffin.GOLD:
                return muffinSprites[0];
            case DarkMagician.Muffin.CHOCOLATE:
                return muffinSprites[1];
            case DarkMagician.Muffin.BLUEBERRY:
                return muffinSprites[2];
            case DarkMagician.Muffin.STRAWBERRY:
                return muffinSprites[3];
            case DarkMagician.Muffin.CHIP:
                return muffinSprites[4];
            case DarkMagician.Muffin.BRAN:
                return muffinSprites[5];
            default:
                return null;    // unreachable code
        }
    }
}
