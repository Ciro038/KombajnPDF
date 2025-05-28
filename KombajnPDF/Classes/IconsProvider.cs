using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KombajnPDF.Classes
{
    public static class IconsProvider
    {
        private static Image ResizeImage(Image image, Size targetSize)
        {
            if (image == null)
                throw new ArgumentNullException(nameof(image));

            // Oblicz skalę, aby zachować proporcje
            float ratioX = (float)targetSize.Width / image.Width;
            float ratioY = (float)targetSize.Height / image.Height;
            float scale = Math.Min(ratioX, ratioY);

            // Oblicz nowy rozmiar
            int scaledWidth = (int)(image.Width * scale) - 1;
            int scaledHeight = (int)(image.Height * scale) - 1;

            // Oblicz pozycję, aby wyśrodkować obraz
            int posX = (targetSize.Width - scaledWidth) / 2;
            int posY = (targetSize.Height - scaledHeight) / 2;

            // Utwórz nowe płótno
            var result = new Bitmap(targetSize.Width, targetSize.Height);
            using (Graphics g = Graphics.FromImage(result))
            {
                g.Clear(Color.Transparent);
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                g.DrawImage(image, posX, posY, scaledWidth, scaledHeight);
            }

            return result;
        }
        public static void SetIconWithResize(Button button, Icon icon)
        {
            if (button == null || icon == null)
                throw new ArgumentNullException("Button and icon cannot be null.");
            var originalIcon = icon.ToBitmap();
            var resizedIcon = ResizeImage(originalIcon, button.ClientSize);
            button.Image = resizedIcon;
            button.Text = string.Empty;
            button.ImageAlign = ContentAlignment.MiddleCenter;
            button.FlatStyle = FlatStyle.Flat;
            button.FlatAppearance.BorderSize = 0;
            button.BackColor = Color.Transparent;
            button.TextImageRelation = TextImageRelation.Overlay;
        }

    }
}
