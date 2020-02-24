using System;
using System.Collections.Generic;

namespace DCP_151
{
    /*
    Given a 2-D matrix representing an image, a location of a pixel in the screen and a color C, 
    replace the color of the given pixel and all adjacent same colored pixels with C.
    */

    public class DCP_151
    {

        static void RecolorPixels (ref Color[, ] screen, int x, int y, Color toColor, int radius)
        {
            Color c = screen[x, y];

            for (int dy = -radius; dy <= radius; dy++)
            {
                for (int dx = -radius; dx <= radius; dx++)
                {
                    if (x + dx < 0 || x + dx >= screen.GetLength (0) || y + dy < 0 || y + dy >= screen.GetLength (1)) continue;
                    if (c.Equals (screen[x + dx, y + dy])) screen[x + dx, y + dy] = Color.Copy (toColor);
                }
            }
        }
    }

    public class Color
    {
        public int r, g, b, a;

        public Color (int r, int g, int b, int a)
        {
            this.r = r;
            this.g = g;
            this.b = b;
            this.a = a;
        }

        public bool Equals (Color c)
        {
            return (c.r == r && c.g == g && c.b == b && c.a == a);
        }

        public static Color Copy (Color c)
        {
            return new Color (c.r, c.g, c.b, c.a);
        }
    }
}