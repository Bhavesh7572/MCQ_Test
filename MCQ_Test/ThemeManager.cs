using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;

namespace MCQ_Test
{
    class ThemeManager
    {
        public static bool IsDarkMode { get; set; }= false;

        // Store the original colors to restore when needed
        private static readonly Dictionary<Control, (Color backColor, Color foreColor)> ControlOriginalColors = new Dictionary<Control, (Color, Color)>();

        // Apply theme (dark or original)
        public static void ApplyTheme(Control control)
        {
            if (IsDarkMode)
                ApplyDarkTheme(control);
            else
                RestoreOriginalTheme(control);
        }

        // Apply Dark Mode colors
        private static void ApplyDarkTheme(Control control)
        {
            Color darkBack = Color.FromArgb(30, 30, 30);
            Color darkFore = Color.White;

            control.BackColor = darkBack;
            control.ForeColor = darkFore;

            foreach (Control child in control.Controls)
            {
                ApplyDarkTheme(child);
            }
        }

        // Restore original theme colors (stored in ControlOriginalColors)
        private static void RestoreOriginalTheme(Control control)
        {
            // If we have previously saved the original colors, restore them
            if (ControlOriginalColors.ContainsKey(control))
            {
                var (originalBackColor, originalForeColor) = ControlOriginalColors[control];
                control.BackColor = originalBackColor;
                control.ForeColor = originalForeColor;
            }
            else
            {
                // If no original color is saved, simply reset to default (set by Designer)
                control.ResetBackColor();
                control.ResetForeColor();
            }

            // Recursively apply to all child controls
            foreach (Control child in control.Controls)
            {
                RestoreOriginalTheme(child);
            }
        }

        // Save the original colors of controls (called in form load or initialization)
        public static void SaveOriginalColors(Control control)
        {
            if (!ControlOriginalColors.ContainsKey(control))
            {
                ControlOriginalColors[control] = (control.BackColor, control.ForeColor);
            }

            foreach (Control child in control.Controls)
            {
                SaveOriginalColors(child);
            }
        }
    }
}
