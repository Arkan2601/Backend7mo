using System;
namespace marcatel_api.Models
{
    public class GetTraspasosModel
    {
        public int Id { get; set; }
        public string AlmacenOrigen { get; set; }
        public string AlmacenDestino { get; set; }
        public string FechaRegistro { get; set; }
        public string FechaRecibido { get; set; }
        public string FechaActualiza { get; set; }
        public string UsuarioEnvia { get; set; }
        public string UsuarioRecibe { get; set; }
        public string UsuarioActualiza { get; set; }
        public string Mensaje { get; set; }
        public string FechaInicio { get; set; }
        public string FechaFinal { get; set; }
    }

    public class InsertTraspasosModel
    {
        public int IdAlmacenOrigen { get; set; }
        public int IdAlmacenDestino { get; set; }
        public int UsuarioEnvia { get; set; }
        public int UsuarioActualiza { get; set; }
    }

    public class UpdateTraspasosModel
    {
        public int Id { get; set; }
        public int IdAlmacenOrigen { get; set; }
        public int IdAlmacenDestino { get; set; }
        public int UsuarioEnvia { get; set; }
        public int UsuarioActualiza { get; set; }
    }

    public class DeleteTraspasosModel
    {
        public int Id { get; set; }
    }

    public class AutorizarTraspasosModel
    {
        public int Id { get; set; }
        public string FechaRecibido { get; set; }
        public int Estatus { get; set; }
        public int UsuarioRecibe { get; set; }
        public int UsuarioActualiza { get; set; }
    }

}