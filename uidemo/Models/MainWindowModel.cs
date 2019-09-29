using System;
using System.Collections.Generic;
using System.Text;

namespace uidemo.Models
{
    public class MainWindowModel
    {
        public MainWindowActionBarItem[] ActionBarItems { get; } = new[]
        {
            new MainWindowActionBarItem { Name = "MAP", PageName = "Map" },
            new MainWindowActionBarItem { Name = "APPROACH", PageName = "Approach" },
            new MainWindowActionBarItem { Name = "RUNWAYS", PageName = "Runways" },
            new MainWindowActionBarItem { Name = "ARF", PageName = "Arf" },
        };
    }

    public class MainWindowActionBarItem
    {
        public string Name { get; set; }
        public string PageName { get; set; }
    }
}
