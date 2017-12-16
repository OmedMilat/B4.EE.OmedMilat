using SQLite;
using System;

namespace B4.EE.OmedMilat.Domain.Models
{
    [Table(nameof(JarvisCommands))]
    public class JarvisCommands
    {
        public string Joke { get; set; }
    }
}
