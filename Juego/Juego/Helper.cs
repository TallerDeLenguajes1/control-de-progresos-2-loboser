using System;
using System.Collections.Generic;
using System.Text;

namespace Juego
{
    public class Helper
    {
        private int anioActual;
        private int mesActual;
        private int diaActual;
        private int anio;
        private int mes;
        private int dia;
        private int aux;
        private string fechaDeNacimiento;
        private int edad;

        public string FechaDeNacimiento { get => fechaDeNacimiento; set => fechaDeNacimiento = value; }
        public int Edad { get => edad; set => edad = value; }

        public string gen_fecha()
        {
            anioActual = DateTime.Today.Year;
            mesActual = DateTime.Today.Month;
            diaActual = DateTime.Today.Day;

            anio = new Random().Next(anioActual-300, anioActual-18);
            mes = new Random().Next(1,12);

            switch (mes)
            {
                case 1:
                    aux = 1;
                    break;
                case 2:
                    if (bisiesto(anio))
                    {
                        aux = 3;
                    }
                    else
                    {
                        aux = 4;
                    }
                    break;
                case 3:
                    aux = 1;
                    break;
                case 4:
                    aux = 2;
                    break;
                case 5:
                    aux = 1;
                    break;
                case 6:
                    aux = 2;
                    break;
                case 7:
                    aux = 1;
                    break;
                case 8:
                    aux = 1;
                    break;
                case 9:
                    aux = 2;
                    break;
                case 10:
                    aux = 1;
                    break;
                case 11:
                    aux = 2;
                    break;
                case 12:
                    aux = 1;
                    break;
            }

            switch (aux)
            {
                case 1:
                    dia = new Random().Next(1,31);
                    break;
                case 2:
                    dia = new Random().Next(1,30);
                    break;
                case 3:
                    dia = new Random().Next(1,29);
                    break;
                case 4:
                    dia = new Random().Next(1, 28);
                    break;
            }

            if (mes-mesActual > 0)
            {
                Edad = anioActual - anio - 1;
            }else if (mes-mesActual < 0)
            {
                Edad = anioActual - anio;
            }else if (mes-mesActual == 0)
            {
                if (dia-diaActual > 0)
                {
                    Edad = anioActual - anio - 1;
                }
                else
                {
                    Edad = anioActual - anio;
                }
            }

            FechaDeNacimiento = dia + "/" + mes + "/" + anio;
            return FechaDeNacimiento;
        }

        public bool bisiesto(int anio)
        {
            if (Convert.ToInt32(anio) % 4 == 0 && Convert.ToInt32(anio) % 100 != 0 || Convert.ToInt32(anio) % 400 == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
    
}
