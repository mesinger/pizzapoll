﻿using System;
using System.Collections.Generic;

namespace App.Models
{
    public class GoodieFormModel
    {
        public Dictionary<string, bool> SelectedGoodies { get; } = new Dictionary<string, bool>()
        {
            {"garlic", false},
            {"fullgrain", false},
        };
    }
}