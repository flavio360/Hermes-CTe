﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration.Install;
using System.Linq;
using System.Threading.Tasks;

namespace WindowsServiceGeraFilaCTe
{
    [RunInstaller(true)]
    public partial class ProjectInstallerGeraFilaCTe : System.Configuration.Install.Installer
    {
        public ProjectInstallerGeraFilaCTe()
        {
            InitializeComponent();
        }
    }
}
