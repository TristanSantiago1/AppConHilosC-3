namespace AppConHilos3;
using System.Threading;

class Program
{
    static void Main(string[] args)
    {
      int workers, ports;
        ThreadPool.GetMaxThreads(out workers,out ports);
        Console.WriteLine("Maximos hilos trabajando: "+workers);
        Console.WriteLine("Maximos puertos para hilos: "+ports);
        ThreadPool.GetMinThreads(out workers,out ports);
        Console.WriteLine("Minimos hilos trabajando: "+workers);
        Console.WriteLine("Minimos puertos (completion port) para hilos: "+ports);
        ThreadPool.GetAvailableThreads(out workers,out ports);
        Console.WriteLine("Hilos de trabajo disponibles: "+workers);
        Console.WriteLine("Hilos de puerto (completion port) disponibles: "+ports);
        int processCount = Environment.ProcessorCount;
        Console.WriteLine($"No. de procesadores disponibles en el sistema: {processCount}");
        Console.WriteLine($"---------------------------------");
        ThreadPool.QueueUserWorkItem(TareaDeFondo);
        ThreadPool.GetAvailableThreads(out workers, out ports);
        Console.WriteLine($"Hilos de trabajo disponibles después del hilo 1: {workers} ");
        Persona p = new Persona("GTristan Eduardo", 21, "Hombre");
        ThreadPool.QueueUserWorkItem(TareDeFondoConParametro, p);
        ThreadPool.GetAvailableThreads(out workers, out ports);
        Console.WriteLine($"Hilos de trabajo disponibles después del hilo 2: {workers} ");
        Thread.Sleep(2000);
        ThreadPool.GetAvailableThreads(out workers, out ports);
        Console.WriteLine($"Hilos de trabajo disponibles al final: {workers} ");
        Console.ReadKey();
    }


    public class Persona{
        public string nombre{get;set;}
        public int edad{get;set;}
        public string sexo{get;set;}
        public Persona(string name, int edad, string sexo){
            this.nombre = name;
            this.edad = edad;
            this.sexo = sexo;
        }
    }

    static void TareaDeFondo(object? obj){
        Console.WriteLine($"hilo 1: Hola soy un holp sin uso de parametro desde threadPool");
        Thread.Sleep(1500);
    }

    static void TareDeFondoConParametro(object? stateInfo){
        if(stateInfo == null){
            return;
        }
        Persona data = (Persona)stateInfo;
        Console.WriteLine($"hola {data.nombre} tu edad es {data.edad}");
        Thread.Sleep(500);
    }


}
