﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace Performances.Model
{
    public class CreativeTeam
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public BitmapImage Photo { get; set; }
        public string Genre { get; set; }
        public string About { get; set; }
        public int SubscribersCount { get; set; }
        public double Rating { get; set; }
    }
}
