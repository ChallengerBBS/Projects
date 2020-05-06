using System;

class HolidaysBetweenTwoDates
{
    static void Main()
    {
        
        int lostgames = int.Parse(Console.ReadLine());
        double headsetPrice = double.Parse(Console.ReadLine());
        double mousePrice = double.Parse(Console.ReadLine());
        double keyboardPrice = double.Parse(Console.ReadLine());
        double monitorPrice = double.Parse(Console.ReadLine());
        
        int trashedHeadsetCount = 0;
        int trashedMouseCount = 0;
        int trashedKeyboardCount = 0;
        int trashedMonitorCount = 0;
        for (int game = 1; game <= lostgames; game++)
        {
            if (game % 12 == 0)
                trashedMonitorCount++;
            if (game % 6 == 0)
                trashedKeyboardCount++;
            if (game % 3 == 0)
                trashedMouseCount++;
            if (game % 2 == 0)
                trashedHeadsetCount++;
        }
        double expenses = trashedHeadsetCount * headsetPrice
            + trashedKeyboardCount * keyboardPrice
            + trashedMonitorCount * monitorPrice
            + trashedMouseCount * mousePrice;
        
        Console.WriteLine($"Rage expenses: {expenses:f2} lv.");
    }
}
