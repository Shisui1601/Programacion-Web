using System.IO;
using System.Text.Json;
class Usuario
{
    public string Cedula { get; set; } = string.Empty;
    public string Nombre { get; set; } = string.Empty;
    public string Apellido { get; set; } = string.Empty;
    public string Telefono { get; set; } = string.Empty;
    public string Correo { get; set; } = string.Empty;
    public string Clave { get; set; } = string.Empty;
}

/*
Pasaporte, nombre, apellido, WhatsApp, fecha de nacimiento.
Coordenadas (latitud y longitud de dónde fue detenido).
Código del agente que está haciendo el registro.
*/
class Incidencia{
    public string Pasaporte { get; set; }
    public string Nombre { get; set; }
    public string Apellido { get; set; }
    public string WhatsApp { get; set; }
    public string FechaNacimiento { get; set; }
    public double Latitud { get; set; }
    public double Longitud { get; set; }
    public string CodigoAgente { get; set; }
}

class DatoLogin{
        public string Cedula { get; set; } = string.Empty;
        public string Clave { get; set; } = string.Empty;


}

class ManejadorUsuario{

    public static ServerResult RegistroIncidencia(Incidencia incidencia){
        if(!Directory.Exists("incidencias")){
            Directory.CreateDirectory("incidencias");
        }

        var miid = Guid.NewGuid().ToString();

        var archivo = $"incidencias/{miid}.json";

        var json = JsonSerializer.Serialize(incidencia);
        
        File.WriteAllText(archivo, json);

        return new ServerResult(true, "Incidencia registrada", miid);

    }

    public static ServerResult IniciarSesion(DatoLogin datos){

        var cedula = datos.Cedula;
        var clave = datos.Clave;

        if(cedula.Length != 11){
            return new ServerResult(false, "La cedula debe tener 11 digitos");
        }

        if(clave.Length == 0){
            return new ServerResult(false, "La clave es obligatoria");
        }

        var archivo = $"usuarios/{cedula}.json";

        if(!File.Exists(archivo)){
            return new ServerResult(false, "Usuario no encontrado");
        }

        var json = File.ReadAllText(archivo);

        var usuario = JsonSerializer.Deserialize<Usuario>(json);

        if(usuario.Clave != clave){
            return new ServerResult(false, "Clave incorrecta");
        }

        usuario.Clave = string.Empty;

        return new ServerResult(true, "Sesion iniciada", usuario);

    }
    public static ServerResult Registro(Usuario usuario)
    {
        List<string> errores = new List<string>();
        if(usuario.Cedula.Length != 11){
            errores.Add("La cedula debe tener 11 digitos");
        }

        if(usuario.Nombre.Length == 0){
            errores.Add("El nombre es obligatorio");
        }

        if(errores.Count > 0){
            Console.WriteLine("Errores en el registro: ");
            foreach(var error in errores){
                Console.WriteLine(error);
            }
            return new ServerResult(false, "Errores en el registro", errores);
        }

        if(!Directory.Exists("usuarios")){
            Directory.CreateDirectory("usuarios");
        }

        var archivo = $"usuarios/{usuario.Cedula}.json";
        
        if(File.Exists(archivo)){
            return new ServerResult(false, "El usuario ya existe.");
        }

        var json = JsonSerializer.Serialize(usuario);

        File.WriteAllText(archivo, json);

        return new ServerResult(true, "Usuario registrado.");
 
    }
}