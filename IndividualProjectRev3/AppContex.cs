using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndividualProjectRev3
{
    public partial class AppContex : Component
    {
        public AppContex()
        {
            InitializeComponent();
        }

        public AppContex(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }
    }
}
