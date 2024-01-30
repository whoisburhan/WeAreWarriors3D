public class CoinInTextForm
{
    public static string CoinInText(int amount)
    {
        if (amount < 1000) return amount.ToString();
        else if (amount >= 1000 && amount < 1000000) return (amount / 1000f).ToString("F1") + "K";
        else return (amount / 1000000f).ToString("F1") + "M";
    }
}
