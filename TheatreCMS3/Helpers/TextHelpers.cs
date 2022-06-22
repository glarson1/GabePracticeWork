using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TheatreCMS3.Helpers
{
    public static class TextHelpers    
    {
        public static string CharacterLimit(string Input, int Length)
        {
            if (Input.Length < Length) return Input;
            return Input.Substring(0, Length) + "...";
        }
    }
}