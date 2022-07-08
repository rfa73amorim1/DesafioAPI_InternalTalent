using ApiMovie.Controllers;
using Microsoft.EntityFrameworkCore;
using Moq;
using MvcMovie.Data;
using MvcMovie.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;


namespace MovieTeste
{
    public class CategoriaControllerTest
    {

        private readonly Mock<DbSet<Categoria>> _mockSet;
        private readonly Mock<MvcMovieContext> _mockContext;
        private readonly Categoria _categoria;
        //public virtual DbSet<Categoria> Categoria { get; set; }



        public CategoriaControllerTest()
        {
            _mockSet = new Mock<DbSet<Categoria>>();
            _mockContext = new Mock<MvcMovieContext>();
            _categoria = new Categoria { CategoriaId = 1, Genero = "CategoriaMOK"};
            _mockContext.Setup(m =>m.Categorias).Returns(_mockSet.Object);
            _mockContext.Setup(m => m.Categorias.FindAsync(1))
                .ReturnsAsync(_categoria);

            _mockContext.Setup(m => m.SetModified(_categoria));


            _mockContext.Setup(m => m.SaveChangesAsync(It.IsAny<CancellationToken>()))
                .ReturnsAsync(1);
        }

        [Fact]
        public async Task Get_Categoria()
        {
            var service = new CategoriasController(_mockContext.Object);
            await service.GetCategoria(1);
            _mockSet.Verify(c => c.FindAsync(1),
                Times.Once());

        }

        [Fact]
        public async Task Put_Categoria()
        {
            var service = new CategoriasController(_mockContext.Object);

            await service.PutCategoria(1, _categoria);

            _mockContext.Verify(m => m.SaveChangesAsync(It.IsAny<CancellationToken>()),
                Times.Once());
        }

        [Fact]
        public async Task Post_Categoria()
        {
            var service = new CategoriasController(_mockContext.Object);
            await service.PostCategoria(_categoria);

            _mockSet.Verify(x => x.Add(_categoria), Times.Once);
            _mockContext.Verify(m => m.SaveChangesAsync(It.IsAny<CancellationToken>()),
                Times.Once());
        }

        [Fact]
        public async Task Delete_Categoria()
        {
            var service = new CategoriasController(_mockContext.Object);
            await service.DeleteCategoria(1);

            _mockSet.Verify(m => m.FindAsync(1),
                Times.Once());
            _mockSet.Verify(x => x.Remove(_categoria), Times.Once);
            _mockContext.Verify(m => m.SaveChangesAsync(It.IsAny<CancellationToken>()),
                Times.Once());
        }

    }
}
