using System;
using System.Collections.Generic;
using System.Text;
using Juego;
using Personajes;

namespace Clases
{
    public class Funciones
    {
        internal Personaje CargarDatos(Personaje NuevoPersonaje)
        {
            Helper Helper = new Helper();
            string[] Tipo = new string[] { "Duende", "Humano", "Orco", "Elfo", "Enano", "Trol", "Lycan", "Trol", "No-muerto", "Lizzard" };

            string[] NombresHombre = new string[] { "John", "Mike", "Charlie", "Gabriel", "Patrick", "Peter" };
            string[] NombresMujer = new string[] { "Ashley", "Nancy", "Abby", "Evie", "Johanna", "Sistine" };

            string[] ApodosHombre = new string[] { "El Demoledor", "El Asesino", "El Sigiloso", "El Dominador", "El Destructor", "El Maniaco", "El Ninja" };
            string[] ApodosMujer = new string[] { "La Demoledora", "La Asesina", "La Sigilosa", "La Dominadora", "La Destructora", "La Maniaca", "La Ninja" };

            int aux = new Random().Next(2);
            if (aux == 0)
            {
                NuevoPersonaje.Nombre = NombresHombre[new Random().Next(6)];
                NuevoPersonaje.Apodo = ApodosHombre[new Random().Next(7)];
            }
            else
            {
                NuevoPersonaje.Nombre = NombresMujer[new Random().Next(6)];
                NuevoPersonaje.Apodo = ApodosMujer[new Random().Next(7)];
            }

            NuevoPersonaje.Tipo = Tipo[new Random().Next(10)];
            NuevoPersonaje.FechaDeNacimiento = Helper.gen_fecha();
            NuevoPersonaje.Edad = Helper.Edad;
            NuevoPersonaje.Salud = (int)Maximos.SaludMax;

            return NuevoPersonaje;
        }

        internal Personaje CargarCaracteristicas(Personaje NuevoPersonaje)
        {
            NuevoPersonaje.Velocidad = new Random().Next(1, (int)Maximos.VelocidadMax);
            NuevoPersonaje.Destreza = new Random().Next(1, (int)Maximos.DestrezaMax);
            NuevoPersonaje.Fuerza = new Random().Next(1, (int)Maximos.FuerzaMax);
            NuevoPersonaje.Nivel = new Random().Next(1, (int)Maximos.NivelMax);
            NuevoPersonaje.Armadura = new Random().Next(1, (int)Maximos.ArmaduraMax);

            return NuevoPersonaje;
        }

        internal string MostrarDatos(Personaje NuevoPersonaje)
        {
            string Datos = "DATOS \n\n" +
            "Tipo: " + NuevoPersonaje.Tipo + " \n" +
            "Nombre: " + NuevoPersonaje.Nombre + " " +
            NuevoPersonaje.Apodo + " \n" +
            "Fecha de Nacimiento: " + NuevoPersonaje.FechaDeNacimiento + " \n" +
            "Edad: " + NuevoPersonaje.Edad + " \n" +
            "Salud: " + NuevoPersonaje.Salud + " \n";

            return Datos;
        }

        internal string MostrarCaracteristicas(Personaje NuevoPersonaje)
        {
            string Caracteristicas = "CARACTERISTICAS \n\n" +
            "Velocidad: " + NuevoPersonaje.Velocidad + " \n" +
            "Destreza: " + NuevoPersonaje.Destreza + " \n" +
            "Fuerza: " + NuevoPersonaje.Fuerza + " \n" +
            "Nivel: " + NuevoPersonaje.Nivel + " \n" +
            "Armadura: " + NuevoPersonaje.Armadura + " \n";

            return Caracteristicas;
        }

        internal string Combate(Personaje Atacante, Personaje Defensor)
        {
            string Informe;
            int Daño = Atacante.Atacar(Defensor);
            if(Daño == 0){
                Informe = Defensor.Nombre + " " + Defensor.Apodo + " a esquivado el atacaque de " + Atacante.Nombre + " " + Atacante.Apodo + "\n";
            }
            else if (Daño <= 5)
            {
                Informe = Atacante.Nombre + " " + Atacante.Apodo + " a tocado a " + Defensor.Nombre + " " + Defensor.Apodo + " haciendole " + Daño + " de daño" + "\n";
            }
            else if (Daño <= 10)
            {
                Informe = Atacante.Nombre + " " + Atacante.Apodo + " le ha hecho un rasguño a " + Defensor.Nombre + " " + Defensor.Apodo + " infligiendole " + Daño + " de daño" + "\n";
            }
            else if(Daño <= 20)
            {
                Informe = Atacante.Nombre + " " + Atacante.Apodo + " ha cortado a " + Defensor.Nombre + " " + Defensor.Apodo + " provocandole " + Daño + " puntos de daño" + "\n";
            }
            else
            {
                Informe = Atacante.Nombre + " " + Atacante.Apodo + " ha realizado un golpe critico contra " + Defensor.Nombre + " " + Defensor.Apodo + " costandole " + Daño + " puntos de salud" + "\n";
            }
            return Informe;
        }


        internal Personaje Ganador(Personaje Personaje1, Personaje Personaje2,List<Personaje> ListaDePersonajes)
        {
            if (Personaje1.Salud > Personaje2.Salud)
            {
                ListaDePersonajes.Remove(Personaje2);
                return Personaje1;
            }
            else if (Personaje2.Salud > Personaje1.Salud)
            {
                ListaDePersonajes.Remove(Personaje1);
                return Personaje2;
            }
            else
            {
                ListaDePersonajes.Remove(Personaje1);
                ListaDePersonajes.Remove(Personaje2);
                return null;
            }
        }

        internal string InformacionDelGanador(Personaje Ganador)
        {
            return "DATOS \n\n" +
                "Tipo: " + Ganador.Tipo + " \n" +
                "Nombre: " + Ganador.Nombre + " " +
                Ganador.Apodo + " \n" +
                "Fecha de Nacimiento: " + Ganador.FechaDeNacimiento + " \n" +
                "Edad: " + Ganador.Edad + " \n" +
                "Salud: " + Ganador.Salud + " \n\n" +
                "CARACTERISTICAS \n\n" +
                "Velocidad: " + Ganador.Velocidad + " \n" +
                "Destreza: " + Ganador.Destreza + " \n" +
                "Fuerza: " + Ganador.Fuerza + " \n" +
                "Nivel: " + Ganador.Nivel + " \n" +
                "Armadura: " + Ganador.Armadura + " \n";
        }

        internal string RecompensaAleatoria(Personaje Ganador)
        {
            int numAleatorio = new Random().Next(1,6);

            Ganador.Salud = (int)Maximos.SaludMax;
            string recompensa;

            switch (numAleatorio)
            {
                case 1:
                    Ganador.Velocidad += 4;
                    recompensa = " ha recibido un aumento de 4 puntos de VELOCIDAD como recompensa aleatoria!";
                    break;
                case 2:
                    Ganador.Destreza += 2;
                    recompensa = " ha recibido un aumento de 2 puntos de DESTREZA como recompensa aleatoria!";
                    break;
                case 3:
                    Ganador.Fuerza += 4;
                    recompensa = " ha recibido un aumento de 4 puntos de FUERZA como recompensa aleatoria!";
                    break;
                case 4:
                    Ganador.Nivel += 4;
                    recompensa = " ha recibido un aumento de 4 NIVELES como recompensa aleatoria!";
                    break;
                case 5:
                    Ganador.Armadura += 4;
                    recompensa = " ha recibido un aumento de 4 puntos de ARMADURA como recompensa aleatoria!";
                    break;
                case 6:
                    Ganador.Salud += 10;
                    recompensa = " ha recibido un aumento de 10 puntos de SALUD como recompensa aleatoria!";
                    break;
                default:
                    recompensa = "";
                    break;
            }
            return "\n" + Ganador.Nombre + " " + Ganador.Apodo + recompensa + "\n";
        }
    }
}
