﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Microsoft.PWABuilder.IOS.Web.Models
{
    public abstract class XcodeItem
    {
        protected XcodeItem(string path)
        {
            this.ItemPath = path;
        }

        public string ItemPath { get; protected init; }

        public abstract string Name { get; protected set; }
    }
}
