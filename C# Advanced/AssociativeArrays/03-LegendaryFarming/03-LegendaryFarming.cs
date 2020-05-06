using System;
using System.Collections.Generic;
using System.Linq;


namespace _03_LegendaryFarming
{
    class Program
    {
        static void Main(string[] args)
        {
			//Some changes
            var collection = new Dictionary<string, int>
            {
                {"shards", 0 },
                {"motes", 0 },
                {"fragments", 0 }
            };
            var junk = new Dictionary<string, int>();
            while(true)
            {
                bool legendaryItem = false;
                var collectionsQnty = Console.ReadLine().ToLower().Split().ToList();
                
                for (int i = 0; i < collectionsQnty.Count; i+=2)
                {
                    string type = collectionsQnty[i + 1];
                    int qnty = int.Parse(collectionsQnty[i]);

                    if(collection.ContainsKey(type))
                    {
                        collection[type] += qnty;
                        if (collection["motes"] >= 250 || collection["fragments"] >= 250 || collection["shards"] >= 250)
                        {
                            collection[type] -= 250;
                            if (type=="motes")
                            {
                                Console.WriteLine("Dragonwrath obtained!");

                            }
                            else if (type=="fragments")
                            {
                                Console.WriteLine("Valanyr obtained!");
                            }
                            else if (type=="shards")
                            {
                                Console.WriteLine("Shadowmourne obtained!");
                            }
                            
                            legendaryItem = true;
                            break;
                        }
                    }
                    else
                    {
                        if (junk.ContainsKey(type))
                            junk[type] += qnty;
                        else
                            junk.Add(type, qnty);
                    }
                    
                }
                if (legendaryItem)
                    break;
            }
            foreach (var item in collection.OrderByDescending(x=>x.Value).ThenBy(x=>x.Key))
            {
                Console.WriteLine(item.Key+": "+item.Value);
            }
            foreach (var item in junk.OrderBy(x=>x.Key))
            {
                Console.WriteLine(item.Key + ": " + item.Value);
            }
        }
    }
}
