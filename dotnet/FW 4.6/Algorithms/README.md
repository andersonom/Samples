# InterviewExercises
C# Examples, Features and Algorithms
 string[] sistemas = { "SistemaABC", "SistemaDEF", "SistemaHIJ", };
            string[] servidores = { "ServidorABC", "ServidorDEF", "ServidorDEF" };

            Random rnd = new Random();

            int qutSistemas = 10;
            int maxLinhas = 3;

            XElement data =

                 new XElement("Servidores",
                    Enumerable.Repeat("", rnd.Next(maxLinhas) + 1)
                        .Select((s2, i2) =>
                             new XElement("Servidor",
                             new XElement("Id", i2 + 1),
                    new XElement("ServidorNome", sistemas[rnd.Next(sistemas.Length)])

                    ,

                new XElement("Sistemas",
                    Enumerable.Repeat("", qutSistemas)
                        .Select((s, i) =>
                             new XElement("Sistema",
                             new XElement("Id", i + 1),
                    new XElement("Nome", sistemas[rnd.Next(sistemas.Length)])


                    )))

                    )));

            data.Save("C:\\Anderson\\Data.xml");

            return View();
            
            Adicionado a referencia https://dotnet.myget.org/F/open-xml-sdk

Install-Package DocumentFormat.OpenXml
