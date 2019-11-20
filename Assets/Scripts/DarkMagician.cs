using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DarkMagician : MonoBehaviour
{
    // enum to help keep the different muffin types straight
    public enum Muffin { GOLD=100, CHOCOLATE=50, BLUEBERRY = 25, STRAWBERRY=20, CHIP=10, BRAN=5 }

    // public, static variables need to persist between scene changes
    public static int Clock;        // current game time
    public static int BestTime;     // fastest recorded game time

    [SerializeField] private GameObject winScreen = default;        // reference to win screen UI
    [SerializeField] private ShopMenu shopMenu = default;           // reference to shop menu UI
    [SerializeField] private GoldenTradeUI goldenTrade = default;   // reference to final, golden shop menu UI
    
    [SerializeField] private Text minutesText = default;            // reference to clock's minutes UI text
    [SerializeField] private Text secondsText = default;            // reference to clock's seconds UI text
    [SerializeField] private Shop[] shops = default;                // reference to the list of all shops
    [SerializeField] private Sprite[] bakerSprites = default;       // reference to the list of possible baker sprites


    void Start()
    {
        // Setup trade reference lists (and only do so once per game launch)
        if (Trade.HundredTrades == null) Trade.CreateHundredTradesList();
        if (Trade.AllLayouts == null) Trade.CreateTradeLayoutsList();
        if (Trade.OneTrades == null)
            Trade.CreateTradesLists();
        else
            Trade.ShuffleTradesLists();     // if the trade lists have already been created in a previous round, just reshuffle them

        // Choose a set from the 100 list to be the final target
        int rand = Random.Range(0, Trade.HundredTrades.Count);
        Trade mcGuffin = Trade.HundredTrades[rand];
        goldenTrade.DisplayTrade(mcGuffin);

        // Choose another set from the 100 list to be the player's starting inventory.  Deep copy to avoid
            // changing the list as the player's inventory changes
        rand = Random.Range(0, Trade.HundredTrades.Count);
        Dictionary<Muffin, int> startingInventory = new Dictionary<Muffin, int>(Trade.HundredTrades[rand].Buying);
        shopMenu.SetInitialPlayerInventory(startingInventory);

        // Distribute other trades to the normal shops by iterating through the shops list and trades lists concurrently
        int onesCounter = 0;
        int twosCounter = 0;
        int threesCounter = 0;

        for (int i = 0; i < shops.Length; i++)
        {
            shops[i].Layout = Trade.AllLayouts[i];
            switch(Trade.AllLayouts[i])
            {
                case Trade.ShopLayout.GOLD:
                    // the golden shop is handled above
                    break;
                case Trade.ShopLayout.ONE_THREE_ONE:
                    shops[i].Trades.Add(Trade.OneTrades[onesCounter]);
                    onesCounter++;
                    shops[i].Trades.Add(Trade.ThreeTrades[threesCounter]);
                    threesCounter++;
                    shops[i].Trades.Add(Trade.OneTrades[onesCounter]);
                    onesCounter++;
                    break;
                case Trade.ShopLayout.ONE_TWO_ONE:
                    shops[i].Trades.Add(Trade.OneTrades[onesCounter]);
                    onesCounter++;
                    shops[i].Trades.Add(Trade.TwoTrades[twosCounter]);
                    twosCounter++;
                    shops[i].Trades.Add(Trade.OneTrades[onesCounter]);
                    onesCounter++;
                    break;
                case Trade.ShopLayout.TWO_TWO_TWO:
                    shops[i].Trades.Add(Trade.TwoTrades[twosCounter]);
                    twosCounter++;
                    shops[i].Trades.Add(Trade.TwoTrades[twosCounter]);
                    twosCounter++;
                    shops[i].Trades.Add(Trade.TwoTrades[twosCounter]);
                    twosCounter++;
                    break;
                case Trade.ShopLayout.TWO_ONE_TWO:
                    shops[i].Trades.Add(Trade.TwoTrades[twosCounter]);
                    twosCounter++;
                    shops[i].Trades.Add(Trade.OneTrades[onesCounter]);
                    onesCounter++;
                    shops[i].Trades.Add(Trade.TwoTrades[twosCounter]);
                    twosCounter++;
                    break;
                case Trade.ShopLayout.ONE_ONE_ONE_ONE:
                    shops[i].Trades.Add(Trade.OneTrades[onesCounter]);
                    onesCounter++;
                    shops[i].Trades.Add(Trade.OneTrades[onesCounter]);
                    onesCounter++;
                    shops[i].Trades.Add(Trade.OneTrades[onesCounter]);
                    onesCounter++;
                    shops[i].Trades.Add(Trade.OneTrades[onesCounter]);
                    onesCounter++;
                    break;
            }
        }

        // Randomly assign a baker to each shop
        System.Random rng = new System.Random();
        int n = bakerSprites.Length;
        while (n > 1)   
        {
            int k;
            do
            {
                k = rng.Next(n);
            } while (k == 0);       // NOTE: we want to leave bakerSprites[0] in place
            n--;
            Sprite value = bakerSprites[k];
            bakerSprites[k] = bakerSprites[n];
            bakerSprites[n] = value;
        }
        for (int i = 0; i < shops.Length; i++)
        {
            shops[i].BakerSprite = bakerSprites[i];
        }

        // Start clock
        Clock = 0;
        InvokeRepeating("ClockTick", 1, 1);
    }
    
    // Updates the simple seconds counter, which also serves as a score display
    void ClockTick()
    {
        Clock += 1;    
        minutesText.text = MinutesString(Clock);
        secondsText.text = SecondsString(Clock);
    }

    // Returns a formatted time string
    public static string TimeString(int in_int)
    {
        string minutes = Mathf.Floor(in_int / 60f).ToString("00");
        string seconds = Mathf.Floor(in_int % 60f).ToString("00");

        return string.Format("{0}:{1}", minutes, seconds);
    }

    // Updates the minutes UI text separately, for formatting
    public string MinutesString(int in_int)
    {
        return Mathf.Floor(in_int / 60f).ToString("00");
    }

    // Updates the seconds UI text separately, for formatting
    public string SecondsString(int in_int)
    {
        return Mathf.Floor(in_int % 60f).ToString("00");
    }

    // Loads the win screen when the final trade button is clicked
    public void Win()
    {
        CancelInvoke();
        GetComponent<AudioSource>().Stop();
        winScreen.SetActive(true);
    }
}
