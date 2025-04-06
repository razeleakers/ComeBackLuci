<h1 align="center">ComeBackLuci v1.2</h1>

## Info

ComeBackLuci es un simple keylogger que guarda un registro de las teclas que presiones en la <a href="https://learn.microsoft.com/en-us/dotnet/api/system.io.path.gettemppath?view=net-8.0&tabs=windows">carpeta temporal del sistema(temp)</a> y hara uso del servicio <a href="https://support.google.com/a/answer/176600?hl=en">SMTP de GMAIL</a> para enviarte los registros

## Uso

[1] Para este ejemplo hare uso del instalador predeterminado de visual studio

<img src="/img/download.png" alt="download">

[2] La primera vez que se ejecute el programa al instalarlo se le solicitara las credenciales de acceso donde se enviaran los registros

<i>-Si cierras la ventana o ingresas credenciales invalidas el programa no enviara a ningun lugar los registros, sin embargo se seguiran guardando en el sistema los archivos</i>

<img src="/img/setup.png" alt="setup">

[3] Puedes verificar el funcionamiento dandole click al boton "Send Message", esto verificara las credenciales y te enviara un correo de prueba para confirmar que todo este correcto

<img src="/img/send.png" alt="send">

[4] Una vez confirmado todo, le das click a "Save and close"

[5] Finalmente el programa enviara los registros como este ejemplo:

<img src="/img/files.png" alt="files">

# Detalles
- Cada vez que se ejecuta el programa esperara 15 segundos para enviar los registros, esto se hizo para que el sistema tenga algo de tiempo para conectarse a internet y no falle el envio al no haber conexion

- Si algun registro falla al enviarse se movera a una carpeta especial donde se almacenan los envios fallidos, el programa siempre verificara la carpeta especial para enviar todos los registros nuevamente

- Todos los archivos que se terminen enviando, el programa los eliminara de tu sistema para no dejar rastro de los registros anteriores
  
- El programa no tiene inicio automatico(startup) por seguridad, asi que tendras que hacerlo manualmente si quieres que cada vez que se apage y prenda el sistema se envien los registros

##

<h4 align="center">Created by M3RFR3T & RESTART2LIFE</h1>
