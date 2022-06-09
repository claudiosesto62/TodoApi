
public class Rootobject
{
    public Definitions definitions { get; set; }
    public Properties9 properties { get; set; }
    public string title { get; set; }
    public string type { get; set; }
}

public class Definitions
{
    public Aperturas Aperturas { get; set; }
    public Bfa Bfa { get; set; }
    public Emails Emails { get; set; }
    public Fechas Fechas { get; set; }
    public Firmanotificacion FirmaNotificacion { get; set; }
    public Identificacioncliente IdentificacionCliente { get; set; }
    public Identificacionpieza IdentificacionPieza { get; set; }
    public Notificacion Notificacion { get; set; }
    public Tipoemaildes TipoEmailDes { get; set; }
}

public class Aperturas
{
    public Properties properties { get; set; }
    public string title { get; set; }
    public string type { get; set; }
}

public class Properties
{
    public Cantapertura cantApertura { get; set; }
    public Primerapertua primerApertua { get; set; }
    public Ultimaapertura ultimaApertura { get; set; }
}

public class Cantapertura
{
    public int _default { get; set; }
    public string description { get; set; }
    public string title { get; set; }
    public string type { get; set; }
}

public class Primerapertua
{
    public string description { get; set; }
    public string format { get; set; }
    public string title { get; set; }
    public string type { get; set; }
}

public class Ultimaapertura
{
    public string description { get; set; }
    public string format { get; set; }
    public string title { get; set; }
    public string type { get; set; }
}

public class Bfa
{
    public Properties1 properties { get; set; }
    public string title { get; set; }
    public string type { get; set; }
}

public class Properties1
{
    public Bloque bloque { get; set; }
    public Fecha fecha { get; set; }
    public Firma firma { get; set; }
}

public class Bloque
{
    public int _default { get; set; }
    public string description { get; set; }
    public string title { get; set; }
    public string type { get; set; }
}

public class Fecha
{
    public string description { get; set; }
    public string format { get; set; }
    public string title { get; set; }
    public string type { get; set; }
}

public class Firma
{
    public string _default { get; set; }
    public string description { get; set; }
    public string title { get; set; }
    public string type { get; set; }
}

public class Emails
{
    public Properties2 properties { get; set; }
    public string title { get; set; }
    public string type { get; set; }
}

public class Properties2
{
    public Emaildestino eMailDestino { get; set; }
    public Emailed eMailED { get; set; }
    public Emailorigen eMailOrigen { get; set; }
}

public class Emaildestino
{
    public Allof[] allOf { get; set; }
    public Default _default { get; set; }
    public string description { get; set; }
    public string title { get; set; }
}

public class Default
{
    public string descrip { get; set; }
    public string email { get; set; }
    public int secid { get; set; }
}

public class Allof
{
    public string _ref { get; set; }
}

public class Emailed
{
    public string _default { get; set; }
    public string description { get; set; }
    public string title { get; set; }
    public string type { get; set; }
}

public class Emailorigen
{
    public string _default { get; set; }
    public string description { get; set; }
    public string title { get; set; }
    public string type { get; set; }
}

public class Fechas
{
    public Properties3 properties { get; set; }
    public string title { get; set; }
    public string type { get; set; }
}

public class Properties3
{
    public Fechaenvio fechaEnvio { get; set; }
    public Fechafinguarda fechaFinGuarda { get; set; }
    public Fecharecepcion fechaRecepcion { get; set; }
    public Fecharegistro fechaRegistro { get; set; }
}

public class Fechaenvio
{
    public string description { get; set; }
    public string format { get; set; }
    public string title { get; set; }
    public string type { get; set; }
}

public class Fechafinguarda
{
    public string description { get; set; }
    public string format { get; set; }
    public string title { get; set; }
    public string type { get; set; }
}

public class Fecharecepcion
{
    public string description { get; set; }
    public string format { get; set; }
    public string title { get; set; }
    public string type { get; set; }
}

public class Fecharegistro
{
    public string description { get; set; }
    public string format { get; set; }
    public string title { get; set; }
    public string type { get; set; }
}

public class Firmanotificacion
{
    public Properties4 properties { get; set; }
    public string title { get; set; }
    public string type { get; set; }
}

public class Properties4
{
    public Bfasign bfaSign { get; set; }
    public Firmacorreo firmaCorreo { get; set; }
    public Firmascorreos firmasCorreos { get; set; }
    public Firmasvr firmasvr { get; set; }
}

public class Bfasign
{
    public Allof1[] allOf { get; set; }
    public Default1 _default { get; set; }
    public string description { get; set; }
    public string title { get; set; }
}

public class Default1
{
    public int bloque { get; set; }
    public object fecha { get; set; }
    public string firma { get; set; }
}

public class Allof1
{
    public string _ref { get; set; }
}

public class Firmacorreo
{
    public string _default { get; set; }
    public string description { get; set; }
    public string title { get; set; }
    public string type { get; set; }
}

public class Firmascorreos
{
    public string _default { get; set; }
    public string description { get; set; }
    public string title { get; set; }
    public string type { get; set; }
}

public class Firmasvr
{
    public string _default { get; set; }
    public string description { get; set; }
    public string title { get; set; }
    public string type { get; set; }
}

public class Identificacioncliente
{
    public Properties5 properties { get; set; }
    public string title { get; set; }
    public string type { get; set; }
}

public class Properties5
{
    public Clientecamp clienteCamp { get; set; }
    public Clientenro clienteNro { get; set; }
}

public class Clientecamp
{
    public string _default { get; set; }
    public string description { get; set; }
    public string title { get; set; }
    public string type { get; set; }
}

public class Clientenro
{
    public string _default { get; set; }
    public string description { get; set; }
    public string title { get; set; }
    public string type { get; set; }
}

public class Identificacionpieza
{
    public Properties6 properties { get; set; }
    public string title { get; set; }
    public string type { get; set; }
}

public class Properties6
{
    public Registronro RegistroNro { get; set; }
    public Claveseg claveseg { get; set; }
    public Protocolo protocolo { get; set; }
}

public class Registronro
{
    public int _default { get; set; }
    public string description { get; set; }
    public string title { get; set; }
    public string type { get; set; }
}

public class Claveseg
{
    public string _default { get; set; }
    public string description { get; set; }
    public string title { get; set; }
    public string type { get; set; }
}

public class Protocolo
{
    public string _default { get; set; }
    public string description { get; set; }
    public string title { get; set; }
    public string type { get; set; }
}

public class Notificacion
{
    public Properties7 properties { get; set; }
    public string title { get; set; }
    public string type { get; set; }
}

public class Properties7
{
    public Dsn dsn { get; set; }
    public Firmanotificacion1 firmaNotificacion { get; set; }
    public Ncfechanotificacion ncFechaNotificacion { get; set; }
    public Notificado notificado { get; set; }
}

public class Dsn
{
    public string _default { get; set; }
    public string description { get; set; }
    public string title { get; set; }
    public string type { get; set; }
}

public class Firmanotificacion1
{
    public Allof2[] allOf { get; set; }
    public Default2 _default { get; set; }
    public string description { get; set; }
    public string title { get; set; }
}

public class Default2
{
    public Bfasign1 bfaSign { get; set; }
    public string firmaCorreo { get; set; }
    public string firmasCorreos { get; set; }
    public string firmasvr { get; set; }
}

public class Bfasign1
{
    public int bloque { get; set; }
    public object fecha { get; set; }
    public string firma { get; set; }
}

public class Allof2
{
    public string _ref { get; set; }
}

public class Ncfechanotificacion
{
    public string description { get; set; }
    public string format { get; set; }
    public string title { get; set; }
    public string type { get; set; }
}

public class Notificado
{
    public bool _default { get; set; }
    public string description { get; set; }
    public string title { get; set; }
    public string type { get; set; }
}

public class Tipoemaildes
{
    public Properties8 properties { get; set; }
    public string title { get; set; }
    public string type { get; set; }
}

public class Properties8
{
    public Descrip descrip { get; set; }
    public Email email { get; set; }
    public Secid secid { get; set; }
}

public class Descrip
{
    public string _default { get; set; }
    public string description { get; set; }
    public string title { get; set; }
    public string type { get; set; }
}

public class Email
{
    public string _default { get; set; }
    public string description { get; set; }
    public string title { get; set; }
    public string type { get; set; }
}

public class Secid
{
    public int _default { get; set; }
    public string description { get; set; }
    public string title { get; set; }
    public string type { get; set; }
}

public class Properties9
{
    public Aperturas1 aperturas { get; set; }
    public Emails1 emails { get; set; }
    public Fechas1 fechas { get; set; }
    public Firmamailorigen firmaMailOrigen { get; set; }
    public Identificacioncliente1 identificacionCliente { get; set; }
    public Identificacionpieza1 identificacionPieza { get; set; }
    public Notificacion1 notificacion { get; set; }
    public Producto producto { get; set; }
    public Subject subject { get; set; }
}

public class Aperturas1
{
    public Allof3[] allOf { get; set; }
    public Default3 _default { get; set; }
    public string title { get; set; }
}

public class Default3
{
    public int cantApertura { get; set; }
    public object primerApertua { get; set; }
    public object ultimaApertura { get; set; }
}

public class Allof3
{
    public string _ref { get; set; }
}

public class Emails1
{
    public Allof4[] allOf { get; set; }
    public Default4 _default { get; set; }
    public string title { get; set; }
}

public class Default4
{
    public Emaildestino1 eMailDestino { get; set; }
    public string eMailED { get; set; }
    public string eMailOrigen { get; set; }
}

public class Emaildestino1
{
    public string descrip { get; set; }
    public string email { get; set; }
    public int secid { get; set; }
}

public class Allof4
{
    public string _ref { get; set; }
}

public class Fechas1
{
    public Allof5[] allOf { get; set; }
    public Default5 _default { get; set; }
    public string title { get; set; }
}

public class Default5
{
    public object fechaEnvio { get; set; }
    public object fechaFinGuarda { get; set; }
    public object fechaRecepcion { get; set; }
    public object fechaRegistro { get; set; }
}

public class Allof5
{
    public string _ref { get; set; }
}

public class Firmamailorigen
{
    public Allof6[] allOf { get; set; }
    public Default6 _default { get; set; }
    public string title { get; set; }
}

public class Default6
{
    public int bloque { get; set; }
    public object fecha { get; set; }
    public string firma { get; set; }
}

public class Allof6
{
    public string _ref { get; set; }
}

public class Identificacioncliente1
{
    public Allof7[] allOf { get; set; }
    public Default7 _default { get; set; }
    public string title { get; set; }
}

public class Default7
{
    public string clienteCamp { get; set; }
    public string clienteNro { get; set; }
}

public class Allof7
{
    public string _ref { get; set; }
}

public class Identificacionpieza1
{
    public Allof8[] allOf { get; set; }
    public Default8 _default { get; set; }
    public string title { get; set; }
}

public class Default8
{
    public int RegistroNro { get; set; }
    public string claveseg { get; set; }
    public string protocolo { get; set; }
}

public class Allof8
{
    public string _ref { get; set; }
}

public class Notificacion1
{
    public Allof9[] allOf { get; set; }
    public Default9 _default { get; set; }
    public string title { get; set; }
}

public class Default9
{
    public string dsn { get; set; }
    public Firmanotificacion2 firmaNotificacion { get; set; }
    public object ncFechaNotificacion { get; set; }
    public bool notificado { get; set; }
}

public class Firmanotificacion2
{
    public Bfasign2 bfaSign { get; set; }
    public string firmaCorreo { get; set; }
    public string firmasCorreos { get; set; }
    public string firmasvr { get; set; }
}

public class Bfasign2
{
    public int bloque { get; set; }
    public object fecha { get; set; }
    public string firma { get; set; }
}

public class Allof9
{
    public string _ref { get; set; }
}

public class Producto
{
    public string _default { get; set; }
    public string title { get; set; }
    public string type { get; set; }
}

public class Subject
{
    public string _default { get; set; }
    public string title { get; set; }
    public string type { get; set; }
}
