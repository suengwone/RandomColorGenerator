using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Util.ColorExtension
{
    public static class RandomUniqueColorGenerator
    {
        private static HashSet<Color32> UniqueColorSet = new HashSet<Color32>();

        public static List<Color> GetUniqueColors(int count)
        {
            List<Color> result = new List<Color>();

            do
            {
                var rgb = GenerateRandomColor32();
                if(UniqueColorSet.Add(rgb))
                    result.Add(rgb);
            } while(count != result.Count);

            // Check for duplicate colors
            result.Distinct();

            if(count != result.Count)
            {
                Debug.Log("!!!!!!! Find Same Color !!!!!!!");
                return GetUniqueColors(count);
            }
            
            return result;
        }

        private static Color32 GenerateRandomColor32()
            => new Color32((byte)Random.Range(0,255), (byte)Random.Range(0,255), (byte)Random.Range(0,255), 255);

        public static Color GetUniqueColor()
            => GetUniqueColors(1)[0];
    }
}
