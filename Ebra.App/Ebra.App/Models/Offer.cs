﻿using System;
using System.Collections.Generic;

namespace Ebra.App.Models
{
    public class Offer : EntityBase
    {
        public double discount { get; set; }
        public DateTime endDate { get; set; }
        public DateTime startDate { get; set; }
        public List<Article> articles { get; set; }
    }
}