﻿using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using Personajes;
using Clases;
using System.Globalization;

namespace Juego
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Personaje> ListaDePersonajes = new List<Personaje>();
            Funciones Funcion = new Funciones();
            int CantidadDePersonajes = 2;

            for (int i = 0; i < CantidadDePersonajes; i++)
            {
                Personaje NuevoPersonaje = new Personaje();

                NuevoPersonaje = Funcion.CargarDatos(NuevoPersonaje);
                NuevoPersonaje = Funcion.CargarCaracteristicas(NuevoPersonaje);

                ListaDePersonajes.Add(NuevoPersonaje);
            }

            for(int i = 0; i < CantidadDePersonajes; i++)
            {
                Console.WriteLine(Funcion.MostrarDatos(ListaDePersonajes[i]));
                Console.WriteLine(Funcion.MostrarCaracteristicas(ListaDePersonajes[i]));
            }

            Console.WriteLine("\nPresiona ENTER para continuar...");
            Console.ReadLine();
            Console.Clear();

            Personaje Personaje1 = ListaDePersonajes[0];
            Personaje Personaje2 = ListaDePersonajes[1];

            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine(Funcion.Combate(Personaje1, Personaje2));
                Console.WriteLine(Funcion.Combate(Personaje2, Personaje1));
            }

            Console.WriteLine("\nPresiona ENTER para revelar el ganador...");
            Console.ReadLine();
            Console.Clear();

            if (Funcion.Ganador(Personaje1, Personaje2,ListaDePersonajes) != null)
            {
                Personaje Ganador = Funcion.Ganador(Personaje1, Personaje2,ListaDePersonajes);
                Console.WriteLine(Funcion.InformacionDelGanador(Ganador));
                Console.WriteLine(Funcion.RecompensaAleatoria(Ganador));
            }
            else
            {
                Console.WriteLine("\nIncreible!, termino en un empate, los dos personajes son eliminados!\n");
            }
        }
    }
}