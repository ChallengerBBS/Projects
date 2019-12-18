using System;
using System.Linq;
using System.IO;
using System.Collections.Generic;


namespace Problem04
{
    class Program
    {
        static void Main(string[] args)
        {
            string picPath = "copyMe.png";
            string copyPicPath = "copyMe-copy.png";
            using (var streamReader = new FileStream(picPath, FileMode.Open))
            {
               
                using (FileStream streamWriter = new FileStream(copyPicPath, FileMode.Create))
                {
                    while(true)
                    {
                        byte[] byteArray = new byte[4096];
                        var size = streamReader.Read(byteArray, 0, byteArray.Length);
                        
                        if(size == 0)
                        {
                            break;
                        }
                        streamWriter.Write(byteArray, 0, byteArray.Length);
                    }
                }

            }
        }
    }
}
