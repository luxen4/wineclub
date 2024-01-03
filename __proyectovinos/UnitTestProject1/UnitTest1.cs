using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using proyectovinos;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            //Definimos las variables
            //Arrange
            var operador1 = 10;
            var operador2 = 11;

            //Ejecutamos la prueba
            //Act
           
            Form1 form1= new Form1();
            var result = form1.sumar(operador1, operador2);

            //Comparamos resultados
            //Assert
            var valorEsperado = 21;
            Assert.AreEqual(valorEsperado, result);
        }
    }
}
// Crear pruebas unitarias
/* https://www.fixedbuffer.com/pruebas-unitarias-en-net/ */