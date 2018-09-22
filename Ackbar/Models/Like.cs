﻿using System;

namespace Ackbar.Models
{
    public class Like
    {
        public long Id { get; set; }
        public DateTime DateTime { get; set; }
        public Game Game { get; set; }
        public Player Player { get; set; }
    }
}