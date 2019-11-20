using System.Collections.Generic;

public class Trade
{
    // enum to help keep the different muffin types straight
    public enum ShopLayout { GOLD=0, ONE_THREE_ONE=1, ONE_TWO_ONE=2, TWO_TWO_TWO=3, TWO_ONE_TWO=4, ONE_ONE_ONE_ONE=5 }

    // reference lists
    public static List<ShopLayout> AllLayouts; // list of trade layouts to assign to the shops
    public static List<Trade> OneTrades;        // list of all trades with one selling muffin
    public static List<Trade> TwoTrades;        // list of all trades with two selling muffins
    public static List<Trade> ThreeTrades;      // list of all trades with three selling muffins
    public static List<Trade> HundredTrades;    // list of all ways to make 100, for golden trade and player starting inventory

    // dictionaries store the muffin types and their quantities in the selling and buying groups of each trade
    public Dictionary<DarkMagician.Muffin, int> Selling = new Dictionary<DarkMagician.Muffin, int>();
    public Dictionary<DarkMagician.Muffin, int> Buying = new Dictionary<DarkMagician.Muffin, int>();


    // Trade constructor takes two list of ints corresponding to the Muffin enum values, one for the buying group and one for the selling group 
    public Trade(List<int> in_selling, List<int> in_buying)
    {
        // Convert selling group ints to Muffin enums and increment their number in the Selling dictionary
        foreach (int i in in_selling)
        {
            DarkMagician.Muffin key = (DarkMagician.Muffin)i;
            if (Selling.ContainsKey(key))
                Selling[key] = Selling[key] + 1;
            else
                Selling.Add(key, 1);
        }

        // Convert buying group ints to Muffin enums and increment their number in the Buying dictionary
        foreach (int i in in_buying)
        {
            DarkMagician.Muffin key = (DarkMagician.Muffin)i;
            if (Buying.ContainsKey(key))
                Buying[key] = Buying[key] + 1;
            else
                Buying.Add(key, 1);
        }
    }

    // Create list of all layout possibilities; the number of each was calculated based on the total number of each trade type
    public static void CreateTradeLayoutsList()
    {
        AllLayouts = new List<ShopLayout>();
        AllLayouts.Add(ShopLayout.ONE_THREE_ONE);
        AllLayouts.Add(ShopLayout.ONE_THREE_ONE);
        AllLayouts.Add(ShopLayout.ONE_THREE_ONE);
        AllLayouts.Add(ShopLayout.ONE_THREE_ONE);
        AllLayouts.Add(ShopLayout.ONE_THREE_ONE);
        AllLayouts.Add(ShopLayout.ONE_TWO_ONE);
        AllLayouts.Add(ShopLayout.ONE_TWO_ONE);
        AllLayouts.Add(ShopLayout.ONE_TWO_ONE);
        AllLayouts.Add(ShopLayout.ONE_TWO_ONE);
        AllLayouts.Add(ShopLayout.ONE_TWO_ONE);
        AllLayouts.Add(ShopLayout.ONE_TWO_ONE);
        AllLayouts.Add(ShopLayout.TWO_TWO_TWO);
        AllLayouts.Add(ShopLayout.TWO_ONE_TWO);
        AllLayouts.Add(ShopLayout.TWO_ONE_TWO);
        AllLayouts.Add(ShopLayout.ONE_ONE_ONE_ONE);
        AllLayouts.Add(ShopLayout.ONE_ONE_ONE_ONE);

        // Shuffle the list and add the gold layout to the front
        AllLayouts.Shuffle();
        AllLayouts.Insert(0, ShopLayout.GOLD);
    }

    // Create lists of all ways to make denominations 10-50, organized based on the number of muffin types in the selling group
    public static void CreateTradesLists()
    {
        OneTrades = new List<Trade>();
        // 1 for 1
        OneTrades.Add(new Trade(new List<int> { 10 }, new List<int> { 5, 5 }));
        OneTrades.Add(new Trade(new List<int> { 20 }, new List<int> { 5, 5, 5, 5 }));
        OneTrades.Add(new Trade(new List<int> { 20 }, new List<int> { 10, 10 }));
        OneTrades.Add(new Trade(new List<int> { 25 }, new List<int> { 5, 5, 5, 5, 5 }));
        OneTrades.Add(new Trade(new List<int> { 50 }, new List<int> { 5, 5, 5, 5, 5, 5, 5, 5, 5, 5 }));
        OneTrades.Add(new Trade(new List<int> { 50 }, new List<int> { 10, 10, 10, 10, 10 }));
        OneTrades.Add(new Trade(new List<int> { 50 }, new List<int> { 25, 25 }));
        // 1 for 2
        OneTrades.Add(new Trade(new List<int> { 20 }, new List<int> { 5, 5, 10 }));
        OneTrades.Add(new Trade(new List<int> { 25 }, new List<int> { 5, 5, 5, 10 }));
        OneTrades.Add(new Trade(new List<int> { 25 }, new List<int> { 5, 10, 10 }));
        OneTrades.Add(new Trade(new List<int> { 25 }, new List<int> { 5, 20 }));    
        OneTrades.Add(new Trade(new List<int> { 50 }, new List<int> { 5, 5, 5, 5, 5, 5, 5, 5, 10 }));
        OneTrades.Add(new Trade(new List<int> { 50 }, new List<int> { 5, 5, 5, 5, 5, 5, 10, 10 }));
        OneTrades.Add(new Trade(new List<int> { 50 }, new List<int> { 5, 5, 5, 5, 5, 5, 20 }));
        OneTrades.Add(new Trade(new List<int> { 50 }, new List<int> { 5, 5, 5, 5, 5, 25 }));
        OneTrades.Add(new Trade(new List<int> { 50 }, new List<int> { 5, 5, 5, 5, 10, 10, 10 }));
        OneTrades.Add(new Trade(new List<int> { 50 }, new List<int> { 5, 5, 10, 10, 10, 10 }));
        OneTrades.Add(new Trade(new List<int> { 50 }, new List<int> { 5, 5, 20, 20 }));
        OneTrades.Add(new Trade(new List<int> { 50 }, new List<int> { 10, 10, 10, 20 }));
        OneTrades.Add(new Trade(new List<int> { 50 }, new List<int> { 10, 20, 20 }));
        // 1 for 3
        OneTrades.Add(new Trade(new List<int> { 50 }, new List<int> { 5, 5, 5, 5, 5, 10, 20 }));
        OneTrades.Add(new Trade(new List<int> { 50 }, new List<int> { 5, 5, 5, 10, 25 }));
        OneTrades.Add(new Trade(new List<int> { 50 }, new List<int> { 5, 5, 10, 10, 20 }));
        OneTrades.Add(new Trade(new List<int> { 50 }, new List<int> { 5, 10, 10, 25 }));
        OneTrades.Add(new Trade(new List<int> { 50 }, new List<int> { 5, 20, 25 }));
        // 1 for 1 reversed
        OneTrades.Add(new Trade(new List<int> { 5, 5 }, new List<int> { 10 }));
        OneTrades.Add(new Trade(new List<int> { 5, 5, 5, 5 }, new List<int> { 20 }));
        OneTrades.Add(new Trade(new List<int> { 10, 10 }, new List<int> { 20 }));
        OneTrades.Add(new Trade(new List<int> { 5, 5, 5, 5, 5 }, new List<int> { 25 }));
        OneTrades.Add(new Trade(new List<int> { 5, 5, 5, 5, 5, 5, 5, 5, 5, 5 }, new List<int> { 50 }));
        OneTrades.Add(new Trade(new List<int> { 10, 10, 10, 10, 10 }, new List<int> { 50 }));
        OneTrades.Add(new Trade(new List<int> { 25, 25 }, new List<int> { 50 }));

        TwoTrades = new List<Trade>();  
        // 2 for 1
        TwoTrades.Add(new Trade(new List<int> { 5, 5, 10 }, new List<int> { 20 }));
        TwoTrades.Add(new Trade(new List<int> { 5, 5, 5, 10 }, new List<int> { 25 }));
        TwoTrades.Add(new Trade(new List<int> { 5, 10, 10 }, new List<int> { 25 }));
        TwoTrades.Add(new Trade(new List<int> { 5, 20 }, new List<int> { 25 }));
        TwoTrades.Add(new Trade(new List<int> { 5, 5, 5, 5, 5, 5, 5, 5, 10 }, new List<int> { 50 }));
        TwoTrades.Add(new Trade(new List<int> { 5, 5, 5, 5, 5, 5, 10, 10 }, new List<int> { 50 }));
        TwoTrades.Add(new Trade(new List<int> { 5, 5, 5, 5, 5, 5, 20 }, new List<int> { 50 }));
        TwoTrades.Add(new Trade(new List<int> { 5, 5, 5, 5, 5, 25 }, new List<int> { 50 }));
        TwoTrades.Add(new Trade(new List<int> { 5, 5, 5, 5, 10, 10, 10 }, new List<int> { 50 }));
        TwoTrades.Add(new Trade(new List<int> { 5, 5, 10, 10, 10, 10 }, new List<int> { 50 }));
        TwoTrades.Add(new Trade(new List<int> { 5, 5, 20, 20 }, new List<int> { 50 }));
        TwoTrades.Add(new Trade(new List<int> { 10, 10, 10, 20 }, new List<int> { 50 }));
        TwoTrades.Add(new Trade(new List<int> { 10, 20, 20 }, new List<int> { 50 }));
        // 2 for 2
        //TwoTrades.Add(new Trade(new List<int> { 5, 25 }, new List<int> { 10, 20 }));
        //TwoTrades.Add(new Trade(new List<int> { 5, 20, 20 }, new List<int> { 10, 10, 25 }));
        //TwoTrades.Add(new Trade(new List<int> { 10, 20 }, new List<int> { 5, 25 }));
        //TwoTrades.Add(new Trade(new List<int> { 10, 10, 25 }, new List<int> { 5, 20, 20 }));

        ThreeTrades = new List<Trade>();
        // 3 for 1
        ThreeTrades.Add(new Trade(new List<int> { 5, 5, 5, 5, 5, 10, 20 }, new List<int> { 50 }));
        ThreeTrades.Add(new Trade(new List<int> { 5, 5, 5, 10, 25 }, new List<int> { 50 }));
        ThreeTrades.Add(new Trade(new List<int> { 5, 5, 10, 10, 20 }, new List<int> { 50 }));
        ThreeTrades.Add(new Trade(new List<int> { 5, 10, 10, 25 }, new List<int> { 50 }));
        ThreeTrades.Add(new Trade(new List<int> { 5, 20, 25 }, new List<int> { 50 }));

        // Shuffle the lists
        ShuffleTradesLists();
    }

    // Shuffles the trade lists
    public static void ShuffleTradesLists()
    {
        OneTrades.Shuffle();
        TwoTrades.Shuffle();
        ThreeTrades.Shuffle();
    }

    // Create list of all ways to make 100; one of these will be picked for the final trade and one will be the player's starting inventory
    public static void CreateHundredTradesList()
    {
        HundredTrades = new List<Trade>();

        // twenty 5s
        HundredTrades.Add(new Trade(new List<int> { 100 }, new List<int> { 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5 }));
        // eighteen 5s
        HundredTrades.Add(new Trade(new List<int> { 100 }, new List<int> { 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 10 }));
        // sixteen 5s
        HundredTrades.Add(new Trade(new List<int> { 100 }, new List<int> { 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 10, 10 }));
        HundredTrades.Add(new Trade(new List<int> { 100 }, new List<int> { 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 20 }));
        // fifteen 5s
        HundredTrades.Add(new Trade(new List<int> { 100 }, new List<int> { 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 25 }));
        // fourteen 5s
        HundredTrades.Add(new Trade(new List<int> { 100 }, new List<int> { 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 10, 10, 10 }));
        HundredTrades.Add(new Trade(new List<int> { 100 }, new List<int> { 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 10, 20 }));
        // thirteen 5s
        HundredTrades.Add(new Trade(new List<int> { 100 }, new List<int> { 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 10, 25 }));
        // twelve 5s
        HundredTrades.Add(new Trade(new List<int> { 100 }, new List<int> { 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 10, 10, 10, 10 }));
        HundredTrades.Add(new Trade(new List<int> { 100 }, new List<int> { 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 10, 10, 20 }));
        HundredTrades.Add(new Trade(new List<int> { 100 }, new List<int> { 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 20, 20 }));
        HundredTrades.Add(new Trade(new List<int> { 100 }, new List<int> { 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 20, 20 }));
        // eleven 5s
        HundredTrades.Add(new Trade(new List<int> { 100 }, new List<int> { 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 10, 10, 25 }));
        HundredTrades.Add(new Trade(new List<int> { 100 }, new List<int> { 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 20, 25 }));
        // ten 5s
        HundredTrades.Add(new Trade(new List<int> { 100 }, new List<int> { 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 10, 10, 10, 10, 10 }));
        HundredTrades.Add(new Trade(new List<int> { 100 }, new List<int> { 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 10, 10, 10, 20 }));
        HundredTrades.Add(new Trade(new List<int> { 100 }, new List<int> { 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 10, 20, 20 }));
        HundredTrades.Add(new Trade(new List<int> { 100 }, new List<int> { 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 25, 25 }));
        HundredTrades.Add(new Trade(new List<int> { 100 }, new List<int> { 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 50 }));
        // nine 5s
        HundredTrades.Add(new Trade(new List<int> { 100 }, new List<int> { 5, 5, 5, 5, 5, 5, 5, 5, 5, 10, 10, 10, 25 }));
        HundredTrades.Add(new Trade(new List<int> { 100 }, new List<int> { 5, 5, 5, 5, 5, 5, 5, 5, 5, 10, 20, 25 }));
        // eight 5s
        HundredTrades.Add(new Trade(new List<int> { 100 }, new List<int> { 5, 5, 5, 5, 5, 5, 5, 5, 10, 10, 10, 10, 10, 10 }));
        HundredTrades.Add(new Trade(new List<int> { 100 }, new List<int> { 5, 5, 5, 5, 5, 5, 5, 5, 10, 10, 10, 10, 20 }));
        HundredTrades.Add(new Trade(new List<int> { 100 }, new List<int> { 5, 5, 5, 5, 5, 5, 5, 5, 10, 10, 20, 20 }));
        HundredTrades.Add(new Trade(new List<int> { 100 }, new List<int> { 5, 5, 5, 5, 5, 5, 5, 5, 10, 50 }));
        HundredTrades.Add(new Trade(new List<int> { 100 }, new List<int> { 5, 5, 5, 5, 5, 5, 5, 5, 20, 20, 20 }));
        // seven 5s
        HundredTrades.Add(new Trade(new List<int> { 100 }, new List<int> { 5, 5, 5, 5, 5, 5, 5, 10, 10, 10, 10, 25 }));
        HundredTrades.Add(new Trade(new List<int> { 100 }, new List<int> { 5, 5, 5, 5, 5, 5, 5, 10, 10, 20, 25 }));
        HundredTrades.Add(new Trade(new List<int> { 100 }, new List<int> { 5, 5, 5, 5, 5, 5, 5, 20, 20, 25 }));
        // six 5s
        HundredTrades.Add(new Trade(new List<int> { 100 }, new List<int> { 5, 5, 5, 5, 5, 5, 10, 10, 10, 10, 10, 10, 10 }));
        HundredTrades.Add(new Trade(new List<int> { 100 }, new List<int> { 5, 5, 5, 5, 5, 5, 10, 10, 10, 10, 10, 20 }));
        HundredTrades.Add(new Trade(new List<int> { 100 }, new List<int> { 5, 5, 5, 5, 5, 5, 10, 10, 10, 20, 20 }));
        HundredTrades.Add(new Trade(new List<int> { 100 }, new List<int> { 5, 5, 5, 5, 5, 5, 10, 10, 25, 25 }));
        HundredTrades.Add(new Trade(new List<int> { 100 }, new List<int> { 5, 5, 5, 5, 5, 5, 10, 10, 50 }));
        HundredTrades.Add(new Trade(new List<int> { 100 }, new List<int> { 5, 5, 5, 5, 5, 5, 10, 20, 20, 20 }));
        HundredTrades.Add(new Trade(new List<int> { 100 }, new List<int> { 5, 5, 5, 5, 5, 5, 20, 50 }));
        // five 5s
        HundredTrades.Add(new Trade(new List<int> { 100 }, new List<int> { 5, 5, 5, 5, 5, 10, 10, 10, 10, 10, 25 }));
        HundredTrades.Add(new Trade(new List<int> { 100 }, new List<int> { 5, 5, 5, 5, 5, 10, 10, 10, 20, 25 }));
        HundredTrades.Add(new Trade(new List<int> { 100 }, new List<int> { 5, 5, 5, 5, 5, 10, 20, 20, 25 }));
        HundredTrades.Add(new Trade(new List<int> { 100 }, new List<int> { 5, 5, 5, 5, 5, 25, 50 }));
        // four 5s
        HundredTrades.Add(new Trade(new List<int> { 100 }, new List<int> { 5, 5, 5, 5, 10, 10, 10, 10, 10, 10, 10, 10 }));
        HundredTrades.Add(new Trade(new List<int> { 100 }, new List<int> { 5, 5, 5, 5, 10, 10, 10, 10, 10, 10, 20 }));
        HundredTrades.Add(new Trade(new List<int> { 100 }, new List<int> { 5, 5, 5, 5, 10, 10, 10, 10, 20, 20 }));
        HundredTrades.Add(new Trade(new List<int> { 100 }, new List<int> { 5, 5, 5, 5, 10, 10, 10, 25, 25 }));
        HundredTrades.Add(new Trade(new List<int> { 100 }, new List<int> { 5, 5, 5, 5, 10, 10, 10, 50 }));
        HundredTrades.Add(new Trade(new List<int> { 100 }, new List<int> { 5, 5, 5, 5, 10, 10, 20, 20, 20 }));
        HundredTrades.Add(new Trade(new List<int> { 100 }, new List<int> { 5, 5, 5, 5, 10, 20, 50 }));
        HundredTrades.Add(new Trade(new List<int> { 100 }, new List<int> { 5, 5, 5, 5, 20, 20, 20, 20 }));
        // three 5s
        HundredTrades.Add(new Trade(new List<int> { 100 }, new List<int> { 5, 5, 5, 10, 10, 10, 10, 10, 10, 25 }));
        HundredTrades.Add(new Trade(new List<int> { 100 }, new List<int> { 5, 5, 5, 10, 10, 10, 10, 20, 25 }));
        HundredTrades.Add(new Trade(new List<int> { 100 }, new List<int> { 5, 5, 5, 10, 10, 20, 20, 25 }));
        HundredTrades.Add(new Trade(new List<int> { 100 }, new List<int> { 5, 5, 5, 10, 25, 50 }));
        HundredTrades.Add(new Trade(new List<int> { 100 }, new List<int> { 5, 5, 5, 20, 20, 20, 25 }));
        // two 5s
        HundredTrades.Add(new Trade(new List<int> { 100 }, new List<int> { 5, 5, 10, 10, 10, 10, 10, 10, 10, 10, 10 }));
        HundredTrades.Add(new Trade(new List<int> { 100 }, new List<int> { 5, 5, 10, 10, 10, 10, 10, 10, 10, 20 }));
        HundredTrades.Add(new Trade(new List<int> { 100 }, new List<int> { 5, 5, 10, 10, 10, 10, 10, 20, 20 }));
        HundredTrades.Add(new Trade(new List<int> { 100 }, new List<int> { 5, 5, 10, 10, 10, 10, 25, 25 }));
        HundredTrades.Add(new Trade(new List<int> { 100 }, new List<int> { 5, 5, 10, 10, 10, 10, 50 }));
        HundredTrades.Add(new Trade(new List<int> { 100 }, new List<int> { 5, 5, 10, 10, 10, 20, 20, 20 }));
        HundredTrades.Add(new Trade(new List<int> { 100 }, new List<int> { 5, 5, 10, 10, 20, 50 }));
        HundredTrades.Add(new Trade(new List<int> { 100 }, new List<int> { 5, 5, 10, 10, 20, 25, 25 }));
        HundredTrades.Add(new Trade(new List<int> { 100 }, new List<int> { 5, 5, 10, 20, 20, 20, 20 }));
        HundredTrades.Add(new Trade(new List<int> { 100 }, new List<int> { 5, 5, 20, 20, 25, 25 }));
        HundredTrades.Add(new Trade(new List<int> { 100 }, new List<int> { 5, 5, 20, 20, 50 }));
        // one 5
        HundredTrades.Add(new Trade(new List<int> { 100 }, new List<int> { 5, 10, 10, 10, 10, 10, 10, 10, 25 }));
        HundredTrades.Add(new Trade(new List<int> { 100 }, new List<int> { 5, 10, 10, 10, 10, 10, 20, 25 }));
        HundredTrades.Add(new Trade(new List<int> { 100 }, new List<int> { 5, 10, 10, 10, 20, 20, 25 }));
        HundredTrades.Add(new Trade(new List<int> { 100 }, new List<int> { 5, 10, 10, 25, 50 }));
        HundredTrades.Add(new Trade(new List<int> { 100 }, new List<int> { 5, 10, 20, 20, 20, 25 }));
        HundredTrades.Add(new Trade(new List<int> { 100 }, new List<int> { 5, 20, 25, 50 }));
        // no 5s
        HundredTrades.Add(new Trade(new List<int> { 100 }, new List<int> { 10, 10, 10, 10, 10, 10, 10, 10, 10, 10 }));
        HundredTrades.Add(new Trade(new List<int> { 100 }, new List<int> { 10, 10, 10, 10, 10, 10, 10, 10, 20 }));
        HundredTrades.Add(new Trade(new List<int> { 100 }, new List<int> { 10, 10, 10, 10, 10, 10, 20, 20 }));
        HundredTrades.Add(new Trade(new List<int> { 100 }, new List<int> { 10, 10, 10, 10, 10, 25, 25 }));
        HundredTrades.Add(new Trade(new List<int> { 100 }, new List<int> { 10, 10, 10, 10, 20, 20, 20 }));
        HundredTrades.Add(new Trade(new List<int> { 100 }, new List<int> { 10, 10, 10, 20, 25, 25 }));
        HundredTrades.Add(new Trade(new List<int> { 100 }, new List<int> { 10, 10, 20, 20, 20, 20 }));
        HundredTrades.Add(new Trade(new List<int> { 100 }, new List<int> { 10, 20, 20, 25, 25 }));
        HundredTrades.Add(new Trade(new List<int> { 100 }, new List<int> { 25, 25, 50 }));
        HundredTrades.Add(new Trade(new List<int> { 100 }, new List<int> { 50, 50 }));
    }
}
