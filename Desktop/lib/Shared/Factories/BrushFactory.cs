using System.Windows.Media;

namespace Desktop.Shared
{
    public static class BrushFactory
    {
        public static Brush Create(string color)
        {
            if (BrushCollection.ContainsKey(color))
                return BrushCollection.Where(a => a.Key.Equals(color)).FirstOrDefault().Value;

            else
                return Brushes.Black;
        }

        public static IDictionary<string, Brush> BrushCollection
        {
            get
            {
                return new Dictionary<string, Brush>()
                {
                    { nameof(Brushes.AliceBlue), Brushes.AliceBlue },
                    { nameof(Brushes.AntiqueWhite), Brushes.AntiqueWhite },
                    { nameof(Brushes.Aqua), Brushes.Aqua },
                    { nameof(Brushes.Aquamarine), Brushes.Aquamarine },
                    { nameof(Brushes.Azure), Brushes.Azure },

                    { nameof(Brushes.Beige), Brushes.Beige },
                    { nameof(Brushes.Bisque), Brushes.Bisque },
                    { nameof(Brushes.Black), Brushes.Black },
                    { nameof(Brushes.BlanchedAlmond), Brushes.BlanchedAlmond },
                    { nameof(Brushes.Blue), Brushes.Blue },
                    { nameof(Brushes.BlueViolet), Brushes.BlueViolet },
                    { nameof(Brushes.Brown), Brushes.Brown },
                    { nameof(Brushes.BurlyWood), Brushes.BurlyWood },

                    { nameof(Brushes.CadetBlue), Brushes.CadetBlue },
                    { nameof(Brushes.Chartreuse), Brushes.Chartreuse },
                    { nameof(Brushes.Chocolate), Brushes.Chocolate },
                    { nameof(Brushes.Coral), Brushes.Coral },
                    { nameof(Brushes.CornflowerBlue), Brushes.CornflowerBlue },
                    { nameof(Brushes.Cornsilk), Brushes.Cornsilk },
                    { nameof(Brushes.Crimson), Brushes.Crimson },
                    { nameof(Brushes.Cyan), Brushes.Cyan },

                    { nameof(Brushes.DarkBlue), Brushes.DarkBlue },
                    { nameof(Brushes.DarkCyan), Brushes.DarkCyan },
                    { nameof(Brushes.DarkGoldenrod), Brushes.DarkGoldenrod },
                    { nameof(Brushes.DarkGray), Brushes.DarkGray },
                    { nameof(Brushes.DarkGreen), Brushes.DarkGreen },
                    { nameof(Brushes.DarkKhaki), Brushes.DarkKhaki },
                    { nameof(Brushes.DarkMagenta), Brushes.DarkMagenta },
                    { nameof(Brushes.DarkOliveGreen), Brushes.DarkOliveGreen },
                    { nameof(Brushes.DarkOrange), Brushes.DarkOrange },
                    { nameof(Brushes.DarkOrchid), Brushes.DarkOrchid },

                    { nameof(Brushes.DarkRed), Brushes.DarkRed },
                    { nameof(Brushes.DarkSalmon), Brushes.DarkSalmon },
                    { nameof(Brushes.DarkSeaGreen), Brushes.DarkSeaGreen },
                    { nameof(Brushes.DarkSlateBlue), Brushes.DarkSlateBlue },
                    { nameof(Brushes.DarkSlateGray), Brushes.DarkSlateGray },
                    { nameof(Brushes.DarkTurquoise), Brushes.DarkTurquoise },
                    { nameof(Brushes.DarkViolet), Brushes.DarkViolet },
                    { nameof(Brushes.DeepPink), Brushes.DeepPink },
                    { nameof(Brushes.DeepSkyBlue), Brushes.DeepSkyBlue },
                    { nameof(Brushes.DimGray), Brushes.DimGray },
                    { nameof(Brushes.DodgerBlue), Brushes.DodgerBlue },

                    { nameof(Brushes.Firebrick), Brushes.Firebrick },
                    { nameof(Brushes.FloralWhite), Brushes.FloralWhite },
                    { nameof(Brushes.ForestGreen), Brushes.ForestGreen },
                    { nameof(Brushes.Fuchsia), Brushes.Fuchsia },

                    { nameof(Brushes.Gainsboro), Brushes.Gainsboro },
                    { nameof(Brushes.GhostWhite), Brushes.GhostWhite },
                    { nameof(Brushes.Gold), Brushes.Gold },
                    { nameof(Brushes.Goldenrod), Brushes.Goldenrod },
                    { nameof(Brushes.Gray), Brushes.Gray },
                    { nameof(Brushes.Green), Brushes.Green },
                    { nameof(Brushes.GreenYellow), Brushes.GreenYellow },

                    { nameof(Brushes.Honeydew), Brushes.Honeydew },
                    { nameof(Brushes.HotPink), Brushes.HotPink },

                    { nameof(Brushes.IndianRed), Brushes.IndianRed },
                    { nameof(Brushes.Indigo), Brushes.Indigo },
                    { nameof(Brushes.Ivory), Brushes.Ivory },                   

                    { nameof(Brushes.Khaki), Brushes.Khaki },

                    { nameof(Brushes.Lavender), Brushes.Lavender },
                    { nameof(Brushes.LavenderBlush), Brushes.LavenderBlush },
                    { nameof(Brushes.LawnGreen), Brushes.LawnGreen },
                    { nameof(Brushes.LemonChiffon), Brushes.LemonChiffon },
                    { nameof(Brushes.LightBlue), Brushes.LightBlue },
                    { nameof(Brushes.LightCoral), Brushes.LightCoral },
                    { nameof(Brushes.LightCyan), Brushes.LightCyan },
                    { nameof(Brushes.LightGoldenrodYellow), Brushes.LightGoldenrodYellow },
                    { nameof(Brushes.LightGray), Brushes.LightGray },
                    { nameof(Brushes.LightGreen), Brushes.LightGreen },                    
                    { nameof(Brushes.LightPink), Brushes.LightPink },
                    { nameof(Brushes.LightSalmon), Brushes.LightSalmon },
                    { nameof(Brushes.LightSeaGreen), Brushes.LightSeaGreen },
                    { nameof(Brushes.LightSkyBlue), Brushes.LightSkyBlue },
                    { nameof(Brushes.LightSlateGray), Brushes.LightSlateGray },                    
                    { nameof(Brushes.LightSteelBlue), Brushes.LightSteelBlue },
                    { nameof(Brushes.LightYellow), Brushes.LightYellow },
                    { nameof(Brushes.Lime), Brushes.Lime },
                    { nameof(Brushes.LimeGreen), Brushes.LimeGreen },
                    { nameof(Brushes.Linen), Brushes.Linen },
                    
                    { nameof(Brushes.Magenta), Brushes.Magenta },
                    { nameof(Brushes.Maroon), Brushes.Maroon },
                    { nameof(Brushes.MediumAquamarine), Brushes.MediumAquamarine },
                    { nameof(Brushes.MediumBlue), Brushes.MediumBlue },
                    { nameof(Brushes.MediumOrchid), Brushes.MediumOrchid },
                    { nameof(Brushes.MediumPurple), Brushes.MediumPurple },
                    { nameof(Brushes.MediumSeaGreen), Brushes.MediumSeaGreen },
                    { nameof(Brushes.MediumSlateBlue), Brushes.MediumSlateBlue },
                    { nameof(Brushes.MediumSpringGreen), Brushes.MediumSpringGreen },
                    { nameof(Brushes.MediumTurquoise), Brushes.MediumTurquoise },
                    { nameof(Brushes.MediumVioletRed), Brushes.MediumVioletRed },
                    { nameof(Brushes.MidnightBlue), Brushes.MidnightBlue },
                    { nameof(Brushes.MintCream), Brushes.MintCream },
                    { nameof(Brushes.MistyRose), Brushes.MistyRose },
                    { nameof(Brushes.Moccasin), Brushes.Moccasin },
                    
                    { nameof(Brushes.NavajoWhite), Brushes.NavajoWhite },
                    { nameof(Brushes.Navy), Brushes.Navy },

                    { nameof(Brushes.OldLace), Brushes.OldLace },
                    { nameof(Brushes.Olive), Brushes.Olive },
                    { nameof(Brushes.OliveDrab), Brushes.OliveDrab },
                    { nameof(Brushes.Orange), Brushes.Orange },
                    { nameof(Brushes.OrangeRed), Brushes.OrangeRed },
                    { nameof(Brushes.Orchid), Brushes.Orchid },

                    { nameof(Brushes.PaleGoldenrod), Brushes.PaleGoldenrod },
                    { nameof(Brushes.PaleGreen), Brushes.PaleGreen },
                    { nameof(Brushes.PaleTurquoise), Brushes.PaleTurquoise },
                    { nameof(Brushes.PaleVioletRed), Brushes.PaleVioletRed },
                    { nameof(Brushes.PapayaWhip), Brushes.PapayaWhip },
                    { nameof(Brushes.PeachPuff), Brushes.PeachPuff },
                    { nameof(Brushes.Peru), Brushes.Peru },
                    { nameof(Brushes.Pink), Brushes.Pink },
                    { nameof(Brushes.Plum), Brushes.Plum },
                    { nameof(Brushes.PowderBlue), Brushes.PowderBlue },
                    { nameof(Brushes.Purple), Brushes.Purple },

                    { nameof(Brushes.Red), Brushes.Red },
                    { nameof(Brushes.RosyBrown), Brushes.RosyBrown },
                    { nameof(Brushes.RoyalBlue), Brushes.RoyalBlue },

                    { nameof(Brushes.SaddleBrown), Brushes.SaddleBrown },
                    { nameof(Brushes.Salmon), Brushes.Salmon },
                    { nameof(Brushes.SandyBrown), Brushes.SandyBrown },
                    { nameof(Brushes.SeaGreen), Brushes.SeaGreen },
                    { nameof(Brushes.SeaShell), Brushes.SeaShell },
                    { nameof(Brushes.Sienna), Brushes.Sienna },
                    { nameof(Brushes.Silver), Brushes.Silver },
                    { nameof(Brushes.SkyBlue), Brushes.SkyBlue },
                    { nameof(Brushes.SlateBlue), Brushes.SlateBlue },
                    { nameof(Brushes.SlateGray), Brushes.SlateGray },
                    { nameof(Brushes.Snow), Brushes.Snow },
                    { nameof(Brushes.SpringGreen), Brushes.SpringGreen },
                    { nameof(Brushes.SteelBlue), Brushes.SteelBlue },

                    { nameof(Brushes.Transparent), Brushes.Transparent },
                    { nameof(Brushes.Tan), Brushes.Tan },
                    { nameof(Brushes.Teal), Brushes.Teal },
                    { nameof(Brushes.Thistle), Brushes.Thistle },
                    { nameof(Brushes.Tomato), Brushes.Tomato },
                    { nameof(Brushes.Turquoise), Brushes.Turquoise },

                    { nameof(Brushes.Violet), Brushes.Violet },

                    { nameof(Brushes.White), Brushes.White },
                    { nameof(Brushes.Wheat), Brushes.Wheat },
                    { nameof(Brushes.WhiteSmoke), Brushes.WhiteSmoke },

                    { nameof(Brushes.Yellow), Brushes.Yellow },
                    { nameof(Brushes.YellowGreen), Brushes.YellowGreen }                    
                };
            }
        }
    }
}
