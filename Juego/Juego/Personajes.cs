using System;
using System.Collections.Generic;
using System.Text;

namespace Personajes
{
    enum Maximos
    {
        VelocidadMax = 10,
        DestrezaMax = 5,
        FuerzaMax = 10,
        NivelMax = 10,
        ArmaduraMax = 10,
        SaludMax = 100,
        DañoMax = 50000,
    }
    public class Personaje
    {
        //Datos
        string tipo;
        string nombre;
        string apodo;
        string fechaDeNacimiento;
        int edad;
        int salud;

        //Caracteristicas
        int velocidad;
        int destreza;
        int fuerza;
        int nivel;
        int armadura;


        //Datos
        public string Tipo { get => tipo; set => tipo = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Apodo { get => apodo; set => apodo = value; }
        public string FechaDeNacimiento { get => fechaDeNacimiento; set => fechaDeNacimiento = value; }
        public int Edad { get => edad; set => edad = value; }
        public int Salud { get => salud; set => salud = value; }


        //Caracteristicas
        public int Velocidad { get => velocidad; set => velocidad = value; }
        public int Destreza { get => destreza; set => destreza = value; }
        public int Fuerza { get => fuerza; set => fuerza = value; }
        public int Nivel { get => nivel; set => nivel = value; }
        public int Armadura { get => armadura; set => armadura = value; }

        public int Atacar(Personaje Defensor)
        {
            float PoderDeAtaque = Destreza * Fuerza * Nivel;
            float EfectividadDeDisparo = new Random().Next(20,50); //Le reduzco algo para que sea mas "equilibrado"
            float ValorDeAtaque = PoderDeAtaque * EfectividadDeDisparo;
            float PoderDeDefensa = Defensor.Armadura * Defensor.Velocidad;
            int DañoProvocado = (int)((((ValorDeAtaque * EfectividadDeDisparo) - PoderDeDefensa) / (int)Maximos.DañoMax) * 10);

            Defensor.Salud -= DañoProvocado;
            return DañoProvocado;
        }
    }
}
