using System;
using System.Drawing; // Ensure this using directive is present
using System.Windows.Forms;

namespace KombajnPDF.Data.Abstract;

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

        // Calculate scale to maintain aspect ratio
        float ratioX = (float)targetSize.Width / image.Width;
        float ratioY = (float)targetSize.Height / image.Height;
        float scale = Math.Min(ratioX, ratioY);

        // Calculate scaled dimensions
        int scaledWidth = (int)(image.Width * scale) - 1;
        int scaledHeight = (int)(image.Height * scale) - 1;

        // Calculate position to center the image
        int posX = (targetSize.Width - scaledWidth) / 2;
        int posY = (targetSize.Height - scaledHeight) / 2;

        // Create resized bitmap
        var result = new Bitmap(targetSize.Width, targetSize.Height);
        using (Graphics g = Graphics.FromImage(result))
        {
            g.Clear(Color.Transparent);
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
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
