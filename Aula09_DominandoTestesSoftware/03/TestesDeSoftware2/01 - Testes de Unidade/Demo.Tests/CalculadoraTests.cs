using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Demo.Tests
{
    public class CalculadoraTests
    {
        /// Todos os métodos do teste são publicos 

        [Fact]
        public void Calculadora_Somar_RetornarValorSoma()
        {
            //Arrange

            var calculadora = new Calculadora();

            //Act

            var resultado = calculadora.Somar(9, 2);

            //Assert
           // Assert.True(resultado == 4);
            Assert.Equal(4,resultado);

        }

        [Theory]
        [InlineData(1,1,2)]

        public void Calculadora_Somar_RetornarValoresSomaCorretos(double v1,double v2,double total)
        {
            //Arrange
            var calculadora = new Calculadora();

            //Act
            var resultado = calculadora.Somar(v1, v2);

            //Assert
            Assert.Equal(total,resultado);
        }
    }
}
