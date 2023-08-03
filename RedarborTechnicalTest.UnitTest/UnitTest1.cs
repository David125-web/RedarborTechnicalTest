namespace RedarborTechnicalTest.UnitTest
{
    public class UnitTest1
    {
        [Fact]
        public void GetEmployeeExito()
        {
            var solicitudPrestamo = new 
            {
                TipoUsuario = TipoUsuarioPrestamo.INVITADO,
                IdentificacionUsuario = "123456789",
                Isbn = Guid.NewGuid()
            };
            // cargamos la data a la db para poder obtener id y consultar con este si el proceso de carga fue satisfactorio
            var carga = this.TestClient.PostAsync("/api/prestamo", solicitudPrestamo, new JsonMediaTypeFormatter()).Result;
            carga.EnsureSuccessStatusCode();
            var respuestaCarga = System.Text.Json.JsonSerializer.Deserialize<Dictionary<string, string>>(carga.Content.ReadAsStringAsync().Result);
            var idPrestamo = respuestaCarga["id"];

            var c = this.TestClient.GetAsync($"api/prestamo/{idPrestamo}").Result;
            c.EnsureSuccessStatusCode();
            var response = c.Content.ReadAsStringAsync().Result;
            var respuestaConsulta = System.Text.Json.JsonSerializer.Deserialize<RespuestaConsultaDto>(response);

            respuestaConsulta.IdUsuarioPrestamoLibro.Should().Be(solicitudPrestamo.IdentificacionUsuario);
            respuestaConsulta.IsbnLibroPrestamo.Should().Be(solicitudPrestamo.Isbn);
        }
    }
}