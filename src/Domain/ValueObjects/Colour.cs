﻿using DrumSpace.Domain.Common;
using DrumSpace.Domain.Exceptions;
using System.Collections.Generic;
using System.Linq;

namespace DrumSpace.Domain.ValueObjects
{
    public class Colour : ValueObject
    {
        static Colour()
        {
        }

        private Colour()
        {
        }

        private Colour(string code)
        {
            Code = code;
        }

        public static Colour From(string code)
        {
            Colour colour = new() { Code = code };

            if (!SupportedColours.Contains(colour))
            {
                throw new UnsupportedColourException(code);
            }

            return colour;
        }

        public static Colour White => new("#FFFFFF");

        public static Colour Red => new("#FF5733");

        public static Colour Orange => new("#FFC300");

        public static Colour Yellow => new("#FFFF66");

        public static Colour Green => new("#CCFF99 ");

        public static Colour Blue => new("#6666FF");

        public static Colour Purple => new("#9966CC");

        public static Colour Grey => new("#999999");

        public string Code { get; private set; }

        public static implicit operator string(Colour colour) => colour.ToString();

        public static explicit operator Colour(string code) => From(code);

        public override string ToString() => Code;


        protected static IEnumerable<Colour> SupportedColours
        {
            get
            {
                yield return White;
                yield return Red;
                yield return Orange;
                yield return Yellow;
                yield return Green;
                yield return Blue;
                yield return Purple;
                yield return Grey;
            }
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Code;
        }
    }
}