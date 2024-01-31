using System;

class Program //creando la clase 
{
    static void Main() //clase principal inicializando cantidades , acumuladas etc.
    {
        int cantidadAumentos = 0;
        int cantidadOperarios = 0, cantidadTecnicos = 0, cantidadProfesionales = 0;
        double acumuladoNetoOperarios = 0, acumuladoNetoTecnicos = 0, acumuladoNetoProfesionales = 0;

        do
        {
            Console.WriteLine("\nIngrese datos del empleado");
            Console.Write("numero de cedula: ");
            string cedula = Console.ReadLine();

            Console.Write("nombre del empleado: ");
            string nombre = Console.ReadLine();

            Console.Write("tipo de empleado (1-Operario, 2-Tecnico, 3-Profesional) : ");
            int tipoEmpleado;
            while (!int.TryParse(Console.ReadLine(), out tipoEmpleado) || tipoEmpleado < 1 || tipoEmpleado > 3)
            {
                Console.Write("por favor ingrese un numero valido entre 1 y 3: ");
            }

            Console.Write("cantidad de horas de trabajo : ");
            double horasLaboradas;
            while (!double.TryParse(Console.ReadLine(), out horasLaboradas) || horasLaboradas < 0)
            {
                Console.Write("por favor ingrese un numero valido mayor o igual a cero: ");
            }

            Console.Write("precio por hora : ");
            double precioPorHora;
            while (!double.TryParse(Console.ReadLine(), out precioPorHora) || precioPorHora < 0)
            {
                Console.Write("por favor ingrese un numero valido mayor o igual a cero: ");
            }

            // calcular salario ordinario
            double salarioOrdinario = horasLaboradas * precioPorHora;

            // calcular aumento utiilizando el if 
            double aumento = 0.0;
            if (tipoEmpleado == 1)
            {
                aumento = salarioOrdinario * 0.15;
                cantidadOperarios++;
                acumuladoNetoOperarios += (salarioOrdinario + aumento - (salarioOrdinario + aumento) * 0.0917); //el salario + el aumento * la deduccion de la ccss
            }
            else if (tipoEmpleado == 2)
            {
                aumento = salarioOrdinario * 0.10;
                cantidadTecnicos++;
                acumuladoNetoTecnicos += (salarioOrdinario + aumento - (salarioOrdinario + aumento) * 0.0917);
            }
            else if (tipoEmpleado == 3)
            {
                aumento = salarioOrdinario * 0.05;
                cantidadProfesionales++;
                acumuladoNetoProfesionales += (salarioOrdinario + aumento - (salarioOrdinario + aumento) * 0.0917);
            }

            // calcular salario bruto deduccion de la CCSS y salario neto
            double salarioBruto = salarioOrdinario + aumento;
            double deduccionCCSS = salarioBruto * 0.0917;
            double salarioNeto = salarioBruto - deduccionCCSS;

            // muestra de  resultados para cada transaccion
            Console.WriteLine("\nResultados para el empleado:");
            Console.WriteLine($"Cedula: {cedula}");
            Console.WriteLine($"Nombre empleado: {nombre}");
            Console.WriteLine($"Tipo empleado: {tipoEmpleado}");
            Console.WriteLine($"Salario por hora: {precioPorHora}");
            Console.WriteLine($"Cantidad de horas: {horasLaboradas}");
            Console.WriteLine($"Salario ordinario: {salarioOrdinario}");
            Console.WriteLine($"Aumento: {aumento}");
            Console.WriteLine($"Salario bruto: {salarioBruto}");
            Console.WriteLine($"Deduccion CCSS: {deduccionCCSS}");
            Console.WriteLine($"Salario neto: {salarioNeto}");

            cantidadAumentos++;

            // preguntar al usuario si desea ingresar otros empleados
            Console.Write("\n¿ Desea ingresar otro empleado ? (Sí/No): "); //mientras sea correcto osea el si se ejecutaria de nuevo lo anterior para pedir datos al empleado
        } while (Console.ReadLine().Equals("Si", StringComparison.OrdinalIgnoreCase));

        // muestra de estadisticas al terminar
        Console.WriteLine("\nEstadisticas finales ");
        MostrarEstadisticas("Operarios", cantidadOperarios, acumuladoNetoOperarios);
        MostrarEstadisticas("Tecnicos", cantidadTecnicos, acumuladoNetoTecnicos);
        MostrarEstadisticas("Profesionales", cantidadProfesionales, acumuladoNetoProfesionales);

        Console.WriteLine("\nPrograma ejecutado.");
    }

    static void MostrarEstadisticas(string tipoEmpleado, int cantidad, double acumuladoNeto)
    {
        Console.WriteLine($"\nCantidad empleados tipo {tipoEmpleado}: {cantidad}");
        Console.WriteLine($"Acumulado salario neto para {tipoEmpleado}: {acumuladoNeto}");
        Console.WriteLine($"Promedio salario neto para {tipoEmpleado}: {(cantidad > 0 ? acumuladoNeto / cantidad : 0)}");
    }
}
