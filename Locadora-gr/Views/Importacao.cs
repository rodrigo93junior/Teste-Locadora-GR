using System;

namespace Views
{
    public static class Importacao
    {
        public static void BDImportacao()
        {
            Console.WriteLine("\n---------------------------");
            Console.WriteLine("Importação Iniciada");
            Controller.Importacao.BDImportacao();
            Console.WriteLine("Importação Concluída");
            Console.WriteLine("---------------------------\n");
        }
    }
}