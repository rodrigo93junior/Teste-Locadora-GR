using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Model
{
    namespace Senac.Tests
    {
       [TestClass]
        public class UnitTest1
        {
            [TestMethod]
            [DataRow("")]
            [DataRow(null)]
            [DataRow(" ")]
            public void Model_Cliente(string value)
            {
                Cliente c = new Cliente();
                var resultado = c.VerificaNome(value);
                Assert.IsTrue(resultado);
            }
        }
        [TestClass]
        public class UnitTest2
        {
            [TestMethod]
            [DataRow("")]
            [DataRow(null)]
            [DataRow(" ")]
            public void Model_Cliente(string value)
            {
                Cliente c = new Cliente();
                var resultado = c.VerificaDataNascimento(value);
                Assert.IsTrue(resultado);
            }
        }
        [TestClass]
        public class UnitTest3
        {
            [TestMethod]
            [DataRow("01/02/1999")]
            [DataRow(null)]
            [DataRow(" ")]
            public void Model_Cliente(string value)
            {
                Cliente c = new Cliente();
                var resultado = c.VerificaDataNascimento2(value);
                Assert.IsTrue(resultado);
            }
        }
        [TestClass]
        public class UnitTest4
        {
            [TestMethod]
            [DataRow("")]
            [DataRow(null)]
            [DataRow(" ")]
            public void Model_Cliente(string value)
            {
                Cliente c = new Cliente();
                var resultado = c.VerificaCpf(value);
                Assert.IsTrue(resultado);
            }
        }
        [TestClass]
        public class UnitTest5
        {
            [TestMethod]
            [DataRow("")]
            [DataRow(null)]
            [DataRow(" ")]
            public void Model_Cliente(string value)
            {
                Cliente c = new Cliente();
                var resultado = c.VerificaGenero(value);
                Assert.IsTrue(resultado);
            }
        }
        [TestClass]
        public class UnitTest6
        {
            [TestMethod]
            [DataRow("")]
            [DataRow(null)]
            [DataRow(" ")]
            public void Model_Cliente(string value)
            {
                Cliente c = new Cliente();
                var resultado = c.VerificaDiasRetorno(value);
                Assert.IsTrue(resultado);
            }
        }
    }
}