using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

//195
namespace PacktLibrary
{
    public class DvdPlayer : IPlayable
    {
        public void Pause()
        {
            WriteLine("DVD player is pausing.");
        }
        public void Play()
        {
            WriteLine("DVD player is playing.");
        }
    }
}
