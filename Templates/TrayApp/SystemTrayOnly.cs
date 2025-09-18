using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TrayApp
{
    internal class SystemTrayOnly: ApplicationContext
    {
        NotifyIcon _icon;
        ContextMenuStrip _menu;

        public SystemTrayOnly()
        {
            _menu = new ContextMenuStrip();
            _menu.Items.Add("Exit", null, OnExit);

            _icon = new NotifyIcon();
            _icon.Icon = Icons.ResourceManager.GetObject("AppIcon") as System.Drawing.Icon;
            _icon.ContextMenuStrip = _menu;

            _icon.Visible = true;
        }

        void OnExit(object? sender, EventArgs e)
        {
            _icon.Visible = false;
            Application.Exit();
        }
    }
}
