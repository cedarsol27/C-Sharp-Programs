using System;
using System.Collections.Generic; // Keep these packages

namespace MajorAssignment03
{
    class Shape  // Base class (parent) 
    {
        string PrintShape = "Shape"; // Here is a field/attribute, unnecessary, but helpful for the future
        public virtual void Draw() // base method 'Draw'
        {
            Console.WriteLine("I am a shape! Shapes are cool!");
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine(PrintShape); //Calls the field "PrintShape"
            }
        }
    }

    class Triangle : Shape  // Derived class (child) 
    {
        public override void Draw() // method 'Draw', overwrites base method
        {
            Console.WriteLine("\nI am a triangle");
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine("I have 3 sides");
            }
            base.Draw(); // go to base (Parent) and run method
        }
    }

    class Circle : Shape  // Derived class (child) 
    {
        public override void Draw() // method 'Draw', overwrites base method
        {
            Console.WriteLine("\nI am round...");
            for (int i = 0; i < 7; i++)
            {
                Console.WriteLine("I like to roll!");
            }
            base.Draw(); // go to base (Parent) and run method
        }
    }

    class Rectangle : Shape  // Derived class (child) 
    {
        public override void Draw() // method 'Draw', overwrites base method
        {
            Console.WriteLine("\nI am a rectangle...who has 4 sides");
            base.Draw(); // go to base (Parent) and run method
        }
    }

    class RunShape // main class
    {
        static void Main()
        {
            var shapes = new List<Shape> // New var called shapes and a new list pulling from the Class
            {
                new Rectangle(), // Here the derived classes are being overridden from the base class
                new Triangle(),  // so each shape has priority to be written
                new Circle()
            };

            foreach (var shape in shapes) // Var here is a new var called shape, and pulls from var shapes
            {                             // For each individual shape is shapes...
                shape.Draw();             // Draw shape, now this goes through each of the List<Shape> objects
            }                             // and prints out Rectangle, Triangle, and Circle
        }                                 // This makes adding a new class very easy and simple by addting it to a new class
    }                                     // and then adding to the List
}