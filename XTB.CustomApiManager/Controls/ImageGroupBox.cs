using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Windows.Forms.VisualStyles;
using System.ComponentModel;

namespace XTB.CustomApiManager.Controls
{
    public class ImageGroupBox : GroupBox
    {
        /// <summary>Contain a reference to the icon to be painted in the header area.</summary>
        private Icon m_Icon = null;
        /// <summary>Contain a reference to the VisualStyleRenderer object that will help in drawing visual styles effects.</summary>
        private VisualStyleRenderer m_Renderer = null;

        /// <summary>Get or set the icon to be painted in the header area.</summary>
        [Description("Icon before the text"), AmbientValue(null), Category("Appearance"), Localizable(true)]
        public Icon Icon
        {
            get { return m_Icon; }
            set { if (m_Icon != value) { m_Icon = value; Invalidate(false); } }
        }

        /// <summary>Override the GroupBox OnPaint method for customized drawing.</summary>
        /// <param name="e">The PaintEventArgs associated object.</param>
        protected override void OnPaint(PaintEventArgs e)
        {
            // This override only draws the control if the icon is not null. Otherwise, the base method is called
            if (m_Icon != null && Application.RenderWithVisualStyles && Width >= 10 && Height >= 10)
            {
                // Draw the entire control
                DrawGroupBox(e.Graphics);
            }
            else base.OnPaint(e);
        }

        /// <summary>Draw the entire control with visual styles effects.</summary>
        /// <param name="grfx">The Graphics object in which the control must painted to.</param>
        private void DrawGroupBox(Graphics grfx)
        {
            // Set the enabled state of the control
            GroupBoxState state = Enabled ? GroupBoxState.Normal : GroupBoxState.Disabled;
            // Set the flags of TextFormat
            TextFormatFlags txtflags = TextFormatFlags.PreserveGraphicsTranslateTransform | TextFormatFlags.PreserveGraphicsClipping | TextFormatFlags.TextBoxControl | TextFormatFlags.WordBreak;
            if (!ShowKeyboardCues) txtflags |= TextFormatFlags.HidePrefix;
            if (RightToLeft == RightToLeft.Yes) txtflags |= TextFormatFlags.RightToLeft | TextFormatFlags.Right;
            // The rectangle that bounds the control
            Rectangle bounds = new Rectangle(0, 0, Width, Height);
            // Initialize the renderer for visual styles
            InitializeRenderer((int)state);
            // Set the rectangle to display the Text
            Size txtsize = TextRenderer.MeasureText(grfx, base.Text, base.Font, new Size(bounds.Width - 14, bounds.Height));
            // The optimized height of the header
            int headerheight = Math.Max(m_Icon.Height, txtsize.Height);
            // Define the rectangle for the icon
            Rectangle iconrect = new Rectangle(9, (headerheight - m_Icon.Height) / 2, m_Icon.Width, m_Icon.Height);
            // Define the rectangle of the text
            Rectangle textrect = new Rectangle(new Point(iconrect.Right, (headerheight - txtsize.Height) / 2), txtsize);
            // Move the rectangles if needed by the txtflags
            if ((txtflags & TextFormatFlags.Right) == TextFormatFlags.Right)
            {
                iconrect.X = bounds.Right - iconrect.Right - 1;
                textrect.X = bounds.Right - textrect.Right - 1;
            }
            // Define the rectangle that defines the inner container
            Rectangle displayrect = bounds; displayrect.Y += headerheight / 2; displayrect.Height -= headerheight / 2;
            // Draw the icon
            DrawIcon(grfx, m_Icon, iconrect, state);
            // Draw the text
            DrawText(grfx, Text, Font, textrect, m_Renderer.GetColor(ColorProperty.TextColor), BackColor, txtflags);
            // Draw the background
            DrawBackground(grfx, displayrect, textrect, m_Icon.Width, txtflags);
            // Clean up
            grfx.Dispose();
        }

        /// <summary>Draw an icon in a enabled or disabled state.</summary>
        /// <param name="grfx">The Graphics object in which the icon must painted to.</param>
        /// <param name="icon">The icon to be painted</param>
        /// <param name="rc">The rectangle that bounds the icon.</param>
        /// <param name="state">Specifies whether the icon must be painted in a disabled or endabled state.</param>
        private void DrawIcon(Graphics grfx, Icon icon, Rectangle rc, GroupBoxState state)
        {
            if (state == GroupBoxState.Disabled)
            {
                using (Image image = m_Icon.ToBitmap())
                {
                    // Draw the disabled icon
                    ControlPaint.DrawImageDisabled(grfx, image, rc.Left, rc.Top, Color.Empty);
                }
            }
            else
            {
                // Draw the enabled icon
                grfx.DrawIcon(icon, rc);
            }
        }

        /// <summary>Draw a text.</summary>
        /// <param name="grfx">The Graphics object in which the text must drawn to.</param>
        /// <param name="text">The text to draw.</param>
        /// <param name="font">The font used to draw the text.</param>
        /// <param name="bounds">The rectangle that bounds the text.</param>
        /// <param name="txtcolor">The fore color of the text.</param>
        /// <param name="backcolor">The color of the background of the text.</param>
        /// <param name="txtflags">Attributes to format the text.</param>
        private void DrawText(Graphics grfx, string text, Font font, Rectangle bounds, Color txtcolor, Color backcolor, TextFormatFlags txtflags)
        {
            TextRenderer.DrawText(grfx, text, font, bounds, txtcolor, backcolor, txtflags);
        }

        /// <summary>Draw the rounded rectangle of the control.</summary>
        /// <param name="grfx">The Graphics object in which the rectangle must drawn to.</param>
        /// <param name="bounds">The rectangle that bounds the rounded rectangle.</param>
        /// <param name="headerrect">The rectangle that bounds the header area.</param>
        /// <param name="iconwidth">The width of the icon of the header.</param>
        /// <param name="txtflags"></param>
        private void DrawBackground(Graphics grfx, Rectangle bounds, Rectangle headerrect, int iconwidth, TextFormatFlags txtflags)
        {
            Rectangle leftrect = bounds; leftrect.Width = 7;
            Rectangle middlerect = bounds; middlerect.Width = Math.Max(0, headerrect.Width + iconwidth);
            Rectangle rightrect = bounds;
            if ((txtflags & TextFormatFlags.Right) == TextFormatFlags.Right)
            {
                leftrect.X = bounds.Right - 7;
                middlerect.X = leftrect.Left - middlerect.Width;
                rightrect.Width = middlerect.X - bounds.X;
            }
            else
            {
                middlerect.X = leftrect.Right;
                rightrect.X = middlerect.Right;
                rightrect.Width = bounds.Right - rightrect.X;
            }
            middlerect.Y = headerrect.Bottom;
            middlerect.Height -= headerrect.Bottom - bounds.Top;
            //VisualStyleRenderer visualstylerenderer = this.CreateRenderer((int)state);
            // Left part
            m_Renderer.DrawBackground(grfx, bounds, leftrect);
            // Middle part
            m_Renderer.DrawBackground(grfx, bounds, middlerect);
            // Right part
            m_Renderer.DrawBackground(grfx, bounds, rightrect);
        }

        /// <summary>Get the color of a text, while the container control is disabled, rendering a disbaled text effect.</summary>
        /// <param name="backColor">The backcolor of the disabled control.</param>
        /// <returns>The disabled color of the text.</returns>
        private Color DisabledTextColor(Color backcolor)
        {
            return GetLuminosity(backcolor) < GetLuminosity(SystemColors.Control) ? ControlPaint.Dark(backcolor) : SystemColors.ControlDark;
        }

        /// <summary>Get the luminosity of a color.</summary>
        /// <param name="color">The color to be analyzed.</param>
        /// <returns>The luminosity of the color.</returns>
        private int GetLuminosity(Color color)
        {
            int num = Math.Max(Math.Max(color.R, color.G), color.B) + Math.Min(Math.Min(color.R, color.G), color.B);
            return (num * 240 + 0xff) / 510;
        }

        /// <summary>Initialize the renderer.</summary>
        /// <param name="state">The state of the control.</param>
        private void InitializeRenderer(int state)
        {
            VisualStyleElement visualstyleelement = VisualStyleElement.Button.GroupBox.Normal;
            if (m_Renderer == null) m_Renderer = new VisualStyleRenderer(visualstyleelement.ClassName, visualstyleelement.Part, state);
            else m_Renderer.SetParameters(visualstyleelement.ClassName, visualstyleelement.Part, state);
        }

        private void InitializeComponent()
        {
            SuspendLayout();
            // 
            // ImageGroupBox
            // 
            Text = "7";
            ResumeLayout(false);

        }
    }
}
