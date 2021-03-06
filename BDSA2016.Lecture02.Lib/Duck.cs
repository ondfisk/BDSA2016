﻿using System;
using System.Collections.Generic;

namespace BDSA2016.Lecture02
{
    public class Duck : IEquatable<Duck>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Age { get; set; }

        /// <summary>
        /// Two ducks are considered equal if their Id's match
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool Equals(Duck other)
        {
            if (other == null)
            {
                return false;
            }
            else
            {
                return Id == other.Id;
            }
        }

        /// <summary>
        /// Overridden default equals to compare ducks by Id
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            return Equals(obj as Duck);
        }

        /// <summary>
        /// GetHashCode should always be overridden when Equals is.
        /// https://msdn.microsoft.com/en-us/library/ms182358.aspx 
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return Id;
        }

        public static ICollection<Duck> Ducks = new[] {
            new Duck { Id = 1, Name = "Donald Duck", Age = 32 },
            new Duck { Id = 2, Name = "Daisy Duck", Age = 30 },
            new Duck { Id = 3, Name = "Huey Duck", Age = 10 },
            new Duck { Id = 4, Name = "Dewey Duck", Age = 10 },
            new Duck { Id = 5, Name = "Louie  Duck", Age = 10 },
            new Duck { Id = 6, Name = "Scrooge McDuck", Age = 60 },
            new Duck { Id = 7, Name = "Flintheart Glomgold", Age = 66 },
            new Duck { Id = 8, Name = "Magica De Spell", Age = 302 },
            new Duck { Id = 9, Name = "John D. Rockerduck", Age = 55 }
        };
    }
}