﻿using System;

namespace App.Models
{
    public interface IGoodieFormModel
    {
        public Tuple<string, string> SelectedGoodies { get; }
    }
}