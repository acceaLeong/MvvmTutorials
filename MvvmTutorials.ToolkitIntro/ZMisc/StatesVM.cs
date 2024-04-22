using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MvvmTutorials.ToolkitIntro.ZMisc;

public partial class StatesVM
{
    public List<States> StatesList { get; set; }

    public StatesVM()
    {
        StatesList = new List<States>
        {
            new States
            {
                State = "Alabama ->",
                County = "Limestone ->",
                City = "Ardmore ->",
                Zipcode = 35759,
            },
            new States
            {
                State = "Alabama ->",
                County = "Madison ->",
                City = "Madison ->",
                Zipcode = 35758,
            },
            new States
            {
                State = "Alabama ->",
                County = "Jefferson ->",
                City = "Birmingham ->",
                Zipcode = 35211,
            }
        };
    }
}