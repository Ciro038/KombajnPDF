using System;
using System.Drawing; // Ensure this using directive is present
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace KombajnPDF.Data.Entity;

/// <summary>
/// Provides helper methods for working with icons in WinForms, including resizing and applying them to buttons.
/// </summary>
public static class IconsProvider
{
    /// <summary>
    /// Resizes an image to fit within the specified size while preserving the aspect ratio.
    /// </summary>
    /// <param name="image">The source image to be resized.</param>
    /// <param name="targetSize">The target size within which the image should fit.</param>
    /// <returns>A new <see cref="Image"/> instance resized and centered inside the target dimensions.</returns>
    /// <exception cref="ArgumentNullException">Thrown if the image or targetSize is null.</exception>
    private static Image ResizeImage(Image image, Size targetSize)
    {
        ArgumentNullException.ThrowIfNull(image);
        ArgumentNullException.ThrowIfNull(targetSize);


        // -1 px bufor bezpieczeństwa (WinForms Button clipping)
        int safeWidth = targetSize.Width - 1;
        int safeHeight = targetSize.Height - 1;

        // Calculate scale to maintain aspect ratio
        float ratioX = (float)safeWidth / image.Width;
        float ratioY = (float)safeHeight / image.Height;
        float scale = Math.Min(ratioX, ratioY);

        // Calculate scaled dimensions
        int scaledWidth = (int)Math.Floor(image.Width * scale);
        int scaledHeight = (int)Math.Floor(image.Height * scale);

        // Calculate position to center the image
        int posX = (safeWidth - scaledWidth) / 2;
        int posY = (safeHeight - scaledHeight) / 2;

        // Create resized bitmap
        var result = new Bitmap(safeWidth, safeHeight);
        using (Graphics g = Graphics.FromImage(result))
        {
            g.Clear(Color.Transparent);
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
            g.PixelOffsetMode = PixelOffsetMode.HighQuality;
            g.SmoothingMode = SmoothingMode.HighQuality;
            g.DrawImage(image, posX, posY, scaledWidth, scaledHeight);
        }

        return result;
    }

    /// <summary>
    /// Sets an icon as the image of a button, resizing it to fit while preserving its aspect ratio.
    /// Clears any text and applies a flat style.
    /// </summary>
    /// <param name="button">The button to which the icon will be applied.</param>
    /// <param name="icon">The icon to be used.</param>
    /// <exception cref="ArgumentNullException">Thrown if the button or icon is null.</exception>
    public static void SetIconWithResize(Button button, Icon icon)
    {
        ArgumentNullException.ThrowIfNull(button);
        ArgumentNullException.ThrowIfNull(icon);

        button.AutoSize = false;
        button.UseVisualStyleBackColor = false;
        button.FlatStyle = FlatStyle.Flat;
        button.FlatAppearance.BorderSize = 0;
        button.Padding = new Padding(2);
        button.Text = string.Empty;
        button.ImageAlign = ContentAlignment.MiddleCenter;
        button.TextImageRelation = TextImageRelation.Overlay;
        button.BackColor = Color.Transparent;

        using var originalIcon = icon.ToBitmap();

        var targetSize = new Size(
            button.ClientSize.Width - button.Padding.Horizontal,
            button.ClientSize.Height - button.Padding.Vertical
        );

        var resizedIcon = ResizeImage(originalIcon, targetSize);

        button.Image = resizedIcon;

    }
}
