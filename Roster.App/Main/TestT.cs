﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roster.App.Main
{
    public class Poo { }
    public class RadioactivePoo : Poo { }

    // just a marker interface, to get the poo type
    public interface IPooProvider<PooType> { }

    // Extension method to get the correct type of excrement
    public static class IPooProviderExtension
    {
        public static PooType StronglyTypedExcrement<PooType>(
            this IPooProvider<PooType> iPooProvider)
            where PooType : Poo
        {
            BaseAnimal animal = iPooProvider as BaseAnimal;
            if (null == animal)
            {
                //throw new InvalidArgumentException("iPooProvider must be a BaseAnimal.");
            }
            return (PooType)animal.Excrement;
        }
    }

    public class BaseAnimal
    {
        public virtual Poo Excrement
        {
            get { return new Poo(); }
        }
    }

    public class Dog : BaseAnimal, IPooProvider<Poo> { }

    public class Cat : BaseAnimal, IPooProvider<RadioactivePoo>
    {
        public override Poo Excrement
        {
            get { return new RadioactivePoo(); }
        }
    }

    /*
    class Program
    {
        static void Main(string[] args)
        {
            Dog dog = new Dog();
            Poo dogPoo = dog.Excrement;

            Cat cat = new Cat();
            RadioactivePoo catPoo = cat.StronglyTypedExcrement();
        }
    }
    */
}
