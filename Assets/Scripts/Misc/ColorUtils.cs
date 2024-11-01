using System.Globalization;
using UnityEngine;

namespace StarsProject.Misc
{
    public static class ColorUtils
    {
        public static Color HexToColor(string hex)
        {
            if (hex.Length != 6 && hex.Length != 8)
            {
                Debug.LogWarning("Hex string should be 6 (RGB) or 8 (RGBA) characters long.");
                return Color.white;
            }

            var r = byte.Parse(hex.Substring(0, 2), NumberStyles.HexNumber);
            var g = byte.Parse(hex.Substring(2, 2), NumberStyles.HexNumber);
            var b = byte.Parse(hex.Substring(4, 2), NumberStyles.HexNumber);
            var a = hex.Length == 8 ? byte.Parse(hex.Substring(6, 2), NumberStyles.HexNumber) : (byte)255;

            return new Color(r / 255f, g / 255f, b / 255f, a / 255f);
        }

        public static Color SetOpacity(this Color color, float alpha)
        {
            var newColor = color;
            newColor.a = alpha;
            return newColor;
        }
    }
}