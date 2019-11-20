using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopMenu : MonoBehaviour
{
    public Dictionary<DarkMagician.Muffin, int> PlayerInventory { get; set; }   // player inventory data
    public Shop CurrentShop { get; set; }                                       // shop whose trades are currently displayed

    [SerializeField] private GameObject[] inventoryQuantities = default;        // reference to player inventory UI
    [SerializeField] private GameObject[] layoutPages = default;                // reference to the different layout pages
    [SerializeField] private Image baker = default;                             // reference to baker image UI
    [SerializeField] private Image quote = default;                             // reference to baker quote UI
    [SerializeField] private Sprite[] quotes = default;                         // reference to list of possible normal quotes
    [SerializeField] private Sprite[] buyQuotes = default;                      // reference to list of possible quotes on buy


    // Sets the player's starting inventory and updates the UI
    public void SetInitialPlayerInventory(Dictionary<DarkMagician.Muffin, int> in_inventory)
    {
        PlayerInventory = in_inventory;

        // Add missing keys to make things easier later
        if (!PlayerInventory.ContainsKey(DarkMagician.Muffin.CHOCOLATE))
            PlayerInventory[DarkMagician.Muffin.CHOCOLATE] = 0;
        if (!PlayerInventory.ContainsKey(DarkMagician.Muffin.BLUEBERRY))
            PlayerInventory[DarkMagician.Muffin.BLUEBERRY] = 0;
        if (!PlayerInventory.ContainsKey(DarkMagician.Muffin.STRAWBERRY))
            PlayerInventory[DarkMagician.Muffin.STRAWBERRY] = 0;
        if (!PlayerInventory.ContainsKey(DarkMagician.Muffin.CHIP))
            PlayerInventory[DarkMagician.Muffin.CHIP] = 0;
        if (!PlayerInventory.ContainsKey(DarkMagician.Muffin.BRAN))
            PlayerInventory[DarkMagician.Muffin.BRAN] = 0;

        UpdatePlayerInventoryUI();
    }

    // Displays the player inventory UI, including hiding items they have zero of
    private void UpdatePlayerInventoryUI()
    {
        if (PlayerInventory[DarkMagician.Muffin.CHOCOLATE] > 0)
        {
            inventoryQuantities[0].GetComponent<Text>().text = PlayerInventory[DarkMagician.Muffin.CHOCOLATE].ToString("00");
            inventoryQuantities[0].SetActive(true);
        }
        else
        {
            inventoryQuantities[0].SetActive(false);
        }
        if (PlayerInventory[DarkMagician.Muffin.BLUEBERRY] > 0)
        {
            inventoryQuantities[1].GetComponent<Text>().text = PlayerInventory[DarkMagician.Muffin.BLUEBERRY].ToString("00");
            inventoryQuantities[1].SetActive(true);
        }
        else
        {
            inventoryQuantities[1].SetActive(false);
        }
        if (PlayerInventory[DarkMagician.Muffin.STRAWBERRY] > 0)
        {
            inventoryQuantities[2].GetComponent<Text>().text = PlayerInventory[DarkMagician.Muffin.STRAWBERRY].ToString("00");
            inventoryQuantities[2].SetActive(true);
        }
        else
        {
            inventoryQuantities[2].SetActive(false);
        }
        if (PlayerInventory[DarkMagician.Muffin.CHIP] > 0)
        {
            inventoryQuantities[3].GetComponent<Text>().text = PlayerInventory[DarkMagician.Muffin.CHIP].ToString("00");
            inventoryQuantities[3].SetActive(true);
        }
        else
        {
            inventoryQuantities[3].SetActive(false);
        }
        if (PlayerInventory[DarkMagician.Muffin.BRAN] > 0)
        {
            inventoryQuantities[4].GetComponent<Text>().text = PlayerInventory[DarkMagician.Muffin.BRAN].ToString("00");
            inventoryQuantities[4].SetActive(true);
        }
        else
        {
            inventoryQuantities[4].SetActive(false);
        }
    }

    // Displays the current shop's possible trades
    private void OnEnable()
    {
        // Turn on the correct layout page
        layoutPages[(int)CurrentShop.Layout].SetActive(true);

        // Set baker and quote sprites
        baker.sprite = CurrentShop.BakerSprite;
        if(CurrentShop.Layout == Trade.ShopLayout.GOLD)
            quote.sprite = quotes[0];
        else
            quote.sprite = quotes[Random.Range(1, quotes.Length)];  
    }

    // Updates the player's inventory as the result of a trade
    public void DoTrade(int in_trade)
    {
        Trade currentTrade = CurrentShop.Trades[in_trade];
        foreach (DarkMagician.Muffin muffin in currentTrade.Selling.Keys)
        {
            PlayerInventory[muffin] = PlayerInventory[muffin] + currentTrade.Selling[muffin];
        }

        foreach (DarkMagician.Muffin muffin in currentTrade.Buying.Keys)
        {
            PlayerInventory[muffin] = PlayerInventory[muffin] - currentTrade.Buying[muffin];
        }

        GetComponent<AudioSource>().Play();
        UpdatePlayerInventoryUI();
        quote.sprite = buyQuotes[Random.Range(1, buyQuotes.Length)];

        layoutPages[(int)CurrentShop.Layout].GetComponent<ShopLayoutPage>().ResetTradeButtons();
    }

    // Closes the menu
    public void BackButtonClick()
    {
        foreach (GameObject page in layoutPages)
            page.SetActive(false);
        gameObject.SetActive(false);
    }
}
