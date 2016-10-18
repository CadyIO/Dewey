using System.Windows.Forms;

namespace Dewey.WinForms
{
    /// <summary>
    /// Extension methods for a TableLayoutPanel
    /// </summary>
    public static class TableLayoutPanelExtensions
    {
        /// <summary>
        /// Fix the padding on a TableLayoutPanel
        /// </summary>
        /// <param name="value">The TableLayoutPanel to fix</param>
        /// <param name="paddingLeft">The padding on the left side</param>
        /// <param name="paddingRight">The padding on the right side</param>
        /// <param name="leaveSpaceForScrollbar">True to account for space for the scrollbar, False otherwise</param>
        public static void FixPadding(this TableLayoutPanel value, int paddingLeft, int paddingRight, bool leaveSpaceForScrollbar)
        {
            if (value.VerticalScroll.Visible) {
                value.Padding = new Padding(paddingLeft, 0, paddingRight + SystemInformation.VerticalScrollBarWidth, 0);
                value.Padding = new Padding(paddingLeft, 0, paddingRight, 0);
            } else {
                if (leaveSpaceForScrollbar) {
                    value.Padding = new Padding(paddingLeft, 0, paddingRight + SystemInformation.VerticalScrollBarWidth, 0);
                } else {
                    value.Padding = new Padding(paddingLeft, 0, paddingRight, 0);
                }
            }
        }
    }
}
