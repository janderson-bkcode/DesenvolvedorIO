using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Demo.Tests
{
    public class CalculadoraTests
    {
        /// Todos os métodos do teste são publicos 

        [Fact] //Fato 2 +2 = 4 
        public void Calculadora_Somar_RetornarValorSoma()
        {
            //Arrange

            var calculadora = new Calculadora();

            //Act

            var resultado = calculadora.Somar(2, 2);

            //Assert
           // Assert.True(resultado == 4);
            Assert.Equal(4,resultado);

        }

        [Theory] //Teoria não só uma soma é suficiente, provando e validando o método somar com demais valores e cenários para ser verdade
        [InlineData(1,1,2)]
        [InlineData(2,2,4)]
        [InlineData(3,3,6)]
        [InlineData(4,4,8)]

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
